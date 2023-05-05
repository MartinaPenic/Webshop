using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webshop.API.Models.Entities;

namespace Webshop.API.Context
{
    public class IdentityContext : IdentityDbContext<AppIdentityUser, AppIdentityRole, int>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<UserProfileEntity> UserProfiles { get; set; }
    }
}
