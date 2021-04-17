using CapstoneOne.Data;
using CapstoneOne.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneOne.Controllers
{
    public class ActivityTypeController : Controller
    {
        private ApplicationDbContext _context;
        public ActivityTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ProductController
        public IActionResult Index()
        {
            IEnumerable<DateActivityType> activityType = _context.DateActivityTypes;
            return View(activityType);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DateActivityType activity)
        {
            if (ModelState.IsValid)
            {
                _context.DateActivityTypes.Add(activity);
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
            var activity = _context.DateActivityTypes.Find(id);
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
            var activity = _context.DateActivityTypes.Find(id);
            if (activity == null)
            {
                return NotFound();
            }
            _context.DateActivityTypes.Remove(activity);
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
            var activity = _context.DateActivityTypes.Find(id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(DateActivityType activity)
        {
            if (ModelState.IsValid)
            {
                _context.DateActivityTypes.Update(activity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }
    }
}
