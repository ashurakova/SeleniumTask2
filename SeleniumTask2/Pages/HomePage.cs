using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace SeleniumTask2
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//summary[contains (text(), 'Why GitHub?')]")]
        private IWebElement WhyGitHubDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//li/a[@href=\"/features/actions\"]")]
        private IWebElement ActionItem { get; set; }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://github.com/");
        }

        public void ActionItemClick()
        {
            WebDriverWait waitForGitHubDropdown = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            waitForGitHubDropdown.Until(ExpectedConditions.ElementToBeClickable(WhyGitHubDropDown));
            WhyGitHubDropDown.Click();
            WebDriverWait waitForActionItem = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            waitForActionItem.Until(ExpectedConditions.ElementToBeClickable(ActionItem));
            ActionItem.Click();
        }
    }
}