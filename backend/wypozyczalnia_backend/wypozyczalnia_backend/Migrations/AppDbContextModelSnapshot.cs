﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wypozyczalnia_backend;

#nullable disable

namespace wypozyczalnia_backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("wypozyczalnia_backend.Models.Klient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DowodOsobisty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("NIP")
                        .HasColumnType("bigint");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrTelefonu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PESEL")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Klient");
                });

            modelBuilder.Entity("wypozyczalnia_backend.Models.Samochod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("CzujnikiParowania")
                        .HasColumnType("BIT")
                        .HasColumnName("CzujnikiParowania");

                    b.Property<bool>("CzyDostepny")
                        .HasColumnType("BIT")
                        .HasColumnName("CzyDostepny");

                    b.Property<int>("IloscOsob")
                        .HasColumnType("INT")
                        .HasColumnName("IloscOsob");

                    b.Property<bool>("Klimatyzacja")
                        .HasColumnType("BIT")
                        .HasColumnName("Klimatyzacja");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Marka");

                    b.Property<int>("MocKm")
                        .HasColumnType("INT")
                        .HasColumnName("MocKm");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Model");

                    b.Property<bool>("Nawigacja")
                        .HasColumnType("BIT")
                        .HasColumnName("Nawigacja");

                    b.Property<string>("Paliwo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Paliwo");

                    b.Property<int>("RokProdukcji")
                        .HasColumnType("INT")
                        .HasColumnName("RokProdukcji");

                    b.Property<string>("Typ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Typ");

                    b.HasKey("Id");

                    b.ToTable("Samochod", (string)null);
                });

            modelBuilder.Entity("wypozyczalnia_backend.Models.Slownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SlownikId")
                        .HasColumnType("int");

                    b.Property<string>("Wartosc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Slownik");
                });

            modelBuilder.Entity("wypozyczalnia_backend.Models.Uzytkownik", b =>
                {
                    b.Property<string>("Haslo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rola")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Uzytkownik");
                });

            modelBuilder.Entity("wypozyczalnia_backend.Models.Wypozyczenie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataOd")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdKlient")
                        .HasColumnType("int");

                    b.Property<int>("IdSamochod")
                        .HasColumnType("int");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<decimal>("Kwota")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Stawka")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TypIlosci")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wypozyczenie");
                });
#pragma warning restore 612, 618
        }
    }
}
