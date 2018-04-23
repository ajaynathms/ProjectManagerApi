using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BusinessEntities;
using BusinessLayer;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManagerApi.Controllers
{
    public class UserController : ApiController
    {
        UserBusiness oUserBusines = new UserBusiness();
        

        [HttpGet]
        [Route("api/getAllUsers")]
        public IEnumerable<UserModel> Get()
        {
          return  oUserBusines.GetAllUsers();
        }



        [HttpPost]
        [Route("api/updateUser")]
        public UserUpdateResult Post( UserModel oUser)
        {
            return oUserBusines.UpdateUser(oUser);
            
        }

        [HttpPost]
        [Route("api/deleteUser")]
        public Status DeleteUser(UserModel oUser)
        {
            return oUserBusines.DeleteUser(oUser);
        }
    }
}