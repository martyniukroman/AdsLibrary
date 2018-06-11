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
using System.Windows.Shapes;
using System.ComponentModel;

namespace adsLibrarySolution {
    /// <summary>
    /// Interaction logic for DeletingWindow.xaml
    /// </summary>
    public partial class DeletingWindow : Window {

       public List<Advert> LocalAdverts = null;
        Client LocalClient = null;

        public DeletingWindow(List<Advert> adverts, Client CurrentUser) {
            InitializeComponent();
            ListViewMain.ItemsSource = LocalAdverts = adverts;
            LocalClient = CurrentUser;

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e) {

            if ((ListViewMain.SelectedItem as Advert).Author.Name == LocalClient.Name) {
                LocalAdverts.RemoveAt(ListViewMain.SelectedIndex);
                ListViewMain.Items.Refresh();
            }
            else {
                MessageBox.Show("eroro");
            }

            
        }
    }
}
