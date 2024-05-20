using lab4_5.Pages;
using lab4_5.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

namespace lab4_5.View
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public UserViewModel User { get; set; }    
        public PurchasedTicketViewModel PurchaseTickets { get; set; }    
        public ClientWindow()
        {
            InitializeComponent();
            DataContext = new UserViewModel();
            User = (UserViewModel)DataContext;
            PurchaseTickets = new PurchasedTicketViewModel();
            MainFrame.Navigate(new Home(PurchaseTickets));
            PurchaseTickets.StartTimer();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Home(PurchaseTickets));
        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StatusTickets(PurchaseTickets));
        }

        private void Schulde_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Schulde(PurchaseTickets));
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            Uri imageUri = new Uri("pack://application:,,,/Resources/img/background_account.png", UriKind.Absolute);
            //BackgroundImg.ImageSource = imageUri;
            MainFrame.Navigate(new Account(User));
        }
    }
}
