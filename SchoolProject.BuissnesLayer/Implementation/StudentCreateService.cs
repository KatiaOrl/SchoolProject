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
        private IClassNumbGetService _classNumbGetService { get; }

        public StudentCreateService(IStudentsRepository studentDataAccess, IClassNumbGetService classNumbGetService)
        {
            _studentDataAccess = studentDataAccess;
            _classNumbGetService = classNumbGetService;
        }

        public async Task<Student> CreateAsync(StudentsUpdateModel student)
        {
            await _classNumbGetService.ValidateAsync(student);
            //await CustomerGetService.ValidateAsync(order);

            //order.Date = DateTime.Now;
            //order.Arrived = false;

            return await _studentDataAccess.InsertAsync(student);
        }
    }
    
}
