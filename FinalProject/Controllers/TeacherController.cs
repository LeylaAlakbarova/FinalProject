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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;
        public TeacherController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Teacher> teachers = _db.Teachers.Include(x => x.TeacherDetail).ToList();

            return View(teachers);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teacher teacher = _db.Teachers.Include(x => x.TeacherDetail)
                .Include(x => x.Skills).ThenInclude(x=>x.Skill).FirstOrDefault(x => x.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }
    }
}
