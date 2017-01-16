using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyData;

namespace HiringCompanyDataTest
{
    [TestFixture]
    public class TaskTest
    {
        #region Declarations
        private HiringCompanyData.Task taskUnderTest;
        private String name;
        private float progress;
        private String description;
        private TaskState taskState;
        private Employee developmentEngineer;
        private UserStory userStory;
        #endregion Declarations

        #region Setup
        public void SetupTest()
        {
            this.taskUnderTest = new HiringCompanyData.Task();
            name = "";
            progress = 0;
            description = "";
            taskState = TaskState.New;
            developmentEngineer = new Employee();
            userStory = new UserStory();
        }
        #endregion Setup

        #region Tests
        [Test]
        public void ConstructorTest1()
        {
            Assert.DoesNotThrow(() => new HiringCompanyData.Task());
        }
        [Test]
        public void ConstructorTest2()
        {
            Assert.DoesNotThrow(() => new Employee());
        }
        [Test]
        public void ConstructorTest3()
        {
            Assert.DoesNotThrow(() => new UserStory());
        }
        [Test]
        public void IdTest()
        {
            int id = 1;
            taskUnderTest.Id = id;

            Assert.AreEqual(id, taskUnderTest.Id);
        }
        [Test]
        public void NameTest()
        {
            name = "proba";
            taskUnderTest.Name = name;

            Assert.AreEqual(name, taskUnderTest.Name);
        }
        [Test]
        public void DescriptionTest()
        {
            description = "proba";
            taskUnderTest.Description = description;

            Assert.AreEqual(description, taskUnderTest.Description);
        }
        [Test]
        public void ProgressTest()
        {
            progress = 8;
            taskUnderTest.Progress = progress;

            Assert.AreEqual(progress, taskUnderTest.Progress);
        }
        [Test]
        public void TaskStateTest()
        {
            taskUnderTest.TaskState = taskState;

            Assert.AreEqual(taskState, taskUnderTest.TaskState);
        }
        [Test]
        public void DevelopmentEngineerTest()
        {
            developmentEngineer.Name = "proba";
            taskUnderTest.DevelopmentEngineer = developmentEngineer;

            Assert.AreEqual(developmentEngineer, taskUnderTest.DevelopmentEngineer);
        }
        [Test]
        public void UserStoryTest()
        {
            userStory.Name = "proba";
            taskUnderTest.UserStory = userStory;

            Assert.AreEqual(userStory, taskUnderTest.UserStory);
        }
        [Test]
        public void ToStringTest()
        {
            taskUnderTest.Id = 1;
            taskUnderTest.Name = "proba";
            taskUnderTest.Description = "proba";
            taskUnderTest.Progress = 8;
            taskUnderTest.TaskState = TaskState.New;
            Assert.AreEqual("ID: " + 1 +
                   " Name: " + this.name +
                   " Description: " + this.description +
                   " Progress: " + this.progress.ToString() +
                   " State: " + this.taskState.ToString(), taskUnderTest.ToString());
        }
        #endregion Tests
    }
}
