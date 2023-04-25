namespace Webshop.App.Models.Dto
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string PictureUrl { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
        public decimal AverageRating { get; set; }
        public List<ProductRating> Ratings { get; set; }
    }
}
