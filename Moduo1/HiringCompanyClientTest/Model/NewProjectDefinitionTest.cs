using Client.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyClientTest.Model
{
    [TestFixture]
    public class NewProjectDefinitionTest
    {
        #region Declarations

        private NewProjectDefinition newProjectDefinitionUnderTest;
        private string name = "Project1";
        private DateTime startDate = DateTime.Now;
        private DateTime endDate = DateTime.Now;
        private string description = "Project1 description";

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.newProjectDefinitionUnderTest = new NewProjectDefinition();
        }

        #endregion setup

        #region tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new NewProjectDefinition());
        }

        [Test]
        public void ConstructorWithParametersTest()
        {
            Assert.DoesNotThrow(() => new NewProjectDefinition(name, startDate, endDate, description));
        }

        [Test]
        public void NullParametersConstructorTest()
        {
            Assert.DoesNotThrow(() => new NewProjectDefinition(null, DateTime.Now, DateTime.Now, null));
        }

        [Test]
        public void NameTest()
        {

            newProjectDefinitionUnderTest.Name = name;

            Assert.AreEqual(name, newProjectDefinitionUnderTest.Name);
        }

        [Test]
        public void StartDateTest()
        {

            newProjectDefinitionUnderTest.StartDate = startDate;

            Assert.AreEqual(startDate, newProjectDefinitionUnderTest.StartDate);
        }

        [Test]
        public void EndDateTest()
        {

            newProjectDefinitionUnderTest.EndDate = endDate;

            Assert.AreEqual(endDate, newProjectDefinitionUnderTest.EndDate);
        }

        [Test]
        public void DescriptionTest()
        {

            newProjectDefinitionUnderTest.Description = description;

            Assert.AreEqual(description, newProjectDefinitionUnderTest.Description);
        }

      
        #endregion
    }
}
