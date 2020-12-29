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
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        ProductRepository productRepository = new ProductRepository();


        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(productRepository.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var cat = productRepository.Get(id);
            if (cat == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(productRepository.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Tbl_Product product)
        {

            //adminLoginRepository.Insert(Admin);
            productRepository.Insert(product);

            return Created("api/products/" + product.ProductId, product);
        }



        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Tbl_Product producty)
        {

            producty.ProductId = id;
            productRepository.Update(producty);
            return Ok(producty);
        }




        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {

            productRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
