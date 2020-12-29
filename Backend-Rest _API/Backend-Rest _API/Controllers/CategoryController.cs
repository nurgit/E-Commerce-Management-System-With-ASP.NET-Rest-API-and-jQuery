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
    [RoutePrefix("api/categorys")]
    public class CategoryController : ApiController
    {
        CategoryRepository categoryrepository = new CategoryRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(categoryrepository.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var cat = categoryrepository.Get(id);
            if (cat == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(categoryrepository.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Tbl_Category category)
        {

            //adminLoginRepository.Insert(Admin);
            categoryrepository.Insert(category);

            return Created("api/categorys/" + category.CategoryId, category);
        }



        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Tbl_Category category)
        {

            category.CategoryId = id;
            categoryrepository.Update(category);
            return Ok(category);
        }




        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {

            categoryrepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
