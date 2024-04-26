namespace GarageSale.Models
{
    public class Buyer(string name, double spend, List<Purchase> purchases)
    {
        public string Name { get; set; } = name;
        public double Spend { get; set; } = spend;

        public List<Purchase> Purchases { get; set; } = purchases ?? [];
    };
}
