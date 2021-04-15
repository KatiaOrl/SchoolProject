using SchoolProject.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.BuissnesLayer.Interfaces
{
    public interface IClassNumbRepository
    {
        public IEnumerable<ClassNumb> GetAllClasses (bool includeStudents = false);
        ClassNumb GetClassNumbById(int classNumbId, bool includeStudents = false);
        void SaveClassNumb(ClassNumb achieve);
        void DeleteClassNumb(ClassNumb achieve);

    }
}
