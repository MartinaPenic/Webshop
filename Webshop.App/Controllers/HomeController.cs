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
        private readonly IShowcaseService _showcaseService;

        public HomeController(IProductService productService, IShowcaseService showcaseService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _showcaseService = showcaseService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> Index()
        {
            var featuredProducts = await _productService.GetFeaturedProducts();
            var newProducts = await _productService.GetNewProducts();
            var popularProducts = await _productService.GetPopularProducts();
            var newShowcase = await _showcaseService.GetNewShowcase();

            var viewModel = new IndexViewModel()
            {
                Showcase = newShowcase,
          
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

        private CollectionItemViewModel GetViewModel(Product product) => (CollectionItemViewModel)product;
          
    }

}



