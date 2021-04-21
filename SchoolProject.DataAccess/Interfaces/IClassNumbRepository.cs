using SchoolProject.DataAccess.Entities;
using SchoolProject.Domain;
using SchoolProject.Domain.Interfaces;
using SchoolProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.DataAccess.Interfaces
{
    public interface IClassNumbRepository
    {
        public IEnumerable<Entities.ClassNumb> GetAllClasses(bool includeStudents = false);
        Entities.ClassNumb GetClassNumbById(int classNumbId, bool includeStudents = false);
        void SaveClassNumb(Entities.ClassNumb achieve);
        void DeleteClassNumb(Entities.ClassNumb achieve);
        Task<Domain.ClassNumb> InsertAsync(ClassNumbUpdateModel classNumb);

        Task<IEnumerable<Domain.ClassNumb>> GetAsync();
        Task<Domain.ClassNumb> GetAsync(IClassNumb classNumb);
        Task<Domain.ClassNumb> GetByAsync(IClassNumb container);

        Task<Domain.ClassNumb> UpdateAsync(ClassNumbUpdateModel classNumb);

    }
}
