using Webshop.App.Helpers;
using Webshop.App.Models.Dto;
using Webshop.App.Services.Interfaces;

namespace Webshop.App.Services
{
    public class ShowcaseService : IShowcaseService
    {
        private readonly HttpClient _client;

        public const string BasePath = "/api/Showcase";

        public ShowcaseService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.DefaultRequestHeaders.Add(ApiKey.Header, ApiKey.Value);
        }

        public async Task<Showcase> GetNewShowcase()
        {
            var result = await _client.GetAsync($"{BasePath}/new");
            return await result.ReadContentAsync<Showcase>();
        }
    }
}
