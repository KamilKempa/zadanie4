using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using symulacjafirmy.Models;
using System.Collections.ObjectModel;

namespace symulacjafirmy.Services
{
    public static class AppData
    {
        public static ObservableCollection<Uzytkownik> Uzytkownicy { get; set; }
            = new ObservableCollection<Uzytkownik>();

        public static ObservableCollection<Zadanie> Zadania { get; set; }
            = new ObservableCollection<Zadanie>();
    }
}
