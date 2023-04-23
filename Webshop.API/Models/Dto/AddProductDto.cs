using System.ComponentModel.DataAnnotations;

namespace Webshop.API.Models.Dto
{
    public class AddProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? Discount { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Color Color { get; set; }

        [Required]
        public Size Size { get; set; }

        public string PictureUrl { get; set; }

        public bool IsFeatured { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        public string Brand { get; set; }
    }
}
