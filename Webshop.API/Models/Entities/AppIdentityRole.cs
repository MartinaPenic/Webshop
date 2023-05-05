using Microsoft.AspNetCore.Identity;

namespace Webshop.API.Models.Entities
{
    public class AppIdentityRole : IdentityRole<int>
    {
        public AppIdentityRole()
        {
        }

        public AppIdentityRole(string roleName) : base(roleName) { }
    }
}
