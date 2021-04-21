using SchoolProject.Domain;
using SchoolProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.BuissnesLayer.Interfaces
{
    public interface IClassNumbUpdateService
    {
        Task<ClassNumb> UpdateAsync(ClassNumbUpdateModel classNumb);
    }
}
