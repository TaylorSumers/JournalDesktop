using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using JournalDesktop.Commands;
using JournalDesktop.ViewModels;
using JournalDesktop.Stores;


namespace JournalDesktop.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(IMediator mediator, NavigationStore navigationStore, TeacherStore teacherStore) : base(mediator)
        {
            LoginCommand = new LoginCommand(mediator, navigationStore, teacherStore, this);
        }

        private string _login;

        public string Login 
        {
            get 
            { 
                return _login; 
            }
            set 
            { 
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _password;

        public string Password
        {
            get 
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
    }
}
