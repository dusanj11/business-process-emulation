using HiringCompanyData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyDataTest
{
    [TestFixture]
    public class UserStoryTest
    {

        #region Declarations
        private UserStory uUnderTest;

        private int id = 1;
        private String name = "US";
        private String description = "Opis";
        private float progress = 100;
        private int weightOfUserStory = 3;
        private UserStoryState userStoryState = UserStoryState.Approved;
        private List<HiringCompanyData.Task> tasks;
        private Project project;
        private int idFromOcDB = 1;

        #endregion Declarations

        #region setup
        [OneTimeSetUp]
        //[TestFixtureSetUp]
        public void SetupTest()
        {
            this.uUnderTest = new UserStory();
        }

        #endregion setup

        #region tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new UserStory());
            Assert.DoesNotThrow(() => new UserStory(name, description, project));
        }


        [Test]
        public void IdTest()
        {
            uUnderTest.Id = id;

            Assert.AreEqual(id, uUnderTest.Id);
        }

        [Test]
        public void NameTest()
        {
            uUnderTest.Name = name;

            Assert.AreEqual(name, uUnderTest.Name);
        }

        [Test]
        public void DescTest()
        {
            uUnderTest.Description = description;

            Assert.AreEqual(description, uUnderTest.Description);
        }


        [Test]
        public void ProgressTest()
        {
            uUnderTest.Progress = progress;

            Assert.AreEqual(progress, uUnderTest.Progress);
        }

        [Test]
        public void WeightTest()
        {
            uUnderTest.WeightOfUserStory = weightOfUserStory;

            Assert.AreEqual(weightOfUserStory, uUnderTest.WeightOfUserStory);
        }

        [Test]
        public void IdFromOcTest()
        {
            uUnderTest.IdFromOcDB = idFromOcDB;

            Assert.AreEqual(idFromOcDB, uUnderTest.IdFromOcDB);
        }

        [Test]
        public void StateTest()
        {
            uUnderTest.UserStoryState = userStoryState;

            Assert.AreEqual(userStoryState, uUnderTest.UserStoryState);
        }

        [Test]
        public void TasksTest()
        {
            tasks = new List<HiringCompanyData.Task>();
            uUnderTest.Tasks = tasks;

            Assert.AreEqual(tasks, uUnderTest.Tasks);
        }

        [Test]
        public void ProjectTest()
        {
            project = new Project();
            uUnderTest.Project = project;

            Assert.AreEqual(project, uUnderTest.Project);
        }

        [Test]
        public void ToStringTest()
        {
           

            uUnderTest.Name = name;
            uUnderTest.WeightOfUserStory = weightOfUserStory;
            string toString = " Name: " + uUnderTest.Name + " Weight: " + uUnderTest.WeightOfUserStory;

            Assert.AreEqual(toString, uUnderTest.ToString());
        }

        #endregion tests
    }
}
