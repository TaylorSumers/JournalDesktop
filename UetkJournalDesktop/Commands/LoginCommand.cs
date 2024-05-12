using JournalDesktop.Stores;
using JournalDesktop.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalDesktop.Models;
using JournalDesktop.Application.Teachers.Queires.GetTeacherInfo;

namespace JournalDesktop.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly IMediator _mediator;
        private readonly NavigationStore _navigationStore;
        private readonly TeacherStore _teacherStore;
        private readonly LoginViewModel _loginViewModel;



        public LoginCommand(IMediator mediator, NavigationStore navigationStore, TeacherStore teacherStore, LoginViewModel loginViewModel)
        {
            _mediator = mediator;
            _navigationStore = navigationStore;
            _teacherStore = teacherStore;
            _loginViewModel = loginViewModel;
        }

        public override async void Execute(object? parameter)
        {
            var query = new GetTeacherQuery()
            {
                Login = _loginViewModel.Login,
                Password = _loginViewModel.Password,
            };
            var teacher = await _mediator.Send(query);

            if (teacher != null)
            {
                _teacherStore.CurrentTeacher = teacher;
                _navigationStore.CurrentViewModel = new JournalViewModel(_mediator);
            }
        }
    }
}
