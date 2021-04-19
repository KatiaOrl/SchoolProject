using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolProject.BuissnesLayer;
using SchoolProject.DataAccess.Interfaces;
using SchoolProject.DataAccess;
using SchoolProject.DataAccess.Entities;
using SchoolProject.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private SchoolProjectDBContext _context;
        //private IClassNumbRepository _classNumbRep;
        private DataManager _dataManager;
        public HomeController(ILogger<HomeController> logger, DataManager dataManager/*SchoolProjectDBContext context, IClassNumbRepository classNumb*/)
        {
            _logger = logger;
            //_context = context;
            //_classNumbRep = classNumb;
            _dataManager = dataManager;
        }
        /*
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            //List<ClassNumb> _classNumb = _context.ClassNumbs.Include(a => a.student).ToList();
            //List<ClassNumb> _classNumb = _classNumbRep.GetAllClasses().ToList();
            List<ClassNumb> _classNumb = _dataManager.ClassNumbs.GetAllClasses(true).ToList();
            return View(_classNumb);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
