using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDesktop.ViewModels
{
    public class JournalViewModel : ViewModelBase
    {
        public JournalViewModel(IMediator mediator) : base(mediator)
        {
        }
    }
}
