using System.ComponentModel.DataAnnotations.Schema;

namespace wypozyczalnia_backend.Models;

[Table("Samochod")]
public class Samochod : BaseModel
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public int Paliwo { get; set; } // Zmiana na int
    public int MocKm { get; set; }
    public int RokProdukcji { get; set; }
    public int IloscOsob { get; set; }
    public int Typ { get; set; } // Zmiana na int
    public bool Klimatyzacja { get; set; }
    public bool Nawigacja { get; set; }
    public bool CzujnikiParowania { get; set; }
    public bool CzyDostepny { get; set; }
}
