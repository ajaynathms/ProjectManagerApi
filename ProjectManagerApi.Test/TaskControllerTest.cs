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
    public class TaskControllerTest
    {
        public static IEnumerable TestDataProject
        {
            get
            {
                string FileLoc = @"TestData\Task.json";
                string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

                var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
                var task = JsonConvert.DeserializeObject<TaskModel>(jsonText);
                yield return task;
            }
        }

        //[Test, TestCaseSource("TestDataProject")]
        //public void TestProject(TaskModel testTask)
        //{
        //    ProjectController oController = new ProjectController();
        //    ProjectUpdateResult pResult = new ProjectUpdateResult();
        //    UserUpdateResult u = AddUser();
        //    testProject.Manager_ID = u.user.User_ID;
        //    testProject.Manager_Name = u.user.First_Name + u.user.Last_Name;
        //    pResult = oController.Post(testProject);
        //    string message = pResult.status.Message;
        //    Assert.AreEqual("Project added successfully", message);
        //    testProject.Project_ID = pResult.project.Project_ID;
        //    Assert.AreEqual("Project updated successfully", oController.Post(testProject).status.Message);

        //}
        //public UserUpdateResult AddUser()
        //{
        //    UserController oController = new UserController();
        //    UserUpdateResult uResult = new UserUpdateResult();
        //    uResult = oController.Post(GetTestDataUser());
        //    string message = uResult.status.Message;
        //    Assert.AreEqual("User added successfully", message);
        //    return uResult;
        //}
        //public ProjectUpdateResult AddProject()
        //{
        //    ProjectController oController = new ProjectController();
        //    ProjectUpdateResult pResult = new ProjectUpdateResult();
        //    UserUpdateResult u = AddUser();
        //    testProject.Manager_ID = u.user.User_ID;
        //    testProject.Manager_Name = u.user.First_Name + u.user.Last_Name;

        //}
        //public static UserModel GetTestDataUser()
        //{
        //    string FileLoc = @"TestData\User.json";
        //    string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

        //    var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
        //    var testUser = JsonConvert.DeserializeObject<UserModel>(jsonText);
        //    return testUser;

        //}
        //public static ProjectModel GetTestProject()
        //{
        //    string FileLoc = @"TestData\Project.json";
        //    string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

        //    var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
        //    var project = JsonConvert.DeserializeObject<ProjectModel>(jsonText);
        //    return project;


        //}

    }
}
