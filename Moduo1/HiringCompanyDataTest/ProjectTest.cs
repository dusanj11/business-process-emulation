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
    public class ProjectTest
    {
        #region Declarations
        private Project pUnderTest;

        private int id = 1;
        private String name = "P1";
        private String description = "Opis";
        private DateTime startDate = DateTime.Now;
        private DateTime endDate = DateTime.Now;
        private Team team;
        private float progress = 100f;
        private List<UserStory> userStories;
        private ProjectState projectState = ProjectState.Accepted;
        private OutsourcingCompany company;
        private HiringCompany hiringCompany;
        private Employee productOwner;
        private bool approved = true;
        private bool ended = true;
        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        //[TestFixtureSetUp]
        public void SetupTest()
        {
            this.pUnderTest = new Project();
        }

        #endregion setup

        #region tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new Project());
            Assert.DoesNotThrow(() => new Project(name, description, startDate, endDate));
        }

        [Test]
        public void IdTest()
        {
            pUnderTest.Id = id;

            Assert.AreEqual(id, pUnderTest.Id);
        }

        [Test]
        public void NameTest()
        {
            pUnderTest.Name = name;

            Assert.AreEqual(name, pUnderTest.Name);
        }

        [Test]
        public void DescTest()
        {
            pUnderTest.Description = description;

            Assert.AreEqual(description, pUnderTest.Description);
        }

        [Test]
        public void StartDateTest()
        {
            pUnderTest.StartDate = startDate;

            Assert.AreEqual(startDate, pUnderTest.StartDate);
        }

        [Test]
        public void EndDateTest()
        {
            pUnderTest.EndDate = endDate;

            Assert.AreEqual(endDate, pUnderTest.EndDate);
        }

        [Test]
        public void ProgressTest()
        {
            pUnderTest.Progress = progress;

            Assert.AreEqual(progress, pUnderTest.Progress);
        }

        [Test]
        public void StatusTest()
        {
            pUnderTest.ProjectState = projectState;

            Assert.AreEqual(projectState, pUnderTest.ProjectState);
        }

        [Test]
        public void EndedTest()
        {
            pUnderTest.Ended = ended;

            Assert.AreEqual(ended, pUnderTest.Ended);
        }


        [Test]
        public void ApprovedTest()
        {
            pUnderTest.Approved = approved;

            Assert.AreEqual(approved, pUnderTest.Approved);
        }

        [Test]
        public void TeamTest()
        {
            team = new Team();
            pUnderTest.Team = team;

            Assert.AreEqual(team, pUnderTest.Team);
        }

        [Test]
        public void UserStoriesTest()
        {
            userStories = new List<UserStory>();
            pUnderTest.UserStories = userStories;

            Assert.AreEqual(userStories, pUnderTest.UserStories);
        }

        [Test]
        public void CompanyTest()
        {
            company = new OutsourcingCompany();
            pUnderTest.Company = company;

            Assert.AreEqual(company, pUnderTest.Company);
        }

        [Test]
        public void HiringCompanyTest()
        {
            hiringCompany = new HiringCompany();
            pUnderTest.HiringCompany = hiringCompany;

            Assert.AreEqual(hiringCompany, pUnderTest.HiringCompany);
        }

        [Test]
        public void OroductOwnerTest()
        {
            productOwner = new Employee();
            pUnderTest.ProductOwner = productOwner;

            Assert.AreEqual(productOwner, pUnderTest.ProductOwner);
        }

        [Test]
        public void ToStringTest()
        {
            pUnderTest.Id = 1;
            pUnderTest.Name = "P1";
            string toString = "1 P1";

            Assert.AreEqual(toString, pUnderTest.ToString());
        }
        #endregion tests
    }
}
