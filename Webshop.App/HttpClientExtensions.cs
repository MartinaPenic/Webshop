using System.Text.Json;

namespace Webshop.App
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<T>(
                dataAsString, 
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return result;
        }
    }
}
