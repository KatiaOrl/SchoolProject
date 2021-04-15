using SchoolProject.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.BuissnesLayer.Interfaces
{
    public interface IStudentsRepository
    {
        public IEnumerable<Student> GetAllStudents(bool includeClassNumb = false);
        Student GetStudentById(int studentId, bool includeClassNumb = false);
        void SaveStudent(Student student);
        void DeleteStudent(Student student);

    }
}
