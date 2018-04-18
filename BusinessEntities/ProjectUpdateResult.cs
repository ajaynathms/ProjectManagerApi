using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class ProjectUpdateResult
    {
        public Status status { get; set; }
        public  ProjectModel project { get; set; }
    }
}
