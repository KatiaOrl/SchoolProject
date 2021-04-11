using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.DataAccess.Entities
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
