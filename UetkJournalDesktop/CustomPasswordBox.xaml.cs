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
    /// Interaction logic for CustomPasswordBox.xaml
    /// </summary>
    public partial class CustomPasswordBox : UserControl
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(CustomPasswordBox));

        public string Password 
        { 
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); } 
        } // unsafe

        public CustomPasswordBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = sender is PasswordBox ? ((PasswordBox)sender).Password : ((TextBox)sender).Text;
            tbxPlaceholder.Visibility = string.IsNullOrEmpty(Password) ? Visibility.Visible : Visibility.Hidden;
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            if (pbxPassword.IsVisible)
            {
                tbxPassword.Text = Password;
                pbxPassword.Visibility = Visibility.Collapsed;
                tbxPassword.Visibility = Visibility.Visible;
                btnShow.Content = "Скрыть";
            }
            else
            {
                pbxPassword.Password = Password;
                tbxPassword.Visibility = Visibility.Collapsed;
                pbxPassword.Visibility = Visibility.Visible;
                btnShow.Content = "Показать";
            }
        }
    }
}
