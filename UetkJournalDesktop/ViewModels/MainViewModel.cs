using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using JournalDesktop.Commands;
using JournalDesktop.Stores;
using JournalDesktop.Domain;

namespace JournalDesktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        private readonly TeacherStore _teacherStore;

        public MainViewModel(IMediator mediator, NavigationStore navigationStore, TeacherStore teacherStore) : base(mediator)
        {
            LogoutCommand = new LogoutCommand(mediator, navigationStore, teacherStore);
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _teacherStore = teacherStore;
            _teacherStore.CurrentTeacherChanged += OnCurrentTeacherChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnCurrentTeacherChanged()
        {
            OnPropertyChanged(nameof(CurrentTeacher));
        }

        public Teacher CurrentTeacher => _teacherStore.CurrentTeacher;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public ICommand GotoProfileCommand { get; }
        
        public ICommand LogoutCommand { get; }
    }
}
