using Client;
using HiringCompanyData;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Proba.Steps
{
    [Binding]
    public class UpdateEmployeeSteps
    {
        private static Employee nevalidni = new Employee();
        private static Employee validni = new Employee();
        private static bool val1;
        private static bool val2;

        [When(@"I try to update employee with wrong username")]
        public void WhenITryToUpdateEmployeeWithWrongUsername()
        {
            nevalidni.Name = "Zana";
            nevalidni.Surname = "Bilbija";
            nevalidni.Username = "afefqfegegg";
            nevalidni.Password = "zax";
            nevalidni.Position = PositionEnum.SM.ToString();
            nevalidni.StartTime = "10.00";
            nevalidni.EndTime = "17.00";
            nevalidni.Login = false;
            nevalidni.Email = "marko.jelaca@gmail.com";
            nevalidni.PasswordUpadateDate = DateTime.Now;
        }
        
        [When(@"I request to update his/hers personal data")]
        public void WhenIRequestToUpdateHisHersPersonalData()
        {
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            EmployeeDB.Instance.UpdateEmployee(nevalidni).Returns(val1 = false);
        }
        
        [When(@"I try to update employee with correct username")]
        public void WhenITryToUpdateEmployeeWithCorrectUsername()
        {
            validni.Name = "Milca";
            validni.Surname = "Kapetna";
            validni.Username = "mica";
            validni.Password = "mica";
            validni.Position = PositionEnum.CEO.ToString();
            validni.StartTime = "10.00";
            validni.EndTime = "17.00";
            validni.Login = false;
            validni.Email = "dusan.jeftic11@gmail.com";
            validni.PasswordUpadateDate = DateTime.Now;
        }
        
        [When(@"I request to update employee's personal data")]
        public void WhenIRequestToUpdateEmployeeSPersonalData()
        {
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            EmployeeDB.Instance.UpdateEmployee(validni).Returns(val2 = true);
        
        }
        
        [Then(@"the result should be negative")]
        public void ThenTheResultShouldBeNegative()
        {
            Assert.AreEqual(val1, false);
        }
        
        [Then(@"the result should be positive")]
        public void ThenTheResultShouldBePositive()
        {
            Assert.AreEqual(val2, true);
        }
    }
}
