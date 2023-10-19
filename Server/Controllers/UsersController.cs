using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EasyER.Server.Models;
using EasyER.Shared;
using EasyER.Server.Filters;
using Microsoft.AspNetCore.Authorization;

namespace EasyER.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize("Admin")]
    public class UsersController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("create")]
        [AuthFilter]
        public async Task<bool> CreateUser(UserBundle userBundle)
        {
            ApplicationUser user = new ApplicationUser();
            user.Email = userBundle.Email;
            user.NormalizedEmail = userBundle.Email.ToUpper();
            user.UserName = user.Email;
            user.EmailConfirmed = true;

            try
            {
                await _userManager.CreateAsync(user, userBundle.Password);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        [HttpPost]
        [Route("role")]
        public async Task AssignToRole(StringBundle stringbundle)
        {
            bool isRoleCreated = await _roleManager.RoleExistsAsync(stringbundle.Role);
            if (!isRoleCreated)
            {
                var role = new IdentityRole();
                role.Name = stringbundle.Role;
                await _roleManager.CreateAsync(role);
            }

            ApplicationUser user = await _userManager.FindByEmailAsync(stringbundle.Email);
            await _userManager.AddToRoleAsync(user, stringbundle.Role);
        }
    }
}
