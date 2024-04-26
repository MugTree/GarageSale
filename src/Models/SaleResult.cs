using System.Text.Json.Serialization;
namespace GarageSale.Models
{
    public record class SaleResult(
        [property: JsonPropertyName("seller")] string SellerName,
        [property: JsonPropertyName("market")] string MarketSentiment,
        [property: JsonPropertyName("profit")] double Profit,
        [property: JsonPropertyName("soldItems")] List<string> SoldItems,
        [property: JsonPropertyName("buyers")] List<Buyer> Buyers)
    {

    }

}