using System.Text.Json.Serialization;
using GarageSale.Utils;

namespace GarageSale.Models
{
    public record class Person([property: JsonPropertyName("name")] string Name)
    {
        public Customer ToCustomer()
        {
            return new Customer(Name, GetDisposition());
        }

        public Seller ToSeller()
        {
            return new Seller(Name, GetDisposition());
        }

        private Disposition GetDisposition()
        {
            return Utilities.GetRandomEnumValue(new Disposition[] { Disposition.Greedy, Disposition.Honest });
        }

    }
}