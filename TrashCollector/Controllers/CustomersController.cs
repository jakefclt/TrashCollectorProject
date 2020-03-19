using System;
using System.Collections.Generic;
using System.Linq;
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
            var customer = _context.Customers.ToList();
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var details = _context.Customers.Where(d => d.Id == id).SingleOrDefault();
                return View(details);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }

            
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,FirstName,LastName,PickupDay,StreetAddress,City,State,Zipcode,StartSuspension,EndSuspension,isSuspended,Balance,OneTimePickup")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var editCustomer = _context.Customers.Where(e => e.Id == id).Single();
                return View(editCustomer);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,FirstName,LastName,PickupDay,StreetAddress,City,State,Zipcode,StartSuspension,EndSuspension,isSuspended,Balance,OneTimePickup")] Customer customer)
        {
            
                try
                {
                    _context.Customers.Update(customer);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(customer);
                }

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
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
