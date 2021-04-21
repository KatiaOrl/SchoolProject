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
    public class StudentCreateService : IStudentCreateService
    {
        private IStudentsRepository _studentDataAccess { get; }

        public StudentCreateService(IStudentsRepository studentDataAccess)
        {
            _studentDataAccess = studentDataAccess;
        }

        public Task<Student> CreateAsync(StudentsUpdateModel customer)
        {
            return _studentDataAccess.InsertAsync(customer);
        }
    }
    
}
