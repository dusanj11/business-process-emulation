using System;
using TechTalk.SpecFlow;

namespace Proba
{
    [Binding]
    public class ShowProjectSteps
    {
        [Given(@"I have signed in sucessfully")]
        public void GivenIHaveSignedInSucessfully()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I push ""(.*)"" button")]
        public void WhenIPushButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the user control for showing projects should be desplayed in current window")]
        public void ThenTheUserControlForShowingProjectsShouldBeDesplayedInCurrentWindow()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
