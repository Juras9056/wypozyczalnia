using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wypozyczalnia_backend.Models;
[Table("Uzytkownik")]
public class Uzytkownik
{
    [Key] 
    public string Login { get; set; }
    public string Haslo { get; set; }
    public string Rola { get; set; }
}