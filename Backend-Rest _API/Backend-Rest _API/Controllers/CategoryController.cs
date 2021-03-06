﻿using Backend_Rest__API.Models;
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
            cat.Links.Add(new Link() { Url = "http://localhost:9799/api/categorys", Method = "GET", Relation = "Get All Cetegory" });
            cat.Links.Add(new Link() { Url = "http://localhost:9799/api/categorys", Method = "Post", Relation = "Create New Cetegory" });
            cat.Links.Add(new Link() { Url = HttpContext.Current.Request.Url.AbsoluteUri.ToString(), Method = "GET", Relation = "Self" });
            cat.Links.Add(new Link() { Url = HttpContext.Current.Request.Url.AbsoluteUri.ToString(), Method = "Put", Relation = "Modify exsisting Category" });
            cat.Links.Add(new Link() { Url = HttpContext.Current.Request.Url.AbsoluteUri.ToString(), Method = "Delete", Relation = "Remove exsisting Category" });
           
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

