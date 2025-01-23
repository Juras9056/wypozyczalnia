## Wypo¿yczalnia samochodów

Aplikacja wypo¿yczalni samochodów to program umo¿liwiaj¹cy zarz¹dzanie flot¹ pojazdów, klientami oraz procesem wypo¿yczeñ. Aplikacja sk³ada siê z interfejsu u¿ytkownika wykonanego z u¿yciem silnika **WPF** oraz backendu opartego na **ASP.NET Core** z pod³¹czeniem do bazy danych **SQL Server**.


**Autorzy**: Karolina Ciszowska, Daniel Jurczyk, Sandra Hyla

## Funkcjonalnoœci
### Zarz¹dzanie flot¹ samochodów:
- dodawanie i usuwanie samochodów
- przechowywanie danych (marka, model, paliwo, moc, rocznik, klimatyzacja, nawigacja)
### Zarz¹dzanie klientami:
- dodawanie, usuwanie i edytowanie klientów
- przechowywanie dancych (imiê, nazwisko, PESEL, NIP, telefon)
### Obs³uga wypo¿yczeñ:
- wybór samochodu i klienta
- wybór daty wynajmu
- wyliczanie kosztów wypo¿yczenia
### Po³¹czenie z baz¹ danych SQL:
- przechowywanie danych w Entity Framework Core
### Interfejs u¿ytkownika WPF:
- aplikacja okienkowa z g³ównym oknem wyboru i osobnymi widokami klientów, samochodów i wypo¿yczeñ

## Technologie
- **Frontend:** WPF (C#)
- **Backend:** ASP.NET Core
- **Baza danych:** SQL Server, Entity Framework
- **System kontroli wersji:** GitHub
### Backend (ASP.NET Core):
Aplikacja backendowa diza³a jako REST API i udostêpnia kontrolery:
- **SamochodController.cs** -> zarz¹dzenie samochodami (GET/api/Samochod)
- **KlientController.cs** -> zarz¹dzanie klientami (GET/api/Klient)
- **WypozyczenieController.cs** -> zarz¹dzanie wypo¿yczeniami (POST/api/Wypozyczenie)
#### Obs³uga bazy danych:
Wykorzystano Entity Framework Core, który mapuje modele na tabelê w bazie SQL Server.

### Frontend (WPF)
Interfejs u¿ytkownika zosta³ utworzony w technologii Windows Presentation Foundation (WPF).
- **MainWindow.xaml** –> ekran g³ówny z nawigacj¹
- **SamochodyWindow.xaml** –> lista samochodów, dodawanie i usuwanie
- **KlienciWindow.xaml** –> lista klientów, dodawanie, usuwanie i edycja
- **WypozyczeniaWindow.xaml** –> panel wypo¿yczeñ
- **DateTimePicker.xaml.cs** –> niestandardowy komponent do wyboru daty i godziny
- **BoolToYesNoConverter.cs** -> konwerter true/false na tak/nie

Komunikacja z API odbywa siê za pomoc¹ **ApiClient.cs**, która wysy³a zapytania HTTP do backendu.

Struktura bazy danych:

Tabela Klient: 
Id, Imie,Nazwisko, Nazwa, PESEL, NIP, NrTelefonu, DowodOsobisty 

- Samochod: Id, marka, model, rok, moc, ile osob, typ, czy usuniêty, udogodnienia*
- Klient: Id, Imie, Nazwisko, Nazwa, PESEL, NIP, NrTelefonu, DowodOsobisty
- Wypozyczenie: Id, IdKlient, IdSamochod, DataOd, DataDo, Ilosc, TypIlosci, Stawka, Kwota
- Slownik: Id, SlownikId
### 
## Instalacja i uruchamianie
1. Sklonowanie repozytorium.
2. Baza danych.
3. Uruchomienie backendu: **wypozyczalnia_backend.sln**.
4. Uruchomienie frontendu: **wpf_app.sln**.

## Elementy obiektowoœci
### Dziedziczenie:
Klasy **Samochod**, **Klient**. **Wypozyczenie** dziedzicz¹ po **BaseModel**.
### Hermetyzacja:
Pola klas s¹ prywatne, dostêpne przez metody.
### Polimorfizm:
Klasa **ApiClient** obs³uguje modele **Samochod**, **Klient**, **Wypozyczenie**.
### Interfejsy:
Obs³uga konwersji **BoolToYesNoConverter.cs**.



