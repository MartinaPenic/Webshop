using Webshop.API.Context;
using Webshop.API.Models.Entities;

namespace Webshop.API.Repositories
{
    public class UserProfileRepository
    {
        private readonly IdentityContext _context;


        public UserProfileRepository(IdentityContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUserAsync(UserProfileEntity newUser)
        {
            try
            {
                _context.UserProfiles.Add(newUser);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
