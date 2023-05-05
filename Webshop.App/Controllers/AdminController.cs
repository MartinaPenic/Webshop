using Microsoft.AspNetCore.Mvc;
using Webshop.App.Helpers;
using Webshop.App.Models;
using Webshop.App.Services.Interfaces;

namespace Webshop.App.Controllers
{
	public class AdminController : Controller
	{
		private readonly IProductService _productService;
		private readonly JwtValidation _jwtValidation;

		public AdminController(IProductService productService, JwtValidation jwtValidation)
		{
			_productService = productService ?? throw new ArgumentNullException(nameof(productService));
			_jwtValidation = jwtValidation;
		}

		public IActionResult Index()
		{
			return View();	
		}


		public IActionResult AddProduct()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> AddProduct(AddProductViewModel model)
		{
			var token = HttpContext.Request.Cookies["accessToken"];

			if (_jwtValidation.ValidateToken(token))
			{
					await _productService.AddProduct(model, token);
					return RedirectToAction("Index", "Account");  
			}
			return View(model);		
		}
	}
}
