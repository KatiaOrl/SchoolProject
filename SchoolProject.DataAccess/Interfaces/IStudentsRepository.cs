using SchoolProject.Domain;
using SchoolProject.DataAccess.Entities;
using SchoolProject.Domain.Interfaces;
using SchoolProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.DataAccess.Interfaces
{
    public interface IStudentsRepository
    {
        public IEnumerable<Entities.Student> GetAllStudents(bool includeClassNumb = false);
        Entities.Student GetStudentById(int studentId, bool includeClassNumb = false);
        void SaveStudent(Entities.Student student);
        void DeleteStudent(Entities.Student student);
        Task<Domain.Student> InsertAsync(StudentsUpdateModel student);
        Task<IEnumerable<Domain.Student>> GetAsync();
        Task<Domain.Student> GetAsync(IStudentIdentity student);
        Task<Domain.Student> UpdateAsync(StudentsUpdateModel student);
        Task<Domain.Student> GetByAsync(IStudentIdentity container);

    }
}
