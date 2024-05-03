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
        static int countClick = 0;

        private static List<CultureInfo> m_Languages = new List<CultureInfo>();

        public static List<CultureInfo> Languages 
        {
            get 
            {
                return m_Languages;
            }
        }

        public App()
        {
            InitializeComponent();
            App.LanguageChanged += App_LanguageChanged;

            m_Languages.Clear();
            m_Languages.Add(new CultureInfo("en-US")); 
            m_Languages.Add(new CultureInfo("ru-RU"));

            Language = lab4_5.Properties.Settings.Default.DefaultLanguage;
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

            if (countClick % 2 == 0)
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

            countClick++;
        }

        public static event EventHandler LanguageChanged;

        public static CultureInfo Language {
            get 
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture; 
            }
            set
            {
                if(value==null) throw new ArgumentNullException("value");
                if(value==System.Threading.Thread.CurrentThread.CurrentUICulture) return;

                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                ResourceDictionary dict = new ResourceDictionary();
                switch(value.Name){
                    case "en-US": 
                        dict.Source = new Uri($"Resources/Lang/lang.{value.Name}.xaml", UriKind.Relative);
                        break;
                    default:
                        dict.Source = new Uri("Resources/Lang/lang.xaml", UriKind.Relative);
                        break;
                }

                App.DeleteOldResources(dict, "Resources/Lang/lang.");
               
                LanguageChanged(Application.Current, new EventArgs());
            }
        }

        private void App_LanguageChanged(Object sender, EventArgs e)
        {
            lab4_5.Properties.Settings.Default.DefaultLanguage = Language;
            lab4_5.Properties.Settings.Default.Save();
        }
    }

}
