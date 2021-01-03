using Backend_Rest__API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend_Rest__API.Controllers
{
    [RoutePrefix("api/categorys/{id}/products")]
    public class ProductByCategoryController : ApiController
    {
        ProductRepository productRepository = new ProductRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        // Get all Products by Categories 
        [Route("")]
        public IHttpActionResult Get(int id)
        {

            return Ok(productRepository.GetProductsByCategory(id));
        }


        //Get a Specific products from category 
        


    }
}
