using Microsoft.AspNetCore.Mvc;
using Webshop.API.Models.Dto;
using Webshop.API.Services;

namespace Webshop.API.Controllers
{

	[Route("api/[controller]")]
	[ApiController]

	public class AuthenticationController : ControllerBase
    {

        private readonly AuthService _authService;

        public AuthenticationController(AuthService authService)
        {
            _authService = authService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.RegisterAsync(model))
                    return Created("", null);
            }
            return BadRequest();
        }


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginAsync(model);
                if (!string.IsNullOrEmpty(result))
                    return Ok(result);

                ModelState.AddModelError("", "Incorrect email or password");
                Unauthorized(model);
            }
            return BadRequest(model);
        }
    }
}




