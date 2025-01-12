using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace wpf_app;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("http://localhost:5298/api/");
    }

    // Pobierz listę klientów
    public async Task<List<Klient>> GetKlienciAsync()
    {
        var response = await _httpClient.GetAsync("Klient");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Klient>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    // Dodaj nowego klienta
    public async Task AddKlientAsync(Klient klient)
    {
        var json = JsonSerializer.Serialize(klient);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("Klient", content);
        response.EnsureSuccessStatusCode();
    }

    // Usuń klienta po ID
    public async Task DeleteKlientAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"Klient/{id}");
        response.EnsureSuccessStatusCode();
    }

    // Pobierz listę samochodów
    public async Task<List<Samochod>> GetSamochodyAsync()
    {
        var response = await _httpClient.GetAsync("Samochod");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Samochod>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }


    public async Task AddSamochodAsync(Samochod samochod)
    {
        var json = JsonSerializer.Serialize(samochod);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("Samochod", content);

        if (!response.IsSuccessStatusCode)
        {
            // Zapisz szczegóły odpowiedzi z serwera
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception($"Błąd podczas dodawania samochodu. Kod: {response.StatusCode}, Odpowiedź: {errorResponse}");
        }
    }


    // Usuń samochód po ID
    public async Task DeleteSamochodAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"Samochod/{id}");
        response.EnsureSuccessStatusCode();
    }
    
    public async Task UpdateKlientAsync(int id, Klient klient)
    {
        var json = JsonSerializer.Serialize(klient);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"Klient/{id}", content);
        response.EnsureSuccessStatusCode();
    }


    
    
}
