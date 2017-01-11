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
           EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
        
        }
        
        [When(@"I request the data about late employees")]
        public void WhenIRequestTheDataAboutLateEmployees()
        {

            EmployeeDB.Instance.GetAllNotSignedInEmployees().Returns(notLoggedIn = new List<Employee>()
                {
                new Employee()
                {
                    Name = "Dusan",
                    Surname = "Jeftic",
                    Username = "dule",
                    Password = "dule",
                    Position = PositionEnum.HR.ToString(),
                    Login = false,
                    StartTime = "10.15",
                    EndTime = "17.15",
                    Email = "dusan.jeftic11@gmail.com",

                }
            });
        }
        
        [When(@"if there is at least one who is late")]
        public void WhenIfThereIsAtLeastOneWhoIsLate()
        {
            int numberOfNotLogged = 0;
            EmployeeDB.Instance.GetReallyEmployees().Returns(allEmployees = new List<Employee>()
                {
                new Employee()
                {
                    Name = "Dusan",
                    Surname = "Jeftic",
                    Username = "dule",
                    Password = "dule",
                    Position = PositionEnum.HR.ToString(),
                    Login = false,
                    StartTime = "10.15",
                    EndTime = "17.15",
                    Email = "dusan.jeftic11@gmail.com",

                }
            });
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
