using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace adsLibrarySolution {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow {

        List<Client> Clients = new List<Client>();
        List<Advert> Adverts = new List<Advert>();
        public Client CurrentUser = null;

        public MainWindow() {
            InitializeComponent();
           // LoginFlyout.IsOpen = true;
            //   this.ShowMessageAsync("Alert", "andriy sosat");

            Client Yalovenko = new Client() { Name = "Yalovenko Vitaliy", Email = "nerevit17@gmail.com", Password = "admin" };

            CurrentUser = Yalovenko;

            Clients.Add(Yalovenko);

        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e) {
            // yee bash
        }

        private void ButtonLoginLast_Click(object sender, RoutedEventArgs e) {
            // yee bash
        }

        private void ButtonSingUp_Click(object sender, RoutedEventArgs e) {
            // yee bash
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            LoginFlyout.IsOpen = true;

            LabelLastUserName.Content = CurrentUser.Name;
            LabelLastUserMail.Content = CurrentUser.Email;

        }
    }
}
