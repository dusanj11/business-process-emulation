using Client;
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
            
        }
        
        [When(@"I request the data about logged employees")]
        public void WhenIRequestTheDataAboutLoggedEmployees()
        {
            loggedIn = ClientProxy.Instance.GetAllEmployees();
        }
        
        [When(@"if there is at least one logged employye")]
        public void WhenIfThereIsAtLeastOneLoggedEmployye()
        {
            int numberOfLogged = 0;
            allEmployees = ClientProxy.Instance.GetReallyAllEmployees();
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
            Assert.That(loggedIn.Count > 0, Is.True);
        }
    }
}
