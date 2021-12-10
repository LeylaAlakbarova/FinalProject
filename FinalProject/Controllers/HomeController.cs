using FinalProject.DataAccess;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            HomeVM viewModel = new HomeVM
            {
                Sliders = _db.Sliders.ToList(),
                Teachers = _db.Teachers.OrderByDescending(x => x.Id).Take(3).Include(x => x.TeacherDetail).ToList(),
                Courses = _db.Courses.OrderByDescending(x => x.Id).Take(8).Include(x => x.CourseDetail).ToList(),
                Notices = _db.Notices.OrderByDescending(x => x.Id).Take(4).ToList(),
                About = _db.Abouts.FirstOrDefault(),

            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Search(string query)
        {
            List<Course> courses = _db.Courses.Where(x => x.Title.Contains(query)).ToList();

            return PartialView("_Search", courses);
        }

    }
}
