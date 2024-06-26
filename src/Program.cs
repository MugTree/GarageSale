﻿using System.Net.Http.Headers;
using dotenv.net;
using GarageSale.Utils;
using GarageSale.Services;
using GarageSale.Models;

var env = DotEnv.Read();
using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

var data = new AppData(client, env);
var people = await data.Get<Person>("PEOPLE_API");
var things = await data.Get<Thing>("THINGS_API");

var seller = people[new Random().Next(people.Count)].ToSeller();
var customers = people.Where(p => p.Name != seller.Name).Select(p => p.ToCustomer()).ToList();
var saleItems = things.Select(t => t.ToSaleItem(seller.Disposition)).ToList();

var sentiment = Utilities.GetRandomEnumValue(new MarketSentiment[] { MarketSentiment.Buyers, MarketSentiment.Sellers });
var sale = new Sale(seller, customers, saleItems, sentiment);

var result = sale.Run();

AppData.WriteReport(result);













