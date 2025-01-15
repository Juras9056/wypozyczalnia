using System.Text.Json.Serialization;

namespace wpf_app.Models
{
    public class Wypozyczenie
    {
        public int Id { get; set; }
        public int IdKlient { get; set; }
        public int IdSamochod { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
        public int Ilosc { get; set; }
        public int TypIlosci { get; set; }
        public decimal Stawka { get; set; }
        public decimal Kwota { get; set; }
    }
}
