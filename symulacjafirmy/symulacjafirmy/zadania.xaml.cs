using System.Windows;
using System.Windows.Controls;
using symulacjafirmy.Models;
using symulacjafirmy.Services;

namespace symulacjafirmy
{
    public partial class zadania : Window
    {
        private Zadanie editingZadanie = null;

        public zadania()
        {
            InitializeComponent();
            zadnaniaGrid.ItemsSource = AppData.Zadania;
            OsobaCombo.ItemsSource = AppData.Uzytkownicy;
            if (AppData.Zadania.Count == 0)
            {
                AppData.Zadania.Add(new Zadanie
                {
                    Tytul = "Raport",
                    Opis = "Przygotować raport kwartalny",
                    Osoba = "Jan",
                    Czyzrealizowane = false
                });

                AppData.Zadania.Add(new Zadanie
                {
                    Tytul = "Spotkanie",
                    Opis = "Spotkanie z klientem",
                    Osoba = "Anna",
                    Czyzrealizowane = true
                });
            }
        }
        private void zatwierdzZadanie(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Tytul.Text) &&
                !string.IsNullOrEmpty(Opis.Text) &&
                OsobaCombo.SelectedValue != null)
            {
                if (editingZadanie != null)
                {
                    editingZadanie.Tytul = Tytul.Text;
                    editingZadanie.Opis = Opis.Text;
                    editingZadanie.Osoba = OsobaCombo.SelectedValue.ToString();
                    editingZadanie.Czyzrealizowane = Czyzrealizowane.IsChecked == true;

                    zadnaniaGrid.Items.Refresh();
                    editingZadanie = null;
                }
                else
                {
                    AppData.Zadania.Add(new Zadanie
                    {
                        Tytul = Tytul.Text,
                        Opis = Opis.Text,
                        Osoba = OsobaCombo.SelectedValue.ToString(),
                        Czyzrealizowane = Czyzrealizowane.IsChecked == true
                    });
                }

                Tytul.Text = "";
                Opis.Text = "";
                OsobaCombo.SelectedIndex = -1;
                Czyzrealizowane.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
            }
        }

        private void UsunZadanie(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Zadanie zadanie)
            {
                AppData.Zadania.Remove(zadanie);
            }
        }

        private void EdytujZadanie(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Zadanie zadanie)
            {
                Tytul.Text = zadanie.Tytul;
                Opis.Text = zadanie.Opis;

                OsobaCombo.SelectedValue = zadanie.Osoba;

                Czyzrealizowane.IsChecked = zadanie.Czyzrealizowane;

                editingZadanie = zadanie;
            }
        }
    }
}
