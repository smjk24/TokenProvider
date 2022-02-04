using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenProvider.Models;

namespace TokenProvider.Controllers
{
    public class LoginController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ApplicationContext db;

        public LoginController(ApplicationContext option)     
        {
            this.db = option;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Account account)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("username", account.UserName);
                HttpContext.Session.SetString("password", account.UserPsswd);
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(account);
            } 
        }
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("username", "");
            return Redirect("Index");
        }

    }
}
