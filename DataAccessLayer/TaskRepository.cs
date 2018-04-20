using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System.Data.Entity;

namespace DataAccessLayer
{
   public class TaskRepository
    {
        public List<Task> GetAllTasks()
        {
            using (var context = new ProjectManagerContext())
            {
               return context.Tasks.Include(x=>x.User).Include(x=>x.Project).ToList();
            }
        }
        public Task AddTask(Task oTask)
        {
            using (var context = new ProjectManagerContext())
            {
                oTask= context.Tasks.Add(oTask);
                context.SaveChanges();
                return oTask;
            }
        }
        public Task UpdateTask(Task oTask)
        {
            using (var context = new ProjectManagerContext())
            {
                oTask= context.Tasks.Attach(oTask);
                context.Entry(oTask).State = EntityState.Modified;
                context.SaveChanges();
                return oTask;
            }
        }
        
    }
}
