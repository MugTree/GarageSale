
class GarageSale()
{

    public static List<SaleResult> Run(Seller seller, List<Customer> customers, List<SaleItem> items, MarketSentiment sentiment)
    {

        Console.WriteLine("seller is... ");
        Console.WriteLine(seller.Name);
        Console.WriteLine(seller.Disposition);

        Console.WriteLine("buyers are ... ");
        foreach (var b in customers)
            Console.WriteLine(b.Name + b.Disposition);


        return [];
    }


}