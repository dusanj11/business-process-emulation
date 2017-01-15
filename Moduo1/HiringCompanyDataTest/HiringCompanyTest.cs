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
    public class HiringCompanyTest
    {
        #region Declarations

        private HiringCompany hcUnderTest;
        private string name = "HC";
 		private string ceo = "Marko Jelaca";
 		private int companyIdThr = 1;
 		private List<Employee> employees;
 		private List<Project> projects;
 	    private List<Partnership> partnerships;
        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        //[TestFixtureSetUp]
        public void SetupTest()
        {
            this.hcUnderTest = new HiringCompany();
        }

        #endregion setup

        #region tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new HiringCompany());
        }

        [Test]
        public void NameTest()
        {
            hcUnderTest.Name = name;

            Assert.AreEqual(name, hcUnderTest.Name);
        }

        [Test]
        public void CeoTest()
        {
            hcUnderTest.Ceo = ceo;

            Assert.AreEqual(ceo, hcUnderTest.Ceo);
        }

        [Test]
        public void Thid()
        {
            hcUnderTest.CompanyIdThr = companyIdThr;

            Assert.AreEqual(companyIdThr, hcUnderTest.CompanyIdThr);
        }

        [Test]
        public void EmployeesTest()
        {
            employees = new List<Employee>();
            hcUnderTest.Employees = employees;

            Assert.AreEqual(employees, hcUnderTest.Employees);
        }

        [Test]
        public void ProjectsTest()
        {
            projects = new List<Project>();
            hcUnderTest.Projects = projects;

            Assert.AreEqual(projects, hcUnderTest.Projects);
        }

        [Test]
        public void PartnershipTest()
        {
            partnerships = new List<Partnership>();
            hcUnderTest.Partnerships = partnerships;

            Assert.AreEqual(partnerships, hcUnderTest.Partnerships);
        }

        [Test]
        public void IdHcTest()
        {
            int id = 1;
            hcUnderTest.IDHc = id;

            Assert.AreEqual(id, hcUnderTest.IDHc);
        }

        [Test]
        public void ToStringTest()
        {
            string toString = "HC Marko Jelaca";
            hcUnderTest.Name = name;
            hcUnderTest.Ceo = ceo;

            Assert.AreEqual(toString, hcUnderTest.ToString());

        }

        #endregion tests
    }
}
