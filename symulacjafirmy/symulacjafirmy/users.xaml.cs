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

namespace symulacjafirmy
{
    /// <summary>
    /// Logika interakcji dla klasy users.xaml
    /// </summary>
    public class User
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int RokUrodzenia { get; set; }
    }
    public partial class users : Window
    {
        private ObservableCollection<User> usersList = new ObservableCollection<User>();
        private User editingUser = null;
        public users()
        {
            InitializeComponent();
            uzytkownicyGrid.ItemsSource = usersList;
            usersList.Add(new User { Imie = "Jan", Nazwisko = "Kowalski", RokUrodzenia = 2003 });
            usersList.Add(new User { Imie = "Anna", Nazwisko = "Kowalska", RokUrodzenia = 2002 });
            usersList.Add(new User { Imie = "ROOT", Nazwisko = "ROOT", RokUrodzenia = 0001 });
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
                    usersList.Add(new User
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
            if (sender is Button btn && btn.Tag is User user)
            {
                usersList.Remove(user);
            }
        }

        private void EdytujUzytkownika(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is User user)
            {
                imie.Text = user.Imie;
                nazwisko.Text = user.Nazwisko;
                rokurodzenia.Text = user.RokUrodzenia.ToString();

                editingUser = user; 
            }
        }
    }
}