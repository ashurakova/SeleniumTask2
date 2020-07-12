using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumTask2.Pages
{
    public class ActionsPage
    {
        private IWebDriver driver;

        public ActionsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search GitHub']")]
        private IWebElement SearchBar { get; set; }

        public void SearchExecution(string searchValue)
        {
            SearchBar.SendKeys(searchValue + Keys.Enter);
        }
    }
}
