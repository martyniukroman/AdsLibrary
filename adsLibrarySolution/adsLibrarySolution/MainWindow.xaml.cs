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
        public MainWindow() {
            InitializeComponent();

        //   this.ShowMessageAsync("Alert", "andriy sosat");

        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e) {
            LoginFlyout.IsOpen = true;
        }

        private void ButtonLoginLast_Click(object sender, RoutedEventArgs e) {
            // yee bash
        }

        private void ButtonLogin_Click_1(object sender, RoutedEventArgs e) {
            // yee bash
        }

        private void ButtonSingUp_Click(object sender, RoutedEventArgs e) {

        }
    }
}
