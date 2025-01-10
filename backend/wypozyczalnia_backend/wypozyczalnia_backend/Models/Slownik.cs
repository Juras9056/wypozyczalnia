using System.ComponentModel.DataAnnotations.Schema;

namespace wypozyczalnia_backend.Models;
[Table("Slownik")]
public class Slownik : BaseModel
{
    public int SlownikId { get; set; }
    public string Wartosc { get; set; }
}