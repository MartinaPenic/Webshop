using System.ComponentModel.DataAnnotations;

namespace Webshop.App.Models.Dto
{
    public class Showcase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
