using System;
using System.Windows;
using System.Collections.Generic;

namespace wpf_app
{
    public partial class SamochodyWindow : Window
    {
        private readonly ApiClient _apiClient;

        public SamochodyWindow()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
            LoadSamochody();
        }

        private async void LoadSamochody()
        {
            try
            {
                // Pobierz samochody z API
                var samochody = await _apiClient.GetSamochodyAsync();

                // Przypisz dane do ListBox
                SamochodyListBox.ItemsSource = samochody;

                // Przypisz dane do ComboBox
                SamochodyComboBox.ItemsSource = samochody;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania samochodów: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private async void DodajSamochod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nowySamochod = new Samochod
                {
                    Marka = MarkaTextBox.Text,
                    Model = ModelTextBox.Text,
                    Paliwo = int.TryParse(PaliwoTextBox.Text, out var paliwo) ? paliwo : 0, // Poprawna konwersja string -> int
                    RokProdukcji = int.TryParse(RokProdukcjiTextBox.Text, out var rok) ? rok : 0,
                    MocKm = int.TryParse(MocKmTextBox.Text, out var moc) ? moc : 0,
                    IloscOsob = int.TryParse(IloscOsobTextBox.Text, out var ilosc) ? ilosc : 0,
                    Klimatyzacja = KlimatyzacjaCheckBox.IsChecked ?? false,
                    Nawigacja = NawigacjaCheckBox.IsChecked ?? false,
                    CzujnikiParowania = CzujnikiCheckBox.IsChecked ?? false,
                    CzyDostepny = true
                };

                await _apiClient.AddSamochodAsync(nowySamochod);
                LoadSamochody();
                MessageBox.Show("Dodano nowy samochód.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas dodawania samochodu: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private async void UsunSamochod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var wybranySamochod = SamochodyComboBox.SelectedItem as Samochod;
                if (wybranySamochod != null)
                {
                    await _apiClient.DeleteSamochodAsync(wybranySamochod.Id);
                    LoadSamochody();
                    MessageBox.Show("Samochód został usunięty.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Proszę wybrać samochód do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas usuwania samochodu: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
