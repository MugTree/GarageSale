using System.Text.Json.Serialization;

namespace GarageSale.Models
{
    // Mapped in from the call to things.json
    public record class Thing([property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("intrinsicValue")] int IntrinsicValue)
    {

        public SaleItem ToSaleItem(Disposition sellerDisposition)
        {
            double salePrice = (sellerDisposition == Disposition.Mean) ? IntrinsicValue * 2 : IntrinsicValue * 1.2;
            //Console.WriteLine("{0} priced at {1} seller is {2}", Name, salePrice, sellerDisposition);
            return new SaleItem(Name, IntrinsicValue, salePrice, false);
        }

    }
}