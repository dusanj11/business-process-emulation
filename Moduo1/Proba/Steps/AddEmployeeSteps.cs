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
        private static Employee nevalidni;
        private static Employee validni;
        private static bool statusNevalidni;
        private static bool statusValidni;

        [Given(@"I can write in database")]
        public void GivenICanWriteInDatabase()
        {

        }

        [Given(@"I have entered employee with existing username")]
        public void GivenIHaveEnteredEmployeeWithExistingUsername()
        {

            nevalidni = new Employee();
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

            ScenarioContext.Current.Add("nevalidni", nevalidni);

        }

        [Given(@"I have power to write on database")]
        public void GivenIHavePowerToWriteOnDatabase()
        {

        }

        [Given(@"I have entered non existing username for employee")]
        public void GivenIHaveEnteredNonExistingUsernameForEmployee()
        {
            HiringCompany hc = new HiringCompany();
            hc.CompanyIdThr = 1;
            hc.Name = " lol";
            hc.Ceo = " lololee";

            validni = new Employee();
            validni.Name = "Zana";
            validni.Surname = "Bilbija";
            validni.Username = "zax";
            validni.Password = "zax";
            validni.Position = PositionEnum.SM.ToString();
            validni.StartTime = "10.00";
            validni.EndTime = "17.00";
            validni.Login = false;
            validni.HiringCompanyId = hc;
            validni.Email = "marko.jelaca@gmail.com";
            validni.PasswordUpadateDate = DateTime.Now;

            ScenarioContext.Current.Add("validni", validni);
        }

        [When(@"I request to add him/her")]
        public void WhenIRequestToAddHimHer()
        {
            Employee emp = ScenarioContext.Current.Get<Employee>("nevalidni");
            statusNevalidni = ClientProxy.Instance.AddEmployee(emp);
        }

        [When(@"I request to put them in database")]
        public void WhenIRequestToPutThemInDatabase()
        {
            Employee emp = ScenarioContext.Current.Get<Employee>("validni");
            statusValidni = ClientProxy.Instance.AddEmployee(emp);
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
