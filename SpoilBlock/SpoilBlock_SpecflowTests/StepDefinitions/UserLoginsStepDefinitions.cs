using SpoilBlock_SpecflowTests.PageObjects;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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

        public UserLoginsStepDefinitions(ScenarioContext context, LoginPage loginPage, HomePage homePage)
        {
            _scenarioContext = context;
            _loginPage = loginPage;
            _homePage = homePage;
        }

        [Given(@"the following users exist")]
        public void GivenTheFollowingUsersExist(Table table)
        {
            IEnumerable<TestUser> users = table.CreateSet<TestUser>();
            _scenarioContext["Users"] = users;
        }

        [Given(@"the following users do not exist")]
        public void GivenTheFollowingUsersDoNotExist(Table table)
        {
            IEnumerable<TestUser> nonUsers = table.CreateSet<TestUser>();
            _scenarioContext["NonUsers"] = nonUsers;
        }

        [Given(@"I am a user with username '([^']*)'")]
        public void GivenIAmAUserWithUsername(string username)
        {
            IEnumerable<TestUser> users = (IEnumerable<TestUser>)_scenarioContext["Users"];
            TestUser u = users.Where(u => u.UserName == username).FirstOrDefault();
            if (u == null)
            {
                // must have been selecting from non-users
                IEnumerable<TestUser> nonUsers = (IEnumerable<TestUser>)_scenarioContext["NonUsers"];
                u = nonUsers.Where(u => u.UserName == username).FirstOrDefault();
            }
            _scenarioContext["CurrentUser"] = u;
        }

        [When(@"I login")]
        [Given(@"I login")]
        public void WhenILogin()
        {
            // Go to the login page
            _loginPage.Goto();


            TestUser u = (TestUser)_scenarioContext["CurrentUser"];
            _loginPage.EnterUsername(u.UserName);
            _loginPage.EnterPassword(u.Password);
            _loginPage.Login();
        }

        [Then(@"I am redirected to the '([^']*)' page")]
        public void ThenIAmRedirectedToThePage(string home)
        {
            _homePage.Goto(home);
            
        }

        [Then(@"I can see a message in the homepage")]
        public void ThenICanSeeAMessageInTheHomepage()
        {
            TestUser u = (TestUser)_scenarioContext["CurrentUser"];
            _homePage.GetWelcomeText.Should().ContainEquivalentOf(u.UserName, AtLeast.Once());
        }
        [Then(@"I can see a login error message")]
        public void ThenICanSeeALoginErrorMessage()
        {
            _loginPage.HasLoginError().Should().BeTrue();
        }

    }
}
