
using lab4_5.Classes;
using Microsoft.Data.SqlClient;
using System.Globalization;
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

namespace lab4_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static TicketsViewModel ViewModel { get; set; }
        private int countClick = 0;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new TicketsViewModel();
            ViewModel = (TicketsViewModel)DataContext;

            App.LanguageChanged += LanguageChanged;

            CultureInfo currLang = App.Language;

            //Заполняем меню смены языка:
            MenuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                MenuLanguage.Items.Add(menuLang);
            }
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in MenuLanguage.Items)
            {
                CultureInfo? ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem? mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo? lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }

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