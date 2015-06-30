using angProjectTrackingServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace angProjectTrackingServices.Controllers
{
    [EnableCors(origins:"http://localhost:55058",headers:"*", methods: "*")]
    public class PTProjectsController : ApiController
    {
        // GET: api/PTProjects
        [Route("api/ptprojects")]
        public IHttpActionResult Get()
        {
            var projects = ProjectsRepository.GetAllProjects();
            return Ok(projects);
        }
        // GET: api/PTProjects/5
        [Route("api/ptprojects/{id?}")]
        public IHttpActionResult Get(int id)
        {
            var project = ProjectsRepository.GetProject(id);
            if (project != null)
            {
                return Ok(project);
            }
            else
            {
                return NotFound();
            }
        }


        // GET: api/PTProjects/raj
        [Route("api/ptprojects/{name:alpha}")]
        public IHttpActionResult Get(string name)
        {
            var project = ProjectsRepository.SearchProjectsByName(name);
            if (project != null)
            {
                return Ok(project);
            }
            else
            {
                return NotFound();
            }
        }


        // POST: api/PTProjects
        [Route("api/ptprojects")]
        public IHttpActionResult Post(Project p)
        {
            var projects = ProjectsRepository.InsertProject(p);
            if (projects != null)
            {
                return Ok(projects);
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/PTProjects/5
        [Route("api/ptprojects")]
        public IHttpActionResult Put(Project p)
        {
            var projects = ProjectsRepository.UpdateProject(p);
            if (projects != null)
            {
                return Ok(projects);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/PTProjects/5
        [Route("api/ptprojects")]
        public IHttpActionResult Delete(Project p)
        {
            var projects = ProjectsRepository.DeleteProject(p);
            if (projects != null)
            {
                return Ok(projects);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
