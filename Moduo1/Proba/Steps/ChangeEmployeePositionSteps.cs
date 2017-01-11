using Client;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Proba.Steps
{
    [Binding]
    public class ChangeEmployeePositionSteps
    {
        private static string us1;
        private static string us2;
        private static bool val1;
        private static bool val2;

        [When(@"I have entered wrong username with crroect title")]
        public void WhenIHaveEnteredWrongUsernameWithCrroectTitle()
        {
            us1 = "kfkflj";
        }

        [When(@"I request to change title of thet employee")]
        public void WhenIRequestToChangeTitleOfThetEmployee()
        {
            val1 = ClientProxy.Instance.ChangeEmployeePosition(us1, "PO");
            Console.WriteLine();
        }

        [When(@"I have entered correct username and wanted title")]
        public void WhenIHaveEnteredCorrectUsernameAndWantedTitle()
        {
            us2 = "dule";
        }

        [When(@"I request to make a change on his/hers title")]
        public void WhenIRequestToMakeAChangeOnHisHersTitle()
        {
            val2 = ClientProxy.Instance.ChangeEmployeePosition(us2, "SM");
        }

        [Then(@"the process should be incomplete")]
        public void ThenTheProcessShouldBeIncomplete()
        {
            Assert.AreEqual(val1, false);
        }

        [Then(@"the process should be complete")]
        public void ThenTheProcessShouldBeComplete()
        {
            Assert.AreEqual(val2, true);
        }
    }
}
