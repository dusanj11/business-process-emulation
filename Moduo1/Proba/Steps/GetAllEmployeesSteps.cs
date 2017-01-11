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
    public class GetAllEmployeesSteps
    {
        private static List<Employee> allEmployees = new List<Employee>();

        [Given(@"I have acces to database")]
        public void GivenIHaveAccesToDatabase()
        {

        }

        [Given(@"I am able to access database")]
        public void GivenIAmAbleToAccessDatabase()
        {

        }

        [When(@"I request to have data about all employees")]
        public void WhenIRequestToHaveDataAboutAllEmployees()
        {
            allEmployees = ClientProxy.Instance.GetReallyAllEmployees();
        }

        [When(@"I want to have the requested data")]
        public void WhenIWantToHaveTheRequestedData()
        {
            allEmployees = ClientProxy.Instance.GetReallyAllEmployees();
        }

        [Then(@"the result should be a list of employees")]
        public void ThenTheResultShouldBeAListOfEmployees()
        {
            Assert.That(allEmployees.Count > 0, Is.True);
        }

        [Then(@"the result should be an empty list")]
        public void ThenTheResultShouldBeAnEmptyList()
        {
            Assert.That(allEmployees.Count == 0, Is.True);
        }
    }
}
