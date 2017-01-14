using Client;
using HiringCompanyData;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Proba.Steps
{
    [Binding]
    public class GetProjectsSteps
    {
        private static List<Project> lp = new List<Project>();

        [When(@"I have requested to see current projects")]
        public void WhenIHaveRequestedToSeeCurrentProjects()
        {
            lp = ClientProxy.Instance.GetProjects(1);
        }

        [When(@"I have requested current projects data")]
        public void WhenIHaveRequestedCurrentProjectsData()
        {
            lp = ClientProxy.Instance.GetProjects(1);
        }

        [Then(@"the result should be a list of projects")]
        public void ThenTheResultShouldBeAListOfProjects()
        {
            Assert.That(lp.Count > 0, Is.True);
        }

        [Then(@"the result should be null or empty list")]
        public void ThenTheResultShouldBeNullOrEmptyList()
        {
            Assert.That(lp.Count == 0, Is.True);
        }
    }
}
