using DA_LTW.Data;
using DA_LTW.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DA_LTW.Controllers
{
    [Authorize(Roles = "guest")]
    public class CustomerController : Controller
    {
        private readonly TourDbContext _db;

        public CustomerController(TourDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        //get
        public IActionResult booking()
        {
            IEnumerable<Tour> objCategoryList = _db.Tours;
            return View(objCategoryList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult createForm(Customer obj)
        {
            return View(obj);
        }


    }
}
