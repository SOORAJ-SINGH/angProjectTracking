using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using angProjectTrackingService2.Models;

namespace angProjectTrackingService2.Controllers
{
    public class PTProjectTasksController : ApiController
    {
        // GET: api/ptprojecttasks
        [Route("api/ptprojecttasks")]
        public IHttpActionResult Get()
        {
            var prjTasks = ProjectTasksRepository.GetAllProjectTasks();
            return Ok(prjTasks);
        }
        // GET: api/ptprojecttasks/5
        [Route("api/ptprojecttasks/{id?}")]
        public IHttpActionResult Get(int id)
        {
            var prjTasks = ProjectTasksRepository.GetProjectTask(id);
            if (prjTasks != null)
            {
                return Ok(prjTasks);
            }
            else
            {
                return NotFound();
            }
        }


        //// GET: api/ptprojecttasks/raj
        //[Route("api/ptprojecttasks/{name:alpha}")]
        //public IHttpActionResult Get(string name)
        //{
        //    var prjTasks = ProjectTasksRepository.SearchProjectsByName(name);
        //    if (prjTasks != null)
        //    {
        //        return Ok(prjTasks);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}


        // POST: api/ptprojecttasks
        [Route("api/ptprojecttasks")]
        public IHttpActionResult Post(ProjectTask p)
        {
            var prjTasks = ProjectTasksRepository.InsertProjectTask(p);
            if (prjTasks != null)
            {
                return Ok(prjTasks);
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/ptprojecttasks/5
        [Route("api/ptprojecttasks")]
        public IHttpActionResult Put(ProjectTask p)
        {
            var prjTasks = ProjectTasksRepository.UpdateProject(p);
            if (prjTasks != null)
            {
                return Ok(prjTasks);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/ptprojecttasks/5
        [Route("api/ptprojecttasks")]
        public IHttpActionResult Delete(ProjectTask p)
        {
            var prjTasks = ProjectTasksRepository.DeleteProject(p);
            if (prjTasks != null)
            {
                return Ok(prjTasks);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
