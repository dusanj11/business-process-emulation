using HiringCompanyData;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Proba
{
    [Binding]
    public class GetAllLoggedEmployeesSteps
    {
        private static List<Employee> loggedIn = new List<Employee>();
        private static List<Employee> allEmployees = new List<Employee>();

        [Given(@"I have access to database")]
        public void GivenIHaveAccessToDatabase()
        {
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
        }
        
        [When(@"I request the data about logged employees")]
        public void WhenIRequestTheDataAboutLoggedEmployees()
        {
            loggedIn = EmployeeDB.Instance.GetEmployees();
        }
        
        [When(@"if there is at least one logged employye")]
        public void WhenIfThereIsAtLeastOneLoggedEmployye()
        {
            int numberOfLogged = 0;
            allEmployees = EmployeeDB.Instance.GetReallyEmployees();
            //Assert.IsNotEmpty(allEmployees);
            Assert.That(allEmployees.Count > 0, Is.True);
            foreach (Employee emp in allEmployees)
            {
                if (emp.Login)
                    numberOfLogged++;
            }
            Assert.Greater(numberOfLogged, 0);
        }
        
        [Then(@"the result should be list of Employees")]
        public void ThenTheResultShouldBeListOfEmployees()
        {
            //Assert.IsNotEmpty(loggedIn);
            Assert.Greater(loggedIn.Count, 0);
        }
    }
}
