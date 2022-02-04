using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenProvider.TokenAuthentication;

namespace TokenProvider.Filter
{
    public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
    {
       
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenManager = (ITokenManager)context.HttpContext.RequestServices.GetService(typeof(ITokenManager));
            bool result = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
                result = false;
            string token = string.Empty;
            if (result)
            {
                token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;
                if (!tokenManager.VerifyToken(token))
                    result = false;
            }
            else
            {
                context.ModelState.AddModelError("UnAuthorized", "Error");
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }
        }
    }
}
