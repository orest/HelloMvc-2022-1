using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloMvc.Data;
using HelloMvc.Models;

namespace HelloMvc.Controllers {
    public class VacationsController : Controller {
        private readonly EmployeeContext _context;

        public VacationsController(EmployeeContext context) {
            _context = context;
        }

        // GET: Vacations
        public IActionResult Index(int employeeId) {

            if (employeeId > 0) {
                var result = _context.Employees.Include(p => p.Vacations).FirstOrDefault(p => p.EmployeeId == employeeId);

                return View(result);
            }

            return RedirectToAction("Index", "Employees");


        }

        // GET: Vacations/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.Vacations == null) {
                return NotFound();
            }

            var vacation = await _context.Vacations
                .Include(v => v.Employee)
                .FirstOrDefaultAsync(m => m.VacationId == id);
            if (vacation == null) {
                return NotFound();
            }

            return View(vacation);
        }

        // GET: Vacations/Create
        public IActionResult Create(int employeeId) {
            var vacation = new VacationVm() { EmployeeId = employeeId };

            return View(vacation);
        }

        // POST: Vacations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vacation vacation) {
            if (ModelState.IsValid) {
                _context.Add(vacation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { employeeId = vacation.EmployeeId });
            }
            return View(vacation);
        }

        // GET: Vacations/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.Vacations == null) {
                return NotFound();
            }

            var vacation = await _context.Vacations.FindAsync(id);
            if (vacation == null) {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", vacation.EmployeeId);
            return View(vacation);
        }

        // POST: Vacations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacationId,Comment,FromDate,ToDate,EmployeeId")] Vacation vacation) {
            if (id != vacation.VacationId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(vacation);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!VacationExists(vacation.VacationId)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", vacation.EmployeeId);
            return View(vacation);
        }

        // GET: Vacations/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Vacations == null) {
                return NotFound();
            }

            var vacation = await _context.Vacations
                .Include(v => v.Employee)
                .FirstOrDefaultAsync(m => m.VacationId == id);
            if (vacation == null) {
                return NotFound();
            }

            return View(vacation);
        }

        // POST: Vacations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if (_context.Vacations == null) {
                return Problem("Entity set 'EmployeeContext.Vacations'  is null.");
            }
            var vacation = await _context.Vacations.FindAsync(id);
            if (vacation != null) {
                _context.Vacations.Remove(vacation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationExists(int id) {
            return _context.Vacations.Any(e => e.VacationId == id);
        }
    }
}
