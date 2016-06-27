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
using MySql.Data.MySqlClient;
using HotelMenagement.otherWindows;

namespace HotelMenagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // zmienne o zasięgu globalnym
        string login;
        string password;


        // kliknięcia w menu górne
        private void MenuItemAutor_Click(object sender, RoutedEventArgs e)
        {
            aboutAutorWindow aboutAutor = new aboutAutorWindow();
            aboutAutor.Topmost = true;
            aboutAutor.ResizeMode = ResizeMode.NoResize;
            aboutAutor.Show();            

            //// tak się twrzy nowe okno w kodzie
            //var windowAboutAutor = new Window();
            //windowAboutAutor.Width = 600;
            //windowAboutAutor.Height = 600;
            //// nadawanie władnego koloru tła, dwie metody
            //windowAboutAutor.Background = Brushes.White;
            //windowAboutAutor.Background = new SolidColorBrush(Color.FromArgb(100, 255, 247, 231));
            //windowAboutAutor.Show(); // works
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            login = txtLogin.Text;
            password = BoxPassword.Password;
            baseConnection connectToDB = new baseConnection();

            if (connectToDB.OpenConnection(login, password))
            {
                tabContStart.IsEnabled = true;
                tabContStart.Visibility = Visibility.Visible;
                txtLogin.IsEnabled = false;
                BoxPassword.IsEnabled = false;
                btnButtonSign.IsEnabled = false;
                nameUserLogOut.Content = login;
                btnLogOut.IsEnabled = true;
                bottomActiveUser.Content = login;
            }
            else
            {
                txtLogin.Text = "";
                BoxPassword.Password = "";
                MessageBox.Show("Brak połączenia z bazą danych. Twój login lub hasło są niepoprawne. Spróbuj ponownie.");
            }

            //Button button12 = new Button();
            //button12.Width = 100;
            //button12.Height = 200;
            //button12.Content = "Pocałuj mnie w dupe";
            //// tak dynamicznie dodaje się kontrolki do kodu
            //ContentBuckground.Children.Add(button12);
        }

        // wylogowanie z aplikacji
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            tabContStart.IsEnabled = false;
            tabContStart.Visibility = Visibility.Hidden;
            txtLogin.IsEnabled = true;
            BoxPassword.IsEnabled = true;
            btnButtonSign.IsEnabled = true;
            nameUserLogOut.Content = "";
            btnLogOut.IsEnabled = false;
            bottomActiveUser.Content = "";
            txtLogin.Text = "";
            BoxPassword.Password = "";
        }

        private void btnAddReservation_Click(object sender, RoutedEventArgs e)
        {
            addReservation reservationWindow = new addReservation();
            reservationWindow.Show();
        }
    }
}
