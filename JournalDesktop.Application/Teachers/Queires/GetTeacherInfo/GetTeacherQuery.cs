using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using JournalDesktop.Domain;

namespace JournalDesktop.Application.Teachers.Queires.GetTeacherInfo
{
    public class GetTeacherQuery : IRequest<Teacher>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
