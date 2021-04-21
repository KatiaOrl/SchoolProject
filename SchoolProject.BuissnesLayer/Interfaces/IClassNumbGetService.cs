using SchoolProject.Domain;
using SchoolProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.BuissnesLayer.Interfaces
{
    public interface IClassNumbGetService
    {
        Task<IEnumerable<ClassNumb>> GetAsync();
        Task<ClassNumb> GetAsync(IClassNumb classNumb);

        Task ValidateAsync(IClassNumb container);
    }
}
