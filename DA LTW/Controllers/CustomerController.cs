using DA_LTW.Data;
using DA_LTW.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DA_LTW.Controllers
{
    [Authorize(Roles = "admin")]
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult createForm(Customer obj)
        {
            return View(obj);
        }


    }
}
