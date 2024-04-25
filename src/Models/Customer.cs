using System.Text.Json.Serialization;
public record class Customer([property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("disposition")] Disposition Disposition);