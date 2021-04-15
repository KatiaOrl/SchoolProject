using Microsoft.EntityFrameworkCore;
using SchoolProject.BuissnesLayer.Interfaces;
using SchoolProject.DataAccess;
using SchoolProject.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolProject.BuissnesLayer.Implementation
{
    public class DBStudentsRepository : IStudentsRepository
    {
        private SchoolProjectDBContext context;
        public DBStudentsRepository(SchoolProjectDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Student> GetAllStudents(bool includeClassNumb = false)
        {
            if (includeClassNumb)
                return context.Set<Student>().Include(x => x.classNumb).AsNoTracking().ToList();
            else
                return context.Students.ToList();
        }

        public Student GetStudentById(int studentId, bool includeClassNumb = false)
        {

            if (includeClassNumb)
                return context.Set<Student>().Include(x => x.classNumb).AsNoTracking().FirstOrDefault(x => x.id == studentId);
            else
                return context.Students.FirstOrDefault(x => x.id == studentId);
        }

        public void SaveStudent(Student student)
        {
            if (student.id == 0)
                context.Students.Add(student);
            else
                context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            context.Students.Remove(student);
            context.SaveChanges();
        }


    }
}
