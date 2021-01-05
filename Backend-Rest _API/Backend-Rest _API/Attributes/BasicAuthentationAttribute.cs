using Backend_Rest__API.Models;
using Backend_Rest__API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Backend_Rest__API.Attributes
{
    public class BasicAuthentationAttribute:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string encodedString = actionContext.Request.Headers.Authorization.Parameter;
                string decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(encodedString));
                string[] splittext = decodedString.Split(new char[] { ':'});
                string username = splittext[0];
                string parword = splittext[0];
                // AdminLoginRepository admin = new AdminLoginRepository();

                AdminLogin adminLogin = new AdminLogin();
                if(adminLogin.AUserName==username && adminLogin.APassword==parword)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);

                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}