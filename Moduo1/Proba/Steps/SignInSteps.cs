using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace Proba
{
    [Binding]
    public class SignInSteps
    {
        private static Application appServ;
        private static Application appClient;
        private static Window window;
        private static TextBox tbUsername;
        private static TextBox tbPassword;
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //appServ = Application.Launch(@"C:\Users\ftn\Desktop\dukiii\Moduo1\HiringCompanyService\bin\Debug\HiringCompanyService.exe");
            appClient = Application.Launch(@"C:\Users\ftn\Desktop\dukiii\Moduo1\Client\bin\Debug\Client.exe");
            window = appClient.GetWindow("Log in");
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            window.Close();
            appClient.Close();
            // appServ.Close();
        }
        [Given(@"I have started the application sucessfully")]
        public void GivenIHaveStartedTheApplicationSucessfully()
        {
            Console.WriteLine("Target application name : " + window.Title);
            Assert.IsNotNull(window.Title);
        }
        
        [Given(@"I have filled username and password with invalid data")]
        public void GivenIHaveFilledUsernameAndPasswordWithInvalidData()
        {
            tbUsername = window.Get<TextBox>("userTxt");
            tbPassword = window.Get<TextBox>("passTxt");
            tbUsername.Enter("Dule");
            tbPassword.Enter("lol");
        }
        
        [Given(@"I have run the correct application")]
        public void GivenIHaveRunTheCorrectApplication()
        {
            Console.WriteLine("Target application name : " + window.Title);
            Assert.IsNotNull(window.Title);
        }
        
        [Given(@"I have entered valid data in text boxes")]
        public void GivenIHaveEnteredValidDataInTextBoxes()
        {
            tbUsername = window.Get<TextBox>("userTxt");
            tbPassword = window.Get<TextBox>("passTxt");
            tbUsername.Enter("maki");
            tbPassword.Enter("maki");
        }
        
        [When(@"I push button ""(.*)""")]
        public void WhenIPushButton(string p0)
        {
            Button signIn = window.Get<Button>(p0);
            signIn.Click();
        }
        
        [When(@"I press ""(.*)""  button")]
        public void WhenIPressButton(string p0)
        {
            Button signIn = window.Get<Button>(p0);
            signIn.Click();
        }
        
        [Then(@"the dialog for client should not open")]
        public void ThenTheDialogForClientShouldNotOpen()
        {
            Assert.AreEqual("Log in", (appClient.GetWindows())[0].Title);
        }
        
        [Then(@"the dialog for client should open")]
        public void ThenTheDialogForClientShouldOpen()
        {
            Assert.AreEqual("Personal space", (appClient.GetWindows())[0].Title);
        }
    }
}
