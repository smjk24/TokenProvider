using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenProvider.Models;

namespace TokenProvider.Controllers
{
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        protected readonly ApplicationContext dbContext;

        public Controller(ApplicationContext context)
        {
            dbContext = context;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var uName = HttpContext.Session.GetString("username");
            var pWord = HttpContext.Session.GetString("password");
            if(dbContext.Accounts.FirstOrDefault(x => x.UserName == uName && x.UserPsswd == pWord) == null)
            {
                filterContext.Result = new RedirectToActionResult("Index", "Login", null);
                return;
            }

        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

    }
}
