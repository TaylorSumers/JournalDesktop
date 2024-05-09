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
using JournalDesktop.Domain;
using JournalDesktop.Pages;
using MediatR;
using JournalDesktop.ViewModels;

namespace JournalDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() 
        {
            InitializeComponent();
        }

        //public static Teacher Teacher { get; set; }
        //private IMediator _mediator;

        //public MainWindow(IMediator mediator)
        //{
        //    InitializeComponent();
        //    _mediator = mediator;
        //    MainFrame.Content = new LoginPage(mediator);
        //}

        //private void btnExit_Click(object sender, RoutedEventArgs e) => MainFrame.Content = new LoginPage(_mediator);

        //private void btnProfile_Click(object sender, RoutedEventArgs e) => MainFrame.Content = new ProfilePage();

        //private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        //{
        //    if (e.Content.GetType() == typeof(LoginPage))
        //    {
        //        grdUserInfo.Visibility = Visibility.Hidden;
        //        tbHeader.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        grdUserInfo.Visibility = Visibility.Visible;
        //        tbHeader.Visibility = Visibility.Hidden;
        //        DataContext = Teacher;
        //    }
        //}
    }
}
