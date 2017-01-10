using System;
using TechTalk.SpecFlow;

namespace Proba
{
    [Binding]
    public class ProbaSteps
    {
        [Given(@"I have sucessfully loaded the application")]
        public void GivenIHaveSucessfullyLoadedTheApplication()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have entered valid username and password")]
        public void GivenIHaveEnteredValidUsernameAndPassword()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press ""(.*)"" button")]
        public void WhenIPressButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the client dialog should open")]
        public void ThenTheClientDialogShouldOpen()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
