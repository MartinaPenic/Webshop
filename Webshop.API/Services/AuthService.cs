using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using Webshop.API.Authentication;
using Webshop.API.Models;
using Webshop.API.Models.Dto;
using Webshop.API.Models.Entities;
using Webshop.API.Repositories;

namespace Webshop.API.Services
{
    public class AuthService
    {
        private readonly UserProfileRepository _userProfileRepository;
        private readonly RoleManager<AppIdentityRole> _roleManager;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        private readonly JwtToken _jwt;

        public AuthService(UserProfileRepository userProfileRepository, RoleManager<AppIdentityRole> roleManager,
            UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, JwtToken jwt)
        {

            _userProfileRepository = userProfileRepository;
            _roleManager = roleManager; 
            _userManager = userManager;
            _signInManager = signInManager;
            _jwt = jwt;  
        }

        public async Task<bool> RegisterAsync(RegisterDto model)
        {
            var noUsers = !await _userManager.Users.AnyAsync();
            var noRoles = !await _roleManager.Roles.AnyAsync();

            try
            {
                if (noRoles)
                {
                    {
                        await _roleManager.CreateAsync(new AppIdentityRole(UserRole.Admin.ToString()));
                        await _roleManager.CreateAsync(new AppIdentityRole(UserRole.ProductManager.ToString()));
                    }
                }

                if (noUsers)
          
                model.RoleTitle = UserRole.Admin.ToString();

                var result = await _userManager.CreateAsync(model, model.Password);

                if (result.Succeeded)
                {
                    var identityUser = await _userManager.FindByEmailAsync(model.Email);

                    await _userManager.AddToRoleAsync(identityUser, model.RoleTitle);

                    UserProfileEntity userProfile = model;
                    userProfile.Id = identityUser.Id;
                    await _userProfileRepository.AddUserAsync(userProfile);

                    return true;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            return false;
        }


        public async Task<string> LoginAsync(LoginDto model)
        {
            var identityUser = await _userManager.FindByEmailAsync(model.Email);
            if (identityUser != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(identityUser, model.Password, false);
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(identityUser);

                    var claimsIdentity = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("id", identityUser.Id.ToString()),
                        new Claim(ClaimTypes.Role, roles[0]),
                        new Claim(ClaimTypes.Name, identityUser.Email!)
                    });

                    return _jwt.Generate(claimsIdentity, DateTime.Now.AddHours(1));
                }
            }
            return string.Empty;
        }
    }
}
