using SchoolProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Domain.Models
{
    public class StudentsUpdateModel : IStudentIdentity, IClassNumb
    {
        public int Id { get; set; }

        public string photo { get; set; }

        public string avgScore { get; set; }

        public string homeAddress { get; set; }

        public int? classNumbId { get; set; }
    }
}
