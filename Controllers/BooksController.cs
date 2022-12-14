using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using School_Library.Common;
using School_Library.Data;
using School_Library.Models;
using School_Library.Models.BookViewModel;
using static System.Reflection.Metadata.BlobBuilder;

namespace School_Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly School_LibraryDbContext _context;

        public BooksController(School_LibraryDbContext context)
        {
            _context = context;
        }

        // GET: Books
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

            var books = _context.Books.Include(x => x.Category)
                .Include(x => x.AuthorBooks)
                .ThenInclude(x => x.Author)
                .AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.NameBook.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    books = books.OrderByDescending(s => s.NameBook);
                    break;
                default:
                    books = books.OrderBy(s => s.NameBook);
                    break;
            }
            int pageSize = 10;


            var bookViewModel = await books.Select(book => new BookViewModel
            {
                BookID = book.BookID,
                NameBook = book.NameBook,
                Category = book.Category,
                Authors = book.AuthorBooks
                .Select(authorBook => authorBook.Author).ToList()
            }).ToListAsync();

            ViewData["BookViewModel"] = bookViewModel;

            return View(await PaginatedList<Book>.CreateAsync(books.AsNoTracking(), pageNumber ?? 1, pageSize));

        }


        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)

            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .Include(x => x.AuthorBooks)
                .ThenInclude(x => x.Author)
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (book == null)

            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            var authors = _context.Authors;

            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "NameAuthor");
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "NameCategory");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookViewModel createBookViewModel)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(createBookViewModel);


                var book = new Book();
                book.CategoryID = createBookViewModel.CategoryID;
                book.NameBook = createBookViewModel.NameBook;


                book.AuthorBooks = new List<AuthorBook>();
                foreach (var item in createBookViewModel.AuthorIDs)
                {
                    var authorBook = new AuthorBook();
                    authorBook.AuthorID = item;

                    book.AuthorBooks.Add(authorBook);
                }
                await _context.Books.AddAsync(book);

                //await _context.AuthorBooks.AddRangeAsync(authorbooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "NameCategory", createBookViewModel.CategoryID);
            return View(createBookViewModel);
        }


        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(x => x.AuthorBooks)
                .ThenInclude(x => x.Author)
                .FirstOrDefaultAsync(m => m.BookID == id);  


            if (book == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.ToListAsync();

            ViewData["AuthorID"] = new SelectList(authors, "AuthorID", "NameAuthor");
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "NameCategory");

            var editBookViewModel = new EditBookViewModel()
            {
                //Authors = book.AuthorBooks.Select(x => new EditAuthorBookViewModel
                //{
                //    Id = x.Author.AuthorID,
                //    NameAuthor = x.Author.NameAuthor,
                //    IsChecked = true
                //}).ToList(),
                Authors = authors.Select(x => new EditAuthorBookViewModel
                {
                    Id = x.AuthorID,
                    NameAuthor = x.NameAuthor,
                    IsChecked = book.AuthorBooks.Any(k => k.AuthorID == x.AuthorID)
                }).ToList(),
                CategoryID = book.CategoryID,
                NameBook = book.NameBook
            };

            ViewData["SelectedAuthors"] = book.AuthorBooks.Select(x => x.Author).ToList();


            return View(editBookViewModel);
        }


        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditBookViewModel editBookViewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var findBook = await _context.Books
                          .Include(x => x.AuthorBooks)
                          .ThenInclude(x => x.Author)
                          .FirstOrDefaultAsync(x => x.BookID == id);
                    findBook.NameBook = editBookViewModel.NameBook;


                    if (editBookViewModel.Authors.Count > 0)
                    {
                        editBookViewModel.Authors = editBookViewModel.Authors.Where(x => x.IsChecked == true).ToList();

                        var dbAuthorsId = findBook.AuthorBooks.Select(x => x.AuthorID).ToList();
                        var findAuthorExists = editBookViewModel.Authors
                            .Where(x => dbAuthorsId.Contains(x.Id))
                            .Select(x => x.Id)
                            .ToList();
                        var filterInDb = findBook.AuthorBooks.Where(x => !findAuthorExists.Contains(x.AuthorID))
                            .Select(x => x.AuthorID)
                            .ToList();
                        var filterInView = editBookViewModel.Authors.Where(x => !dbAuthorsId.Contains(x.Id))
                            .Select(x => x.Id)
                            .ToList();

                        foreach (var item in filterInDb)
                          {
                            var remove = findBook.AuthorBooks.FirstOrDefault(x => x.AuthorID == item );
                            if (remove != null)
                            {
                                findBook.AuthorBooks.Remove(remove);
                            }
                        }

                        foreach (var item in filterInView)
                        {
                            var authorBook = new AuthorBook();
                            authorBook.AuthorID = item;
                            findBook.AuthorBooks.Add(authorBook);

                        }

                        //foreach (var item in editBookViewModel.Authors)
                        //{ 
                        //    var findAuthor = findBook.AuthorBooks.FirstOrDefault(x => x.AuthorBookID == item.Id && x.BookID == findBook.BookID);
                        //    if (findAuthor == null)
                        //    {
                        //        var authorBook = new AuthorBook();
                        //        authorBook.AuthorID = item.Id;
                        //        findBook.AuthorBooks.Add(authorBook);                     
                        //    }

                        //}
                    }
                    _context.Books.Update(findBook); 
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists())
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

            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "NameCategory", editBookViewModel.CategoryID);
            return View(editBookViewModel);
        }

        private bool BookExists()
        {
            throw new NotImplementedException();
        }




        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .Include(x => x.AuthorBooks)
                .ThenInclude(x => x.Author)
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'School_LibraryDbContext.Books'  is null.");
            }
            var book = await _context.Books
                .Include(x => x.AuthorBooks)
                .ThenInclude(x => x.Author)
                .FirstOrDefaultAsync(x => x.BookID == id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }

    }
}