using System.Text.Json.Serialization;

namespace GarageSale.Models
{
    public record class SaleResult(
        [property: JsonPropertyName("seller")] string Seller,
        [property: JsonPropertyName("profit")] double Profit,
        [property: JsonPropertyName("items")] List<string> Items)
    {

    }

}