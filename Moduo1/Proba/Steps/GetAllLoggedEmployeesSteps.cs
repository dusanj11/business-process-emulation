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
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();    
        }
        
        [When(@"I request the data about logged employees")]
        public void WhenIRequestTheDataAboutLoggedEmployees()
        {
            EmployeeDB.Instance.GetEmployees().Returns(loggedIn = new List<Employee>()
                {
                new Employee()
                {
                    Name = "Dusan",
                    Surname = "Jeftic",
                    Username = "dule",
                    Password = "dule",
                    Position = PositionEnum.HR.ToString(),
                    Login = true,
                    StartTime = "10.15",
                    EndTime = "17.15",
                    Email = "dusan.jeftic11@gmail.com",

                }
            });
        }
        
        [When(@"if there is at least one logged employye")]
        public void WhenIfThereIsAtLeastOneLoggedEmployye()
        {
            int numberOfLogged = 0;
            EmployeeDB.Instance.GetReallyEmployees().Returns(allEmployees = new List<Employee>()
                {
                new Employee()
                {
                    Name = "Dusan",
                    Surname = "Jeftic",
                    Username = "dule",
                    Password = "dule",
                    Position = PositionEnum.HR.ToString(),
                    Login = true,
                    StartTime = "10.15",
                    EndTime = "17.15",
                    Email = "dusan.jeftic11@gmail.com",

                }
            });
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
