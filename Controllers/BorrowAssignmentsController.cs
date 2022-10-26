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
using School_Library.Models.BookViewModel;

namespace School_Library.Controllers
{
    public class BorrowAssignmentsController : Controller
    {
        private readonly School_LibraryDbContext _context;
        private readonly List<StatusBorrowAssignment> statusBorrowAssignments = new List<StatusBorrowAssignment>();

        public BorrowAssignmentsController(School_LibraryDbContext context)
        {
            _context = context;
            statusBorrowAssignments.Add(new StatusBorrowAssignment
            {
                Id = 1, 
               

            }) ;
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
                .FirstOrDefaultAsync(m => m.BorrowAssignmentID == id);
            if (borrowAssignment == null)
            {
                return NotFound();
            }

            return View(borrowAssignment);
        }

        // GET: BorrowAssignments/Create
        public   IActionResult Create()
        {
            ViewData["Status"] = new SelectList(statusBorrowAssignments,  "Id", "Name");
            ViewData["BookID"] = new SelectList(_context.Books, "NameBook", "NameBook");
            ViewData["StudentID"] = new SelectList(_context.Students, "NameStudent", "NameStudent");

            
            return View();
        }

        // POST: BorrowAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowAssignment borrowAssignment)
        {
            if (ModelState.IsValid)
            {
              
                _context.Add(borrowAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["BookID"] = new SelectList(_context.Books, "NameBook", "NameBook", borrowAssignment.BookID);
            ViewData["StudentID"] = new SelectList(_context.Students, "NameStudent", "NameStudent", borrowAssignment.StudentID);

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
            ViewData["Status"] = new SelectList(statusBorrowAssignments, "Id", "Name");
            ViewData["BookID"] = new SelectList(_context.Books, "NameBook", "NameBook");
            ViewData["StudentID"] = new SelectList(_context.Students, "NameStudent", "NameStudent");
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
                .FirstOrDefaultAsync(m => m.BorrowAssignmentID == id);
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
            return _context.BorrowAssignments.Any(e => e.BorrowAssignmentID == id);
        }
    }
}