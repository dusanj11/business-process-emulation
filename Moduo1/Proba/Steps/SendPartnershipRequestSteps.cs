using Client;
using HiringCompanyData;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Proba.Steps
{
    [Binding]
    public class SendPartnershipRequestSteps
    {
        private static OutsourcingCompany oc1;
        private static OutsourcingCompany oc2;
        private static HiringCompany hc1;
        private static HiringCompany hc2;
        private static bool val1;
        private static bool val2;

        [Given(@"I have opted for one outsourcing company")]
        public void GivenIHaveOptedForOneOutsourcingCompany()
        {
            oc1 = ClientProxy.Instance.GetOutsourcingCompany("DMS NS");
            hc1 = ClientProxy.Instance.GetHiringCompany(1);
        }


        [When(@"I request to send them the request")]
        public void WhenIRequestToSendThemTheRequest()
        {
            val1 = ClientProxy.Instance.SendPartnershipRequest(oc1.IdFromOutSourcingDB, hc1);
        }
        
        [Then(@"the result should be completed with value true")]
        public void ThenTheResultShouldBeCompletedWithValueTrue()
        {
            Assert.IsTrue(val1);
        }

    }
}
