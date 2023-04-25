using Webshop.App.Helpers;
using Webshop.App.Models.Dto;
using Webshop.App.Services.Interfaces;

namespace Webshop.App.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public const string BasePath = "/api/Product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.DefaultRequestHeaders.Add(ApiKey.Header, ApiKey.Value);
        }

        public async Task<IEnumerable<Product>> GetFeaturedProducts()
        {
            var result = await _client.GetAsync($"{BasePath}/featured");
            return await result.ReadContentAsync<List<Product>>();
        }

        public async Task<IEnumerable<Product>> GetNewProducts()
        {
            var result = await _client.GetAsync($"{BasePath}/new");
            return await result.ReadContentAsync<List<Product>>();
        }

        public async Task<IEnumerable<Product>> GetPopularProducts()
        {
            var result = await _client.GetAsync($"{BasePath}/popular");
            return await result.ReadContentAsync<List<Product>>();
        }

        public async Task<Product> GetProduct(int id)
        {
            var result = await _client.GetAsync($"{BasePath}/{id}");
            return await result.ReadContentAsync<Product>();
        }

        public async Task<IEnumerable<ProductRating>> GetProductRatings(int id)
        {
            var result = await _client.GetAsync($"{BasePath}/{id}/ratings");
            return await result.ReadContentAsync<List<ProductRating>>();
        }
    }
}