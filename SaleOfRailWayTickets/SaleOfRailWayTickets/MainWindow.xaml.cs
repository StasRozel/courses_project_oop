
using lab4_5.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
/*aboba*/
using System.Collections.ObjectModel;

namespace lab4_5
{
    public partial class MainWindow : Window
    {
        public static TicketsViewModel ViewModel { get; set; }
        public UndoRedoManager _UndoRedoManager { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new TicketsViewModel();
            ViewModel = (TicketsViewModel)DataContext;
            var lstNames = new List<string>() { "Harry", "Brandin" };
            _UndoRedoManager = new UndoRedoManager(new ObservableCollection<string>(lstNames));
            //App.LanguageChanged += LanguageChanged;

            MessageBox.Show(_UndoRedoManager.ToString());
        }

        private void LanguageChange_Click(Object sender, RoutedEventArgs e)
        {
            App.LanguageChange(lab4_5.Properties.Settings.Default.DefaultLanguage);

        }

        private void ThemeChange_Click(object sender, RoutedEventArgs e)
        {
            App.ThemeChange();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            AddTicket addTicket = new AddTicket();
            addTicket.Show();
        }

        private void FilterByTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                ViewModel.FilterTicketsByTime.Execute(FilterByTime);
                MessageBox.Show("Click");
            }
        }
    }
}