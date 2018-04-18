using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessLayer;
namespace ProjectManagerApi.Controllers
{
    public class ProjectController : ApiController
    {
        ProjectBusiness oProject = new ProjectBusiness();
        [HttpGet]
        [Route("api/getAllProjects")]
        public IHttpActionResult Get()
        {
            return Ok(oProject.GetAllProject());
        }



        [HttpPost]
        [Route("api/updateProject")]
        public ProjectUpdateResult Post(ProjectModel oProj)
        {
            return oProject.UpdateProject(oProj);

        }
    }
}