using SpoilBlock_SpecflowTests.PageObjects;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SpoilBlock_SpecflowTests.StepDefinitions
{
    [Binding]
    public class SearchStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly LoginPage _loginPage;
        private readonly SearchPage _searchPage;

        public SearchStepDefinitions(ScenarioContext context, LoginPage loginPage, SearchPage searchPage)
        {
            _scenarioContext = context;
            _loginPage = loginPage;
            _searchPage = searchPage;
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            _loginPage.Goto();
            _loginPage.EnterUsername("SampleUser1");
            _loginPage.EnterPassword("Password1!");
            //_loginPage.EnterUsername("ncamuso");
            //_loginPage.EnterPassword("Hi!12345");
            _loginPage.Login();
        }

        [When(@"I navigate to the Search page")]
        public void WhenINavigateToTheSearchPage()
        {
            _searchPage.Goto();
        }

        [Then(@"I will see the search bar")]
        public void ThenIWillSeeTheSearchBar()
        {
            Assert.That(_searchPage.SearchBarExists, Is.True);
        }

        [Given(@"I am on the search page")]
        public void GivenIAmOnTheSearchPage()
        {
            _searchPage.Goto();
        }

        [When(@"I enter (.*) into the search bar")]
        public void WhenIEnterNameIntoTheSearchBar(string name)
        {
            _searchPage.makeSearch(name);
        }

        [Then(@"I will see a table of shows")]
        public void ThenIWillSeeATableOfShows()
        {
            Assert.That(_searchPage.getTitles().Any(), Is.True);
        }

        [Then(@"(.*) will be in the results in that table")]
        public void ThenNameWillBeInTheResultsInThatTable(string name)
        {
            var titles = _searchPage.getTitles();
            Assert.That(titles.Contains(name));
        }
    }
}
