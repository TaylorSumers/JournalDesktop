using JournalDesktop.Stores;
using JournalDesktop.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDesktop.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly IMediator _mediator;

        private readonly NavigationStore _navigationStore;

        private readonly TeacherStore _teacherStore;

        public LogoutCommand(IMediator mediator, NavigationStore navigationStore, TeacherStore teacherStore)
        {
            _mediator = mediator;
            _navigationStore = navigationStore;
            _teacherStore = teacherStore;
        }

        public override void Execute(object? parameter)
        {
            // Логика выхода
            _navigationStore.CurrentViewModel = new LoginViewModel(_mediator, _navigationStore, _teacherStore);
            _teacherStore.CurrentTeacher = null;
        }
    }
}
