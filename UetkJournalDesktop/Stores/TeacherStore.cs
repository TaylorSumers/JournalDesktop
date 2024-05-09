using JournalDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDesktop.Stores
{
    public class TeacherStore
    {
        private Teacher _currentTeacher;

        public Teacher CurrentTeacher
        {
            get => _currentTeacher;
            set
            {
                _currentTeacher = value;
                OnCurrentTeacherChanged();
            }
        }

        public event Action CurrentTeacherChanged;

        private void OnCurrentTeacherChanged()
        {
            CurrentTeacherChanged?.Invoke();
        }
    }
}
