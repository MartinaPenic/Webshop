using System.Text.Json.Serialization;

namespace Webshop.API.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum Color
    {
        White,
        Black,
        Red,
        Green,
        Blue,
        Yellow
    }
}
