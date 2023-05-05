using Webshop.API.Models;
using Webshop.App.Models.Dto;

namespace Webshop.App.Models
{
    public class ItemDetailsViewModel
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public string ImageUrl { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
        public decimal AverageRating { get; set; }
        public List<ProductRating> ProductRatings { get; set; }


        public static implicit operator ItemDetailsViewModel(Product product)
        {
            return new ItemDetailsViewModel
            {
                Id = product.Id,
                Title = product.Name,
                Description = product.Description,
                Category = product.Category,
                ImageUrl = product.PictureUrl,
                Price = (int)product.Price,
                Color = product.Color,
                Size = product.Size,
                SKU = product.SKU,
                Brand = product.Brand,
                AverageRating = product.AverageRating,
                ProductRatings = product.Ratings
            };
        }
    }
}
