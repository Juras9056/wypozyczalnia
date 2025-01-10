using System.Net.Http;
using System.Text.Json;

namespace wpf_app;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<Klient>> GetKlienciAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:5298/api/Klient");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine(json);
        return JsonSerializer.Deserialize<List<Klient>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    //public async Task<Klient> GetKlientById(int id)
    //{
    //    var response = await _httpClient.GetAsync($"http://localhost:5298/api/Klient/{id}");
    //}
}