using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumTask2
{
    public class SeleniumRepositoryPage
    {
        public SeleniumRepositoryPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver,this);
        }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'pagehead')]//*[@itemprop='name']/a")]
        private IWebElement SeleniumRepository { get; set; }
        public void CheckRepositoryName()
        {
            Assert.AreEqual(SeleniumRepository.Text, "selenium");
        }
    }
}