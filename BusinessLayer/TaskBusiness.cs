using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessEntities;
namespace BusinessLayer
{
   public class TaskBusiness
    {
        TaskRepository repoTask = new TaskRepository();
        ParentTaskRepository parent = new ParentTaskRepository();
        public List<TaskModel> GetAllTasks()
        {
            return repoTask.GetAllTasks().Select(x => new TaskModel
            {
                End_Date = x.End_Date,
                Parent_ID = x.Parent_ID,
                Parent_Name = x.ParentTask?.Parent_Task,
                Priority = x.Priority,
                Project_ID = x.Project_ID,
                Project_Name = x.Project.Project1,
                Start_Date = x.Start_Date,
                Status = x.Status,
                TaskName = x.Task1,
                Task_ID = x.Task_ID,
                User_ID = x.User_ID,
                User_Name = x.User?.First_Name + " " + x.User?.Last_Name


            }).ToList();
        }

        public List<ParentTaskModel> GetAllParentTasks()
        {
            return parent.GetAllTasks().Select(x => new ParentTaskModel
            {

                Parent_ID = x.Parent_ID,
                Parent_Name = x.Parent_Task

            }).ToList();
        }
        public TaskUpdateResult UpdateTask(TaskModel oTask)
        {
            Status oStatus = new Status();
            if(oTask.Parent_ID==null)
            {
                
                ParentTask oParent = new ParentTask()
                {
                    Parent_Task = oTask.TaskName
                };
                oParent=parent.AddParentTask(oParent);
                oTask.Parent_ID = oParent.Parent_ID;
            }
            DataAccessLayer.Task task = new DataAccessLayer.Task()
            {
                End_Date = oTask.End_Date,
                Parent_ID = oTask.Parent_ID,
                Priority = oTask.Priority,
                Project_ID = oTask.Project_ID,
                Start_Date = oTask.Start_Date,
                Status = oTask.Status,
                Task1 = oTask.TaskName,
                User_ID = oTask.User_ID
            };
            if (oTask.Task_ID == 0)
            {
                task = repoTask.AddTask(task);
                oStatus = new Status() { Message = "Task added successfully", Result = true };
            }
            else
            {
                task.Task_ID = oTask.Task_ID;
               task= repoTask.UpdateTask(task);
                oStatus = new Status() { Message = "Task updated successfully", Result = true };
            }

            return new TaskUpdateResult()
            {
                status = oStatus,
                task = null
            };

        }

       
    }
}
