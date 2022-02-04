using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenProvider.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using TokenProvider.Filter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TokenProvider.Controllers
{
    [Route("~/Api/Controller/[controller]")]
    [ApiController]
    public class APITESTController : ControllerBase
    {
        public ApplicationContext _db;

        public APITESTController(ApplicationContext context)
        {
            this._db = context;  
        }
        // GET: api/<ApiController>
        [TokenAuthenticationFilter]
        [HttpGet]
        [Route("Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<ApiController>
        [HttpPost]
        [Route("Login")]
        public IActionResult PostLogin(Account account)
        {
            if (account.UserName == null)
            {
                return BadRequest("Invalid request");
            }
            if (_db.Accounts.FirstOrDefault(x => x.UserName == account.UserName && x.UserPsswd == account.UserPsswd) == null)
            {
                return Unauthorized();
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authnetication"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:2000",
                    audience: "http://localhost:2000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Key = tokenString });
            }
        }
        [Authorize]
        [HttpPost]
        [Route("TokenRoute")]
        public IList<Account> Toks()
        {
            var x = _db.Accounts; 
            return x.ToList();
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
