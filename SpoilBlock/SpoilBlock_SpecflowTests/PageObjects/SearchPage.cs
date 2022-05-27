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
        private IWebElement ResultsTable => _browserInteractions.WaitAndReturnElement(By.Id("resultsTable"));

        public bool GetSearchBox => SearchBox.Displayed;

        public string ResultTableText => ResultsTable.Text;

        public SearchPage(IBrowserInteractions browserInteractions)
            : base(browserInteractions)
        {
            PageName = Common.SearchPageName;
        }

        public bool SearchBarExists()
        {
            if (SearchBox != null)
                return true;
            return false;
        }
        public void makeSearch(string searchQuery)
        {
            SearchBox.SendKeysWithClear(searchQuery);
            SearchButton.Click();
        }

        public List<string> getTitles()
        {
            var titleTds = ResultsTable.FindElements(By.ClassName("mediatitle"));
            var returnList = new List<string>();
            foreach (var titleTd in titleTds)
            {
                returnList.Add(titleTd.Text);
            }

            return returnList;
        }

        public void Add(string title)
        {
            ResultsTable.FindElements(By.ClassName("btn")).WhereElementsHavePropertyValue("data-title", title).FirstOrDefault().Click();
        }

    }
}
