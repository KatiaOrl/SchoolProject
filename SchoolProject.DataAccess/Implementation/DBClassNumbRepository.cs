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
    public class DBClassNumbRepository : IClassNumbRepository
    {
        private SchoolProjectDBContext context;
        private IMapper Mapper { get; }
        public DBClassNumbRepository(SchoolProjectDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Entities.ClassNumb> GetAllClasses(bool includeStudents = false)
        {
            if (includeStudents)
                return context.Set<Entities.ClassNumb>().Include(x => x.student).AsNoTracking().ToList();
            else
                return context.ClassNumbs.ToList();
        }

        public Entities.ClassNumb GetClassNumbById(int classNumbId, bool includeStudents = false)
        {
            if (includeStudents)
                return context.Set<Entities.ClassNumb>().Include(x => x.student).AsNoTracking().FirstOrDefault(x => x.id == classNumbId);
            else
                return context.ClassNumbs.FirstOrDefault(x => x.id == classNumbId);
        }

        public void SaveClassNumb(Entities.ClassNumb classNumb)
        {
            if (classNumb.id == 0)
                context.ClassNumbs.Add(classNumb);
            else
                context.Entry(classNumb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteClassNumb(Entities.ClassNumb classNumb)
        {
            context.ClassNumbs.Remove(classNumb);
            context.SaveChanges();
        }
        public async Task<Domain.ClassNumb> InsertAsync(ClassNumbUpdateModel classNumb)
        {
            var result = await context.ClassNumbs.AddAsync(Mapper.Map<Entities.ClassNumb>(classNumb));

            await context.SaveChangesAsync();

            return Mapper.Map<Domain.ClassNumb>(result.Entity);
        }

        public async Task<IEnumerable<Domain.ClassNumb>> GetAsync()
        {
            return Mapper.Map<IEnumerable<Domain.ClassNumb>>(await context.ClassNumbs.Include(x => x.student).ToListAsync());
        }
        public async Task<Domain.ClassNumb> GetAsync(IClassNumb classNumb)
        {
            if (classNumb == null)
            {
                throw new ArgumentNullException(nameof(classNumb));
            }

            return Mapper.Map<Domain.ClassNumb>(await context.ClassNumbs.Include(x => x.student).FirstOrDefaultAsync(x => x.id == classNumb.classNumbId));
        }
        public async Task<Domain.ClassNumb> GetByAsync(IClassNumb container)
        {
            return Mapper.Map<Domain.ClassNumb>(await context.ClassNumbs.FirstOrDefaultAsync(x => x.id == container.classNumbId));
        }

        public async Task<Domain.ClassNumb> UpdateAsync(ClassNumbUpdateModel classNumb)
        {
            if (classNumb == null)
            {
                throw new ArgumentNullException(nameof(classNumb));
            }

            var entity = await context.ClassNumbs.FirstOrDefaultAsync(x => x.id == classNumb.classNumbId);

            var result = Mapper.Map(classNumb, entity);

            context.Update(result);

            await context.SaveChangesAsync();

            return Mapper.Map<Domain.ClassNumb>(result);
        }
    }
}
