using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTask2.Pages;

namespace SeleniumTask2
{
    public class SeleniumWebDriverTest
    {
        private IWebDriver driver;

        [SetUp]
        public void InitializeDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void PerformTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.OpenHomePage();
            homePage.ActionItemClick();

            ActionsPage actionsPage = new ActionsPage(driver);
            actionsPage.SearchExecution("Selenium");

            SearchResultPage searchResultPage = new SearchResultPage(driver);
            searchResultPage.OpenFirstResultInNewTab();
            searchResultPage.SearchResultPageRefresh();
            
            SeleniumRepositoryPage seleniumRepositoryPage = new SeleniumRepositoryPage(driver);
            seleniumRepositoryPage.CheckRepositoryName();

            ActionsWithTabs.CloseCurrentTab(driver);
            ActionsWithTabs.SwitchToFirstTab(driver);

            ApiDotNetPage apiDotNetPage = new ApiDotNetPage(driver);
            apiDotNetPage.OpenApiDotNetPage();
            apiDotNetPage.PageSourceSaving();
            apiDotNetPage.IHasInputDeviceElementPresent();
        }
        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}