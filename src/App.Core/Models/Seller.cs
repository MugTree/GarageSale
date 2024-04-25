using System.Text.Json.Serialization;
public record class Seller([property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("disposition")] Disposition Disposition);