using System.ComponentModel;
using System.Text.Json;

public class Data(HttpClient client, IDictionary<string, string> env)
{
    private readonly IDictionary<string, string> _envVars = env;
    private readonly HttpClient _client = client;

    public async Task<List<T>> GetData<T>(string apiName)
    {
        await using Stream stream =
         await _client.GetStreamAsync(_envVars[apiName]);
        return await JsonSerializer.DeserializeAsync<List<T>>(stream) ?? [];
    }

}