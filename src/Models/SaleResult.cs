using System.Text.Json.Serialization;

namespace GarageSale.Models
{
    public record class SaleResult([property: JsonPropertyName("customer")] string Customer);
}