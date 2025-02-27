USE [master]
GO
/****** Object:  Database [Wypozyczalnia_samochodow]    Script Date: 05.01.2025 14:58:14 ******/
CREATE DATABASE [Wypozyczalnia_samochodow]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Wypozyczalnia_samochodow', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Wypozyczalnia_samochodow.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Wypozyczalnia_samochodow_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Wypozyczalnia_samochodow_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Wypozyczalnia_samochodow].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET ARITHABORT OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET  MULTI_USER 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET QUERY_STORE = ON
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Wypozyczalnia_samochodow]
GO
/****** Object:  Table [dbo].[Klient]    Script Date: 05.01.2025 14:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klient](
	[Id] [int] NOT NULL,
	[Imie] [nvarchar](15) NULL,
	[Nazwisko] [nvarchar](20) NULL,
	[Nazwa] [nvarchar](30) NULL,
	[PESEL] [bigint] NULL,
	[NIP] [bigint] NULL,
	[NrTelefonu] [nvarchar](20) NULL,
	[DowodOsobisty] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Samochod]    Script Date: 05.01.2025 14:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Samochod](
	[Id] [int] NOT NULL,
	[Marka] [nvarchar](20) NULL,
	[Model] [nvarchar](20) NULL,
	[Paliwo] [int] NULL,
	[MocKm] [smallint] NULL,
	[RokProdukcji] [smallint] NULL,
	[IloscOsob] [tinyint] NULL,
	[Typ] [int] NULL,
	[Klimatyzacja] [bit] NULL,
	[Nawigacja] [bit] NULL,
	[CzujnikiParowania] [bit] NULL,
	[CzyDostepny] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slownik]    Script Date: 05.01.2025 14:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slownik](
	[Id] [int] NOT NULL,
	[SlownikId] [int] NULL,
	[Wartosc] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wypozyczenie]    Script Date: 05.01.2025 14:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wypozyczenie](
	[Id] [int] NOT NULL,
	[IdKlient] [int] NULL,
	[IdSamochod] [int] NULL,
	[DataOd] [datetime] NULL,
	[DataDo] [datetime] NULL,
	[Ilosc] [smallint] NULL,
	[TypIlosci] [int] NULL,
	[Stawka] [int] NULL,
	[Kwota] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Samochod]  WITH CHECK ADD  CONSTRAINT [FK_Samochod_Slownik_Paliwo] FOREIGN KEY([Paliwo])
REFERENCES [dbo].[Slownik] ([Id])
GO
ALTER TABLE [dbo].[Samochod] CHECK CONSTRAINT [FK_Samochod_Slownik_Paliwo]
GO
ALTER TABLE [dbo].[Samochod]  WITH CHECK ADD  CONSTRAINT [FK_Samochod_Slownik_TypSamochodu] FOREIGN KEY([Typ])
REFERENCES [dbo].[Slownik] ([Id])
GO
ALTER TABLE [dbo].[Samochod] CHECK CONSTRAINT [FK_Samochod_Slownik_TypSamochodu]
GO
ALTER TABLE [dbo].[Wypozyczenie]  WITH CHECK ADD  CONSTRAINT [FK_Wypozyczenie_Klient_IdKlient] FOREIGN KEY([IdKlient])
REFERENCES [dbo].[Klient] ([Id])
GO
ALTER TABLE [dbo].[Wypozyczenie] CHECK CONSTRAINT [FK_Wypozyczenie_Klient_IdKlient]
GO
ALTER TABLE [dbo].[Wypozyczenie]  WITH CHECK ADD  CONSTRAINT [FK_Wypozyczenie_Samochod_IdSamochod] FOREIGN KEY([IdSamochod])
REFERENCES [dbo].[Samochod] ([Id])
GO
ALTER TABLE [dbo].[Wypozyczenie] CHECK CONSTRAINT [FK_Wypozyczenie_Samochod_IdSamochod]
GO
ALTER TABLE [dbo].[Wypozyczenie]  WITH CHECK ADD  CONSTRAINT [FK_Wypozyczenie_Slownik_Stawka] FOREIGN KEY([Stawka])
REFERENCES [dbo].[Slownik] ([Id])
GO
ALTER TABLE [dbo].[Wypozyczenie] CHECK CONSTRAINT [FK_Wypozyczenie_Slownik_Stawka]
GO
ALTER TABLE [dbo].[Wypozyczenie]  WITH CHECK ADD  CONSTRAINT [FK_Wypozyczenie_Slownik_TypIlosci] FOREIGN KEY([TypIlosci])
REFERENCES [dbo].[Slownik] ([Id])
GO
ALTER TABLE [dbo].[Wypozyczenie] CHECK CONSTRAINT [FK_Wypozyczenie_Slownik_TypIlosci]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Paliwo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Samochod', @level2type=N'CONSTRAINT',@level2name=N'FK_Samochod_Slownik_Paliwo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TypSamochodu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Samochod', @level2type=N'CONSTRAINT',@level2name=N'FK_Samochod_Slownik_TypSamochodu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IdKlient' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wypozyczenie', @level2type=N'CONSTRAINT',@level2name=N'FK_Wypozyczenie_Klient_IdKlient'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IdSamochod' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wypozyczenie', @level2type=N'CONSTRAINT',@level2name=N'FK_Wypozyczenie_Samochod_IdSamochod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stawka' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wypozyczenie', @level2type=N'CONSTRAINT',@level2name=N'FK_Wypozyczenie_Slownik_Stawka'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TypIlosci' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wypozyczenie', @level2type=N'CONSTRAINT',@level2name=N'FK_Wypozyczenie_Slownik_TypIlosci'
GO
USE [master]
GO
ALTER DATABASE [Wypozyczalnia_samochodow] SET  READ_WRITE 
GO
