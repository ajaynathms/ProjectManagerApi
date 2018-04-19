using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System.Data.Entity;

namespace DataAccessLayer
{
   public class ProjectRepository
    {
        public List<Project> GetAllProject()
        {
            using (var context = new ProjectManagerContext())
            {
               return context.Projects.Where(x=>x.Status=="Active").Include(x=>x.Users).Include(x=>x.Tasks).ToList();
            }
        }
        public Project AddProject(Project oProject)
        {
            using (var context = new ProjectManagerContext())
            {
                oProject= context.Projects.Add(oProject);
                context.SaveChanges();
                return oProject;
            }
        }
        public Project UpdateProject(Project oProject)
        {
            using (var context = new ProjectManagerContext())
            {
                context.Projects.Attach(oProject);
                context.Entry(oProject).State = EntityState.Modified;
                context.SaveChanges();
                return oProject;
            }
        }
       
    }
}
