using Client;
using HiringCompanyContract;
using HiringCompanyData;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace Proba
{
    [Binding]
    public class GetAllNotLoggedEmployeesSteps
    {
        private static List<Employee> notLoggedIn = new List<Employee>();
        private static List<Employee> allEmployees = new List<Employee>();


        [Given(@"I have a way of accesing database")]
        public void GivenIHaveAWayOfAccesingDatabase()
        {
            //EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            // ClientProxy.Instance = Substitute.For<IHiringCompany>();

        }

        [When(@"I request the data about late employees")]
        public void WhenIRequestTheDataAboutLateEmployees()
        {
            //EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            //notLoggedIn = EmployeeDB.Instance.GetAllNotSignedInEmployees();
            notLoggedIn = ClientProxy.Instance.GetAllNotSignedInEmployees();
        }

        [When(@"if there is at least one who is late")]
        public void WhenIfThereIsAtLeastOneWhoIsLate()
        {
            // EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            int numberOfNotLogged = 0;
            //allEmployees = EmployeeDB.Instance.GetReallyEmployees();
            allEmployees = ClientProxy.Instance.GetReallyAllEmployees();
            Assert.That(allEmployees.Count > 0, Is.True);
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
            Assert.That(notLoggedIn.Count > 0, Is.True);
        }
    }
}
