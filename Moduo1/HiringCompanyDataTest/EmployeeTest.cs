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
    public class EmployeeTest
    {
        #region Declarations

        private Employee empUnderTest;
        private String username = "marko";
        private String password  = "marko";
        private String name = "Marko";
        private String surname = "Jelaca";
        private String position = "CEO";
        private String startTime = "10.0";
        private String endTime = "18.0";
        private String email = "jelaca.marko@gmail.com";
        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        //[TestFixtureSetUp]
        public void SetupTest()
        {
            this.empUnderTest = new Employee();
        }

        #endregion setup

        #region tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new Employee());
        }

        [Test]
        public void UsernameTest()
        {
        
            empUnderTest.Username= username;

            Assert.AreEqual(username, empUnderTest.Username);
        }

        [Test]
        public void PasswordTest()
        {
          
            empUnderTest.Password = password;

            Assert.AreEqual(password, empUnderTest.Password);
        }

        [Test]
        public void NameTest()
        {
    
            empUnderTest.Name = name;

            Assert.AreEqual(name, empUnderTest.Name);
        }


        [Test]
        public void SurnameTest()
        {
          
            empUnderTest.Surname = surname;

            Assert.AreEqual(surname, empUnderTest.Surname);
        }

        [Test]
        public void PositionTest()
        {
          
            empUnderTest.Position = position;

            Assert.AreEqual(position, empUnderTest.Position);
        }

        [Test]
        public void StartTimeTest()
        {
        
            empUnderTest.StartTime = startTime;

            Assert.AreEqual(startTime, empUnderTest.StartTime);
        }

        [Test]
        public void EndTimeTest()
        {
           
            empUnderTest.EndTime = endTime;

            Assert.AreEqual(endTime, empUnderTest.EndTime);
        }

        [Test]
        public void EmailTest()
        {
          
            empUnderTest.Email = email;

            Assert.AreEqual(email, empUnderTest.Email);
        }

        [Test]
        public void PasswordUpdateTest()
        {
            DateTime passwordupdate = DateTime.Now;
            empUnderTest.PasswordUpadateDate = passwordupdate;

            Assert.AreEqual(passwordupdate, empUnderTest.PasswordUpadateDate);


        }

        [Test]
        public void LogInTest()
        {
            bool login = true;
            empUnderTest.Login = login;

            Assert.AreEqual(login, empUnderTest.Login);
        }

        [Test]
        public void HiringCompanyTest()
        {
            HiringCompany hc = new HiringCompany();
            empUnderTest.HiringCompanyId = hc;

            Assert.AreEqual(hc, empUnderTest.HiringCompanyId);
        }

        [Test]
        public void IdTest()
        {
            int id = 1;
            empUnderTest.IDtmp = 1;

            Assert.AreEqual(id, empUnderTest.IDtmp);
        }


        [Test]
        public void ToStringTest()
        {
            empUnderTest.IDtmp = 1;
            empUnderTest.Name = "Marko";
            empUnderTest.Surname = "Jelaca";
            string toString = "Marko Jelaca";

            Assert.AreEqual(toString, empUnderTest.ToString());
        }
        #endregion tests
    }
}
