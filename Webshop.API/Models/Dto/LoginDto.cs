using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Webshop.API.Models.Entities;

namespace Webshop.API.Models.Dto
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


        public static implicit operator AppIdentityUser(LoginDto model)
        {
            return new AppIdentityUser()
            {
                UserName = model.Email,
                Email = model.Email
            };
        }
    }
}
