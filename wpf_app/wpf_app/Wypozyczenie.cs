using System;
using System.Text.Json.Serialization;

namespace wpf_app
{
    public class Wypozyczenie
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("idKlient")]
        public int IdKlient { get; set; }

        [JsonPropertyName("idSamochod")]
        public int IdSamochod { get; set; }

        [JsonPropertyName("dataOd")]
        public DateTime DataOd { get; set; }

        [JsonPropertyName("dataDo")]
        public DateTime DataDo { get; set; }

        [JsonPropertyName("ilosc")]
        public int Ilosc { get; set; }

        [JsonPropertyName("typIlosci")]
        public string TypIlosci { get; set; }

        [JsonPropertyName("stawka")]
        public decimal Stawka { get; set; }

        [JsonPropertyName("kwota")]
        public decimal Kwota { get; set; }
    }
}