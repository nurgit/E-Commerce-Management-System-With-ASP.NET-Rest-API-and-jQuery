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
    [RoutePrefix("api/adminlogin")]
    public class AdminLoginController : ApiController
    {
        AdminLoginRepository adminLoginRepository = new AdminLoginRepository();



        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(adminLoginRepository.GetAll());
        }
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var post = adminLoginRepository.Get(id);
            if (post == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(adminLoginRepository.Get(id));
        }

        //--------
        [Route("")]
        public IHttpActionResult Post(AdminLogin Admin)
        {

            //adminLoginRepository.Insert(Admin);
            adminLoginRepository.Insert(Admin);

            return Created("api/AdminLogin/" + Admin.AId, Admin);
        }



        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] AdminLogin Admin)
        {

            Admin.AId= id;
            adminLoginRepository.Update(Admin);
            return Ok(Admin);
        }




        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {

            adminLoginRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
