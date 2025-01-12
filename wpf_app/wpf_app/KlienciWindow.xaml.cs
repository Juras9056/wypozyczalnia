using System;
using System.Windows;

namespace wpf_app;

public partial class KlienciWindow : Window
{
    private readonly ApiClient _apiClient;

    public KlienciWindow()
    {
        InitializeComponent();
        _apiClient = new ApiClient();
        LoadKlienci();
    }

    // Wczytanie listy klientów z API
    private async void LoadKlienci()
    {
        try
        {
            var klienci = await _apiClient.GetKlienciAsync();
            KlienciListView.ItemsSource = klienci;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Błąd podczas ładowania klientów: {ex.Message}");
        }
    }

    // Dodanie nowego klienta
    private async void DodajKlienta_Click(object sender, RoutedEventArgs e)
    {
        var nowyKlient = new Klient
        {
            Imie = ImieTextBox.Text,
            Nazwisko = NazwiskoTextBox.Text,
            Nazwa = NazwaTextBox.Text,
            Pesel = TryParsePesel(PESELTextBox.Text),
            NrTelefonu = NrTelefonuTextBox.Text,
            DowodOsobisty = DowodOsobistyTextBox.Text
        };

        try
        {
            await _apiClient.AddKlientAsync(nowyKlient);
            LoadKlienci();
            MessageBox.Show("Dodano nowego klienta.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Błąd podczas dodawania klienta: {ex.Message}");
        }
    }

    // Edycja istniejącego klienta
    private async void EdytujKlienta_Click(object sender, RoutedEventArgs e)
    {
        if (KlienciListView.SelectedItem is not Klient wybranyKlient)
        {
            MessageBox.Show("Nie wybrano klienta do edycji.");
            return;
        }

        wybranyKlient.Imie = ImieTextBox.Text;
        wybranyKlient.Nazwisko = NazwiskoTextBox.Text;
        wybranyKlient.Nazwa = NazwaTextBox.Text;
        wybranyKlient.Pesel = TryParsePesel(PESELTextBox.Text);
        wybranyKlient.NrTelefonu = NrTelefonuTextBox.Text;
        wybranyKlient.DowodOsobisty = DowodOsobistyTextBox.Text;

        try
        {
            await _apiClient.UpdateKlientAsync(wybranyKlient.Id, wybranyKlient);
            LoadKlienci();
            MessageBox.Show("Zaktualizowano dane klienta.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Błąd podczas edytowania klienta: {ex.Message}");
        }
    }

    // Usunięcie klienta
    private async void UsunKlienta_Click(object sender, RoutedEventArgs e)
    {
        if (KlienciListView.SelectedItem is not Klient wybranyKlient)
        {
            MessageBox.Show("Nie wybrano klienta do usunięcia.");
            return;
        }

        try
        {
            await _apiClient.DeleteKlientAsync(wybranyKlient.Id);
            LoadKlienci();
            MessageBox.Show("Usunięto klienta.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Błąd podczas usuwania klienta: {ex.Message}");
        }
    }

    // Metoda pomocnicza do parsowania PESEL
    private long? TryParsePesel(string peselText)
    {
        return long.TryParse(peselText, out var pesel) ? pesel : null;
    }
}
