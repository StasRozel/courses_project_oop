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

namespace lab4_5
{
    /// <summary>
    /// Логика взаимодействия для AddTicket.xaml
    /// </summary>
    public partial class AddTicket : Window
    {
        public AddTicket()
        {
            InitializeComponent();
            DataContext = MainWindow.ViewModel;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ButtonAdd.CommandParameter = $"{AddNameWay.Text},{AddDescription.Text},{AddNumberTrain.Text},{AddPrice.Text},{TicketTimePicker.Text},{Train.IsChecked}"; 
        }

        //private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    ButtonAdd.CommandParameter = $"{MainWindow.ViewModel.SelectedTicket.Id}, {AddNameWay.Text}, {AddDescription.Text}, {AddNumberTrain.Text}, {AddPrice.Text}, {TicketTimePicker.Text}"; ;
        //}
    }
}
