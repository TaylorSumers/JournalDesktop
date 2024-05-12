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

namespace JournalDesktop
{
    /// <summary>
    /// Interaction logic for CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl
    {
        public string Placeholder { get; set; }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(TextProp), typeof(string), typeof(CustomTextBox));

        public string TextProp
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public CustomTextBox()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
