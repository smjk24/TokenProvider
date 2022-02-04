using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenProvider.Models;

namespace TokenProvider.TokenAuthentication
{
    public class TokenManager : ITokenManager
    {
        private List<Token> listToken;
       // private readonly ApplicationContext _dbContext;
        public TokenManager()
        {
           // _dbContext = context;
            listToken = new List<Token>();
        }
        //public bool Authenticate(string userName, string password)
        //{
        //    if (_dbContext.Accounts.FirstOrDefault(x => x.UserName == userName && x.UserPsswd == password) == null)
        //        if (!string.IsNullOrWhiteSpace(userName) &&
        //            !string.IsNullOrWhiteSpace(password) &&
        //            userName.ToLower() == "admin" &&
        //            password == "password")
        //            return true;
        //        else
        //            return false;
        //    else
        //        return false;
        //}
        public Token NewToken()
        {
            var token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                ExpiryDate = DateTime.Now.AddHours(1)
            };
            listToken.Add(token);
            return token;
        }
        public bool VerifyToken(string token)
        {
            if (listToken.Any(x => x.Value == token &&
             x.ExpiryDate > DateTime.Now))
                return true;
            else
                return false;

        }
    }
}
