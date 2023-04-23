using Microsoft.AspNetCore.Mvc;
using Webshop.App.Models;
using Webshop.App.Models.Dto;
using Webshop.App.Services.Interfaces;
using Webshop.App.ViewModels;

namespace Webshop.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> Index()
        {
            var featuredProducts = await _productService.GetFeaturedProducts();
            var newProducts = await _productService.GetNewProducts();
            var popularProducts = await _productService.GetPopularProducts();

            var viewModel = new IndexViewModel()
            {
                Showcase = new ShowcaseViewModel
                {
                    Title = "GET UP TO %40 OFF",
                    Ingress = "Don't miss this opportunity",
                    Subtitle = "Online shopping free home delivery over $100",
                    ButtonCaption = "SHOP NOW",
                    ImageUrl = "static-images/showcase-img.png"
                },
                Featured = new CollectionViewModel()
                {
                    Title = "Featured",
                    CollectionItems = featuredProducts.Select(GetViewModel).ToList()
                },
                New = new CollectionViewModel()
                {
                    Title = "2 FOR USD $29",
                    ButtonCaption = "NEW PRODUCTS",
                    CollectionItems = newProducts.Select(GetViewModel).ToList()
                },
                Popular = new CollectionViewModel()
                {
                    Title = "2 FOR USD $49",
                    ButtonCaption = "POPULAR PRODUCTS",
                    CollectionItems = popularProducts.Select(GetViewModel).ToList()
                }
            };

            return View(viewModel);
        }

        private CollectionItemViewModel GetViewModel(Product product) =>
            new()
            {
                Id = product.Id,
                Category = product.Category,
                ImageUrl = product.PictureUrl,
                Price = (int)product.Price,
                Title = product.Title,
                AverageRating = product.AverageRating,
                ButtonCaption = "QUICK VIEW"
            };
    }
}














