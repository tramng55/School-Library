using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School_Library.Data;
using School_Library.Models;

namespace School_Library.Controllers
{
    public class BorrowAssignmentsController : Controller
    {
        private readonly School_LibraryDbContext _context;

        public BorrowAssignmentsController(School_LibraryDbContext context)
        {
            _context = context;
        }

        // GET: BorrowAssignments
        public async Task<IActionResult> Index()
        {
            var school_LibraryDbContext = _context.BorrowAssignments.Include(b => b.Book).Include(b => b.Student);
            return View(await school_LibraryDbContext.ToListAsync());
        }

        // GET: BorrowAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BorrowAssignments == null)
            {
                return NotFound();
            }

            var borrowAssignment = await _context.BorrowAssignments
                .Include(b => b.Book)
                .Include(b => b.Student)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (borrowAssignment == null)
            {
                return NotFound();
            }

            return View(borrowAssignment);
        }

        // GET: BorrowAssignments/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID");
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID");

            return View();
        }

        // POST: BorrowAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,StudentID,Status")] BorrowAssignment borrowAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrowAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", borrowAssignment.BookID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", borrowAssignment.StudentID);
          
            return View(borrowAssignment);
        }

        // GET: BorrowAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BorrowAssignments == null)
            {
                return NotFound();
            }

            var borrowAssignment = await _context.BorrowAssignments.FirstOrDefaultAsync(x => x.BorrowAssignmentID == id);
            if (borrowAssignment == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", borrowAssignment.BookID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", borrowAssignment.StudentID);
            return View(borrowAssignment);
        }

        // POST: BorrowAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookID,StudentID,Status")] BorrowAssignment borrowAssignment)
        {
            if (id != borrowAssignment.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowAssignmentExists(borrowAssignment.StudentID))
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
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", borrowAssignment.BookID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", borrowAssignment.StudentID);
            return View(borrowAssignment);
        }

        // GET: BorrowAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BorrowAssignments == null)
            {
                return NotFound();
            }

            var borrowAssignment = await _context.BorrowAssignments
                .Include(b => b.Book)
                .Include(b => b.Student)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (borrowAssignment == null)
            {
                return NotFound();
            }

            return View(borrowAssignment);
        }

        // POST: BorrowAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BorrowAssignments == null)
            {
                return Problem("Entity set 'School_LibraryDbContext.BorrowAssignments'  is null.");
            }
            var borrowAssignment = await _context.BorrowAssignments.FindAsync(id);
            if (borrowAssignment != null)
            {
                _context.BorrowAssignments.Remove(borrowAssignment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowAssignmentExists(int id)
        {
          return _context.BorrowAssignments.Any(e => e.StudentID == id);
        }
    }
}
