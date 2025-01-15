namespace wypozyczalnia_backend.Dto;

public class LoginDto
{
    public string? Login { get; set; }
    public string? Haslo { get; set; }
}

public class Samochod
{
    public string Marka { get; set; }
    public string Model { get; set; }

    public Samochod()
    {
        Marka = string.Empty;
        Model = string.Empty;
    }
}
