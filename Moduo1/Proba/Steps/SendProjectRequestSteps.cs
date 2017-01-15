using Client;
using HiringCompanyData;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Proba.Steps
{
    [Binding]
    public class SendProjectRequestSteps
    {
        private static OutsourcingCompany oc;
        private static HiringCompany hc;
        private static Project pr;
        private static bool val;

        [Given(@"I have chosen both project and outsourcing company")]
        public void GivenIHaveChosenBothProjectAndOutsourcingCompany()
        {
            pr = ClientProxy.Instance.GetProject("P1");
            hc = ClientProxy.Instance.GetHiringCompany(1);
            oc = ClientProxy.Instance.GetOutsourcingCompany("DMS NS");
        }
        
        [When(@"I send the request")]
        public void WhenISendTheRequest()
        {
            val = ClientProxy.Instance.SendProjectRequest(hc.IDHc, oc.IdFromOutSourcingDB, pr);
        }
        
        [Then(@"the request should be sent correctly")]
        public void ThenTheRequestShouldBeSentCorrectly()
        {
            Assert.IsTrue(val);
        }
    }
}
