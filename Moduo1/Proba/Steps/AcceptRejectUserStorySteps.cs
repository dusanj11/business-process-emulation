using Client;
using HiringCompanyData;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Proba.Steps
{
    [Binding]
    public class AcceptRejectUserStorySteps
    {
        private UserStory us1;
        private UserStory us2;
        private bool val1;
        private bool val2;

        [Given(@"I have picked an user story to accept")]
        public void GivenIHavePickedAnUserStoryToAccept()
        {
            us1 = ClientProxy.Instance.GetUserStoryFromId(1); 
        }
        
        [Given(@"I have opted desired user story to reject")]
        public void GivenIHaveOptedDesiredUserStoryToReject()
        {
            us2 = ClientProxy.Instance.GetUserStoryFromId(2); 
        }
        
        [When(@"I choose to accept it")]
        public void WhenIChooseToAcceptIt()
        {
            val1 = ClientProxy.Instance.SendUserStoryToOc(us1);
        }
        
        [When(@"I request to reject it")]
        public void WhenIRequestToRejectIt()
        {
            val2 = ClientProxy.Instance.SendUserStoryToOc(us1);
        }
        
        [Then(@"the result should be value true")]
        public void ThenTheResultShouldBeValueTrue()
        {
            Assert.IsTrue(val1);
        }

        [Then(@"the returning value should be true")]
        public void ThenTheResultShouldBeValueFalse()
        {
            Assert.IsTrue(val2);
        }
    }
}
