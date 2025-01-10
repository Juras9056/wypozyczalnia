using Microsoft.EntityFrameworkCore;
using wypozyczalnia_backend.Models;

namespace wypozyczalnia_backend;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Wypozyczenie> Wypozyczenia { get; set; }
    public DbSet<Uzytkownik> Uzytkownicy { get; set; }
    public DbSet<Slownik> Slowniki { get; set; }
    public DbSet<Samochod> Samochody { get; set; }
    public DbSet<Klient> Klienci { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Uzytkownik>().HasNoKey();
        base.OnModelCreating(modelBuilder);
    }
}