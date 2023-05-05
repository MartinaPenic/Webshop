using Microsoft.AspNetCore.Mvc;
using Webshop.App.Helpers;
using Webshop.App.Models;
using Webshop.App.Services.Interfaces;

namespace Webshop.App.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountService _accountService;
		private readonly JwtValidation _jwtValidation;

		public AccountController(IAccountService accountService, JwtValidation jwtValidation)
		{
			_accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
			_jwtValidation = jwtValidation;
		}

		public IActionResult Index()
		{
			var token = HttpContext.Request.Cookies["accessToken"];
			if (token != null)
			{
				if (_jwtValidation.ValidateToken(token!))
				{
					return RedirectToAction("Index", "Admin");
				}
			}
			return View();
		}


		public IActionResult Register()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				await _accountService.Register(model);

				return RedirectToAction("Login", "Account");
			}
			return View(model);
		}


		public IActionResult Login()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{		
		if (ModelState.IsValid)
			{
				var result = await _accountService.Login(model);

				if (result.IsSuccessStatusCode)
				{
					var token = await result.Content.ReadAsStringAsync();
					var options = new CookieOptions
					{
						HttpOnly = true,
						Secure = true,
						Expires = DateTime.Now.AddHours(1)
					};

					HttpContext.Response.Cookies.Append("accessToken", token, options);

					return RedirectToAction("Index", "Admin");
				}
				ModelState.AddModelError("", "Incorrect login details!");
			}
			return View();
		}


		[HttpPost]
		public IActionResult Logout()
		{
			HttpContext.Response.Cookies.Delete("accessToken");

			return RedirectToAction("Index", "Home");
		}
	}
}




