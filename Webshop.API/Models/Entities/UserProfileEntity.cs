using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Webshop.API.Models.Dto;

namespace Webshop.API.Models.Entities
{
    public class UserProfileEntity
    {
        [Key, ForeignKey(nameof(User))]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } 

        [Required]
        public string LastName { get; set; }

        [Required]
        public AppIdentityUser User { get; set; }
    }
}
