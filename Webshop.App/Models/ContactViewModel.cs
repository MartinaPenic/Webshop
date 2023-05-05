using System.ComponentModel.DataAnnotations;

namespace Webshop.App.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Name is a required field")]
        [RegularExpression(@"^[a-öA-Ö]+(?:['´-][a-öA-Ö]+)*$", ErrorMessage = "Enter a valid name")]
		[MinLength(2, ErrorMessage = "Enter at least 2 characters")]
		public string Name { get; set; } 

        [Required(ErrorMessage = "Email is a  required field")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid email")]
		[MinLength(2, ErrorMessage = "Enter at least 2 characters")]
		[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Comment is a required field")]
		[MinLength(2, ErrorMessage = "Enter at least 2 characters")]
		public string Message { get; set; } 
    }
}
