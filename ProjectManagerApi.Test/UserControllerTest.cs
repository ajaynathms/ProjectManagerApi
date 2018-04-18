using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagerApi.Controllers;
using NUnit.Framework;
namespace ProjectManagerApi.Test
{
    [TestFixture]
    public class UserControllerTest
    {
        [Test]
        public void TestGetAllUser()
        {
            UserController oController = new UserController();
            Assert.AreEqual(0, oController.GetAllUsers().Count());

        }
    }
}
