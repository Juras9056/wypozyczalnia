using System.ComponentModel.DataAnnotations.Schema;

namespace wypozyczalnia_backend.Models;

[Table("Slownik")]
public class Slownik : BaseModel
{
    public string Wartosc { get; set; }
}