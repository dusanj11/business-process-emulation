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
            np.Company = new HiringCompanyData.OutsourcingCompany("proba kompanija");
            np.Description = "lalala";
            np.HiringCompany = ClientProxy.Instance.GetHiringCompany(7);
            np.ProductOwner = ClientProxy.Instance.GetEmployee("naci", "naci");
        }

        [When(@"I have requested to add it")]
        public void WhenIHaveRequestedToAddIt()
        {
            val = ClientProxy.Instance.AddProjectDefinition(np);
        }

        [Then(@"the result should be afirmative")]
        public void ThenTheResultShouldBeAfirmative()
        {
            Assert.AreEqual(val, true);
        }
    }
}
