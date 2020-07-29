using Newtonsoft.Json.Linq;
using OkiraEntity.EntityPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OkiraAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected IHttpActionResult ActionResultWithError(Exception exception, HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            var json = JToken.FromObject(new ResponseError(exception.Message, exception.InnerException?.Message));
            return Content(code, json);
        }
    }
}
