namespace wypozyczalnia_backend.Dto;

public class KlientDto
{
    public string? Imie { get; set; } // Nullable string
    public string? Nazwisko { get; set; } // Nullable string
    public string? Nazwa { get; set; } // Nullable string
    public long? PESEL { get; set; } // Nullable string
    public long? NIP { get; set; } // Nullable string
    public string? NrTelefonu { get; set; } // Nullable string
    public string? DowodOsobisty { get; set; } // Nullable string
}