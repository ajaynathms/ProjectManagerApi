using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class TaskUpdateResult
    {
        public Status status { get; set; }
        public  TaskModel task { get; set; }
    }
}
