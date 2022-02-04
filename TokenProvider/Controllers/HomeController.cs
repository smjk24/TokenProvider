using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenProvider.Models;

namespace TokenProvider.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ApplicationContext option) : base(option)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
