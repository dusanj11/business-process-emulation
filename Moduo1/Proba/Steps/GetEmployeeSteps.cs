using Client;
using HiringCompanyData;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestStack.White;

namespace Proba.Steps
{
    [Binding]
    public class GetEmployeeSteps
    {
        private static Employee emp = new Employee();
        private static Application app;
        private static string us1;
        private static string us2;
        private static string us3;
        private static string ps1;
        private static string ps2;
        private static string ps3;
        [BeforeTestRun]
        public static  void BeforeTestRun()
        {
           app = Application.Launch(@"C:\Users\jelac\OneDrive\PSI\EPPRepo\Moduo1\HiringCompanyService\bin\Debug\HiringCompanyService.exe");
        }
        [AfterTestRun]
        public static void AftertestRun()
        {
            app.Close();
        }

        [Given(@"I can use database")]
        public void GivenICanUseDatabase()
        {
            
        }
        
        [Given(@"I have entered valid username and password")]
        public void GivenIHaveEnteredValidUsernameAndPassword()
        {
            us1 = "dule";
            ps1 = "dule";
        }
        
        [Given(@"I have the power work on datbase")]
        public void GivenIHaveThePowerWorkOnDatbase()
        {
            
        }
        
        [Given(@"I have entered valid username and invalid password")]
        public void GivenIHaveEnteredValidUsernameAndInvalidPassword()
        {
            //EmployeeDB.Instance.GetEmployee(null, null).Returns(new Employee());
            us2 = "dule";
            ps2 = "reoifrnfrno";
        }
        
        [Given(@"I have a way to read from database")]
        public void GivenIHaveAWayToReadFromDatabase()
        {
            
        }
        
        [Given(@"I have entered invalid data")]
        public void GivenIHaveEnteredInvalidData()
        {
            us3 = "eugieug";
            ps3 = "afewfewff";
        }
        
        [When(@"I request to get wanted data")]
        public void WhenIRequestToGetWantedData()
        {
            emp = ClientProxy.Instance.GetEmployee(us1, ps1);
        }
        
        [When(@"I request the possesion of that data")]
        public void WhenIRequestThePossesionOfThatData()
        {
            emp = ClientProxy.Instance.GetEmployee(us2, ps2);
        }
        
        [When(@"I request the certain data")]
        public void WhenIRequestTheCertainData()
        {
            emp = ClientProxy.Instance.GetEmployee(us3, ps3);
        }
        
        [Then(@"the result should be an instance of employee")]
        public void ThenTheResultShouldBeAnInstanceOfEmployee()
        {
            Assert.Equals(us1, emp.Username);
        }
        
        [Then(@"the result should be a null value or empty object")]
        public void ThenTheResultShouldBeANullValueOrEmptyObject()
        {
            Assert.That(emp == null, Is.True);
        }
        
        [Then(@"the result should be an empty object or null")]
        public void ThenTheResultShouldBeAnEmptyObjectOrNull()
        {
            Assert.That(emp == null, Is.True);
        }
    }
}
