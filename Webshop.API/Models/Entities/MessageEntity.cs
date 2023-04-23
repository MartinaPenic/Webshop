using System.ComponentModel.DataAnnotations;

namespace Webshop.API.Models.Entities
{
    public class MessageEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]  
        public string Name { get; set; } 

        [Required]
        public string Email { get; set; } 

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
