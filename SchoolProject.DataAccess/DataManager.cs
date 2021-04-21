using SchoolProject.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.DataAccess
{
    public class DataManager
    {
        private IClassNumbRepository _classNumbRepository;
        private IStudentsRepository _studentsRepository;
        public DataManager(IClassNumbRepository classNumbRepository, IStudentsRepository studentsRepository)
        {
            _classNumbRepository = classNumbRepository;
            _studentsRepository = studentsRepository;
        }

        public IClassNumbRepository ClassNumbs { get { return _classNumbRepository; } }
        public IStudentsRepository Students { get { return _studentsRepository; } }
    }
}
