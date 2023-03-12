using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA_LTW.Data;
using DA_LTW.Models;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace DA_LTW.Controllers
{
    public class AccountsController : Controller
    {
        private readonly TourDbContext _db;

        public AccountsController(TourDbContext db)
        {
            _db = db;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            return View();
        }
        
        //Log out
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Accounts");
        }

        //Register
        [HttpPost]
        public IActionResult Register(Customer obj)
        {
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                if (ModelState.IsValid)
                {
                    //Create transaction
                    transaction.CreateSavepoint("BeforeMoreCustomer");

                    _db.Customers.Add(obj);
                    _db.SaveChanges();
                    transaction.Commit();
                    //return to sign up
                    TempData["Success"] = "Customer create successfully";
                    TempData["SDT"] = obj.sdt;
                    return RedirectToAction("Signup");
                }
            }catch(Exception ex)
            {
                //Roll back after save change
                transaction.RollbackToSavepoint("BeforeMoreCustomer");
            }
            return NotFound();
        }

        //[GET] SignUp
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        //Hash password
        private string hash(string password)
        {
            var sha = SHA256.Create();
            var asByteArr = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArr);
            return Convert.ToBase64String(hashedPassword);
        }

        

        //[POST] SignUP 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(Account acc)
        {
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                
                //Create transaction
                transaction.CreateSavepoint("BeforeMoreAccount");

                // hash pw
                //store to temp var
                string StoredPassword = hash(acc.Password);
                    acc.Password = StoredPassword;

                

                //save changes
                
                _db.Accounts.Add(acc);
                _db.SaveChanges();

                //asign role "guest" for user
                UserRole role = new UserRole();
                role.IdAccount = acc.IdAccount;
                role.IdRoles = 2;

                _db.UserRole.Add(role);
                _db.SaveChanges();

                transaction.Commit();

                //return to sign up
                TempData["Success"] = "Account create successfully";

                return RedirectToAction("booking", "Customer");
            }
            catch (Exception ex)
            {
                //Roll back after save change
                transaction.RollbackToSavepoint("BeforeMoreAccount");
            }
            return View(acc);
        }

        //validate user and authorization
        private async void validate(Account modelLogin, Account? check)
        {
            var checkRole = _db.UserRole.FirstOrDefault(x => x.IdAccount == check.IdAccount);
            var role = _db.Roles.FirstOrDefault(x => x.IdRoles == checkRole.IdRoles);

            List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.MobilePhone, modelLogin.sdt),
                    new Claim(ClaimTypes.Role, role.NameRole)

                    // Bánh (Tên bánh, Giá trị)
                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), properties);
        }

        //GET Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //POST login
        [HttpPost]
        public async Task<IActionResult> Login(Account modelLogin)
        {
            //check hash pw vs user sending pw
            var check = _db.Accounts.FirstOrDefault(x => x.sdt == modelLogin.sdt && x.Password == hash(modelLogin.Password));


            if (check == null)
            {
                return NotFound();
            }
            else
            {
                validate(modelLogin, check);

                return RedirectToAction("Index", "Home");
            }

            ViewData["ValidateMessage"] = "user not found";
            return View();
        }

    }
}
