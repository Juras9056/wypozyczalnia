using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using wpf_app.Models;

namespace wpf_app
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5298/api/")
            };
        }

        private async Task<T> HandleApiCallAsync<T>(Func<Task<HttpResponseMessage>> apiCall)
        {
            try
            {
                var response = await apiCall();

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Błąd API: Kod {response.StatusCode}, Szczegóły: {errorResponse}");
                }

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                // Logowanie błędu do konsoli
                Console.WriteLine($"[API ERROR]: {ex.Message}");
                throw; // Ponowne zgłoszenie wyjątku
            }
        }

        // Pobierz listę klientów
        public async Task<List<Klient>> GetKlienciAsync()
        {
            return await HandleApiCallAsync<List<Klient>>(() => _httpClient.GetAsync("Klient"));
        }

        // Dodaj nowego klienta
        public async Task AddKlientAsync(Klient klient)
        {
            await HandleApiCallAsync<object>(() =>
            {
                var json = JsonSerializer.Serialize(klient);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                return _httpClient.PostAsync("Klient", content);
            });
        }

        // Usuń klienta po ID
        public async Task DeleteKlientAsync(int id)
        {
            try
            {
                // Tworzenie żądania DELETE
                var request = new HttpRequestMessage(HttpMethod.Delete, $"Klient/{id}");
                request.Content = new StringContent(string.Empty); // Dodanie pustej treści

                Console.WriteLine($"Wysyłanie żądania DELETE na URL: {request.RequestUri}");

                // Wysłanie żądania
                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Błąd DELETE: {response.StatusCode} - {errorResponse}");
                    throw new Exception($"Błąd podczas usuwania klienta: {response.StatusCode} - {errorResponse}");
                }

                Console.WriteLine("Klient został pomyślnie usunięty.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd w DeleteKlientAsync: {ex.Message}");
                throw;
            }
        }


        // Pobierz listę samochodów
        public async Task<List<Samochod>> GetSamochodyAsync()
        {
            return await HandleApiCallAsync<List<Samochod>>(() => _httpClient.GetAsync("Samochod"));
        }

        // Dodaj nowy samochód
        public async Task AddSamochodAsync(Samochod samochod)
        {
            await HandleApiCallAsync<object>(() =>
            {
                var json = JsonSerializer.Serialize(samochod);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                return _httpClient.PostAsync("Samochod", content);
            });
        }

        // Usuń samochód po ID
        public async Task DeleteSamochodAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"http://localhost:5298/api/Samochod/{id}");
            response.EnsureSuccessStatusCode();
        }


        // Aktualizuj klienta po ID
        public async Task UpdateKlientAsync(int id, Klient klient)
        {
            try
            {
                var json = JsonSerializer.Serialize(klient);
                Console.WriteLine($"Wysyłany JSON: {json}"); // Logowanie JSON-a
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"Klient/{id}", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Błąd podczas aktualizacji klienta: {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UpdateKlientAsync ERROR]: {ex.Message}");
                throw;
            }
        }


        // Pobierz listę wypożyczeń
        public async Task<List<Wypozyczenie>> GetWypozyczeniaAsync()
        {
            return await HandleApiCallAsync<List<Wypozyczenie>>(() => _httpClient.GetAsync("Wypozyczenie"));
        }

        // Dodaj wypożyczenie
        public async Task AddWypozyczenieAsync(Wypozyczenie wypozyczenie)
        {
            try
            {
                var json = JsonSerializer.Serialize(wypozyczenie);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("Wypozyczenie", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Błąd podczas dodawania wypożyczenia. Kod: {response.StatusCode}, Szczegóły: {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AddWypozyczenieAsync ERROR]: {ex.Message}");
                throw;
            }
        }


        // Aktualizuj wypożyczenie
        public async Task UpdateWypozyczenieAsync(int id, Wypozyczenie wypozyczenie)
        {
            try
            {
                var json = JsonSerializer.Serialize(wypozyczenie);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Wypozyczenie/{id}", content);
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Błąd podczas aktualizacji wypożyczenia. Kod: {response.StatusCode}, Szczegóły: {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UpdateWypozyczenieAsync ERROR]: {ex.Message}");
                throw;
            }
        }

        // Usuń wypożyczenie
        public async Task DeleteWypozyczenieAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Wypozyczenie/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Błąd podczas usuwania wypożyczenia. Kod: {response.StatusCode}, Szczegóły: {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DeleteWypozyczenieAsync ERROR]: {ex.Message}");
                throw;
            }
        }
    }
}
