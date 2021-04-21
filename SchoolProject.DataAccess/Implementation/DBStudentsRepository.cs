using Microsoft.EntityFrameworkCore;
using SchoolProject.DataAccess.Interfaces;
using SchoolProject.DataAccess;
using SchoolProject.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Domain.Models;
using AutoMapper;
using SchoolProject.Domain;
using SchoolProject.Domain.Interfaces;


namespace SchoolProject.DataAccess.Implementation
{
    public class DBStudentsRepository : IStudentsRepository
    {
        private SchoolProjectDBContext context;
        private IMapper mapper { get; }
        public DBStudentsRepository(SchoolProjectDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IEnumerable<Entities.Student> GetAllStudents(bool includeClassNumb = false)
        {
            if (includeClassNumb)
                return context.Set<Entities.Student>().Include(x => x.classNumb).AsNoTracking().ToList();
            else
                return context.Students.ToList();
        }

        public Entities.Student GetStudentById(int studentId, bool includeClassNumb = false)
        {

            if (includeClassNumb)
                return context.Set<Entities.Student>().Include(x => x.classNumb).AsNoTracking().FirstOrDefault(x => x.id == studentId);
            else
                return context.Students.FirstOrDefault(x => x.id == studentId);
        }

        public void SaveStudent(Entities.Student student)
        {
            if (student.id == 0)
                context.Students.Add(student);
            else
                context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteStudent(Entities.Student student)
        {
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public async Task<Domain.Student> InsertAsync(StudentsUpdateModel student)
        {
            var result = await context.Students.AddAsync(mapper.Map<Entities.Student>(student));

            await context.SaveChangesAsync();

            return mapper.Map<Domain.Student>(result.Entity);
        }

        public async Task<IEnumerable<Domain.Student>> GetAsync()
        {
            return mapper.Map<IEnumerable<Domain.Student>>(await context.Students.Include(x => x.classNumb).ToListAsync());
        }
        private async Task<Entities.Student> Get(IStudentIdentity student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            return await context.Students.Include(x => x.classNumb)
                .FirstOrDefaultAsync(x => x.id == student.Id);
        }

        public async Task<Domain.Student> GetAsync(IStudentIdentity student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            return mapper.Map<Domain.Student>(await Get(student));
        }

        public async Task<Domain.Student> UpdateAsync(StudentsUpdateModel student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var entity = await context.Students.FirstOrDefaultAsync(x => x.id == student.Id);

            var result = mapper.Map(student, entity);

            context.Update(result);

            await context.SaveChangesAsync();

            return mapper.Map<Domain.Student>(result);
        }

        public async Task<Domain.Student> GetByAsync(IStudentIdentity container)
        {
            return mapper.Map<Domain.Student>(await context.Students.FirstOrDefaultAsync(x => x.id == container.Id));
        }
    }
}
