using FinalProject.DataAccess;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _db;
        public EventController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Event> events = _db.Events.OrderByDescending(x => x.Id).Take(8).ToList();

            return View(events);
        }

        public IActionResult Detail(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Event evnt = _db.Events.FirstOrDefault(x => x.Id == id);

            if(evnt == null)
            {
                return NotFound();
            }

            return View(evnt);
        }
    }
}
