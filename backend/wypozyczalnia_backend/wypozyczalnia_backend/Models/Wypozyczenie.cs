using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wypozyczalnia_backend.Models;

namespace wpf_app
{
    public class Wypozyczenie
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Klient")]
        public int IdKlient { get; set; }
        public Klient? Klient { get; set; } // Opcjonalna relacja

        [ForeignKey("Samochod")]
        public int IdSamochod { get; set; }
        public Samochod? Samochod { get; set; } // Opcjonalna relacja

        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
        public int Ilosc { get; set; }
        public int TypIlosci { get; set; }
        public decimal Stawka { get; set; }
        public decimal Kwota { get; set; }
    }

}