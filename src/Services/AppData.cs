using System.Text.Json;
using GarageSale.Models;

namespace GarageSale.Services
{
    public class AppData(HttpClient client, IDictionary<string, string> env)
    {
        private readonly IDictionary<string, string> _envVars = env;
        private readonly HttpClient _client = client;

        public async Task<List<T>> Get<T>(string apiKey)
        {
            await using Stream stream =
             await _client.GetStreamAsync(_envVars[apiKey]);
            return await JsonSerializer.DeserializeAsync<List<T>>(stream) ?? [];
        }

        public static void WriteReport(SaleResult res)
        {
            // In real world would probably send data off somewhere else...
            string json = JsonSerializer.Serialize(res);
            Console.WriteLine(json);
        }

    }
}