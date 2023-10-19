using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace EasyER.Server.Filters
{
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Debug.WriteLine("From AuthFilter: "+ context.HttpContext.User.Identity.Name);
            if(context.HttpContext.User.HasClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin"))
            {
                Debug.WriteLine("User is in Admin Role");
            }
        }
    }
}
