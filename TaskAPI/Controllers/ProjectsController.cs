using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TaskAPI.Models.BOL;
using TaskAPI.Models.DAL;

namespace TaskAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:63129", "*", "*")]
    public class ProjectsController : ApiController
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: api/Projects
        [HttpGet]
        [Route("api/getAllProjects")]
        public List<Project> getAllProjects()
        {
            return db.Project.GetAll().ToList();
        }
    }
}