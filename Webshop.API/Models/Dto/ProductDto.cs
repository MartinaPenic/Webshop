namespace Webshop.API.Models.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public string PictureUrl { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
        public List<ProductRatingDto> Ratings { get; set; }
        public decimal AverageRating => (Ratings?.Count is 0) ? 0 : (decimal)Ratings.Average(r => r.Score);
    }
}