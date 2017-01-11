using Client;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Proba.Steps
{
    [Binding]
    public class ChangePasswordSteps
    {
        private static string us1;
        private static string opas1;
        private static string npas1;
        private static string us2;
        private static string opas2;
        private static string npas2;
        private static string us3;
        private static string opas3;
        private static string npas3;
        private static bool val1;
        private static bool val2;
        private static bool val3;

        [When(@"I have entered valid username, wrong password and new password,")]
        public void WhenIHaveEnteredValidUsernameWrongPasswordAndNewPassword()
        {
            us1 = "dule";
            opas1 = "rgerg";
            npas1 = "dewfefe";
        }
        
        [When(@"I request to change it")]
        public void WhenIRequestToChangeIt()
        {
            val1 = ClientProxy.Instance.ChangePassword(us1, opas1, npas1);
        }
        
        [When(@"I have entered invalid username, and new paswword")]
        public void WhenIHaveEnteredInvalidUsernameAndNewPaswword()
        {
            us2 = "eergg";
            opas2 = "rgerg";
            npas2 = "dewfefe";
        }
        
        [When(@"I request to change old password")]
        public void WhenIRequestToChangeOldPassword()
        {
            val2 = ClientProxy.Instance.ChangePassword(us2, opas2, npas2);
        }
        
        [When(@"I have both username and password valid, and new paswword")]
        public void WhenIHaveBothUsernameAndPasswordValidAndNewPaswword()
        {
            us3 = "dule";
            opas3 = "dule";
            npas3 = "dukica";
        }
        
        [When(@"I request to make a change on my password")]
        public void WhenIRequestToMakeAChangeOnMyPassword()
        {
            val3 = ClientProxy.Instance.ChangePassword(us3, opas3, npas3);
        }
        
        [Then(@"the result should be ended without a change")]
        public void ThenTheResultShouldBeEndedWithoutAChange()
        {
            Assert.AreEqual(val1, false);
        }
        
        [Then(@"the result should be non-positive")]
        public void ThenTheResultShouldBeNon_Positive()
        {
            Assert.AreEqual(val2, false);
        }
        
        [Then(@"the result should have a positive outcome")]
        public void ThenTheResultShouldHaveAPositiveOutcome()
        {
            Assert.AreEqual(val3, true);
        }
    }
}
