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
           // this.Title = CurrentUser.Name;

            //  Clients.Add(Yalovenko);

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
                        this.ShowMessageAsync("Notification", "Login successfull.");
                        TextBoxLoginMail.Text = "";
                        TextBoxLoginPass.Text = "";
                        CurrentUser = LoginClient;
                        LabelLastUserName.Content = CurrentUser.Name;
                        LabelLastUserMail.Content = CurrentUser.Email;
                        LabelUntilLogin.Content = null;
                        this.Title = CurrentUser.Name;
                        foreach (Advert Ad in Adverts)                                                            //looking for logged user adverts in list of adverts
                        {
                            if (Ad.Author.ID == LoginClient.ID)
                            {
                                if (Adverts != null)
                                {
                                    ListViewMain.Items.Clear();
                                }
                                Adverts.Add(Ad);                     //adding logged on user ads to ListView
                            }
                        }
                    }
                }
            }
            else if (TextBoxLoginMail.Text == "")
            {
                this.ShowMessageAsync("Alert", "Please input your e-mail.");
            }
            else if (TextBoxLoginPass.Text == "")
            {
                this.ShowMessageAsync("Alert", "Please input your password.");
            }
            else
            {
                this.ShowMessageAsync("Alert", "Please input your e-mail and password.");
            }
            if (ClientFound == false)
            {
                this.ShowMessageAsync("Alert", "User with such email does not exist");
            }
        }

        private void ButtonSingUp_Click(object sender, RoutedEventArgs e)
        {

            if (TextBoxSingMail.Text != "" && TextBoxSingName.Text != "" && TextBoxSingPass.Text != "") //checking if all fields have data
            {
                Client TempClient = new Client();                              //creating temp user
                TempClient.ID = ++IDgenerator;
                TempClient.Email = TextBoxSingMail.Text;                       //  -----------------------
                TempClient.Password = TextBoxSingPass.Text;                    //    copying data from text boxes
                TempClient.Name = TextBoxSingName.Text;                        //  -----------------------
                TextBoxSingName.Text = "";                                     //  -----------------------
                TextBoxSingPass.Text = "";                                     //      clearing textboxes
                TextBoxSingMail.Text = "";                                     //  -----------------------
                Clients.Add(TempClient);                                       //adding client lo list of clients
                CurrentUser = TempClient;
                LabelUntilLogin.Content = "";
                this.ShowMessageAsync("Notification", "Sign up successfull");
            }
            else
            {
                this.ShowMessageAsync("Alert", "All fields must be filled!");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            LoginFlyout.IsOpen = true;
        }

        private void MenuAddAdvert_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                this.Title = CurrentUser.Name;
                this.ShowMessageAsync("Alert", "There is no active sessions, login to continue");
                return;
            }
            else
            {
                AddingWindow addingWindow = new AddingWindow();
                if(addingWindow.ShowDialog() == true)
                {
                    Advert NewAdvert = new Advert();
                    NewAdvert.AdvertImageSource = addingWindow.TextBoxImageSource.Text;
                    NewAdvert.Author = CurrentUser;
                    NewAdvert.Header = addingWindow.TextBoxTitle.Text;
                    NewAdvert.ID = ++IDgenerator;
                    NewAdvert.Information = addingWindow.TextBoxImageAdditional.Text;
                    Adverts.Add(NewAdvert);
                    ListViewMain.Items.Refresh();
                }
            }

        }

        private void MenuDeleteAdvert_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                this.Title = CurrentUser.Name;
                this.ShowMessageAsync("Alert", "There is no active sessions, login to continue");
                return;
            }
            else
            {

            }
        }

        private void ButtonLoginLast_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
