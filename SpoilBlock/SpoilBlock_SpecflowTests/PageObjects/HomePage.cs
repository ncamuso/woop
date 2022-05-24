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
        private IEnumerable<IWebElement> NewShowTitle => _browserInteractions.WaitAndReturnElements(By.Id("newShowTitle"));
        private IEnumerable<IWebElement> AddButton => _browserInteractions.WaitAndReturnElements(By.ClassName("btn btn-primary"));


        public HomePage(IBrowserInteractions browserInteractions)
            : base(browserInteractions)
        {
            PageName = Common.HomePageName;
        }

        public string GetTitle => Title.Text;
        public string GetWelcomeText => WelcomeText.Text;

        public string GetAddButtonText(int index) => AddButton.ElementAt(index).Text;

        //public string GetTableTexts((int index) => NewShowsTable.ElementAt(index).Text;

        //public string GetShowsTitle((int index)) => NewShowsTable.ElementAt(index).Text;
        public IEnumerable<string> GetAddButtonTexts() => AddButton.Select(x => x.Text);


        public void ClickAddButton(int index)
        {
            AddButton.ElementAt(index).Click();
        }




    }
}