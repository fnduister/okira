using OkiraAPI.DAL;
using OkiraAPI.Tools;
using OkiraEntity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OkiraAPI.Controllers
{
    [RoutePrefix("api")]
    public class LoginController : BaseController
    {
        [Route("login/{username}")]
        [AllowAuthenticatedUsers(Username = "username")]
        public IHttpActionResult Login(string username, string password)
        {
            try
            {
                User user = UserDataAcces.Login(username, password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return ActionResultWithError(ex);
            }
        }
    }
}
