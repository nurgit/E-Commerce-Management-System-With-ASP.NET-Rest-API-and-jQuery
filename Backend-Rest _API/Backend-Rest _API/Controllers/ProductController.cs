using Backend_Rest__API.Models;
using Backend_Rest__API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
            var pduct = productRepository.Get(id);
            if ( pduct== null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            pduct.Links.Add(new Link() { Url = "http://localhost:9799/api/adminlogin", Method = "GET", Relation = "Get All products" });
            pduct.Links.Add(new Link() { Url = "http://localhost:9799/api/adminlogin", Method = "Post", Relation = "Create New products" });
            pduct.Links.Add(new Link() { Url = HttpContext.Current.Request.Url.AbsoluteUri.ToString(), Method = "GET", Relation = "Self" });
            pduct.Links.Add(new Link() { Url = HttpContext.Current.Request.Url.AbsoluteUri.ToString(), Method = "Put", Relation = "Modify exsisting products" });
            pduct.Links.Add(new Link() { Url = HttpContext.Current.Request.Url.AbsoluteUri.ToString(), Method = "Delete", Relation = "Remove exsisting products" });
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
