using SchoolProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Domain.Models
{
    public class ClassNumbUpdateModel :  IClassNumb
    {
        public int? classNumbId { get; set; }
        public string classNumb { get; set; }
       
        public string desc { get; set; }
    }
}
