using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class UserUpdateResult
    {
        public Status status { get; set; }
        public  UserModel user { get; set; }
    }
}
