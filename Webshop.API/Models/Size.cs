using System.Text.Json.Serialization;

namespace Webshop.API.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum Size
    {
        S,
        M,
        L,
        XL
    }
}
