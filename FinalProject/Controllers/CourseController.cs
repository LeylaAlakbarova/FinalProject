using FinalProject.DataAccess;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        public CourseController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Course> courses = _db.Courses.OrderByDescending(x => x.Id).Take(12).ToList();

            return View(courses);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = _db.Courses.Include(x => x.CourseDetail).
                Include(x => x.CourseParam).Include(x => x.CourseTag).FirstOrDefault(x => x.Id == id);

            if(course == null)
            {
                return NotFound();
            }

            return View(course);
        }
    }
}
