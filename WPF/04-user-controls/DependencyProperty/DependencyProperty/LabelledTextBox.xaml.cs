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

namespace DependencyProperty
{
    /// <summary>
    /// Interaction logic for LabelledTextBox.xaml
    /// </summary>
    public partial class LabelledTextBox : UserControl
    {

        public static readonly System.Windows.DependencyProperty LabelTextProperty =
            System.Windows.DependencyProperty.Register("LabelText", typeof(string), typeof(LabelledTextBox));

        public string LabelText
        {
            get { return GetValue(LabelTextProperty) as string; }
            set { SetValue(LabelTextProperty, value); }
        }

        public LabelledTextBox()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
