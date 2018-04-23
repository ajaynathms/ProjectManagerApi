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

        [Test, TestCaseSource("TestDataProject")]
        public void TestTask(TaskModel testTask)
        {
            ProjectController oController = new ProjectController();
            ProjectUpdateResult pResult = new ProjectUpdateResult();
            UserUpdateResult u = AddUser();
            ProjectModel testProject = GetTestProject();
            TaskController taskc = new TaskController();
            TaskUpdateResult tresult = new TaskUpdateResult();
            testProject.Manager_ID = u.user.User_ID;
            testProject.Manager_Name = u.user.First_Name + u.user.Last_Name;
            pResult = oController.Post(testProject);
            string message = pResult.status.Message;
            Assert.AreEqual("Project added successfully", message);
            testTask.Project_ID = pResult.project.Project_ID;
            testTask.Project_Name = pResult.project.ProjectName;
            testTask.User_ID = u.user.User_ID;
            tresult = taskc.Post(testTask);
            Assert.AreEqual("Task added successfully", tresult.status.Message);
            TaskModel tasks = taskc.Get().Where(x=>x.TaskName == testTask.TaskName).FirstOrDefault();
            tresult = taskc.Post(tasks);
            Assert.AreEqual("Task updated successfully", tresult.status.Message);            
        }
        public UserUpdateResult AddUser()
        {
            UserController oController = new UserController();
            UserUpdateResult uResult = new UserUpdateResult();
            uResult = oController.Post(GetTestDataUser());
            string message = uResult.status.Message;
            Assert.AreEqual("User added successfully", message);
            return uResult;
        }

        public static UserModel GetTestDataUser()
        {
            string FileLoc = @"TestData\User.json";
            string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

            var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
            var testUser = JsonConvert.DeserializeObject<UserModel>(jsonText);
            return testUser;

        }
        public static ProjectModel GetTestProject()
        {
            string FileLoc = @"TestData\Project.json";
            string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

            var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
            var project = JsonConvert.DeserializeObject<ProjectModel>(jsonText);
            return project;


        }

    }
}
