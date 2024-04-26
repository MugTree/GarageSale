using GarageSale.Utils;
using GarageSale.Models;

namespace GarageSale.Services
{
    public class SaleDay(Seller seller, List<Customer> customers, List<SaleItem> items, MarketSentiment sentiment)
    {
        private readonly Seller Seller = seller;
        public readonly List<Customer> Customers = customers;
        public readonly List<SaleItem> Items = items;
        public readonly MarketSentiment Sentiment = sentiment;
        public List<SaleResult> Run()
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
                    if (Seller.Disposition == Disposition.Friendly && c.Disposition == Disposition.Friendly && i.Price < c.Funds)
                    {
                        c.Funds -= i.Price;
                        i.Sold = true;
                        Seller.Profit += i.Price - i.IntrinsicValue;
                        c.Purchases.Add(new Purchase(i.Name, i.Price));
                        Console.WriteLine("{0} has bought the {1} for {2}", c.Name, i.Name, i.Price);

                    }
                    if (Seller.Disposition == Disposition.Mean && c.Disposition == Disposition.Mean && Sentiment == MarketSentiment.Buyers)
                    {
                        Console.WriteLine("{0} is out today doesn't like {1} and it's the wrong time...", c.Name, Seller.Name);
                        break;
                    }
                    if (c.Funds == 0)
                    {
                        Console.WriteLine("{0} is out of money...", c.Name);
                        break;
                    }
                }
            }

            Console.WriteLine("{0} has made a profit of {1}", Seller.Name, Seller.Profit);


            foreach (var c in Customers)
                foreach (var p in c.Purchases)
                    Console.WriteLine(p.Name);


            return [];
        }
    }
}
