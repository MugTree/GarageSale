using System.Text.Json.Serialization;
public record class SaleResult([property: JsonPropertyName("customer")] string Customer);