using System;
using System.Collections.Generic;
using System.IO;
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

namespace lab4_5
{
    /// <summary>
    /// Логика взаимодействия для ChangeTicket.xaml
    /// </summary>
    public partial class ChangeTicket : Window
    {

        public ChangeTicket()
        {
            InitializeComponent();
            this.DataContext = AdminPanel.ViewModel;
        }

        private void SaveChange_Click(object sender, RoutedEventArgs e)
        {
            ButtonChange.CommandParameter = $"{AdminPanel.ViewModel.SelectedTicket.Id},{ChangeNameWay.Text},{ChangeDescription.Text},{ChangeNumberTrain.Text},{ChangePrice.Text},{TicketTimePicker.Text},{Train.IsChecked}";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ButtonDelete.CommandParameter = AdminPanel.ViewModel.SelectedTicket.Id;
        }

    }
}
