using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using angProjectTrackingServices.Models;

namespace angProjectTrackingServices.Controllers
{
    public class PTManagerCommentsController : ApiController
    {

        // GET: api/ptmanagercomments
        [Route("api/ptmanagercomments")]
        public IHttpActionResult Get()
        {
            var mgrComments = ManagerCommentsRepository.GetAllManagerComments();
            return Ok(mgrComments);
        }
        // GET: api/ptmanagercomments/5
        [Route("api/ptmanagercomments/{id?}")]
        public IHttpActionResult Get(int id)
        {
            var mgrComments = ManagerCommentsRepository.GetManagerComment(id);
            if (mgrComments != null)
            {
                return Ok(mgrComments);
            }
            else
            {
                return NotFound();
            }
        }


        //// GET: api/ptmanagercomments/raj
        //[Route("api/ptmanagercomments/{name:alpha}")]
        //public IHttpActionResult Get(string name)
        //{
        //    var mgrComments = ManagerCommentsRepository.SearchProjectsByName(name);
        //    if (mgrComments != null)
        //    {
        //        return Ok(mgrComments);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}


        // POST: api/ptmanagercomments
        [Route("api/ptmanagercomments")]
        public IHttpActionResult Post(ManagerComment p)
        {
            var mgrComments = ManagerCommentsRepository.InsertManagerComment(p);
            if (mgrComments != null)
            {
                return Ok(mgrComments);
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/ptmanagercomments/5
        [Route("api/ptmanagercomments")]
        public IHttpActionResult Put(ManagerComment p)
        {
            var mgrComments = ManagerCommentsRepository.UpdateManagerComment(p);
            if (mgrComments != null)
            {
                return Ok(mgrComments);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/ptmanagercomments/5
        [Route("api/ptmanagercomments")]
        public IHttpActionResult Delete(ManagerComment p)
        {
            var mgrComments = ManagerCommentsRepository.DeleteManagerComment(p);
            if (mgrComments != null)
            {
                return Ok(mgrComments);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
