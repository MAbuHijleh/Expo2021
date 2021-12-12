using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpoAdmin.Data;
using Microsoft.AspNetCore.Authorization;
using ExpoAdmin.Models;

namespace ExpoAdmin.Controllers
{
    public class RegistredUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistredUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistredUsers
        [Authorize]
        public async Task<IActionResult> Index(
            string currentFilter,
            string searchString,
            int? pageNumber
            )
        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var students = from s in _context.RUsers
                           select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.FullName.Contains(searchString)
                                       || s.Email.Contains(searchString) 
                                       || s.Phone.Contains(searchString) );
            }

            int pageSize = 1;
            return View(await PaginatedList<RegistredUser>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: RegistredUsers/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registredUser = await _context.RUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registredUser == null)
            {
                return NotFound();
            }

            return View(registredUser);
        }

        // GET: RegistredUsers/Create
        public IActionResult Create(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                TempData["status"] = message;
            return View();
        }

        // POST: RegistredUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Organization,Title,Email,Phone,City,Gender,State")] RegistredUser registredUser)
        {
            registredUser.TimeCreated = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                _context.Add(registredUser);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Create), new { message = "success!" });
            }
            return View(registredUser);
        }

        // GET: RegistredUsers/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registredUser = await _context.RUsers.FindAsync(id);
            if (registredUser == null)
            {
                return NotFound();
            }
            return View(registredUser);
        }

        // POST: RegistredUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Organization,Title,Email,Phone,City,Gender,State")] RegistredUser registredUser)
        {
            if (id != registredUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registredUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistredUserExists(registredUser.Id))
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
            return View(registredUser);
        }

        // // GET: RegistredUsers/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var registredUser = await _context.Users
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (registredUser == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return View(registredUser);
        // }

        // // POST: RegistredUsers/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var registredUser = await _context.Users.FindAsync(id);
        //     _context.Users.Remove(registredUser);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        private bool RegistredUserExists(int id)
        {
            return _context.RUsers.Any(e => e.Id == id);
        }
    }
}
