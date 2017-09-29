using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace I18n_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string DEFAULT_CULTURE_CODE = "en-US";

        /// <summary>
        /// Converts user friendly culture names to internal culture names.
        /// There are better ways to do this, but this is simple.
        /// </summary>
        IDictionary<string, string> languageCultureCodeMap = new Dictionary<string, string>
        {
            { "English (US)", "en-US" },
            { "Deutsch (DE)", "de-DE" }
        };

        public MainWindow()
        {
            SetLanguage(DEFAULT_CULTURE_CODE);
            InitializeComponent();
        }

        void SetLanguage(string cultureCode)
        {
            ResourceDictionary dict = new ResourceDictionary();
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);

            // all of our localized strings live in the i18n folder //
            string i18n_path = string.Format("i18n/Strings.{0}.xaml", cultureCode);

            // if we can't find the requested culture code, then go to default //
            if (Uri.IsWellFormedUriString(i18n_path, UriKind.Relative))
                dict.Source = new Uri(i18n_path, UriKind.Relative);
            else
                dict.Source = new Uri(string.Format("i18n/Strings.{0}.xaml", DEFAULT_CULTURE_CODE), UriKind.Relative);

            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            // pull selected item's text contents
            var item = sender as ComboBox;
            if (item == null)
                return;

            // this isn't good code, but it'll pull the language from the drop-down menu //
            var language = ((ComboBoxItem)item.SelectedItem).ToString().Split(':')[1].Trim();

            // map text content to culture code
            string cultureCode;
            if (!languageCultureCodeMap.TryGetValue(language, out cultureCode))
                SetLanguage(DEFAULT_CULTURE_CODE);
            else
                SetLanguage(cultureCode);
        }
    }
}
