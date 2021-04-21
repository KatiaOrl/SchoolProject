using SchoolProject.Domain;
using SchoolProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.BuissnesLayer.Interfaces
{
    public interface IStudentGetService
    {
        Task<IEnumerable<Student>> GetAsync();
        Task<Student> GetAsync(IStudentIdentity student);
        Task ValidateAsync(IStudentIdentity container);
    }
}
