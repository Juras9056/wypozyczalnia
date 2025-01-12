using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wypozyczalnia_backend.Models
{
    public class Samochod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Automatyczne generowanie wartości Id
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Paliwo { get; set; }
        public int MocKm { get; set; }
        public int RokProdukcji { get; set; }
        public int IloscOsob { get; set; }
        public int Typ { get; set; }
        public bool Klimatyzacja { get; set; }
        public bool Nawigacja { get; set; }
        public bool CzujnikiParowania { get; set; }
        public bool CzyDostepny { get; set; }
    }
}