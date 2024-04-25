using System.Net.Http.Headers;
using dotenv.net;

var env = DotEnv.Read();
using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

var data = new Data(client, env);
var people = await data.GetData<Person>("PEOPLE_API");
var things = await data.GetData<Thing>("THINGS_API");


var rand = new Random();
var seller = people[rand.Next(people.Count)].ToSeller();
var customers = people.Where(p => p.Name != seller.Name).Select(p => p.ToCustomer()).ToList();
var saleItems = things.Select(t => t.ToSaleItem(seller.Disposition)).ToList();

var sale = GarageSale.Run(seller, customers, saleItems); //.Run(people, things);

