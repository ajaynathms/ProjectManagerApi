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
        public IEnumerable<TaskModel> Get()
        {
            return oTaskBusines.GetAllTasks();
        }

        [HttpGet]
        [Route("api/getAllParentTasks")]
        public IHttpActionResult GetParentTasks()
        {
            return Ok(oTaskBusines.GetAllParentTasks());
        }


        [HttpPost]
        [Route("api/updateTask")]
        public TaskUpdateResult Post(TaskModel oTask)
        {
            return oTaskBusines.UpdateTask(oTask);

        }

    }
}
