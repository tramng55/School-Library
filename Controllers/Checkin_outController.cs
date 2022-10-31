using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School_Library.Data;
using School_Library.Models;
using School_Library.Models.Checkin_outViewModel;

namespace School_Library
{
    public class Checkin_outController : Controller
    {
        private readonly School_LibraryDbContext _context;

        public Checkin_outController(School_LibraryDbContext context)
        {
            _context = context;
        }

        // GET: Checkin_out
        public async Task<IActionResult> Index()
        {
            var school_LibraryDbContext = _context.Checkin_outs.Include(c => c.Staff).Include(c => c.Student);


            return View(await school_LibraryDbContext.ToListAsync());
        }

        // GET: Checkin_out/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Checkin_outs == null)
            {
                return NotFound();
            }

            var checkin_out = await _context.Checkin_outs
                .Include(c => c.Staff)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Checkin_outID == id);
            if (checkin_out == null)
            {
                return NotFound();
            }

            return View(checkin_out);
        }

        // GET: Checkin_out/Create
        public IActionResult Create()
        {

            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID");
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "StaffID");
            return View();
        }

        // POST: Checkin_out/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatCheckin_outViewModel creatCheckin_outViewModel)
        {
            if (ModelState.IsValid)
            {
                var checkin_out = new Checkin_out();
                checkin_out.StudentID = creatCheckin_outViewModel.StudentID;
                checkin_out.StaffID = creatCheckin_outViewModel.StaffID;
                checkin_out.To = creatCheckin_outViewModel.To;
                checkin_out.From = creatCheckin_outViewModel.From;
                await _context.Checkin_outs.AddAsync(checkin_out);

                _context.Add(checkin_out);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", creatCheckin_outViewModel.StudentID);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "StaffID", creatCheckin_outViewModel.StaffID);
            return View(creatCheckin_outViewModel);
        }

        // GET: Checkin_out/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Checkin_outs == null)
            {
                return NotFound();
            }

            var checkin_out = await _context.Checkin_outs
                .Include(x => x.Student).Include(x => x.Staff)
                .FirstOrDefaultAsync(x => x.Checkin_outID == id);
            if (checkin_out == null)
            {
                return NotFound();
            }
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID");
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "StaffID");
            
            var editCheckin_outBookViewModel = new EditCheckin_outViewModel();
            

            return View(editCheckin_outBookViewModel);
        }

        // POST: Checkin_out/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditCheckin_outViewModel editCheckin_outViewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var findCheckin_out = await _context.Checkin_outs.FindAsync(id);
                    findCheckin_out.To = editCheckin_outViewModel.To;
                    findCheckin_out.From = editCheckin_outViewModel.From;
                    _context.Checkin_outs.Update(findCheckin_out);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Checkin_outExists())
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

            //ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "StaffID", editCheckin_outBookViewModel.StaffID);
            return View(editCheckin_outViewModel);
        }

        private bool Checkin_outExists()
        {
            throw new NotImplementedException();
        }

        // GET: Checkin_out/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Checkin_outs == null)
            {
                return NotFound();
            }

            var checkin_out = await _context.Checkin_outs
                .Include(x => x.Student)
                .Include(x => x.Staff)
                .FirstOrDefaultAsync(m => m.Checkin_outID == id);
            if (checkin_out == null)
            {
                return NotFound();
            }

            return View(checkin_out);
        }

        // POST: Checkin_out/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Checkin_outs == null)
            {
                return Problem("Entity set 'School_LibraryDbContext.Checkin_outs'  is null.");
            }
            var checkin_out = await _context.Checkin_outs
                .Include(x => x.Student)
                .Include(x => x.Staff)
                .FirstOrDefaultAsync(m => m.Checkin_outID == id);
            if (checkin_out != null)
            {
                _context.Checkin_outs.Remove(checkin_out);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Checkin_outExists(int id)
        {
            return _context.Checkin_outs.Any(e => e.Checkin_outID == id);
        }
    }
}