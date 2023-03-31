using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA_LTW.Data;
using DA_LTW.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace DA_LTW.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ToursController : Controller
    {
        private readonly TourDbContext _context;

        public ToursController(TourDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Tours
        public async Task<IActionResult> Index()
        {
              return _context.Tours != null ? 
                          View(await _context.Tours.ToListAsync()) :
                          Problem("Entity set 'TourDbContext.Tours'  is null.");
        }

        // GET: Admin/Tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tours == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .FirstOrDefaultAsync(m => m.IdTour == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // GET: Admin/Tours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTour,Name_tour,People,Tour_guide,Detail,stay,Difficult,CreateDateTime,Started_date,Price,TotalDay,ImgURL")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tour);
        }

        // GET: Admin/Tours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tours == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }
            return View(tour);
        }

        // POST: Admin/Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTour,Name_tour,People,Tour_guide,Detail,stay,Difficult,CreateDateTime,Started_date,Price,TotalDay,ImgURL")] Tour tour)
        {
            if (id != tour.IdTour)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourExists(tour.IdTour))
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
            return View(tour);
        }

        // GET: Admin/Tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tours == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .FirstOrDefaultAsync(m => m.IdTour == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // POST: Admin/Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tours == null)
            {
                return Problem("Entity set 'TourDbContext.Tours'  is null.");
            }
            var tour = await _context.Tours.FindAsync(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourExists(int id)
        {
          return (_context.Tours?.Any(e => e.IdTour == id)).GetValueOrDefault();
        }
    }
}
