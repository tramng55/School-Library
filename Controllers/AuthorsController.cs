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
using School_Library.Models.AuthorViewModel;
using School_Library.Models.BookViewModel;
using static System.Reflection.Metadata.BlobBuilder;

namespace School_Library.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly School_LibraryDbContext _context;

        public AuthorsController(School_LibraryDbContext context)
        {
            _context = context;
        }

        // GET: Authors
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

            var authors = from s in _context.Authors
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                authors = authors.Where(s => s.NameAuthor.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    authors = authors.OrderByDescending(s => s.NameAuthor);
                    break;
                default:
                    authors = authors.OrderBy(s => s.NameAuthor);
                    break;
            }
            int pageSize = 10;



            return View(await PaginatedList<Author>.CreateAsync(authors.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .Include(x => x.AuthorBooks)
                .ThenInclude(x => x.Book)
                .FirstOrDefaultAsync(m => m.AuthorID == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID");
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "AuthorID");
            return View();


        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAuthorViewModel createAuthorViewModel)
        {
            if (ModelState.IsValid)
            {
                var author = new Author();
                author.AuthorID = createAuthorViewModel.AuthorID;
                author.NameAuthor = createAuthorViewModel.NameAuthor;
                author.NameBook = createAuthorViewModel.NameBook;
                await _context.Authors.AddAsync(author);
                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "AuthorID", createAuthorViewModel.AuthorID);
            return View(createAuthorViewModel);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);
                
            if (author == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID");
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "AuthorID");

            var editAuthorViewModel = new EditAuthorViewModel();

            return View(editAuthorViewModel);
        }
        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditAuthorViewModel editAuthorViewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var findAuthor = await _context.Authors.FindAsync(id);
                    findAuthor.AuthorID = editAuthorViewModel.AuthorID;
                    findAuthor.NameBook = editAuthorViewModel.NameBook;
                    findAuthor.NameAuthor = editAuthorViewModel.NameAuthor;
                    _context.Authors.Update(findAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists())
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
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "NameAuthor", editAuthorViewModel.AuthorID);
            return View(editAuthorViewModel);
        }

        private bool AuthorExists()
        {
            throw new NotImplementedException();
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuthorID == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Authors == null)
            {
                return Problem("Entity set 'School_LibraryDbContext.Authors'  is null.");
            }
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorID == id);
        }
    }
}