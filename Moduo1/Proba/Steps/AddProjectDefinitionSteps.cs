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
    public class AddProjectDefinitionSteps
    {
        private static Project np = new Project();
        private static bool val;

        [When(@"I have created a definition data for a project")]
        public void WhenIHaveCreatedADefinitionDataForAProject()
        {
            np.Name = "moj projekat";
        }
        
        [When(@"I have requested to add it")]
        public void WhenIHaveRequestedToAddIt()
        {
            ProjectDB.Instance = Substitute.For<IProjectDB>();
            ProjectDB.Instance.AddProject(np).Returns(val = true);
        }
        
        [Then(@"the result should be afirmative")]
        public void ThenTheResultShouldBeAfirmative()
        {
            Assert.AreEqual(val, true);
        }
    }
}
