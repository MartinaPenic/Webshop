using System.ComponentModel.DataAnnotations;

namespace Webshop.API.Models.Dto
{
    public class AddMessageDto
    {
        [MinLength(2)]
        [Required]
        public string Name { get; set; } 

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; } 
    }
}
