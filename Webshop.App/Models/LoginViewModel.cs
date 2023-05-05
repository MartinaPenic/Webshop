using System.ComponentModel.DataAnnotations;

namespace Webshop.App.Models
{
    public class LoginViewModel
    {
		[Required(ErrorMessage = "Email is a required field!")]
		public string Email { get; set; } 

		[Required(ErrorMessage = "Password is a required field!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
