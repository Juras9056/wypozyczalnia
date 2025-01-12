INSERT INTO Samochod (Id, Marka, Model, Paliwo, MocKm, RokProdukcji, IloscOsob, Typ, Klimatyzacja, Nawigacja, CzujnikiParowania, CzyDostepny)
VALUES 
(1, 'Volkswagen', 'Golf', 1, 150, 2020, 5, 1, 1, 1, 0, 1),
(2, 'Audi', 'A4', 2, 190, 2021, 5, 2, 1, 1, 1, 0),
(3, 'BMW', 'X5', 1, 245, 2019, 7, 3, 1, 1, 0, 1),
(4, 'Toyota', 'Corolla', 2, 132, 2022, 5, 1, 0, 0, 0, 1),
(5, 'Ford', 'Focus', 1, 120, 2018, 5, 1, 1, 0, 1, 1),
(6, 'Mercedes', 'C-Class', 2, 211, 2020, 5, 2, 1, 1, 1, 0),
(7, 'Peugeot', '308', 1, 130, 2021, 5, 1, 1, 0, 0, 1),
(8, 'Renault', 'Clio', 2, 100, 2023, 5, 1, 0, 0, 0, 1),
(9, 'Kia', 'Ceed', 1, 140, 2019, 5, 1, 1, 1, 1, 0),
(10, 'Honda', 'Civic', 2, 180, 2021, 5, 2, 1, 0, 1, 1);

-- Rekordy dla osób fizycznych
INSERT INTO Klient (Id, Imie, Nazwisko, Nazwa, PESEL, NIP, NrTelefonu, DowodOsobisty)
VALUES
(1, 'Jan', 'Kowalski', NULL, 12345678901, NULL, '123-456-789', 'AB1234567'),
(2, 'Anna', 'Nowak', NULL, 98765432123, NULL, '987-654-321', 'CD9876543'),
(6, 'Piotr', 'Zieliñski', NULL, 12312312345, NULL, '555-123-456', 'EF1234567'),
(7, 'Maria', 'Wiœniewska', NULL, 65432198765, NULL, '600-800-900', 'GH9876543'),
(10, 'Krzysztof', 'Lewandowski', NULL, 11223344556, NULL, '501-234-567', 'IJ1122334');

-- Rekordy dla firm
INSERT INTO Klient (Id, Imie, Nazwisko, Nazwa, PESEL, NIP, NrTelefonu, DowodOsobisty)
VALUES
(3, NULL, NULL, 'Firma ABC', NULL, 1234567890, '123-456-789', 'AB1234567'),
(4, NULL, NULL, 'XYZ Sp. z o.o.', NULL, 9876543210, '987-654-321', 'CD9876543'),
(5, NULL, NULL, 'TechSolutions', NULL, 1122334455, '555-789-012', 'EF1234567'),
(9, NULL, NULL, 'MegaIndustries', NULL, 6677889900, '600-999-888', 'GH9876543'),
(8, NULL, NULL, 'GreenEnergy', NULL, 4433221100, '501-567-890', 'IJ1122334');

INSERT INTO Wypozyczenie (Id, IdKlient, IdSamochod, DataOd, DataDo, Ilosc, TypIlosci, Stawka, Kwota)
VALUES
(1, 1, 3, '2024-01-15 09:00:00', '2024-01-15 18:00:00', 8, 2, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '20z³/h'), 160.00),
(2, 2, 5, '2024-02-10 08:00:00', '2024-02-10 16:00:00', 8, 2, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '30z³/h'), 240.00),
(3, 3, 7, '2024-03-03 10:00:00', '2024-03-03 18:00:00', 8, 2, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '20z³/h'), 160.00),
(4, 4, 8, '2024-04-20 12:00:00', '2024-04-20 20:00:00', 8, 2, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '30z³/h'), 240.00),
(5, 5, 2, '2024-05-15 07:00:00', '2024-05-15 15:00:00', 8, 2, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '100z³/dzieñ'), 800.00),
(6, 6, 9, '2024-06-10 09:00:00', '2024-06-10 17:00:00', 8, 2, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '20z³/h'), 160.00),
(7, 7, 6, '2024-07-05 08:00:00', '2024-07-05 16:00:00', 8, 2, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '30z³/h'), 240.00),
(8, 8, 10, '2024-08-21 09:00:00', '2024-08-21 17:00:00', 8, 2, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '180z³/dzieñ'), 1440.00),
(9, 9, 1, '2024-09-13 10:00:00', '2024-09-13 18:00:00', 8, 2, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '150z³/dzieñ'), 1200.00),
(10, 10, 4, '2024-10-25 11:00:00', '2024-10-25 19:00:00', 8, 2, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '100z³/dzieñ'), 800.00),
(11, 1, 2, '2024-01-05 10:00:00', '2024-01-05 15:00:00', 5, 1, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '100z³/dzieñ'), 500.00),
(12, 3, 6, '2024-03-18 09:00:00', '2024-03-18 16:00:00', 7, 1, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '150z³/dzieñ'), 1050.00),
(13, 5, 8, '2024-05-30 14:00:00', '2024-05-30 22:00:00', 8, 2, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '20z³/h'), 160.00),
(14, 7, 3, '2024-07-02 13:00:00', '2024-07-02 21:00:00', 8, 2, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '30z³/h'), 240.00),
(15, 9, 10, '2024-09-01 08:00:00', '2024-09-01 16:00:00', 8, 2, (SELECT Id FROM Slownik WHERE SlownikId = 4 AND Wartosc = '100z³/dzieñ'), 800.00);


INSERT INTO Slownik (Id, SlownikId, Wartosc)
VALUES
(1, 1, 'sedan'),            -- TypSamochodu
(2, 1, 'kombi'),            -- TypSamochodu
(3, 1, 'hatchback'),        -- TypSamochodu
(4, 1, 'bus'),              -- TypSamochodu
(5, 2, 'benzyna'),          -- Paliwo
(6, 2, 'diesel'),           -- Paliwo
(7, 2, 'benzyna+lpg'),      -- Paliwo
(8, 2, 'hybryda'),          -- Paliwo
(9, 2, 'elektryczny'),      -- Paliwo
(10, 3, 'dni'),             -- TypIlosci
(11, 3, 'godziny'),         -- TypIlosci
(12, 4, '20z³/h'),          -- Stawka
(13, 4, '30z³/h'),          -- Stawka
(14, 4, '100z³/dzieñ'),     -- Stawka
(15, 4, '150z³/dzieñ'),     -- Stawka
(16, 4, '180z³/dzieñ');     -- Stawka