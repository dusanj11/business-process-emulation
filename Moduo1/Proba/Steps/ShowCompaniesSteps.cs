﻿using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Proba
{
    [Binding]
    public class ShowCompaniesSteps
    {
        private static Application appServ;
        private static Application appClient;
        private static Window window;
        private static Window windowCl;
        private static TextBox tbUsername;
        private static TextBox tbPassword;

        //[BeforeTestRun]
        //public static void BeforeTestRun()
        //{
        //    //appServ = Application.Launch(@"C:\Users\ftn\Desktop\dukiii\Moduo1\HiringCompanyService\bin\Debug\HiringCompanyService.exe");
        //    //appClient = Application.Launch(@"C:\Users\ftn\Desktop\dukiii\Moduo1\Client\bin\Debug\Client.exe");
        //    window = appClient.GetWindow("Log in");
        //}
        //[AfterTestRun]
        //public static void AfterTestRun()
        //{
        //    window.Close();
        //    appClient.Close();
        //    // appServ.Close();
        //}

        [Given(@"I have logged in succesfully")]
        public void GivenIHaveLoggedInSuccesfully()
        {
            Console.WriteLine("Target application name : " + window.Title);
            Assert.IsNotNull(window.Title);
            tbUsername = window.Get<TextBox>("userTxt");
            tbPassword = window.Get<TextBox>("passTxt");
            tbUsername.Enter("Dule"); //izmeniti na validne podatke
            tbPassword.Enter("lol");  //izmeniti na validne podatke
            Button signIn = window.Get<Button>("signInBtn");
            signIn.Click();
            windowCl = appClient.GetWindow("Log in");
        }
        
        [When(@"I press button ""(.*)""")]
        public void WhenIPressButton(string p0)
        {
            Button showProj = window.Get<Button>(p0);
            showProj.Click();
        }
        
        [Then(@"the window should contain a data grid with that information")]
        public void ThenTheWindowShouldContainADataGridWithThatInformation()
        {
            SearchCriteria searchCriteria = SearchCriteria
            .ByAutomationId("projectsDataGrid");
            ListView dg = (ListView)windowCl.Get(searchCriteria);
            Assert.IsNotNull(dg);
        }
    }
}
