using SchoolProject.Domain;
using SchoolProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.BuissnesLayer.Interfaces
{
    public interface IStudentCreateService
    {
        Task<Student> CreateAsync(StudentsUpdateModel student);
    }
}
