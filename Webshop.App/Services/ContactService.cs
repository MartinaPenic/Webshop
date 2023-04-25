using System.Text;
using System.Text.Json;
using Webshop.App.Helpers;
using Webshop.App.Models;
using Webshop.App.Services.Interfaces;

namespace Webshop.App.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _client;

        public const string BasePath = "/api/Message";

        public ContactService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.DefaultRequestHeaders.Add(ApiKey.Header, ApiKey.Value);
        }

        public async Task SendMessage(ContactViewModel message)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{BasePath}/create");
            request.Content = new StringContent(JsonSerializer.Serialize(message), Encoding.UTF8, "application/json");
            await _client.SendAsync(request);
        }
    }
}
