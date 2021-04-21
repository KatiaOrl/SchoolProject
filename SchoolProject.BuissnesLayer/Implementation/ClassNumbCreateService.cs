using SchoolProject.BuissnesLayer.Interfaces;
//using SchoolProject.DataAccess.Entities;
using SchoolProject.DataAccess.Interfaces;
using SchoolProject.Domain;
using SchoolProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.BuissnesLayer.Implementation
{
    public class ClassNumbCreateService : IClassNumbCreateService
    {
        private IClassNumbRepository _classNumbDataAccess { get; }

        public ClassNumbCreateService(IClassNumbRepository classNumbDataAccess)
        {
            _classNumbDataAccess = classNumbDataAccess;
        }
        public Task<ClassNumb> CreateAsync(ClassNumbUpdateModel classNumb)
        {
            return _classNumbDataAccess.InsertAsync(classNumb);
        }
    }
}
