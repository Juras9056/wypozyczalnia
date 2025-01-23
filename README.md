## Wypo�yczalnia samochod�w

Aplikacja wypo�yczalni samochod�w to program umo�liwiaj�cy zarz�dzanie flot� pojazd�w, klientami oraz procesem wypo�ycze�. Aplikacja sk�ada si� z interfejsu u�ytkownika wykonanego z u�yciem silnika **WPF** oraz backendu opartego na **ASP.NET Core** z pod��czeniem do bazy danych **SQL Server**.


**Autorzy**: Karolina Ciszowska, Daniel Jurczyk, Sandra Hyla

## Funkcjonalno�ci
### Zarz�dzanie flot� samochod�w:
- dodawanie i usuwanie samochod�w
- przechowywanie danych (marka, model, paliwo, moc, rocznik, klimatyzacja, nawigacja)
### Zarz�dzanie klientami:
- dodawanie, usuwanie i edytowanie klient�w
- przechowywanie dancych (imi�, nazwisko, PESEL, NIP, telefon)
### Obs�uga wypo�ycze�:
- wyb�r samochodu i klienta
- wyb�r daty wynajmu
- wyliczanie koszt�w wypo�yczenia
### Po��czenie z baz� danych SQL:
- przechowywanie danych w Entity Framework Core
### Interfejs u�ytkownika WPF:
- aplikacja okienkowa z g��wnym oknem wyboru i osobnymi widokami klient�w, samochod�w i wypo�ycze�

## Technologie
- **Frontend:** WPF (C#)
- **Backend:** ASP.NET Core
- **Baza danych:** SQL Server, Entity Framework
- **System kontroli wersji:** GitHub
### Backend (ASP.NET Core):
Aplikacja backendowa diza�a jako REST API i udost�pnia kontrolery:
- **SamochodController.cs** -> zarz�dzenie samochodami (GET/api/Samochod)
- **KlientController.cs** -> zarz�dzanie klientami (GET/api/Klient)
- **WypozyczenieController.cs** -> zarz�dzanie wypo�yczeniami (POST/api/Wypozyczenie)
#### Obs�uga bazy danych:
Wykorzystano Entity Framework Core, kt�ry mapuje modele na tabel� w bazie SQL Server.

### Frontend (WPF)
Interfejs u�ytkownika zosta� utworzony w technologii Windows Presentation Foundation (WPF).
- **MainWindow.xaml** �> ekran g��wny z nawigacj�
- **SamochodyWindow.xaml** �> lista samochod�w, dodawanie i usuwanie
- **KlienciWindow.xaml** �> lista klient�w, dodawanie, usuwanie i edycja
- **WypozyczeniaWindow.xaml** �> panel wypo�ycze�
- **DateTimePicker.xaml.cs** �> niestandardowy komponent do wyboru daty i godziny
- **BoolToYesNoConverter.cs** -> konwerter true/false na tak/nie

Komunikacja z API odbywa si� za pomoc� **ApiClient.cs**, kt�ra wysy�a zapytania HTTP do backendu.

Struktura bazy danych:

Tabela Klient: 
Id, Imie,Nazwisko, Nazwa, PESEL, NIP, NrTelefonu, DowodOsobisty 

- Samochod: Id, marka, model, rok, moc, ile osob, typ, czy usuni�ty, udogodnienia*
- Klient: Id, Imie, Nazwisko, Nazwa, PESEL, NIP, NrTelefonu, DowodOsobisty
- Wypozyczenie: Id, IdKlient, IdSamochod, DataOd, DataDo, Ilosc, TypIlosci, Stawka, Kwota
- Slownik: Id, SlownikId
### 
## Instalacja i uruchamianie
1. Sklonowanie repozytorium.
2. Baza danych.
3. Uruchomienie backendu: **wypozyczalnia_backend.sln**.
4. Uruchomienie frontendu: **wpf_app.sln**.

## Elementy obiektowo�ci
### Dziedziczenie:
Klasy **Samochod**, **Klient**. **Wypozyczenie** dziedzicz� po **BaseModel**.
### Hermetyzacja:
Pola klas s� prywatne, dost�pne przez metody.
### Polimorfizm:
Klasa **ApiClient** obs�uguje modele **Samochod**, **Klient**, **Wypozyczenie**.
### Interfejsy:
Obs�uga konwersji **BoolToYesNoConverter.cs**.



