using Microsoft.EntityFrameworkCore;
using SchoolProject.DataAccess.Interfaces;
using SchoolProject.DataAccess;
using SchoolProject.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolProject.DataAccess.Implementation
{
    public class DBClassNumbRepository : IClassNumbRepository
    {
        private SchoolProjectDBContext context;
        public DBClassNumbRepository(SchoolProjectDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<ClassNumb> GetAllClasses(bool includeStudents = false)
        {
            if (includeStudents)
                return context.Set<ClassNumb>().Include(x => x.student).AsNoTracking().ToList();
            else
                return context.ClassNumbs.ToList();
        }

        public ClassNumb GetClassNumbById(int classNumbId, bool includeStudents = false)
        {
            if (includeStudents)
                return context.Set<ClassNumb>().Include(x => x.student).AsNoTracking().FirstOrDefault(x => x.id == classNumbId);
            else
                return context.ClassNumbs.FirstOrDefault(x => x.id == classNumbId);
        }

        public void SaveClassNumb(ClassNumb classNumb)
        {
            if (classNumb.id == 0)
                context.ClassNumbs.Add(classNumb);
            else
                context.Entry(classNumb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteClassNumb(ClassNumb classNumb)
        {
            context.ClassNumbs.Remove(classNumb);
            context.SaveChanges();
        }


    }
}
