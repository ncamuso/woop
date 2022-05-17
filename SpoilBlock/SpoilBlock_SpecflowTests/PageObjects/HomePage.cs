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
    public class HomePage : Page
    {
        //need to change elements to our homepage html elements& id

        private IWebElement Title => _browserInteractions.WaitAndReturnElement(By.Id("title"));
        private IWebElement WelcomeText => _browserInteractions.WaitAndReturnElement(By.Id("loggedin-welcome"));
        private IWebElement NewShowsTable => _browserInteractions.WaitAndReturnElement(By.Id("newshowstable"));
        

        public HomePage(IBrowserInteractions browserInteractions)
            : base(browserInteractions)
        {
            PageName = Common.HomePageName;
        }

        public string GetTitle => Title.Text;
        public string GetWelcomeText => WelcomeText.Text;

        public void Add(string title)
        {
            NewShowsTable.FindElements(By.ClassName("btn")).WhereElementsHavePropertyValue("data-title", title).FirstOrDefault().Click();
        }




    }
}