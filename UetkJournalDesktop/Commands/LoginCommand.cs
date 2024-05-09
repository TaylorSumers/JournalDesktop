using JournalDesktop.Stores;
using JournalDesktop.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalDesktop.Models;

namespace JournalDesktop.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly IMediator _mediator;

        private readonly NavigationStore _navigationStore;

        private readonly TeacherStore _teacherStore;

        public LoginCommand(IMediator mediator, NavigationStore navigationStore, TeacherStore teacherStore)
        {
            _mediator = mediator;
            _navigationStore = navigationStore;
            _teacherStore = teacherStore;
        }

        public override void Execute(object? parameter)
        {
            // Логика авторизации
            _navigationStore.CurrentViewModel = new JournalViewModel(_mediator);
            var teacher = new Teacher()
            {
                Name = "Иван",
                Surname = "Иванов"
            };
            _teacherStore.CurrentTeacher = teacher;
        }
    }
}
