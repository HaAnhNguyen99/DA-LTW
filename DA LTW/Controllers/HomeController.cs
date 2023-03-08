using DA_LTW.Data;
using DA_LTW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DA_LTW.Controllers
{
    public class HomeController : Controller
    {
        private readonly TourDbContext _db;

        public HomeController(TourDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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