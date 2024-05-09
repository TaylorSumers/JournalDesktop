using JournalDesktop.Application.Teachers.Queires.GetTeacherInfo;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace JournalDesktop.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {

        public LoginPage()
        {
            InitializeComponent();
        }

        //IMediator _mediator;

        //public LoginPage(IMediator mediator)
        //{
        //    InitializeComponent();
        //    _mediator = mediator;
        //}

        //private async void btnEnter_Click(object sender, RoutedEventArgs e)
        //{
        //    var login = tbxLogin.Text;
        //    var password = pbxPassword.Password; // unsafe
        //    var query = new GetTeacherQuery()
        //    {
        //        Login = login,
        //        Password = password
        //    };

        //    try
        //    {
        //        var teacher = await _mediator.Send(query);
        //        //MainWindow.Teacher = teacher;
        //        NavigationService.Navigate(new JournalPage());
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
    }
}
