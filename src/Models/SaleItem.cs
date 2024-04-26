namespace GarageSale.Models
{
    public class SaleItem(string name, int intrinsicValue, double price, bool sold)
    {
        public string Name { get; set; } = name;
        public double Price { get; set; } = price;
        public int IntrinsicValue { get; set; } = intrinsicValue;
        public bool Sold { get; set; } = sold;

    }
}