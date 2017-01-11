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
            EmployeeDB.Instance.GetReallyEmployees().Returns(allEmployees = new List<Employee>()
            {
                new Employee()
                {
                    Name = "Dusan",
                    Surname = "Jeftic",
                    Username = "dule",
                    Password = "dule",
                    Position = PositionEnum.HR.ToString(),
                    StartTime = "10.15",
                    EndTime = "17.15",
                    Email = "dusan.jeftic11@gmail.com",

                }
            });
        }
        
        [When(@"I want to have the requested data")]
        public void WhenIWantToHaveTheRequestedData()
        {
            EmployeeDB.Instance.GetReallyEmployees().Returns(allEmployees = null);
        }
        
        [Then(@"the result should be a list of employees")]
        public void ThenTheResultShouldBeAListOfEmployees()
        {
            Assert.That(allEmployees.Count > 0, Is.True);
        }
        
        [Then(@"the result should be an empty list")]
        public void ThenTheResultShouldBeAnEmptyList()
        {
            Assert.That(allEmployees == null, Is.True);
        }
    }
}
