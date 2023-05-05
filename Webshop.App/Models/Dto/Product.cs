using Webshop.API.Models;

namespace Webshop.App.Models.Dto
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }   
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
		public bool IsFeatured { get; set; }    
		public string PictureUrl { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
        public decimal AverageRating { get; set; }
        public List<ProductRating> Ratings { get; set; }
    }
}
