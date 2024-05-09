using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDesktop.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected IMediator _mediator;

        public ViewModelBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
