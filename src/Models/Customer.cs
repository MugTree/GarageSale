using System.Dynamic;
using System.Text.Json.Serialization;
using GarageSale.Utils;

namespace GarageSale.Models
{
    public class Customer(string name, double funds, Disposition disposition)
    {

        public string Name { get; set; } = name;
        public double Funds { get; set; } = funds;
        public Disposition Disposition { get; set; } = disposition;

        public List<Purchase> Purchases { get; set; } = [];
    };
}
