using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDesktop.Models
{
    public class StudentLesson
    {
        public Guid StudentLessonId { get; set; }

        public Guid LessonId { get; set; }

        public Guid StudentId { get; set; }

        public DateTime LessonDate { get; set; }

        public Guid MarkId { get; set; }
    }
}
