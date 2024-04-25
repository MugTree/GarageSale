using System.Text.Json.Serialization;
public record class Thing([property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("intrinsicValue")] int IntrinsicValue)
{

    public SaleItem ToSaleItem(Disposition sellerDisposition)
    {
        int disposition = (int)sellerDisposition;
        return new SaleItem(Name, Cost: IntrinsicValue * disposition);
    }

}