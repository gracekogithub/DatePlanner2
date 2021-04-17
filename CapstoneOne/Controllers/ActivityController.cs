using CapstoneOne.Data;
using CapstoneOne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneOne.Controllers
{
    public class ActivityController : Controller
    {
        private ApplicationDbContext _context;
        public ActivityController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ProductController
        public IActionResult Index()
        {
            IEnumerable<DateActivity> activities = _context.DateActivities;
            return View(activities);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> TypeDropDown = _context.DateActivityTypes.Select(i => new SelectListItem { 
              Text = i.Name,
              Value =i.Id.ToString()
            });
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DateActivity activity)
        {
            if (ModelState.IsValid)
            {
                //activity.DateActivityTypeId = 1;
                _context.DateActivities.Add(activity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }
        //Get
        public IActionResult Delete(int? id)
        {
            if(id ==null || id == 0)
            {
                return NotFound();
            }
            var activity = _context.DateActivities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost (int? id)
        {
            var activity = _context.DateActivities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }
            _context.DateActivities.Remove(activity);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //Get
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var activity = _context.DateActivities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(DateActivity activity)
        {
            if (ModelState.IsValid)
            {
                _context.DateActivities.Update(activity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }
    }
}
