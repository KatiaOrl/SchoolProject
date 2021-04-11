using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Domain
{
    public class Student
    {
        // ID Ученика
        public int id { get; set; }
        // имя и фамилия ученика
        public string firstName { get; set; }
        public string lastName { get; set;}
        // Фото ученика
        public string photo { get; set;}
        // Средний балл ученика
        public int avgScore { get; set; }
        // Домашний адрес ученика
        public string homeAddress { get; set; }
        // ID класса Ученика
        public int classID { get; set; }
        public virtual ClassNumb classNumb { get; set; }
    }
}
