using System.Text.Json.Serialization;

namespace Webshop.API.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum Category
    {
        Clothes,
        Shoes,
        Accessories,
        Beauty,
        Sport
    }
}
