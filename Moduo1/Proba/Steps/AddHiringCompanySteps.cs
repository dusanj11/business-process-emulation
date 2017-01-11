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
    public class AddHiringCompanySteps
    {
        private static HiringCompany hc1 = new HiringCompany();
        private static HiringCompany hc2 = new HiringCompany();
        private static bool val1;
        private static bool val2;

        [When(@"I have entered a company with existing id")]
        public void WhenIHaveEnteredACompanyWithExistingId()
        {
            hc1.CompanyIdThr = 7;
        }

        [When(@"I have tryed to put it in database")]
        public void WhenIHaveTryedToPutItInDatabase()
        {
            val1 = ClientProxy.Instance.AddHiringCompany(hc1);
        }

        [When(@"I have entered a company with  new id")]
        public void WhenIHaveEnteredACompanyWithNewId()
        {
            hc2.CompanyIdThr = 777;
        }

        [When(@"I have requested to put it in database")]
        public void WhenIHaveRequestedToPutItInDatabase()
        {
            val2 = ClientProxy.Instance.AddHiringCompany(hc2);
        }

        [Then(@"the result should be failing")]
        public void ThenTheResultShouldBeFailing()
        {
            Assert.AreEqual(val1, false);
        }

        [Then(@"the result should be sucessful")]
        public void ThenTheResultShouldBeSucessful()
        {
            Assert.AreEqual(val2, true);
        }
    }
}
