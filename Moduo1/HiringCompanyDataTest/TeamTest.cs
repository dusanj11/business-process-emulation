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
    public class TeamTest
    {

        #region Declarations
        private Team tUnderTest;

        #endregion Declarations
        private int id = 1;
        private String name = "T";
        private Employee teamLead;
        private List<Project> projects;
        private List<Employee> developmentEngineers;
        private Employee scrumMaster;
        #region setup

        [OneTimeSetUp]
        //[TestFixtureSetUp]
        public void SetupTest()
        {
            this.tUnderTest = new Team();
        }

        #endregion setup

        #region tests

        [Test]
        public void ConstructorTest()
        {

            Assert.DoesNotThrow(() => new Team());
            Assert.DoesNotThrow(() => new Team(name));
            Assert.DoesNotThrow(() => new Team(name, teamLead, scrumMaster));
        }

        [Test]
        public void IdTest()
        {
            tUnderTest.Id = id;

            Assert.AreEqual(id, tUnderTest.Id);
        }

        [Test]
        public void NameTest()
        {
            tUnderTest.Name = name;

            Assert.AreEqual(name, tUnderTest.Name);
        }

        [Test]
        public void TeamLeadTest()
        {
            teamLead = new Employee();
            tUnderTest.TeamLead = teamLead;

            Assert.AreEqual(teamLead, tUnderTest.TeamLead);
        }

        [Test]
        public void ScrumMasterTest()
        {
            scrumMaster = new Employee();
            tUnderTest.ScrumMaster = scrumMaster;

            Assert.AreEqual(scrumMaster, tUnderTest.ScrumMaster);
        }

        [Test]
        public void DevelopTest()
        {
            developmentEngineers = new List<Employee>();
            tUnderTest.DevelopmentEngineers = developmentEngineers;

            Assert.AreEqual(developmentEngineers, tUnderTest.DevelopmentEngineers);
        }

        [Test]
        public void ProjectsTest()
        {
            projects = new List<Project>();
            tUnderTest.Projects = projects;

            Assert.AreEqual(projects, tUnderTest.Projects);
        }

        [Test]
        public void ToStringTest()
        {
            tUnderTest.Name = name;
            Assert.AreEqual(tUnderTest.Name, tUnderTest.ToString());
        }

        #endregion tests

    }
}
