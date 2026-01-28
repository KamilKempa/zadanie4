using symulacjafirmy.Models;
using System.Collections.ObjectModel;

namespace symulacjafirmy.Services
{
    public class UsersService
    {
        public ObservableCollection<Uzytkownik> Uzytkownicy { get; set; }
            = new ObservableCollection<Uzytkownik>();

        public void Dodaj(Uzytkownik user)
        {
            Uzytkownicy.Add(user);
        }

        public void Usun(Uzytkownik user)
        {
            Uzytkownicy.Remove(user);
        }
    }
}
