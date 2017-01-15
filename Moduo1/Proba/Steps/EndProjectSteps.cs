using Client;
using HiringCompanyData;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Proba.Steps
{
    [Binding]
    public class EndProjectSteps
    {
        private Project pr;
        private bool val;

        [Given(@"I have chosen a project to end")]
        public void GivenIHaveChosenAProjectToEnd()
        {
            pr = ClientProxy.Instance.GetProject("P1");
        }
        
        [When(@"I request to end it")]
        public void WhenIRequestToEndIt()
        {
            val = ClientProxy.Instance.MarkProjectEnded(pr);
        }
        
        [Then(@"the result should be afirmativly returned")]
        public void ThenTheResultShouldBeAfirmativlyReturned()
        {
            Assert.IsTrue(val);
        }
    }
}
