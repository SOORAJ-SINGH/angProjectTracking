using angProjectTrackingService2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace angProjectTrackingService2.Controllers
{
    public class PTUserStoryController : ApiController
    {
        // GET: api/ptuserstories
        [Route("api/ptuserstories")]
        public IHttpActionResult Get()
        {
            var usrStories = UserStoryRepository.GetAllUserStories();
            return Ok(usrStories);
        }
        // GET: api/ptuserstories/5
        [Route("api/ptuserstories/{id?}")]
        public IHttpActionResult Get(int id)
        {
            var usrStories = UserStoryRepository.GetUserStory(id);
            if (usrStories != null)
            {
                return Ok(usrStories);
            }
            else
            {
                return NotFound();
            }
        }


        //// GET: api/PTProjects/raj
        //[Route("api/ptuserstories/{name:alpha}")]
        //public IHttpActionResult Get(string name)
        //{
        //    var usrStories = UserStoryRepository.SearchProjectsByName(name);
        //    if (usrStories != null)
        //    {
        //        return Ok(usrStories);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}


        // POST: api/ptuserstories
        [Route("api/ptuserstories")]
        public IHttpActionResult Post(UserStory p)
        {
            var usrStoriess = UserStoryRepository.InsertUserStory(p);
            if (usrStoriess != null)
            {
                return Ok(usrStoriess);
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/ptuserstories/5
        [Route("api/ptuserstories")]
        public IHttpActionResult Put(UserStory p)
        {
            var usrStoriess = UserStoryRepository.UpdateUserStory(p);
            if (usrStoriess != null)
            {
                return Ok(usrStoriess);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/ptuserstories/5
        [Route("api/ptuserstories")]
        public IHttpActionResult Delete(UserStory p)
        {
            var usrStoriess = UserStoryRepository.DeleteUserStory(p);
            if (usrStoriess != null)
            {
                return Ok(usrStoriess);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
