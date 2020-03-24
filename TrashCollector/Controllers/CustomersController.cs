using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public ActionResult Index()
        {
          
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).ToList();
            return View(customer);
        }

        // GET: Customers/Details/5
        
        public ActionResult Details(int id)
        {
            try
            {
                var details = _context.Customers.Where(d => d.CustomerId == id).SingleOrDefault();
                return View(details);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Customers/Create

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                //assign customer FK to identity user PK
                customer.IdentityUserId = userId;

                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer =  _context.Customers.Where(c => c.CustomerId == id).Single();
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,FirstName,LastName,PickupDay,StreetAddress,City,State,Zipcode,StartSuspension,EndSuspension,isSuspended,Balance,OneTimePickup")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return View();
            }
        }
         

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, Customer customers)
        {
            var customer =  _context.Customers.FindAsync(id);
            _context.Customers.Remove(customers);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
