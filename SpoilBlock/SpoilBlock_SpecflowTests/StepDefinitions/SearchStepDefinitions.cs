using System;
using TechTalk.SpecFlow;

namespace SpoilBlock_SpecflowTests.StepDefinitions
{
    [Binding]
    public class SearchStepDefinitions
    {
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            throw new PendingStepException();
        }

        [When(@"I navigate to the Search page")]
        public void WhenINavigateToTheSearchPage()
        {
            throw new PendingStepException();
        }

        [Then(@"I will see the search bar")]
        public void ThenIWillSeeTheSearchBar()
        {
            throw new PendingStepException();
        }

        [Given(@"I am on the search page")]
        public void GivenIAmOnTheSearchPage()
        {
            throw new PendingStepException();
        }

        [When(@"I enter <name> into the search bar")]
        public void WhenIEnterNameIntoTheSearchBar()
        {
            throw new PendingStepException();
        }

        [Then(@"I will see a table of shows")]
        public void ThenIWillSeeATableOfShows()
        {
            throw new PendingStepException();
        }

        [Then(@"<name> will be in the results in that table")]
        public void ThenNameWillBeInTheResultsInThatTable(Table table)
        {
            throw new PendingStepException();
        }
    }
}
