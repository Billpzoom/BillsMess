using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Bill.Domain.Auth;
using Bill.IApplication;
using Bill.WebApi.Models;

namespace Bill.WebApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("login")]
        [ResponseType(typeof(ResultViewModel<User>))]
        public HttpResponseMessage Login([FromBody] LoginRequestViewModel request)
        {
            var result = new ResultViewModel<User>();
            try
            {
                var user = AutofacConfig.Resolve<IUserService>().Login(request.Username, request.Password);
                result.Code = "200";
                result.Message = "OK";
                result.Data = user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
