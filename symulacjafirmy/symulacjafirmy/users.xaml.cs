using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using symulacjafirmy.Models;
using symulacjafirmy.Services;

namespace symulacjafirmy
{
    /// <summary>
    /// Logika interakcji dla klasy users.xaml
    /// </summary>
  
    public partial class users : Window
    {
        private UsersService service = new UsersService();
        private Uzytkownik editingUser = null;
    
        public users()
        {
            InitializeComponent();
            uzytkownicyGrid.ItemsSource = service.Uzytkownicy;
            service.Dodaj(new Uzytkownik { Imie = "Jan", Nazwisko = "Kowalski", RokUrodzenia = 2003 });
            service.Dodaj(new Uzytkownik { Imie = "Anna", Nazwisko = "Kowalska", RokUrodzenia = 2002 });
            service.Dodaj(new Uzytkownik { Imie = "ROOT", Nazwisko = "ROOT", RokUrodzenia = 1 });
            ;
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
                    service.Dodaj(new Uzytkownik
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
                MessageBox.Show("wypelnij poprawnie wszystkie pola");
            }
        }

        private void UsunUzytkownika(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Uzytkownik user)
            {
                service.Usun(user);
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