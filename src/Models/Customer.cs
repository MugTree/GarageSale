using System.Text.Json.Serialization;
using GarageSale.Utils;

namespace GarageSale.Models
{
    public record class Customer([property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("disposition")] Disposition Disposition);
}
