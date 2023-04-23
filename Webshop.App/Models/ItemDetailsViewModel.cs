using Webshop.App.Models.Dto;

namespace Webshop.App.Models
{
    public class ItemDetailsViewModel
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string ImageUrl { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
        public decimal AverageRating { get; set; }
        public List<ProductRating> ProductRatings { get; set; }
    }
}
