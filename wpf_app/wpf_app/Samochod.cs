using System.Text.Json.Serialization;

namespace wpf_app;

public class Samochod
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("marka")]
    public string Marka { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("paliwo")]
    public int Paliwo { get; set; } // Zmiana na int


    [JsonPropertyName("mocKm")]
    public int MocKm { get; set; }

    [JsonPropertyName("rokProdukcji")]
    public int RokProdukcji { get; set; }

    [JsonPropertyName("iloscOsob")]
    public int IloscOsob { get; set; }

    [JsonPropertyName("typ")]
    public int Typ { get; set; }

    [JsonPropertyName("klimatyzacja")]
    public bool Klimatyzacja { get; set; }

    [JsonPropertyName("nawigacja")]
    public bool Nawigacja { get; set; }

    [JsonPropertyName("czujnikiParowania")]
    public bool CzujnikiParowania { get; set; }

    [JsonPropertyName("czyDostepny")]
    public bool CzyDostepny { get; set; }

    
}