using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTask2
{
    public class SearchResultPage
    {
        private IWebDriver driver;
        public SearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//ul[@class='repo-list']/li[1]//a[1]")]
        private IWebElement FirstSearchResult { get; set; }
        
        public void SearchResultPageRefresh()
        {
            driver.Navigate().Refresh();
        }

        public void OpenFirstResultInNewTab()
        {
            string linkToTab = FirstSearchResult.GetAttribute("href");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            List<string> handles = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(handles[1]);
            driver.Navigate().GoToUrl(linkToTab);
        }
    }
}