using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;
using System.Collections.ObjectModel;


namespace SpoilBlock_SpecflowTests.PageObjects
{
    public class HomePage : Page
    {
        //need to change elements to our homepage html elements& id

        private IWebElement Title => _browserInteractions.WaitAndReturnElement(By.Id("title"));
        private IWebElement WelcomeText => _browserInteractions.WaitAndReturnElement(By.Id("loggedin-welcome"));
        private IEnumerable<IWebElement> AppleButtons => _browserInteractions.WaitAndReturnElements(By.CssSelector("#listOfApples button"));

        public HomePage(IBrowserInteractions browserInteractions)
            : base(browserInteractions)
        {
            PageName = Common.HomePageName;
        }

        public string GetTitle => Title.Text;
        public string GetWelcomeText => WelcomeText.Text;

        public string GetAppleButtonText(int index) => AppleButtons.ElementAt(index).Text;

        public IEnumerable<string> GetAppleButtonTexts() => AppleButtons.Select(x => x.Text);

        

        

    }
}