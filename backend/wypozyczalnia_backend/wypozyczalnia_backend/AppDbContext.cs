using Microsoft.EntityFrameworkCore;
using wpf_app;
using wypozyczalnia_backend.Models;

namespace wypozyczalnia_backend;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DbSety dla tabel w bazie danych
    public DbSet<Wypozyczenie> Wypozyczenia { get; set; }
    public DbSet<Uzytkownik> Uzytkownicy { get; set; }
    public DbSet<Slownik> Slowniki { get; set; }
    public DbSet<Samochod> Samochody { get; set; }

    public DbSet<Klient> Klienci { get; set; }
    public object Wypozyczenie { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mapowanie tabeli Samochod
        modelBuilder.Entity<Samochod>(entity =>
        {
            entity.ToTable("Samochod"); // Nazwa tabeli w bazie danych
            entity.HasKey(e => e.Id); // Klucz główny

            // Mapowanie pól
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Marka).HasColumnName("Marka");
            entity.Property(e => e.Model).HasColumnName("Model");
            entity.Property(e => e.Paliwo).HasColumnName("Paliwo");
            entity.Property(e => e.MocKm).HasColumnName("MocKm").HasColumnType("INT");
            entity.Property(e => e.RokProdukcji).HasColumnName("RokProdukcji").HasColumnType("INT");
            entity.Property(e => e.IloscOsob).HasColumnName("IloscOsob").HasColumnType("INT");
            entity.Property(e => e.Typ).HasColumnName("Typ");
            entity.Property(e => e.Klimatyzacja).HasColumnName("Klimatyzacja").HasColumnType("BIT");
            entity.Property(e => e.Nawigacja).HasColumnName("Nawigacja").HasColumnType("BIT");
            entity.Property(e => e.CzujnikiParowania).HasColumnName("CzujnikiParowania").HasColumnType("BIT");
            entity.Property(e => e.CzyDostepny).HasColumnName("CzyDostepny").HasColumnType("BIT");
        });

        // Mapowanie tabeli Uzytkownik bez klucza głównego
        modelBuilder.Entity<Uzytkownik>().HasNoKey();

        // Jeśli inne tabele wymagają mapowania, dodaj je poniżej
        base.OnModelCreating(modelBuilder);
        
        {
            modelBuilder.Entity<Klient>()
                .Property(k => k.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
    


}
