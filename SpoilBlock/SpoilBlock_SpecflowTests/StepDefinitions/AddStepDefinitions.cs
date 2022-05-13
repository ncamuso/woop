using System;
using TechTalk.SpecFlow;

namespace SpoilBlock_SpecflowTests.StepDefinitions
{
    [Binding]
    public class AddStepDefinitions
    {
        [When(@"I click the Add button next to <name>")]
        public void WhenIClickTheAddButtonNextToName()
        {
            throw new PendingStepException();
        }

        [Then(@"My watchlist will contain <name>")]
        public void ThenMyWatchlistWillContainName(Table table)
        {
            throw new PendingStepException();
        }
    }
}
