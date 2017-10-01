using System.Collections.Generic;
using System.Windows;

namespace DataBindingExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string APPLE = "Apple";
        const string BANANA = "Banana";
        const string ORANGES = "Oranges";
        const string STRAWBERRIES = "Strawberries";

        string log_text = string.Empty;

        List<Model> models = new List<Model>
        {
             new Model("Alaine", 0, new List<string>() { APPLE, BANANA }),
             new Model("Jenee", 1, new List<string>() { APPLE, BANANA, ORANGES, STRAWBERRIES }),
             new Model("Karol", 2, new List<string>() { ORANGES }),
             new Model("Isaac", 3, new List<string>() { BANANA, STRAWBERRIES }),
             new Model("Lillian", 4, new List<string>() { APPLE, ORANGES }),
             new Model("Elois", 5, new List<string>() { STRAWBERRIES, APPLE }),
             new Model("Dominick", 6, new List<string>() { ORANGES, BANANA }),
             new Model("Claudine", 7, new List<string>() { BANANA, STRAWBERRIES, ORANGES }),
             new Model("Wayne", 8, new List<string>() { BANANA }),
             new Model("Maia", 9, new List<string>() { STRAWBERRIES, BANANA }),
        };

        public MainWindow()
        {
            InitializeComponent();

            /**
             * This is important - this allows the WPF Binding mechanism 
             * to find the correct class & properties
             */
            DataContext = this;
        }

        public List<Model> Models
        {
            get { return models; }
            set { models = value; }
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            var converted = new List<string>();
            foreach (var element in models)
                converted.Add(element.ToString());

            textBox.Text += "\n-----------------\n" +  string.Join("\n", converted);
        }
    }
}
