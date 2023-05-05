using System.ComponentModel.DataAnnotations;
using Webshop.App.Models.Dto;

namespace Webshop.App.Models
{
    public class RegisterViewModel
    {
		[Display(Name = "First name")]
		[Required(ErrorMessage = "Email is a required field!")]
		[MinLength(2, ErrorMessage = "Enter at least 2 characters")]
		public string FirstName { get; set; }

		[Display(Name = "Last name")]
		[Required(ErrorMessage = "Last name is a required field")]
		[MinLength(2, ErrorMessage = "Enter at least 2 characters")]
		public string LastName { get; set; } 

		[Display(Name = "Email")]
		[Required(ErrorMessage = "Email is a required field")]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email is not valid!")]
		[EmailAddress]
		public string Email { get; set; } 

		[Display(Name = "Password")]
		[Required(ErrorMessage = "Password is a required field")]
		[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Password is not valid!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Confirm password")]
		[Required(ErrorMessage = "Password is a required field!")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "The password doesn't match!")]
		public string ConfirmPassword { get; set; }

		public static implicit operator Register(RegisterViewModel model)
		{
			return new Register
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				Password = model.Password,
			};
		}
	}
}
