using JournalDesktop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UetkJournal.Desktop.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
