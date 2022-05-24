using SpoilBlock_SpecflowTests.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpoilBlock_SpecflowTests.StepDefinitions
{
    public class TestAdd
    {
        public string ShowName { get; set; }
    }
        [Binding]
    public class AddStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;

        [When(@"I click the Add button next to <name>")]
        public void WhenIClickTheAddButtonNextToName()
        {
            int addIndex = 1;
            _homePage.ClickAddButton(addIndex);
        }

        [Then(@"My watchlist will contain <name>")]
        public void ThenMyWatchlistWillContainName(Table table)
        {
            throw new PendingStepException();
        }
    }
}
