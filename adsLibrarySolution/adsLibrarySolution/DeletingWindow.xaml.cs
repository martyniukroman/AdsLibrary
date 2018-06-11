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

namespace adsLibrarySolution {
    /// <summary>
    /// Interaction logic for DeletingWindow.xaml
    /// </summary>
    public partial class DeletingWindow : Window {
        public DeletingWindow(List<Advert> adverts,Client CurrentUser) {
            InitializeComponent();
           
        }
    }
}
