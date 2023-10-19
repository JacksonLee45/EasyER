using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace EasyER.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
}