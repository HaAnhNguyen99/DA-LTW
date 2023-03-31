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
using System.Security.Claims;

namespace DA_LTW.Controllers
{
    [Authorize]
    public class ToursController : Controller
    {
        private readonly TourDbContext _context;

        public ToursController(TourDbContext context)
        {
            _context = context;
        }

        // GET: Tours
        public async Task<IActionResult> Index()
        {
              return _context.Tours != null ? 
                          View(await _context.Tours.ToListAsync()) :
                          Problem("Entity set 'TourDbContext.Tours'  is null.");
        }

        //Booking tour
        public async Task<IActionResult> Booking(int id)
        {
            var principal = HttpContext.User as ClaimsPrincipal;
            var sdt = principal?.Claims
              .First(c => c.Type == ClaimTypes.MobilePhone).Value.ToString();

            //begin transaction for add order
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (ModelState.IsValid)
                {
                    //Create transaction
                    transaction.CreateSavepoint("BeforeMoreOrder");

                    //create order
                    Order newOr = new Order()
                    {
                        IdTour = id,
                        sdt = sdt
                    };

                    //save changes
                    _context.Orders.Add(newOr);
                    _context.SaveChanges();
                    transaction.Commit();
                    return Content("Booking tour success. Please wait until our confirm email");
                }
                /*if (User.Identity.IsAuthenticated)
                {
                    var ten = principal?.Claims.First(c => c.Type == ClaimTypes.Name).Value.ToString();
                }*/
            }

            catch (Exception ex)
            {
                //Roll back after save change
                transaction.RollbackToSavepoint("BeforeMoreOrder");
            }
            return NotFound();
        }

        // GET: Tours/Details
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


        [Authorize(Roles ="admin")]
        public IActionResult Create()
        {
            return View();
        }

        //POST: Tours/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTour,Name_tour,People,Tour_guide,stay,Difficult,CreateDateTime,Started_date,Price,TotalDay")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tour);
        }

        // GET: Tours/Edit/5
        [Authorize(Roles = "admin")]
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

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTour,Name_tour,Detail,People,Tour_guide,stay,Difficult,CreateDateTime,Started_date,Price,TotalDay")] Tour tour)
        {
            if (id != tour.IdTour)
            {
                return NotFound();
            }

            try
            {
                _context.Update(tour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
            return View(tour);
        }

        // GET: Tours/Delete/5
        [Authorize(Roles = "admin")]    
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

        // POST: Tours/Delete/5
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
