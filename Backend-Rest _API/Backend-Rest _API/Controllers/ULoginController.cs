using Backend_Rest__API.Models;
using Backend_Rest__API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend_Rest__API.Controllers
{
    [RoutePrefix("api/ulogin")]
    public class ULoginController : ApiController
    {
        UserRegistrationRepository userRegistrationRepository = new UserRegistrationRepository();
        [Route("")]
        public IHttpActionResult Post(UserRegistration user)
        {
            UserRegistration logggedInUser = userRegistrationRepository.GetAll().Where(s => s.Uname == user.Uname && s.Upassword == user.Upassword).FirstOrDefault();
            if (logggedInUser != null)
            {
                return Ok(logggedInUser);
            }
            return StatusCode(HttpStatusCode.Unauthorized);
        }
    }
}
