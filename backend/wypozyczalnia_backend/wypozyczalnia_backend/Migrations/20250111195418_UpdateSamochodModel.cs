using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wypozyczalnia_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSamochodModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PESEL = table.Column<long>(type: "bigint", nullable: true),
                    NIP = table.Column<long>(type: "bigint", nullable: true),
                    NrTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DowodOsobisty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Samochod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paliwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MocKm = table.Column<int>(type: "int", nullable: false),
                    RokProdukcji = table.Column<int>(type: "int", nullable: false),
                    IloscOsob = table.Column<int>(type: "int", nullable: false),
                    Typ = table.Column<int>(type: "int", nullable: false),
                    Klimatyzacja = table.Column<bool>(type: "bit", nullable: false),
                    Nawigacja = table.Column<bool>(type: "bit", nullable: false),
                    CzujnikiParowania = table.Column<bool>(type: "bit", nullable: false),
                    CzyDostepny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samochod", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "Slownik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlownikId = table.Column<int>(type: "int", nullable: false),
                    Wartosc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slownik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownik",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Haslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rola = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Wypozyczenie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKlient = table.Column<int>(type: "int", nullable: false),
                    IdSamochod = table.Column<int>(type: "int", nullable: false),
                    DataOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    TypIlosci = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stawka = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kwota = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wypozyczenie", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "Samochod");

            migrationBuilder.DropTable(
                name: "Slownik");

            migrationBuilder.DropTable(
                name: "Uzytkownik");

            migrationBuilder.DropTable(
                name: "Wypozyczenie");
        }
    }
}
