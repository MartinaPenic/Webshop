using Microsoft.AspNetCore.Mvc;
using Webshop.App.Models;
using Webshop.App.Services.Interfaces;

namespace Webshop.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> Index(int id)
        {
            var product = await _productService.GetProduct(id);

            var viewModel = new ItemDetailsViewModel
            {
                Id = product.Id,
                Title = product.Title,
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

            return View(viewModel);
        }
    }
}
