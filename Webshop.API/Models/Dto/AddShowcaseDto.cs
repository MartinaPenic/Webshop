using System.ComponentModel.DataAnnotations;

namespace Webshop.API.Models.Dto
{
    public class AddShowcaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}

