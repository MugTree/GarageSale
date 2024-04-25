using System.Text.Json.Serialization;

namespace GarageSale.Models
{

    public record class SaleItem([property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("cost")] int Cost);
}