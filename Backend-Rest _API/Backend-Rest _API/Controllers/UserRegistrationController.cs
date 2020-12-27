﻿using Backend_Rest__API.Models;
using Backend_Rest__API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend_Rest__API.Controllers
{
    [RoutePrefix("api/userregistration")]
    public class UserRegistrationController : ApiController
    {
        UserRegistrationRepository userRegistrationRepository = new UserRegistrationRepository();
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(userRegistrationRepository.GetAll());
        }
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var post = userRegistrationRepository.Get(id);
            if (post == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(userRegistrationRepository.Get(id));
        }

        //--------
        [Route("")]
        public IHttpActionResult Post(UserRegistration user)
        {

            userRegistrationRepository.Insert(user);
            return Created("api/userregistration/" + user.UId, user);
        }



        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] UserRegistration user)
        {

            user.UId = id;
            userRegistrationRepository.Update(user);
            return Ok(user);
        }



        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {

            userRegistrationRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


    }
}
