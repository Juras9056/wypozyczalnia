namespace wypozyczalnia_backend.Dto;

public class Klient
{
    public int Id { get; set; } // Ustawione na int
    public string? Imie { get; set; }
    public string? Nazwisko { get; set; }
    public string? Nazwa { get; set; }
    public long? PESEL { get; set; }
    public long? NIP { get; set; }
    public string? NrTelefonu { get; set; }
    public string? DowodOsobisty { get; set; }
}
