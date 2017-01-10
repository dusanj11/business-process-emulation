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
    public class GetAllNotLoggedEmployeesSteps
    {
        private static List<Employee> notLoggedIn;
        private static List<Employee> allEmployees;

        [Given(@"I have a way of accesing database")]
        public void GivenIHaveAWayOfAccesingDatabase()
        {
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
        }
        
        [When(@"I request the data about late employees")]
        public void WhenIRequestTheDataAboutLateEmployees()
        {
            notLoggedIn = EmployeeDB.Instance.GetAllNotSignedInEmployees();
        }
        
        [When(@"if there is at least one who is late")]
        public void WhenIfThereIsAtLeastOneWhoIsLate()
        {
            int numberOfNotLogged = 0;
            allEmployees = EmployeeDB.Instance.GetReallyEmployees();
            Assert.IsNotEmpty(allEmployees);
            foreach (Employee emp in allEmployees)
            {
                if (!emp.Login)
                    numberOfNotLogged++;
            }
            Assert.Greater(numberOfNotLogged, 0);
        }
        
        [Then(@"the result should be a list of  employees who are late")]
        public void ThenTheResultShouldBeAListOfEmployeesWhoAreLate()
        {
            Assert.IsNotEmpty(notLoggedIn);
        }
    }
}
