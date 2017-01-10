using Client.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  FALI JOS TESTOVA ZA PROEPERTY
namespace HiringCompanyClientTest.Model
{
    [TestFixture]
    public class NewEmployeeTest
    {
        #region Declarations

        private NewEmployee newEmployeeUnderTest;
        private string name = "Dusan";
        private string surname = "Jeftic";
        private string username = "dusan";
        private string password = "dusan";
        private string startTime = "10.00";
        private string endTime = "17.00";
        private string position = "CEO";

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.newEmployeeUnderTest = new NewEmployee();
        }

        #endregion setup

        #region tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new NewEmployee());
        }

        [Test]
        public void ConstructorWithParametersTest()
        {
            Assert.DoesNotThrow(() => new NewEmployee(name, surname, username, password, startTime, endTime, position));
        }

        [Test]
        public void NullParametersConstructorTest()
        {
            Assert.DoesNotThrow(() => new NewEmployee(null, null, null, null, null, null, null));
        }

        [Test]
        public void NameTest()
        {
           
            newEmployeeUnderTest.Name = name;

            Assert.AreEqual(name, newEmployeeUnderTest.Name);
        }

        [Test]
        public void SurnameTest()
        {

            newEmployeeUnderTest.Surname = surname;

            Assert.AreEqual(surname, newEmployeeUnderTest.Surname);
        }


        #endregion
    }
}
