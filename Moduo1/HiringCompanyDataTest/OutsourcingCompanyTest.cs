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
    public class OutsourcingCompanyTest
    {
        #region Declarations
        private OutsourcingCompany ocUnderTest;
        private int id = 1;
        private String name = "OC";
        private List<Project> projects;
        private List<Partnership> partnerships;
        private int idFromOutSourcingDB = 2;
        private List<Employee> employees;
        private List<Team> teams;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        //[TestFixtureSetUp]
        public void SetupTest()
        {
            this.ocUnderTest = new OutsourcingCompany();
        }

        #endregion setup

        #region tests

        [Test]
        public void ConstructorTest()
        {

            Assert.DoesNotThrow(() => new OutsourcingCompany());
            Assert.DoesNotThrow(() => new OutsourcingCompany(name));
            Assert.DoesNotThrow(() => new OutsourcingCompany(name, projects));
        }

        [Test]
        public void IdTest()
        {
            ocUnderTest.Id = id;

            Assert.AreEqual(id, ocUnderTest.Id);
        }

        [Test]
        public void NameTest()
        {
            ocUnderTest.Name = name;

            Assert.AreEqual(name, ocUnderTest.Name);
        }

        [Test]
        public void IdFromOcDbTest()
        {
            ocUnderTest.IdFromOutSourcingDB = idFromOutSourcingDB;

            Assert.AreEqual(idFromOutSourcingDB, ocUnderTest.IdFromOutSourcingDB);
        }

        [Test]
        public void ProjectsTest()
        {
            projects = new List<Project>();
            ocUnderTest.Projects = projects;

            Assert.AreEqual(projects, ocUnderTest.Projects);
        }

        [Test]
        public void PartnershipTest()
        {
            partnerships = new List<Partnership>();
            ocUnderTest.Partnerships = partnerships;

            Assert.AreEqual(partnerships, ocUnderTest.Partnerships);
        }

        [Test]
        public void EmployeeTest()
        {
            employees = new List<Employee>();
            ocUnderTest.Employees = employees;

            Assert.AreEqual(employees, ocUnderTest.Employees);
        }

        [Test]
        public void TeamsTest()
        {
            teams = new List<Team>();
            ocUnderTest.Teams = teams;

            Assert.AreEqual(teams, ocUnderTest.Teams);
        }


        [Test]
        public void ToStringTest()
        {
            string toString = "ID: 1 Name: OC";
            ocUnderTest.Id = 1;
            ocUnderTest.Name = "OC";

            Assert.AreEqual(toString, ocUnderTest.ToString());

        }
        #endregion tests



    }
    }
