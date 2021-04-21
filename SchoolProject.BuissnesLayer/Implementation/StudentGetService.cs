using SchoolProject.BuissnesLayer.Interfaces;
using SchoolProject.DataAccess.Interfaces;
using SchoolProject.Domain;
using SchoolProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.BuissnesLayer.Implementation
{
    public class StudentGetService : IStudentGetService
    {
        private IStudentsRepository _studentDataAccess { get; }
        public StudentGetService(IStudentsRepository studentDataAccess)
        {
            _studentDataAccess = studentDataAccess;
        }
        public Task<IEnumerable<Student>> GetAsync()
        {
            return _studentDataAccess.GetAsync();
        }

        public Task<Student> GetAsync(IStudentIdentity student)
        {
            return _studentDataAccess.GetAsync(student);
        }

        public async Task ValidateAsync(IStudentIdentity container)
        {
            if (container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var entity = await _studentDataAccess.GetByAsync(container);

            if (entity is null)
            {
                throw new InvalidOperationException($"Customer not found by ID {container.Id}");
            }
        }
    }
}
