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
                    Paliwo = int.Parse(PaliwoTextBox.Text), // Oczekuje wartości int
                    MocKm = int.Parse(MocKmTextBox.Text),
                    RokProdukcji = int.Parse(RokProdukcjiTextBox.Text),
                    IloscOsob = int.Parse(IloscOsobTextBox.Text),
                    Klimatyzacja = KlimatyzacjaCheckBox.IsChecked ?? false,
                    Nawigacja = NawigacjaCheckBox.IsChecked ?? false,
                    CzujnikiParowania = CzujnikiCheckBox.IsChecked ?? false,
                    CzyDostepny = true
                };

    

                // Wyślij żądanie POST do API
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
                // Weryfikacja, czy wybrano samochód
                if (SamochodyComboBox.Items.Count == 0)
                {
                    MessageBox.Show("Nie ma samochodów do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var wybranySamochod = SamochodyComboBox.SelectedItem as Samochod;
                if (wybranySamochod == null)
                {
                    MessageBox.Show("Proszę wybrać samochód do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Potwierdzenie usunięcia
                var wynik = MessageBox.Show($"Czy na pewno chcesz usunąć samochód {wybranySamochod.Marka} {wybranySamochod.Model}?",
                    "Potwierdzenie usunięcia",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (wynik != MessageBoxResult.Yes)
                {
                    return; // Użytkownik anulował
                }

                // Usunięcie samochodu przez API
                await _apiClient.DeleteSamochodAsync(wybranySamochod.Id);

                // Odświeżenie listy samochodów
                LoadSamochody();

                MessageBox.Show("Samochód został usunięty.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Wyświetlenie szczegółowego komunikatu o błędzie
                MessageBox.Show($"Błąd podczas usuwania samochodu: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
