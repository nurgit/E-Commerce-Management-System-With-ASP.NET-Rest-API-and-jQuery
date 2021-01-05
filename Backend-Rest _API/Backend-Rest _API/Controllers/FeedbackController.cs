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
    [RoutePrefix("api/feedbacks")]
    public class FeedbackController : ApiController
    {
        FeedbackRepository feedbackRepository = new FeedbackRepository();




        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(feedbackRepository.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var fb = feedbackRepository.Get(id);
            if (fb == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            fb.Links.Add(new Link() { Url = "http://localhost:9799/api/adminlogin", Method = "GET", Relation = "Get All feedbacks" });
            fb.Links.Add(new Link() { Url = "http://localhost:9799/api/adminlogin", Method = "Post", Relation = "Create New feedbacks" });
            fb.Links.Add(new Link() { Url = HttpContext.Current.Request.Url.AbsoluteUri.ToString(), Method = "GET", Relation = "Self" });
            fb.Links.Add(new Link() { Url = HttpContext.Current.Request.Url.AbsoluteUri.ToString(), Method = "Put", Relation = "Modify exsisting feedbacks" });
            fb.Links.Add(new Link() { Url = HttpContext.Current.Request.Url.AbsoluteUri.ToString(), Method = "Delete", Relation = "Remove exsisting feedbacks" });
            return Ok(feedbackRepository.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Feedback feedback)
        {

            feedbackRepository.Insert(feedback);

            return Created("api/categorys/" + feedback.FeedbackId, feedback);
        }



        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Feedback feedback)
        {

            feedback.FeedbackId = id;
            feedbackRepository.Update(feedback);
            return Ok(feedback);
        }




        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {

            feedbackRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
