using System.Text.Json.Serialization;
using GarageSale.Utils;

namespace GarageSale.Models
{
    // Mapped in from the call to people.json
    public record class Person([property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("funds")] int Funds)
    {
        public Customer ToCustomer()
        {
            return new Customer(Name, Funds, GetDisposition());
        }

        public Seller ToSeller()
        {
            return new Seller(Name, GetDisposition());
        }

        private Disposition GetDisposition()
        {
            return Utilities.GetRandomEnumValue(new Disposition[] { Disposition.Mean, Disposition.Friendly });
        }

    }
}