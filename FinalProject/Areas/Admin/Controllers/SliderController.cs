using FinalProject.DataAccess;
using FinalProject.Extenions;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
			_env = env;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _db.Sliders.ToList();

            return View(sliders);
        }

		#region Create
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Slider slider)
		{
			if (!ModelState.IsValid)
				return View();
			if (slider.Photo == null)
			{
				ModelState.AddModelError(nameof(slider.Photo), "Please select image");
				return View();
			}
			if (!slider.Photo.IsImage())
			{
				ModelState.AddModelError(nameof(slider.Photo), "Supported only image files");
				return View();
			}
			if (slider.Photo.IsMaxLength(2048))
			{
				ModelState.AddModelError(nameof(slider.Photo), "File size must be less 2 mb");
				return View();
			}
			string folder = Path.Combine(_env.WebRootPath, "assets", "img", "slider");
			slider.ImageUrl = await slider.Photo.SaveImageAsync(folder);
			await _db.Sliders.AddAsync(slider);
			await _db.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		#endregion

		#region Update
		public IActionResult Update(int? id)
		{
			if (id == null)
				return RedirectToAction("Index");

			Slider slider = _db.Sliders.FirstOrDefault(x => x.Id == id);

			if (slider == null)
				return RedirectToAction("Index");

			return View(slider);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(int? id, Slider slider)
		{
			if (id == null)
				return RedirectToAction("Index");

			Slider dbSlider = _db.Sliders.FirstOrDefault(x => x.Id == id);

			if (slider == null)
				return RedirectToAction("Index");

			if(slider.Photo != null)
			{
				if (!slider.Photo.IsImage())
				{
					ModelState.AddModelError(nameof(slider.Photo), "Supported only image files");
					return View(dbSlider);
				}
				if (slider.Photo.IsMaxLength(2048))
				{
					ModelState.AddModelError(nameof(slider.Photo), "File size must be less 2 mb");
					return View(dbSlider);
				}
				string folder = Path.Combine(_env.WebRootPath, "assets", "img", "slider");
				dbSlider.ImageUrl = await slider.Photo.SaveImageAsync(folder);
				string oldFile = Path.Combine(folder, slider.ImageUrl);
				if (System.IO.File.Exists(oldFile))
				{
					System.IO.File.Delete(oldFile);
				}
			}

			dbSlider.Title = slider.Title;
			dbSlider.Description = slider.Description;

			await _db.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		#endregion

		public async Task<IActionResult> Delete(int? id)
        {
			if (id == null)
				return RedirectToAction("Index");

			Slider dbSlider = _db.Sliders.FirstOrDefault(x => x.Id == id);

			if (dbSlider == null)
				return RedirectToAction("Index");

			_db.Sliders.Remove(dbSlider);
			await _db.SaveChangesAsync();
			return RedirectToAction("Index");

		}
	}
}
