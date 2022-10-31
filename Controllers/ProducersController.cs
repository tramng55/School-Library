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
using School_Library.Models.CategoryViewModel;
using School_Library.Models.ProducerViewModel;

namespace School_Library.Controllers
{
    public class ProducersController : Controller
    {
        private readonly School_LibraryDbContext _context;

        public ProducersController(School_LibraryDbContext context)
        {
            _context = context;
        }

        // GET: Producers
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

            var producers = from s in _context.producers
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                producers = producers.Where(s => s.NameProducer.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    producers = producers.OrderByDescending(s => s.NameProducer);
                    break;
                default:
                    producers = producers.OrderBy(s => s.NameProducer);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<Producer>.CreateAsync(producers.AsNoTracking(), pageNumber ?? 1, pageSize));

        }
        // GET: Producers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.producers == null)
            {
                return NotFound();
            }

            var producer = await _context.producers
                .FirstOrDefaultAsync(m => m.ProducerID == id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        // GET: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProducerViewModel createProducerViewModel)
        {
            if (ModelState.IsValid)
            {
                var producer = new Producer();
                producer.ProducerID = createProducerViewModel.ProducerID;
                producer.NameProducer = createProducerViewModel.NameProducer;
                producer.Address = createProducerViewModel.Address;
                producer.Email = createProducerViewModel.Email;
                await _context.producers.AddAsync(producer);
                _context.Add(producer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProducerID"] = new SelectList(_context.producers, "NameProducer", "NameProducer", createProducerViewModel.ProducerID);
            return View(createProducerViewModel);
        }

        // GET: Producers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.producers == null)
            {
                return NotFound();
            }

            var producer = await _context.producers.FindAsync(id);
            if (producer == null)
            {
                return NotFound();
            }

            var editProducerViewModel = new EditProducerViewModel();

            return View(editProducerViewModel);
        }

        // POST: Producers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProducerViewModel editProducerViewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var findProducer = await _context.producers.FindAsync(id);
                    findProducer.NameProducer = editProducerViewModel.NameProducer;
                    findProducer.Address = editProducerViewModel.Address;
                    findProducer.Email = editProducerViewModel.Email;
                    _context.producers.Update(findProducer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducerExists())
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
            return View(editProducerViewModel);
        }

        private bool ProducerExists()
        {
            throw new NotImplementedException();
        }

        // GET: Producers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.producers == null)
            {
                return NotFound();
            }

            var producer = await _context.producers
                .FirstOrDefaultAsync(m => m.ProducerID == id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        // POST: Producers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.producers == null)
            {
                return Problem("Entity set 'School_LibraryDbContext.producers'  is null.");
            }
            var producer = await _context.producers.FindAsync(id);
            if (producer != null)
            {
                _context.producers.Remove(producer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducerExists(int id)
        {
          return _context.producers.Any(e => e.ProducerID == id);
        }
    }
}
