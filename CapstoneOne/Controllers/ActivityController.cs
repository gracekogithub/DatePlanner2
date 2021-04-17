using CapstoneOne.Data;
using CapstoneOne.Models;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DateActivity activity)
        {
            if (ModelState.IsValid)
            {
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
