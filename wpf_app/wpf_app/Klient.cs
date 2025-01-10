using System.Text.Json.Serialization;

namespace wpf_app;

public class Klient
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("imie")]
    public string Imie { get; set; }

    [JsonPropertyName("nazwisko")]
    public string Nazwisko { get; set; }

    [JsonPropertyName("nazwa")]
    public string Nazwa { get; set; }

    [JsonPropertyName("pesel")]
    public long Pesel { get; set; }

    [JsonPropertyName("nip")]
    public long Nip { get; set; }

    [JsonPropertyName("nrTelefonu")]
    public string NrTelefonu { get; set; }

    [JsonPropertyName("dowodOsobisty")]
    public string DowodOsobisty { get; set; }
}