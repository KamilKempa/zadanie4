using System.Windows;
using System.Windows.Controls;
using symulacjafirmy.Models;
using symulacjafirmy.Services;

namespace symulacjafirmy
{
    public partial class users : Window
    {
        private Uzytkownik editingUser = null;

        public users()
        {
            InitializeComponent();
            uzytkownicyGrid.ItemsSource = AppData.Uzytkownicy;
            if (AppData.Uzytkownicy.Count == 0)
            {
                AppData.Uzytkownicy.Add(new Uzytkownik
                {
                    Imie = "Jan",
                    Nazwisko = "Kowalski",
                    RokUrodzenia = 2003
                });

                AppData.Uzytkownicy.Add(new Uzytkownik
                {
                    Imie = "Anna",
                    Nazwisko = "Kowalska",
                    RokUrodzenia = 2002
                });

                AppData.Uzytkownicy.Add(new Uzytkownik
                {
                    Imie = "ROOT",
                    Nazwisko = "ROOT",
                    RokUrodzenia = 1
                });
            }
        }

        private void zatwierdzuzytkownik(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(imie.Text) &&
                !string.IsNullOrEmpty(nazwisko.Text) &&
                int.TryParse(rokurodzenia.Text, out int rok))
            {
                if (editingUser != null)
                {
                    editingUser.Imie = imie.Text;
                    editingUser.Nazwisko = nazwisko.Text;
                    editingUser.RokUrodzenia = rok;

                    uzytkownicyGrid.Items.Refresh();
                    editingUser = null;
                }
                else
                {
                    AppData.Uzytkownicy.Add(new Uzytkownik
                    {
                        Imie = imie.Text,
                        Nazwisko = nazwisko.Text,
                        RokUrodzenia = rok
                    });
                }

                imie.Text = "";
                nazwisko.Text = "";
                rokurodzenia.Text = "";
            }
            else
            {
                MessageBox.Show("Wypełnij poprawnie wszystkie pola!");
            }
        }

        private void UsunUzytkownika(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Uzytkownik user)
            {
                AppData.Uzytkownicy.Remove(user);
            }
        }

        private void EdytujUzytkownika(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Uzytkownik user)
            {
                imie.Text = user.Imie;
                nazwisko.Text = user.Nazwisko;
                rokurodzenia.Text = user.RokUrodzenia.ToString();

                editingUser = user;
            }
        }
    }
}
