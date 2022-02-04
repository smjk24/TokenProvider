using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenProvider.Models;
using TokenProvider.TokenAuthentication;

namespace TokenProvider.Api.Controller
{
    [Route("~/Api/Controller/[controller]")]
    [ApiController]
    public class TokenAPiController : ControllerBase
    {
        private readonly ITokenManager tokenManager;
        public ApplicationContext context;

        public TokenAPiController(ITokenManager tokenManager,ApplicationContext db)
        {
            this.tokenManager = tokenManager;
            context = db;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult PostLogin(string user, string psw)
        {
            if (context.Accounts.FirstOrDefault(x => x.UserName.Equals(user) && x.UserPsswd.Equals(psw))!=null)
            {
                return Ok(new { Token = tokenManager.NewToken() });
            }

            //if (tokenManager.Authenticate(user, psw))
            //{
            //    return Ok(new { Token = tokenManager.NewToken() });
            //}
            else
            {
                ModelState.AddModelError("UnAuthorised", "Error");
                return Unauthorized(ModelState);
            }

        }
    }
}
