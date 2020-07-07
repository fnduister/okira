using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OkiraAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OkiraAPI.Tools
{
    public class AllowAuthenticatedUsers : ActionFilterAttribute
    {
        public string Username { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var authHelper = new BasicAuthHttpModuleHelper();
            var authHeader = HttpContext.Current.Request.Headers["Authorization"];
            try
            {
                var authUsername = authHelper.AuthenticateUser(authHeader);
                if (Username != null && actionContext.ActionArguments.ContainsKey(Username))
                {
                    if (authUsername != actionContext.ActionArguments[Username] as string)
                    {
                        throw new Exception(string.Format("[{0}] {1}", HttpStatusCode.Unauthorized, "Access denied."));
                    }
                }
                base.OnActionExecuting(actionContext);
            }
            catch (Exception ex)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(ex.Message)
            };
            }
        }
    }
}