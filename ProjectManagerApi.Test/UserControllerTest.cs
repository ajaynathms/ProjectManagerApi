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
                string FileLoc = @"TestData\User.json";
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
            UserUpdateResult uResult = new UserUpdateResult();
            uResult = oController.Post(testUser);
            string message = uResult.status.Message;
            Assert.AreEqual("User added successfully", message);
            testUser.User_ID = uResult.user.User_ID;
            Assert.AreEqual("User updated successfully",oController.Post(testUser).status.Message);
            Assert.NotNull(oController.Get());
            Assert.IsTrue(oController.DeleteUser(testUser).Result);

        }
         
    }
}
