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
    public class TaskController : ApiController
    {

        TaskBusiness oTaskBusines = new TaskBusiness();


        [HttpGet]
        [Route("api/getAllTasks")]
        public IHttpActionResult Get()
        {
            return Ok(oTaskBusines.GetAllTasks());
        }



        [HttpPost]
        [Route("api/updateTask")]
        public TaskUpdateResult Post(TaskModel oTask)
        {
            return oTaskBusines.UpdateTask(oTask);

        }

    }
}
