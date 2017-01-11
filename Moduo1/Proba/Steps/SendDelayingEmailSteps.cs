using Client;
using HiringCompanyContract;
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
            
            //ClientProxy.Instance.SendDelayingEmail(us).Returns(val = true);
            val = ClientProxy.Instance.SendDelayingEmail(us);
            Console.WriteLine(ClientProxy.Instance.ToString());
        }
        
        [Then(@"the email should be sent successfully")]
        public void ThenTheEmailShouldBeSentSuccessfully()
        {
            Assert.AreEqual(val, true);
        }
    }
}
