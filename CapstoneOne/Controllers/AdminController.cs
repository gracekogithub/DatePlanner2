using CapstoneOne.Data;
using CapstoneOne.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CapstoneOne.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
		}

		// GET: AdminController
		public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var admins = _context.Admins.Where(c => c.IdentityUserId == userId).ToList();
            if (admins.Count == 0)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(admins);
        }
    

        // GET: AdminController/Details/5
        public IActionResult Details(int id)
        {
            var Admin = _context.Admins.Where(e => e.AdminId == id).FirstOrDefault();

            return View(Admin);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Admin admin )
        {
            try
            {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            admin.IdentityUserId = userId;
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
            catch
            {
            Console.WriteLine("Error");
            return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            var admin = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(admin);
        
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Admin admin)
        {
            try
            {
                 var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                admin.IdentityUserId = userId;
                 _context.Admins.Update(admin);
                 _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
        }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public IActionResult Delete(int id)
        {
            var deleteAdmin = _context.Admins.Where(r => r.AdminId == id).FirstOrDefault();
            return View(deleteAdmin);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Admin admin)
        {
            try
            {
                var adminId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                admin.IdentityUserId = adminId;
                _context.Admins.Remove(admin);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
