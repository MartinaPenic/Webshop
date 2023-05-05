using System.ComponentModel.DataAnnotations;

namespace Webshop.App.Models.Dto
{
	public class Register
	{ 
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
		public string Email { get; set; }

		[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
		public string Password { get; set; }

		public string RoleName { get; set; } = "ProductManager";
	}
}
