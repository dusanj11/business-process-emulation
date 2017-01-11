﻿using Client;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Proba.Steps
{
    [Binding]
    public class EmployeeLogInSteps
    {
        private static string us1;
        private static string us2;
        private static bool val1;
        private static bool val2;

        [When(@"I have entered valid username")]
        public void WhenIHaveEnteredValidUsername()
        {
            us1 = "dule";
        }
        
        [When(@"I request to change my log status")]
        public void WhenIRequestToChangeMyLogStatus()
        {
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            EmployeeDB.Instance.EmployeeLogIn(us1).Returns(val1 = true);
        }
        
        [When(@"I have entered invalid username")]
        public void WhenIHaveEnteredInvalidUsername()
        {
            us2 = "ufieuer";
        }
        
        [When(@"I have requested to update my log status")]
        public void WhenIHaveRequestedToUpdateMyLogStatus()
        {
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            EmployeeDB.Instance.EmployeeLogIn(us2).Returns(val2 = false);
        }
        
        [Then(@"the result should be returning true")]
        public void ThenTheResultShouldBeReturningTrue()
        {
            Assert.AreEqual(val1, true);
        }
        
        [Then(@"the result should not be returning true")]
        public void ThenTheResultShouldNotBeReturningTrue()
        {
            Assert.AreEqual(val2, false);
        }
    }
}
