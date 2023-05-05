using System.Text;
using System.Text.Json;
using Webshop.App.Helpers;
using Webshop.App.Models;
using Webshop.App.Services.Interfaces;

namespace Webshop.App.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Authentication";
       
        public AccountService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.DefaultRequestHeaders.Add(ApiKey.Header, ApiKey.Value);
        }

        public async Task<HttpResponseMessage> Register(RegisterViewModel model)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{BasePath}/register");
            request.Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            return await _client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> Login(LoginViewModel model)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{BasePath}/login");
            request.Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            return await _client.SendAsync(request);
        }
    }
}
