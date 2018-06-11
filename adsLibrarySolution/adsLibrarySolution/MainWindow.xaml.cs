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
using System.Xml;
using System.Xml.Serialization;
using System.IO;
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
            //this.ShowMessageAsync("Alert", "andriy sosat"); // нахуй іди
            string ClientListPath = System.IO.Path.Combine(Environment.CurrentDirectory, "ClientsList.xml");
            string AdvertListPath = System.IO.Path.Combine(Environment.CurrentDirectory, "AdvertsList.xml");
            XmlSerializer sClients = new XmlSerializer(typeof(List<Client>));
            XmlSerializer sAdverts = new XmlSerializer(typeof(List<Advert>));
            using (StreamReader sr = new StreamReader(ClientListPath))
            {
                Clients = (sClients.Deserialize(sr)) as List<Client>;
            }
            using (StreamReader sr = new StreamReader(AdvertListPath))
            {
                Adverts = (sAdverts.Deserialize(sr)) as List<Advert>;
            }
            if (Clients.Count != 0)
            {
                LabelLastUserName.Content = Clients.Last().Name;
                LabelLastUserMail.Content = Clients.Last().Email;
            }
            ListViewMain.ItemsSource = Adverts;
    

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
                        LabelUntilLogin.Content = "";
                        TextBoxLoginMail.Text = "";
                        TextBoxLoginPass.Text = "";
                        CurrentUser = LoginClient;
                        LabelLastUserName.Content = CurrentUser.Name;
                        LabelLastUserMail.Content = CurrentUser.Email;
                        this.Title = CurrentUser.Name;
                        //foreach (Advert Ad in Adverts)                                                            //looking for logged user adverts in list of adverts
                        //{
                        //    if (Ad.Author.ID == LoginClient.ID)
                        //    {
                        //        if (Adverts != null)
                        //        {
                        //            ListViewMain.Items.Clear();
                        //        }
                        //        Adverts.Add(Ad);                     //adding logged on user ads to ListView
                        //    }
                        //}
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

        private async void MenuAddAdvert_Click(object sender, RoutedEventArgs e) {
            if (CurrentUser == null) {
                await this.ShowMessageAsync("Alert", "There is no active sessions, login to continue");
                LoginFlyout.IsOpen = true;
                return;
            }
            else {
                AddingWindow addingWindow = new AddingWindow();
                if (addingWindow.ShowDialog() == true) {
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

        private async void MenuDeleteAdvert_Click(object sender, RoutedEventArgs e) {
            if (CurrentUser == null) {
                await this.ShowMessageAsync("Alert", "There is no active sessions, login to continue");
                LoginFlyout.IsOpen = true;
                return;
            }
            else {
                DeletingWindow del = new DeletingWindow(Adverts, CurrentUser);
                del.ShowDialog();
                this.Adverts = del.LocalAdverts;
                ListViewMain.Items.Refresh();
            }
        }

        private async void ButtonLoginLast_Click(object sender, RoutedEventArgs e) {
            //   MessageBox.Show("suck");
            if (Clients.Last().Password == TextBoxLoginPassLast.Text) {
                CurrentUser = Clients.Last();
                this.Title = CurrentUser.Name;
                LabelUntilLogin.Content = "";
            }
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            string ClientListPath = System.IO.Path.Combine(Environment.CurrentDirectory, "ClientsList.xml");
            string AdvertListPath = System.IO.Path.Combine(Environment.CurrentDirectory, "AdvertsList.xml");
            XmlSerializer sClients = new XmlSerializer(typeof(List<Client>));
            XmlSerializer sAdverts = new XmlSerializer(typeof(List<Advert>));
            if(Clients!=null)
            {
                using (StreamWriter sw = new StreamWriter(ClientListPath))
                {
                    sClients.Serialize(sw, Clients);
                }
            }
            if(Adverts!=null)
            {
                using (StreamWriter sw = new StreamWriter(AdvertListPath))
                {
                    sAdverts.Serialize(sw, Adverts);
                }
            }

        }
    }
}
