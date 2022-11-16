using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloMvc.Data;
using HelloMvc.Models;
using HelloMvc.Models.VM;

namespace HelloMvc.Controllers {
    public class HolidaysController : Controller {
        private readonly EmployeeContext _context;

        public HolidaysController(EmployeeContext context) {
            _context = context;
        }

        // GET: Holidays
        public IActionResult Index() {
            var holidays = _context.Holidays.ToList();
            //var vm = new List<HolidayVm>();
            //foreach (var holiday in holidays) {
            //    vm.Add(new HolidayVm(holiday));
            //}
            var vm = holidays.Select(p => new HolidayVm(p)).ToList();

            return View(vm);
        }

        // GET: Holidays/Details/5
        public async Task<IActionResult> Details(string id) {
            if (id == null || _context.Holidays == null) {
                return NotFound();
            }

            var holiday = await _context.Holidays
                .FirstOrDefaultAsync(m => m.HolidayCode == id);
            if (holiday == null) {
                return NotFound();
            }

            return View(holiday);
        }

        // GET: Holidays/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Holidays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HolidayCode,DisplayName")] Holiday holiday) {
            if (ModelState.IsValid) {
                _context.Add(holiday);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(holiday);
        }

        // GET: Holidays/Edit/5
        public async Task<IActionResult> Edit(string id) {
            if (id == null || _context.Holidays == null) {
                return NotFound();
            }

            var holiday = await _context.Holidays.FindAsync(id);
            if (holiday == null) {
                return NotFound();
            }
            return View(holiday);
        }

        // POST: Holidays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HolidayCode,DisplayName")] Holiday holiday) {
            if (id != holiday.HolidayCode) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(holiday);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!HolidayExists(holiday.HolidayCode)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(holiday);
        }

        // GET: Holidays/Delete/5
        public async Task<IActionResult> Delete(string id) {
            if (id == null || _context.Holidays == null) {
                return NotFound();
            }

            var holiday = await _context.Holidays
                .FirstOrDefaultAsync(m => m.HolidayCode == id);
            if (holiday == null) {
                return NotFound();
            }

            return View(holiday);
        }

        // POST: Holidays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            if (_context.Holidays == null) {
                return Problem("Entity set 'EmployeeContext.Holidays'  is null.");
            }
            var holiday = await _context.Holidays.FindAsync(id);
            if (holiday != null) {
                _context.Holidays.Remove(holiday);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HolidayExists(string id) {
            return _context.Holidays.Any(e => e.HolidayCode == id);
        }
    }
}
