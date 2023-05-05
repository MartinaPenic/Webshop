using System.ComponentModel.DataAnnotations;
using Webshop.API.Models.Entities;

namespace Webshop.API.Models.Dto
{
    public class RegisterDto
    {
        [Required]  
        public string FirstName { get; set; }

        [Required]  
        public string LastName { get; set; }

        [Required]  
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
        public string Password { get; set; }

        public string RoleTitle { get; set; } = UserRole.ProductManager.ToString();


        public static implicit operator AppIdentityUser(RegisterDto model)
        {
            return new AppIdentityUser()
            {
                UserName = model.Email,
                Email = model.Email
            };
        }

        public static implicit operator UserProfileEntity(RegisterDto model)
        {
            return new UserProfileEntity()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }
    }
}
