using System;
using System.Collections.Generic;
using System.Windows;

namespace wpf_app
{
    public partial class WypozyczeniaWindow : Window
    {
        private readonly ApiClient _apiClient;

        public WypozyczeniaWindow()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
            LoadWypozyczenia();
        }

        private async void LoadWypozyczenia()
        {
            try
            {
                var wypozyczenia = await _apiClient.GetWypozyczeniaAsync();
                WypozyczeniaListView.ItemsSource = wypozyczenia;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania wypożyczeń: {ex.Message}");
            }
        }

        private async void DodajWypozyczenie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(IdKlientTextBox.Text, out var idKlient) ||
                    !int.TryParse(IdSamochodTextBox.Text, out var idSamochod) ||
                    !int.TryParse(IloscTextBox.Text, out var ilosc) ||
                    !decimal.TryParse(StawkaTextBox.Text, out var stawka) ||
                    !decimal.TryParse(KwotaTextBox.Text, out var kwota) ||
                    string.IsNullOrWhiteSpace(TypIlosciTextBox.Text))
                {
                    MessageBox.Show("Uzupełnij poprawnie wszystkie pola.");
                    return;
                }

                var wypozyczenie = new Wypozyczenie
                {
                    IdKlient = idKlient,
                    IdSamochod = idSamochod,
                    DataOd = DataOdDatePicker.SelectedDate ?? DateTime.Now,
                    DataDo = DataDoDatePicker.SelectedDate ?? DateTime.Now,
                    Ilosc = ilosc,
                    TypIlosci = TypIlosciTextBox.Text,
                    Stawka = stawka,
                    Kwota = kwota
                };

                await _apiClient.AddWypozyczenieAsync(wypozyczenie);
                LoadWypozyczenia();
                MessageBox.Show("Dodano wypożyczenie.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas dodawania wypożyczenia: {ex.Message}");
            }
        }

        private async void UsunWypozyczenie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WypozyczeniaListView.SelectedItem is not Wypozyczenie selected)
                {
                    MessageBox.Show("Wybierz wypożyczenie do usunięcia.");
                    return;
                }

                await _apiClient.DeleteWypozyczenieAsync(selected.Id);
                LoadWypozyczenia();
                MessageBox.Show("Usunięto wypożyczenie.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas usuwania wypożyczenia: {ex.Message}");
            }
        }
    }
}
