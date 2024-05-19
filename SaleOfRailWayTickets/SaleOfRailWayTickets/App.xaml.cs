using lab4_5.Classes;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace lab4_5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static int countClickTheme = 0;
        static int countClickLang = 0;
        public static Session? session;

        public App()
        {
            InitializeComponent();
            session = new Session();
            //App.LanguageChanged += App_LanguageChanged;
        }

        private static void DeleteOldResources(ResourceDictionary newDict, string uri)
        {
            ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                          where d.Source != null && d.Source.OriginalString.StartsWith(uri)
                                          select d).First();
            if (oldDict != null)
            {
                int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                Application.Current.Resources.MergedDictionaries.Insert(ind, newDict);
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(newDict);
            }
        }

        public static void ThemeChange()
        {
            string uriPurpurTheme = "Resources/Theme/PurpurTheme.xaml";
            string uriSkyTheme = "Resources/Theme/SkyTheme.xaml";

            string uriOrangeColorMIU = "pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Orange.xaml";
            string uriIndigoColorMIU = "pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Indigo.xaml";

            ResourceDictionary dict = new ResourceDictionary();
            ResourceDictionary dictMIU = new ResourceDictionary();

            if (countClickTheme % 2 == 0)
            {
                dict.Source = new Uri(uriSkyTheme, UriKind.Relative);
                dictMIU.Source = new Uri(uriIndigoColorMIU, UriKind.Absolute);
            }
            else
            {
                dict.Source = new Uri(uriPurpurTheme, UriKind.Relative);
                dictMIU.Source = new Uri(uriOrangeColorMIU, UriKind.Absolute);
            }

            App.DeleteOldResources(dict, "Resources/Theme/");

            App.DeleteOldResources(dictMIU, "pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.");

            countClickTheme++;
        }

        public static event EventHandler LanguageChanged;

        public static void LanguageChange(CultureInfo value)
        {
            //if (value == null) throw new ArgumentNullException("value");
            //if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

            //System.Threading.Thread.CurrentThread.CurrentUICulture = value;

            ResourceDictionary dict = new ResourceDictionary();

            if (countClickLang % 2 == 0)
            {
                dict.Source = new Uri($"Resources/Lang/lang.en-US.xaml", UriKind.Relative);
            }
            else
            {
                dict.Source = new Uri("Resources/Lang/lang.xaml", UriKind.Relative);
            }

            App.DeleteOldResources(dict, "Resources/Lang/lang.");

            //LanguageChanged(Application.Current, new EventArgs());

            countClickLang++;
        }

        //private void App_LanguageChanged(Object sender, EventArgs e)
        //{
        //    lab4_5.Properties.Settings.Default.DefaultLanguage = Language;
        //    lab4_5.Properties.Settings.Default.Save();
        //}
    }

}
