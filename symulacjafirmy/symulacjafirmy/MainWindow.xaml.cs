using System.Linq;
using System.Windows;
using symulacjafirmy.Services;

namespace symulacjafirmy
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OdswiezDashboard();
        }

        private void OdswiezDashboard()
        {
            DashboardGrid.ItemsSource = AppData.Zadania
                .Where(z => z.Czyzrealizowane == false)
                .ToList();
        }

        private void uzytkownicy(object sender, RoutedEventArgs e)
        {
            users u = new users();
            u.ShowDialog();

            OdswiezDashboard();
        }

        private void zadania(object sender, RoutedEventArgs e)
        {
            zadania z = new zadania();
            z.ShowDialog();

            OdswiezDashboard();
        }
    }
}
