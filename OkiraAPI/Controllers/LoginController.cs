using OkiraAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OkiraAPI.Controllers
{
    [RoutePrefix("api")]
    public class LoginController : ApiController
    {
        [Route("login/{username}")]
        [AllowAuthenticatedUsers(Username = "username")]
        public IHttpActionResult Login(string username)
        {
            //En attente 
            return Ok();
        }
    }
}
