using System.Text.Json.Serialization;
namespace GarageSale.Models
{
    public record class SaleResult(
        [property: JsonPropertyName("seller")] string Seller,
        [property: JsonPropertyName("profit")] double Profit,
        [property: JsonPropertyName("soldItems")] List<string> SoldItems,
        [property: JsonPropertyName("buyers")] List<Buyer> Buyers)
    {

    }

}