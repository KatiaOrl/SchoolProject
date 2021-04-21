using SchoolProject.BuissnesLayer.Interfaces;
using SchoolProject.DataAccess.Interfaces;
using SchoolProject.Domain;
using SchoolProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.BuissnesLayer.Implementation
{
    public class StudentUpdateService : IStudentUpdateService
    {
        private IStudentsRepository _studentDataAccess { get; }
        public StudentUpdateService(IStudentsRepository studentDataAccess)
        {
            _studentDataAccess = studentDataAccess;
        }
        public Task<Student> UpdateAsync(StudentsUpdateModel student)
        {
            return _studentDataAccess.UpdateAsync(student);
        }
    }
}
