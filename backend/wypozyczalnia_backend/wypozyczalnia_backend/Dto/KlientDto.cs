namespace wypozyczalnia_backend.Dto
{
    /// <summary>
    /// Klasa DTO dla przesyłania danych klienta. 
    /// Używana tylko w celach transferu danych między API a aplikacją kliencką.
    /// </summary>
    public class KlientDto
    {
        public int Id { get; set; } // ID klienta
        public string? Imie { get; set; } // Imię klienta
        public string? Nazwisko { get; set; } // Nazwisko klienta
        public string? Nazwa { get; set; } // Nazwa firmy (opcjonalne)
        public long? PESEL { get; set; } // PESEL klienta (opcjonalne)
        public long? NIP { get; set; } // NIP klienta (opcjonalne)
        public string? NrTelefonu { get; set; } // Numer telefonu klienta
        public string? DowodOsobisty { get; set; } // Dowód osobisty klienta
    }
}