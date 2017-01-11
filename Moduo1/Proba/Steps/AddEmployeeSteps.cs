using Client;
using HiringCompanyData;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Proba
{
    [Binding]
    public class AddEmployeeSteps
    {
        private static Employee nevalidni = new Employee();
        private static Employee validni = new Employee();
        private static bool statusNevalidni;
        private static bool statusValidni;

        [Given(@"I can write in database")]
        public void GivenICanWriteInDatabase()
        {
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
        }
        
        [Given(@"I have entered employee with existing username")]
        public void GivenIHaveEnteredEmployeeWithExistingUsername()
        {
            Employee nevalidni = new Employee();
            nevalidni.Name = "Milica";
            nevalidni.Surname = "Kapetina";
            nevalidni.Username = "mica";
            nevalidni.Password = "mica";
            nevalidni.Position = PositionEnum.CEO.ToString();
            nevalidni.StartTime = "10.00";
            nevalidni.EndTime = "17.00";
            nevalidni.Login = false;
            nevalidni.Email = "marko.jelaca@gmail.com";
            nevalidni.PasswordUpadateDate = DateTime.Now;
            
        }
        
        [Given(@"I have power to write on database")]
        public void GivenIHavePowerToWriteOnDatabase()
        {
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
        }
        
        [Given(@"I have entered non existing username for employee")]
        public void GivenIHaveEnteredNonExistingUsernameForEmployee()
        {
            Employee validni = new Employee();
            validni.Name = "Zana";
            validni.Surname = "Bilbija";
            validni.Username = "zax";
            validni.Password = "zax";
            validni.Position = PositionEnum.SM.ToString();
            validni.StartTime = "10.00";
            validni.EndTime = "17.00";
            validni.Login = false;
            validni.Email = "marko.jelaca@gmail.com";
            validni.PasswordUpadateDate = DateTime.Now;
            
        }
        
        [When(@"I request to add him/her")]
        public void WhenIRequestToAddHimHer()
        {
            EmployeeDB.Instance.AddEmployee(nevalidni).Returns(statusNevalidni = false);
        }
        
        [When(@"I request to put them in database")]
        public void WhenIRequestToPutThemInDatabase()
        {
            EmployeeDB.Instance.AddEmployee(validni).Returns(statusValidni = true);
        }
        
        [Then(@"the result should be false")]
        public void ThenTheResultShouldBeFalse()
        {
            Assert.AreEqual(statusNevalidni, false);
        }
        
        [Then(@"the result should be true")]
        public void ThenTheResultShouldBeTrue()
        {
            Assert.AreEqual(statusValidni, true);
        }
    }
}
