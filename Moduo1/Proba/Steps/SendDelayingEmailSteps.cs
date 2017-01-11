using Client;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Proba.Steps
{
    [Binding]
    public class SendDelayingEmailSteps
    {
        private static string us;
        private static bool val;

        [When(@"I present the correct data of employee")]
        public void WhenIPresentTheCorrectDataOfEmployee()
        {
            us = "dule";
        }
        
        [When(@"I request to notify him by email")]
        public void WhenIRequestToNotifyHimByEmail()
        {
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            val = ClientProxy.Instance.SendDelayingEmail(us);
        }
        
        [Then(@"the email should be sent successfully")]
        public void ThenTheEmailShouldBeSentSuccessfully()
        {
            Assert.AreEqual(val, true);
        }
    }
}
