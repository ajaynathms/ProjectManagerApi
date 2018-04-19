using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ParentTaskRepository
    {
        public List<ParentTask> GetAllTasks()
        {
            using (var context = new ProjectManagerContext())
            {
                return context.ParentTasks.ToList();
            }
        }
        public ParentTask AddParentTask(ParentTask oTask)
        {
            using (var context = new ProjectManagerContext())
            {
                oTask = context.ParentTasks.Add(oTask);
                context.SaveChanges();
                return oTask;
            }
        }
        public ParentTask UpdateParentTask(ParentTask oTask)
        {
            using (var context = new ProjectManagerContext())
            {
                oTask = context.ParentTasks.Attach(oTask);
                context.Entry(oTask).State = EntityState.Modified;
                context.SaveChanges();
                return oTask;
            }
        }
    }
}
