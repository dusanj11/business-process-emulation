﻿using Client;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Proba.Steps
{
    [Binding]
    public class EmployeeLogOutSteps
    {
        private static string us1;
        private static string us2;
        private static bool val1;
        private static bool val2;

        [When(@"I have presented incorrect username")]
        public void WhenIHavePresentedIncorrectUsername()
        {
            us2 = "ufieuer";
        }
        
        [When(@"I have request to change log status")]
        public void WhenIHaveRequestToChangeLogStatus()
        {
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            EmployeeDB.Instance.EmployeeLogOut(us2).Returns(val2 = false);
        }
        
        [When(@"I have presented correct username")]
        public void WhenIHavePresentedCorrectUsername()
        {
            us1 = "dule";
        }
        
        [When(@"I have requested changing log status")]
        public void WhenIHaveRequestedChangingLogStatus()
        {
            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            EmployeeDB.Instance.EmployeeLogOut(us1).Returns(val1 = true);
        }
        
        [Then(@"the result should be returning false")]
        public void ThenTheResultShouldBeReturningFalse()
        {
            Assert.AreEqual(val2, false);
        }
        
        [Then(@"the result should be returning positive value")]
        public void ThenTheResultShouldBeReturningPositiveValue()
        {
            Assert.AreEqual(val1, true);
        }
    }
}
