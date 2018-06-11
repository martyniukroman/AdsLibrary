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

namespace adsLibrarySolution
{
    /// <summary>
    /// Interaction logic for AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        public AddingWindow()
        {
            InitializeComponent();
        }

        private void ButtonReturn_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxImageAdditional.Text != "" && TextBoxTitle.Text != "" && TextBoxImageSource.Text != "")
            {
                DialogResult = true;
                this.Close();
            }
        }

        private void TextBoxImageAdditional_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxImageSource_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
