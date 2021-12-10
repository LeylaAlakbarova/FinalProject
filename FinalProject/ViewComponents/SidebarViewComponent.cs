using FinalProject.DataAccess;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewComponents
{
    public class SidebarViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        public SidebarViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            SidebarVM sidebar = new SidebarVM
            {
                Categories = _db.Categories.Include(x => x.Courses).ToList(),
                Blogs = _db.Blogs.OrderByDescending(x => x.Id).ToList()
            };

            return View(sidebar);
        }
    }
}
