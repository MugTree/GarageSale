namespace GarageSale.Models
{
    public class Seller(string name, Disposition disposition)
    {
        public string Name { get; set; } = name;
        public Disposition Disposition { get; set; } = disposition;
        public double Profit { get; set; }
    }
}