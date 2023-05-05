using System.ComponentModel.DataAnnotations;
using Webshop.App.Models.Dto;

namespace Webshop.App.Models
{
	public class AddProductViewModel
	{
		[Required(ErrorMessage = "Name is a required field")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Description is a required field")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Price is a required field")]
		public decimal Price { get; set; }

	    [Required(ErrorMessage = "IsFeatured is a required field")]
		public bool IsFeatured { get; set; }

		public int Discount { get; set; } 

		[Required(ErrorMessage = "Picture is a required field")]
		public string PictureUrl { get; set; }

		[Required(ErrorMessage = "SKU is a required field")]
		public string SKU { get; set; }

		[Required(ErrorMessage = "Brand is a required field")]
		public string Brand { get; set; }

		[Required(ErrorMessage = "Category is a required field")]
		public string Category { get; set; }

		[Required(ErrorMessage = "Color is a required field")]
		public string Color { get; set; }

		[Required(ErrorMessage = "Size is a required field")]
		public string Size { get; set; }


		public static implicit operator Product(AddProductViewModel model)
		{
			return new AddProductViewModel
			{
				Name = model.Name,
				Description = model.Description,	
				Price = model.Price,
				Discount = model.Discount,		
				Category = model.Category,
				IsFeatured = model.IsFeatured,
				Color = model.Color,
				Size = model.Size,
				PictureUrl = model.PictureUrl,
				SKU = model.SKU,
				Brand = model.Brand
			};
		}
	}
}
