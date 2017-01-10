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
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
        }
        
        [Given(@"I am able to access database")]
        public void GivenIAmAbleToAccessDatabase()
        {
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
        }
        
        [When(@"I request to have data about all employees")]
        public void WhenIRequestToHaveDataAboutAllEmployees()
        {
            allEmployees = EmployeeDB.Instance.GetReallyEmployees();
        }
        
        [When(@"I want to have the requested data")]
        public void WhenIWantToHaveTheRequestedData()
        {
            allEmployees = EmployeeDB.Instance.GetReallyEmployees();
        }
        
        [Then(@"the result should be a list of employees")]
        public void ThenTheResultShouldBeAListOfEmployees()
        {
            Assert.IsNotEmpty(allEmployees);
        }
        
        [Then(@"the result should be an empty list")]
        public void ThenTheResultShouldBeAnEmptyList()
        {
            Assert.IsEmpty(allEmployees);
        }
    }
}
