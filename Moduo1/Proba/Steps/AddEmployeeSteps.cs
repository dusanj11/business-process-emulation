using System;
using TechTalk.SpecFlow;

namespace Proba
{
    [Binding]
    public class AddEmployeeSteps
    {
        [Given(@"I can write in database")]
        public void GivenICanWriteInDatabase()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have entered employee with existing username")]
        public void GivenIHaveEnteredEmployeeWithExistingUsername()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have power to write on database")]
        public void GivenIHavePowerToWriteOnDatabase()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have entered non existing username for employee")]
        public void GivenIHaveEnteredNonExistingUsernameForEmployee()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I request to add him/her")]
        public void WhenIRequestToAddHimHer()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I request to put them in database")]
        public void WhenIRequestToPutThemInDatabase()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be false")]
        public void ThenTheResultShouldBeFalse()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be true")]
        public void ThenTheResultShouldBeTrue()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
