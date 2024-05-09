using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDesktop.Domain
{
    public class Teacher
    {
        public Guid Id { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Patronymic { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public byte[] Photo { get; set; }

        public string[] Subjects { get; set; }

        public string FullName
        {
            get
            {
                return $"{Surname} {Name}";
            }
        }

        public string FullName2
        {
            get
            {
                return $"{Surname} {Name} {Patronymic}";
            }
        }

        public string SubjectsString
        {
            get
            {
                return string.Join("; ", Subjects);
            }
        }
    }
}
