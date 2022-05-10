using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;
using System.Collections.ObjectModel;
using Fuji_BDDTests.PageObjects;
using Fuji_BDDTests;

namespace SpoilBlock_SpecflowTests.PageObjects
{
    public class SearchPage : Page
    {
        private IWebElement SearchBox => _browserInteractions.WaitAndReturnElement(By.Id("searchQuery"));
        private IWebElement SearchButton => _browserInteractions.WaitAndReturnElement(By.Id("searchButton"));
        private IWebElement AddButton => _browserInteractions.WaitAndReturnElement(By.Id("resultsTable"));

        public SearchPage(IBrowserInteractions browserInteractions)
            : base(browserInteractions)
        {
            PageName = Common.SearchPageName;
        }

        public void makeSearch(string searchQuery)
        {
            SearchBox.SendKeysWithClear(searchQuery);
            SearchButton.Click();
        }

        public List<string> getTitles()

    }
}
