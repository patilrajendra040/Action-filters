using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace FiltersDemo.AuthData
{
    public class AuthAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        private bool _Auth;
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //Logic for authenticating a user

            _Auth = (filterContext.ActionDescriptor.GetCustomAttributes
                (typeof(OverrideAuthenticationAttribute), true).Length == 0);
        }

        //Runs after the OnAuthentication method  
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //TODO: Additional tasks on the request  
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}