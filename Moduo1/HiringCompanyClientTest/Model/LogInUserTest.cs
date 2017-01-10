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
    public class LogInUserTest
    {
        #region Declarations

        private LogInUser logInUserUnderTest;
        private string usernameTest = "Marko";
        private string passwordTest = "Marko";

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.logInUserUnderTest = new LogInUser();
        }

        #endregion setup

        #region tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new LogInUser());
        }

        [Test]
        public void ConstructorWithParametersTest()
        {
            Assert.DoesNotThrow(() => new LogInUser(usernameTest, passwordTest));
        }

        [Test]
        public void NullParametersConstructorTest()
        {
            Assert.DoesNotThrow(() => new LogInUser(null, null));
        }

        [Test]
        public void UsernameTest()
        {
   
            logInUserUnderTest.Username = usernameTest;

            Assert.AreEqual(usernameTest, logInUserUnderTest.Username);
        }

        [Test]
        public void PasswordTest()
        {

            logInUserUnderTest.Password = passwordTest;

            Assert.AreEqual(passwordTest, logInUserUnderTest.Password);
        }

        
        #endregion
    }
}
