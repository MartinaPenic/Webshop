using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.API.Models.Dto;
using Webshop.API.Services;

namespace Webshop.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Roles = "Admin, ProductManager")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _productService.AddProductAsync(dto);

            if (result) return Ok();
            return StatusCode(500);
        }


        [Authorize(Roles = "Admin, ProductManager")]
        [Route("delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (await _productService.DeleteProductAsync(id))
                return Ok();

            return BadRequest();
        }


        [Route("new")]
        [HttpGet]
        public async Task<IActionResult> GetNewProducts()
        {
            var products = await _productService.GetNewProductsAsync();

            if (products.Count() == 0) return NoContent();
            return Ok(products);
        }


        [Route("featured")]
        [HttpGet]
        public async Task<IActionResult> GetFeaturedProducts()
        {
            var products = await _productService.GetFeaturedProductsAsync();

            if (products.Count() == 0) return NoContent();
            return Ok(products);
        }


        [Route("popular")]
        [HttpGet]
        public async Task<IActionResult> GetPopularProducts()
        {
            var products = await _productService.GetPopularProductsAsync();

            if (products.Count() == 0) return NoContent();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductAsync(id);

            if (product == null) return NotFound();
            return Ok(product);
        }


        [Route("offer")]
        [HttpGet]
        public async Task<IActionResult> GetSpecialOffer()
        {
            var products = await _productService.GetSpecialOfferProductsAsync();

            if (products.Count() == 0) return NoContent();
            return Ok(products);
        }


        [Route("{id}/ratings")]
        [HttpGet]
        public async Task<IActionResult> GetProductRatings(int id)
        {
            var ratings = await _productService.GetProductRatingsAsync(id);

            if (ratings.Count() == 0) return NoContent();
            return Ok(ratings);
        }


        [Route("{id}/ratings/create")]
        [HttpPost]
        public async Task<IActionResult> AddProductRating(int id, AddProductRatingDto dto)
        {
            var product = await _productService.GetProductAsync(id);
            if (product is null) return NotFound();

            var result = await _productService.AddProductRatingAsync(id, dto);

            if (result) return Ok(); 
            return StatusCode(500);
        }
    }
}
