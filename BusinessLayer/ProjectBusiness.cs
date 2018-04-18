using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLayer
{
    public class ProjectBusiness
    {
        ProjectRepository repoProject = new ProjectRepository();
        public List<ProjectModel> GetAllProject()
        {
            return repoProject.GetAllProject().Select(x => new ProjectModel
            {
                Project_ID = x.Project_ID,
                ProjectName = x.Project1,
                Priority = x.Priority,
                End_Date = x.End_Date,
                Manager_ID = x.Users.FirstOrDefault(y => y.Project_ID == x.Project_ID)?.User_ID,
                Manager_Name = x.Users.FirstOrDefault(y => y.Project_ID == x.Project_ID)?.First_Name + " " + x.Users.FirstOrDefault(y => y.Project_ID == x.Project_ID)?.Last_Name,
                NumberOfTasks = x.Tasks.Count,
                Start_Date = x.Start_Date,
                Status = x.Status

            }).ToList();
        }

        public ProjectUpdateResult UpdateProject(ProjectModel oProj)
        {
            Status oStatus = new Status();
            Project proj = new Project()
            {
                End_Date = oProj.End_Date,
                Priority = oProj.Priority,
                Project1 = oProj.ProjectName,
                Start_Date = oProj.Start_Date,
                Status = oProj.Status

            };
            if (oProj.Project_ID == 0)
            {
                proj = repoProject.AddProject(proj);
                oStatus = new Status() { Message = "Project added successfully", Result = true };
            }
            else
            {
                proj.Project_ID = oProj.Project_ID;
                proj = repoProject.UpdateProject(proj);
                oStatus = new Status() { Message = "Project updated successfully", Result = true };
            }

            return new ProjectUpdateResult()
            {
                status = oStatus,
                project = new ProjectModel
                {
                    Project_ID = proj.Project_ID,
                    ProjectName = proj.Project1,
                    Priority = proj.Priority,
                    End_Date = proj.End_Date,
                    Manager_ID = proj.Users.FirstOrDefault(y => y.Project_ID == proj.Project_ID)?.User_ID,
                    Manager_Name = proj.Users.FirstOrDefault(y => y.Project_ID == proj.Project_ID)?.First_Name + " " + proj.Users.FirstOrDefault(y => y.Project_ID == proj.Project_ID)?.Last_Name,
                    NumberOfTasks = proj.Tasks.Count,
                    Start_Date = proj.Start_Date,
                    Status = proj.Status
                }
            };

        }

    }
}
