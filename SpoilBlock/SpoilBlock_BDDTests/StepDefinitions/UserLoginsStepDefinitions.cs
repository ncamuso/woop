using SpoilBlock_SpecflowTests.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpoilBlock_SpecflowTests.StepDefinitions
{
    public class TestUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    [Binding]
    public class UserLoginsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;

        [Given(@"the following users exist")]
        public void GivenTheFollowingUsersExist(Table table)
        {
            throw new PendingStepException();
        }

        [Given(@"the following users do not exist")]
        public void GivenTheFollowingUsersDoNotExist(Table table)
        {
            throw new PendingStepException();
        }

        [Given(@"I am a user with username '([^']*)'")]
        public void GivenIAmAUserWithUsername(string userame)
        {
            throw new PendingStepException();
        }

        [When(@"I login")]
        public void WhenILogin()
        {
            throw new PendingStepException();
        }

        [Then(@"I am redirected to the '([^']*)' page")]
        public void ThenIAmRedirectedToThePage(string home)
        {
            throw new PendingStepException();
        }

        [Then(@"I can see a personalized message in the drop down menu in the icon that includes my username")]
        public void ThenICanSeeAPersonalizedMessageInTheDropDownMenuInTheIconThatIncludesMyUsername()
        {
            throw new PendingStepException();
        }
    }
}
