using System.ComponentModel.DataAnnotations.Schema;

namespace wypozyczalnia_backend.Models;
[Table("Klient")]
public class Klient : BaseModel
{
    public string? Imie { get; set; } // Nullable string
    public string? Nazwisko { get; set; } // Nullable string
    public string? Nazwa { get; set; } // Nullable string
    public long? PESEL { get; set; }
    public long? NIP { get; set; } // Nullable string
    public string? NrTelefonu { get; set; } // Nullable string
    public string? DowodOsobisty { get; set; } // Nullable string
}