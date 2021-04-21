﻿using SchoolProject.BuissnesLayer.Interfaces;
using SchoolProject.DataAccess.Interfaces;
using SchoolProject.Domain;
using SchoolProject.Domain.Interfaces;
using SchoolProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.BuissnesLayer.Implementation
{
    public class ClassNumbGetService : IClassNumbGetService
    {
        private IClassNumbRepository _classNumbDataAccess { get; }

        public ClassNumbGetService(IClassNumbRepository classNumbDataAccess)
        {
            _classNumbDataAccess = classNumbDataAccess;
        }

        public Task<IEnumerable<ClassNumb>> GetAsync()
        {
            return _classNumbDataAccess.GetAsync();
        }

        public Task<ClassNumb> GetAsync(IClassNumb classNumb)
        {
            return _classNumbDataAccess.GetAsync(classNumb);
        }

        public async Task ValidateAsync(IClassNumb container)
        {
            if (container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var entity = await _classNumbDataAccess.GetByAsync(container);

            if (entity is null)
            {
                throw new InvalidOperationException($"Book not found by ID {container.classNumbId}");
            }
        }
    }
}
