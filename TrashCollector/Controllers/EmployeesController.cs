using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
           
        }

        public DateTime DateTime { get;}

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            //grabs the PK of the user who is currently logged in (right after registration or login)
            //PK of identity user

            
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeeLoggedIn = _context.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();

            
            var customersInZip = _context.Customers.Where(c => c.Zipcode == employeeLoggedIn.ZipCode).ToListAsync();


            //customers that have pickup today (day of week)
            //DateTime.Now
            //customersInZip
            
            return View(await customersInZip);
        }

        public IActionResult FilterDays()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FilterDays(FilterDayViewModel filterDayViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeeLoggedIn = _context.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();
            
            var pickupByDay = _context.Customers.Where(c => c.PickupDay == filterDayViewModel.Day && c.Zipcode == employeeLoggedIn.ZipCode).ToList();
            return View("Index", pickupByDay);
        }

        public IActionResult ConfirmPickup(int id)
        {
            ConfirmPickupViewModel viewModel = new ConfirmPickupViewModel();
            viewModel.CustomerId = id;
            return View();
        }

        //[HttpPost]

        public IActionResult ConfirmPickupConfirmation(ConfirmPickupViewModel confirmPickupViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeeLoggedIn = _context.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();

            var pickupConfirmed = _context.Customers.Where(c => c.PickUp == confirmPickupViewModel.Pickup).ToList();
            
                                                    
            _context.SaveChanges();
            return View("Index", pickupConfirmed);
        }


        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,ZipCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

               
                employee.IdentityUserId = userId;

                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,ZipCode")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
