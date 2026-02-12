using symulacjafirmy.Models;
using System.Collections.ObjectModel;

namespace symulacjafirmy.Services
{
    public class ZadaniaService
    {
        public ObservableCollection<Zadanie> Zadania { get; set; }
            = new ObservableCollection<Zadanie>();

        public void Dodaj(Zadanie zadanie)
        {
            Zadania.Add(zadanie);
        }

        public void Usun(Zadanie zadanie)
        {
            Zadania.Remove(zadanie);
        }
    }
}
