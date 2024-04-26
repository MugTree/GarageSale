using GarageSale.Utils;
using GarageSale.Models;

namespace GarageSale.Services
{
    public class SaleDay(Seller seller, List<Customer> customers, List<SaleItem> items, MarketSentiment sentiment)
    {
        private readonly Seller Seller = seller;
        private readonly List<Customer> Customers = customers;
        private readonly List<SaleItem> Items = items;
        private readonly MarketSentiment Sentiment = sentiment;

        private void CompleteSale(Customer c, SaleItem i)
        {
            c.Funds -= i.Price;
            i.Sold = true;
            Seller.Profit += i.Price - i.IntrinsicValue;
            c.Purchases.Add(new Purchase(i.Name, i.Price));
            Console.WriteLine("{0} has bought the {1} for {2}", c.Name, i.Name, i.Price);
        }
        public SaleResult Run()
        {

            foreach (var c in Customers)
            {
                Console.WriteLine("Customer {0} is {1}", c.Name, c.Disposition);
                foreach (var i in Items)
                {
                    if (i.Sold)
                    {
                        Console.WriteLine("{0} has already sold, try something else...", i.Name);
                        continue;
                    }
                    if (i.Price > c.Funds)
                    {
                        Console.WriteLine("{0} Can't afford the {1}", c.Name, i.Name);
                        continue;
                    }
                    if (Seller.Disposition == Disposition.Mean && c.Disposition == Disposition.Mean && Sentiment == MarketSentiment.Buyers)
                    {
                        Console.WriteLine("{0} is out today doesn't like {1} and it's the wrong time...", c.Name, Seller.Name);
                        break;
                    }
                    if (Seller.Disposition == Disposition.Friendly && c.Disposition == Disposition.Friendly && i.Price < c.Funds)
                    {
                        CompleteSale(c, i);
                    }
                    if (c.Funds == 0)
                    {
                        Console.WriteLine("{0} is out of money...", c.Name);
                        break;
                    }
                    var r = new Random();
                    // Purchase on a whim
                    if (r.Next(0, 2) == 1 && i.Price < c.Funds)
                    {
                        Console.WriteLine("{0} makes an impulse purchase...", c.Name);
                        CompleteSale(c, i);
                    }
                }
            }

            Console.WriteLine("{0} has made a profit of {1}", Seller.Name, Seller.Profit);

            var res = new SaleResult(Seller.Name, Seller.Profit, Items.Where(i => i.Sold).Select(p => p.Name).ToList());

            return res;
        }
    }
}
