using Backend_Rest__API.Models;
using Backend_Rest__API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend_Rest__API.Controllers
{   [RoutePrefix("api/carts")]
    public class CartController : ApiController
    {
        CartRepository cartrepository = new CartRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(cartrepository.GetAll());
        }
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var post = cartrepository.Get(id);
            if (post == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(cartrepository.Get(id));
        }

        //--------
        [Route("")]
        public IHttpActionResult Post(Tbl_Cart cart)
        {

            //adminLoginRepository.Insert(Admin);
            cartrepository.Insert(cart);

            return Created("api/carts/" + cart.CartId, cart);
        }



        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Tbl_Cart cart)
        {

            cart.CartId = id;
            cartrepository.Update(cart);
            return Ok(cart);
        }




        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {

            cartrepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
