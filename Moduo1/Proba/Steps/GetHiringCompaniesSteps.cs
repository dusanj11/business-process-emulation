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
    public class GetHiringCompaniesSteps
    {
        private static int id1;
        private static int id2;
        private static HiringCompany hc1 = new HiringCompany();
        private static HiringCompany hc2 = new HiringCompany();

        [When(@"I entered id of company")]
        public void WhenIEnteredIdOfCompany()
        {
            id1 = 86758;
        }

        [When(@"I have requested to get that company")]
        public void WhenIHaveRequestedToGetThatCompany()
        {
            hc1 = ClientProxy.Instance.GetHiringCompany(id1);
        }

        [When(@"I filled data with existing id")]
        public void WhenIFilledDataWithExistingId()
        {
            id2 = 7;
        }

        [When(@"I have requested to have that company detailes")]
        public void WhenIHaveRequestedToHaveThatCompanyDetailes()
        {
            hc2 = ClientProxy.Instance.GetHiringCompany(id2);
        }

        [Then(@"the result should be returning a false value")]
        public void ThenTheResultShouldBeReturningAFalseValue()
        {
            Assert.That(hc1.CompanyIdThr.ToString() == null, Is.True);
        }

        [Then(@"the result should be  hiring company")]
        public void ThenTheResultShouldBeAListOfAllHiringCompanies()
        {
            Assert.That(hc2.CompanyIdThr.ToString() != null, Is.True);
        }
    }
}
