using System.ComponentModel.DataAnnotations;

namespace Webshop.API.Models.Dto
{
    public class ShowcaseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
