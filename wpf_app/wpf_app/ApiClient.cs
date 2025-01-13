using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
            await HandleApiCallAsync<object>(() => _httpClient.DeleteAsync($"Klient/{id}"));
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
            await HandleApiCallAsync<object>(() => _httpClient.DeleteAsync($"Samochod/{id}"));
        }

        // Aktualizuj klienta po ID
        public async Task UpdateKlientAsync(int id, Klient klient)
        {
            await HandleApiCallAsync<object>(() =>
            {
                var json = JsonSerializer.Serialize(klient);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                return _httpClient.PutAsync($"Klient/{id}", content);
            });
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
