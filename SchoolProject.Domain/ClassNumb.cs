using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Domain
{
    public class ClassNumb
    {
        // ID класса
        public int id { get; set; }
        // Номер класса
        public string classNumb { get; set; }
        // Описание класса
        public string desc { get; set; }
        public List<Student> student { get; set; }
    }
}
