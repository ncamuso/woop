using System;
using TechTalk.SpecFlow;

namespace SpoilBlock_SpecflowTests.StepDefinitions
{
    [Binding]
    public class HomePageAddStepDefinitions
    {
        [Given(@"I am logged in the account")]
        public void GivenIAmLoggedInTheAccount()
        {
            throw new PendingStepException();
        }

        [Given(@"I am on the homepage page")]
        public void GivenIAmOnTheHomepagePage()
        {
            throw new PendingStepException();
        }

        [When(@"I click the Add next to shows <name>")]
        public void WhenIClickTheAddNextToShowsName()
        {
            throw new PendingStepException();
        }

        [Then(@"<name> will be added to my watchlist")]
        public void ThenNameWillBeAddedToMyWatchlist()
        {
            throw new PendingStepException();
        }
    }
}
