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

    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {
        OrderRepository orderRepository = new OrderRepository();
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(orderRepository.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var cat = orderRepository.Get(id);
            if (cat == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(orderRepository.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Order order)
        {

            //adminLoginRepository.Insert(Admin);
            orderRepository.Insert(order);

            return Created("api/categorys/" + order.OrderId, order);
        }



        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Order order)
        {

            order.OrderId = id;
            orderRepository.Update(order);
            return Ok(order);
        }




        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {

            orderRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
