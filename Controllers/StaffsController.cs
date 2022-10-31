using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School_Library.Common;
using School_Library.Data;
using School_Library.Models;
using School_Library.Models.StaffViewModel;

namespace School_Library.Controllers
{
    public class StaffsController : Controller
    {
        private readonly School_LibraryDbContext _context;

        public StaffsController(School_LibraryDbContext context)
        {
            _context = context;
        }

        // GET: Staffs
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var staffs = from s in _context.Staffs
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                staffs = staffs.Where(s => s.NameStaff.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    staffs = staffs.OrderByDescending(s => s.NameStaff);
                    break;
                default:
                    staffs = staffs.OrderBy(s => s.NameStaff);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<Staff>.CreateAsync(staffs.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Staffs == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            ViewData["StaffID"] = new SelectList(_context.Staffs, "NameStaff", "NameStaff");
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStaffViewModel createStaffViewModel)
        {
            if (ModelState.IsValid)
            {
                var staff = new Staff();
                staff.NameStaff = createStaffViewModel.NameStaff;
                staff.Dayofbirth = createStaffViewModel.Dayofbirth;
                staff.PhoneNumber = createStaffViewModel.PhoneNumber;
                await _context.Staffs.AddAsync(staff);
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffID"] = new SelectList(_context.Staffs, "NameStaff", "NameStaff", createStaffViewModel.StaffID);
            return View(createStaffViewModel);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Staffs == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["StaffID"] = new SelectList(_context.Staffs, "NameStaff", "NameStaff");

            var editStaffViewModel = new EditStaffViewModel();

            return View(editStaffViewModel);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditStaffViewModel editStaffViewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var findStaff = await _context.Staffs.FindAsync(id);
                    findStaff.NameStaff = editStaffViewModel.NameStaff;
                    findStaff.Dayofbirth = editStaffViewModel.Dayofbirth;
                    findStaff.PhoneNumber = editStaffViewModel.PhoneNumber;
                    _context.Update(findStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists())
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
            return View(editStaffViewModel);
        }

        private bool StaffExists()
        {
            throw new NotImplementedException();
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Staffs == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Staffs == null)
            {
                return Problem("Entity set 'School_LibraryDbContext.Staffs'  is null.");
            }
            var staff = await _context.Staffs.FindAsync(id);
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
          return _context.Staffs.Any(e => e.StaffID == id);
        }
    }
}
