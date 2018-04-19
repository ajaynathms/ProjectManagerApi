using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagerApi.Controllers;
using NUnit.Framework;
using BusinessEntities;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Collections;
using System.Reflection;

namespace ProjectManagerApi.Test
{
    [TestFixture]
    public class UserControllerTest
    {
        public static IEnumerable GetTestDataUser
        {
            get
            {
                string FileLoc = @"TestData\AddUser.json";
                string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\","").Replace("\\bin\\Debug", "");

                var jsonText = File.ReadAllText(Path.Combine(FilePath,FileLoc));
                var adduser = JsonConvert.DeserializeObject<UserModel>(jsonText);
                yield return adduser;
            }
        }

        [Test, TestCaseSource("GetTestDataUser")]
        public void TestAddUser(UserModel testUser)
        {
            UserController oController = new UserController();
            Assert.AreEqual("User added successfully", oController.Post(testUser).status.Message);
        }

        public static UserModel GetAddUserTestData()
        {
            string FileLoc = @"C:\Users\Admin\Documents\PM2\ProjectManagerApi\ProjectManagerApi.Test\TestData\AddUser.json";

            var jsonText = File.ReadAllText(FileLoc);
            var adduser = JsonConvert.DeserializeObject<UserModel>(jsonText);
            return adduser;
        }

        
    }
}
