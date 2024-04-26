using System.Text.Json.Serialization;
using GarageSale.Utils;

namespace GarageSale.Models
{

    public class Purchase(string name, double price)
    {
        public string Name { get; set; } = name;
        public double Price { get; set; } = price;

    }
}