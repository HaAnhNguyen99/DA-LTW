using DA_LTW.Data;
using DA_LTW.Models;
using Microsoft.AspNetCore.Mvc;

namespace DA_LTW.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TourDbContext _db;

        public CustomerController(TourDbContext db)
        {
            _db = db;
        }

        //get
        public IActionResult createForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult createForm(Customer obj)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Categories create successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
