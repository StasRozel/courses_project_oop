using lab4_5.ViewModel;
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

namespace lab4_5.Pages
{
    /// <summary>
    /// Логика взаимодействия для StatusTickets.xaml
    /// </summary>
    public partial class StatusTickets : Page
    {

        public StatusTickets(PurchasedTicketViewModel purchasedTicket)
        {
            InitializeComponent();
            DataContext = purchasedTicket;
        }

       
    }
}
