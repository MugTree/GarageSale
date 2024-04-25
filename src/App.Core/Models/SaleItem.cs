using System.Text.Json.Serialization;
public record class SaleItem([property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("cost")] int Cost);