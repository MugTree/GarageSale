using System.ComponentModel;
using System.Text.Json;

public class WebData(HttpClient client, IDictionary<string, string> env)
{
    private readonly IDictionary<string, string> _envVars = env;
    private readonly HttpClient _client = client;

    public async Task<List<T>> Get<T>(string apiKey)
    {
        await using Stream stream =
         await _client.GetStreamAsync(_envVars[apiKey]);
        return await JsonSerializer.DeserializeAsync<List<T>>(stream) ?? [];
    }

}