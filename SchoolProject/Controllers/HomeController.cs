using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolProject.DataAccess;
using SchoolProject.DataAccess.Entities;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SchoolProjectDBContext _context;
        public HomeController(ILogger<HomeController> logger, SchoolProjectDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        /*
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            List<ClassNumb> _classNumb = _context.ClassNumbs.Include(a => a.student).ToList();
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
