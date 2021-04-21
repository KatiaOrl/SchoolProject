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
    public class ClassNumbUpdateService : IClassNumbUpdateService
    {
        private IClassNumbRepository _classNumbDataAccess { get; }
        public ClassNumbUpdateService(IClassNumbRepository classNumbDataAccess)
        {
            _classNumbDataAccess = classNumbDataAccess;
        }
        public Task<ClassNumb> UpdateAsync(ClassNumbUpdateModel classNumb)
        {
            return _classNumbDataAccess.UpdateAsync(classNumb);
        }
    }
}
