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
    public class AuthorBooksController : Controller
    {
        private readonly School_LibraryDbContext _context;

        public AuthorBooksController(School_LibraryDbContext context)
        {
            _context = context;
        }

        // GET: AuthorBooks
        public async Task<IActionResult> Index()
        {
            var school_LibraryDbContext = _context.AuthorBooks.Include(a => a.Author).Include(a => a.Book);
            return View(await school_LibraryDbContext.ToListAsync());
        }

        // GET: AuthorBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AuthorBooks == null)
            {
                return NotFound();
            }

            var authorBook = await _context.AuthorBooks
                .Include(a => a.Author)
                .Include(a => a.Book)
                .FirstOrDefaultAsync(m => m.AuthorBookID == id);
            if (authorBook == null)
            {
                return NotFound();
            }

            return View(authorBook);
        }

        // GET: AuthorBooks/Create
        public IActionResult Create()
        {
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "AuthorID");
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID");
            return View();
        }

        // POST: AuthorBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorID,BookID")] AuthorBook authorBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "AuthorID", authorBook.AuthorID);
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", authorBook.BookID);
            return View(authorBook);
        }

        // GET: AuthorBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AuthorBooks == null)
            {
                return NotFound();
            }

            var authorBook = await _context.AuthorBooks.FindAsync(id);
            if (authorBook == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "AuthorID", authorBook.Author);
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", authorBook.Book);
            return View(authorBook);
        }

        // POST: AuthorBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorID,BookID")] AuthorBook authorBook)
        {
            if (id != authorBook.AuthorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorBookExists(authorBook.AuthorID))
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
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "AuthorID", authorBook.Author);
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", authorBook.Book);
            return View(authorBook);
        }

        // GET: AuthorBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AuthorBooks == null)
            {
                return NotFound();
            }

            var authorBook = await _context.AuthorBooks
                .Include(a => a.Author)
                .Include(a => a.Book)
                .FirstOrDefaultAsync(m => m.AuthorBookID == id);
            if (authorBook == null)
            {
                return NotFound();
            }

            return View(authorBook);
        }

        // POST: AuthorBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AuthorBooks == null)
            {
                return Problem("Entity set 'School_LibraryDbContext.AuthorBooks'  is null.");
            }
            var authorBook = await _context.AuthorBooks.FindAsync(id);
            if (authorBook != null)
            {
                _context.AuthorBooks.Remove(authorBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorBookExists(int id)
        {
          return _context.AuthorBooks.Any(e => e.AuthorBookID == id);
        }
        
        

    }
}
