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
    [RoutePrefix("api/alogin")]
    public class ALoginController : ApiController
    {
      
        AdminLoginRepository adminLoginRepository = new AdminLoginRepository();
        [Route("")]
        public IHttpActionResult Post(AdminLogin Admin)
        {
            AdminLogin logggedInUser = adminLoginRepository.GetAll().Where(s => s.AUserName == Admin.AUserName && s.APassword == Admin.APassword).FirstOrDefault();
            if (logggedInUser != null)
            {
                return Ok(logggedInUser);
            }
            return StatusCode(HttpStatusCode.Unauthorized);
        }
    }
}
