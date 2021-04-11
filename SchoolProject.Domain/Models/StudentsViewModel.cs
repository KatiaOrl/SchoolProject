using SchoolProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Domain.Models
{
    class StudentsViewModel : IStudentIdentity, IClassNumb
    {
        public int Id { get;}
        public int? classNumbId { get; }
        public string firstName {get; }
        public string lastName {get; }
        public string photo { get; }
        public int avgScore { get; }
    }
}
