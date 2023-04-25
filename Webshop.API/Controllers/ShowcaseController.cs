using Microsoft.AspNetCore.Mvc;
using System.Net;
using Webshop.API.Models.Dto;
using Webshop.API.Models.Entities;
using Webshop.API.Services;

namespace Webshop.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ShowcaseController : ControllerBase
    { 

        private readonly ShowcaseService _showcaseService;

        public ShowcaseController(ShowcaseService showcaseService)
        {
            _showcaseService = showcaseService;
        }


        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> AddShowcase(AddShowcaseDto newShowcase)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _showcaseService.AddShowcaseAsync(newShowcase);

            if (result == true) { return Ok(newShowcase); }
            return StatusCode(500);
        }

        [Route("new")]
        [HttpGet]
        [ProducesResponseType(typeof(ProductEntity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewProducts()
        {
            var showcase = await _showcaseService.GetNewShowcaseAsync();

            if (showcase is null) return NoContent();
            return Ok(showcase);
        }
    }
}
