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

            var viewModel = new ItemDetailsViewModel();
            viewModel = product;


            return View(viewModel);
        }
    }
}
