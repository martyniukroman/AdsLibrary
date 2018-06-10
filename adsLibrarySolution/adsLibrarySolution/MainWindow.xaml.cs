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

namespace adsLibrarySolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {

        List<Client> Clients = new List<Client>();
        List<Advert> Adverts = new List<Advert>();
        public Client CurrentUser = null;
        public int IDgenerator = 1;
        public MainWindow()
        {
            InitializeComponent();
            // LoginFlyout.IsOpen = true;
            //   this.ShowMessageAsync("Alert", "andriy sosat"); // нахуй іди

            ListViewMain.ItemsSource = Adverts;

            Client Yalovenko = new Client() { Name = "Yalovenko Vitaliy", Email = "nerevit17@gmail.com", Password = "admin" };
            Yalovenko.ID = IDgenerator;
            CurrentUser = Yalovenko;

            Clients.Add(Yalovenko);

        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            bool ClientFound = false;
            if (TextBoxLoginMail.Text != "" && TextBoxLoginPass.Text != "")           //checking if all fields have data
            {
                foreach (Client LoginClient in Clients)                                //looking for logged clients in list of clients
                {
                    if (LoginClient.Email == TextBoxLoginMail.Text && LoginClient.Password == TextBoxLoginPass.Text)    //checking if login textboxes are filled
                    {
                        ClientFound = true;
                        MessageBox.Show("Logon successfull!");
                        foreach (Advert Ad in Adverts)                                                            //looking for logged user adverts in list of adverts
                        {
                            if (Ad.Author.ID == LoginClient.ID)
                            {
                                if (Adverts != null)
                                {
                                    ListViewMain.Items.Add(Ad);                              //adding logged on  user ads to ListView
                                }

                            }
                        }
                    }
                }
            }
            else if (TextBoxLoginMail.Text == "")
            {
                MessageBox.Show("Please input your e-mail.");
            }
            else if (TextBoxLoginPass.Text == "")
            {
                MessageBox.Show("Please input your password.");
            }
            else
            {
                MessageBox.Show("Please input your e-mail and password.");
            }
            if (ClientFound == false)
            {
                MessageBox.Show("User with such email does not exist");
            }
        }

        private void ButtonSingUp_Click(object sender, RoutedEventArgs e)
        {

            if (TextBoxSingMail.Text != "" && TextBoxSingName.Text != "" && TextBoxSingPass.Text != "") //checking if all fields have data
            {
                Client TempClient = new Client();                              //creating temp user
                IDgenerator++;
                TempClient.ID = IDgenerator;
                TempClient.Email = TextBoxSingMail.Text;                       //  -----------------------
                TempClient.Password = TextBoxSingPass.Text;                    //    copying data from text boxes
                TempClient.Name = TextBoxSingName.Text;                        //  -----------------------
                TextBoxSingName.Text = "";                                     //  -----------------------
                TextBoxSingPass.Text = "";                                     //      clearing textboxes
                TextBoxSingMail.Text = "";                                     //  -----------------------
                Clients.Add(TempClient);                                       //adding client lo list of clients
                MessageBox.Show("Sign up successfull");
            }
            else
            {
                MessageBox.Show("All fields must be filled!");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            LoginFlyout.IsOpen = true;

            LabelLastUserName.Content = CurrentUser.Name;
            LabelLastUserMail.Content = CurrentUser.Email;

        }
    }
}
