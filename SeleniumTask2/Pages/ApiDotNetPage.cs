using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.IO;

namespace SeleniumTask2
{
    public class ApiDotNetPage
    {
        private IWebDriver driver;
        string apiDonNetPageURL = "https://www.selenium.dev/selenium/docs/api/dotnet/";
        public ApiDotNetPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'IHasInputDevices')][contains(text(),'Interface')]")]
        private IWebElement IHasInputInputDeviceInterface { get; set; }

        public void OpenApiDotNetPage()
        {
            driver.Navigate().GoToUrl(apiDonNetPageURL);
        }

        public void PageSourceSaving()
        {
            string[] pageSource;
            pageSource = driver.PageSource.Split(' ');
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\ExtractContent");
            using (StreamWriter sw = File.CreateText(Directory.GetCurrentDirectory() + @"\ExtractContent\pageSource.html"))
            {
                foreach (string item in pageSource)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public void IHasInputDeviceElementPresent()
        {
            driver.Navigate().GoToUrl(Directory.GetCurrentDirectory() + @"\ExtractContent\pageSource.html");
            bool elementIsDisplayed=IHasInputInputDeviceInterface.Displayed;
            if (!elementIsDisplayed)
            {
                throw new Exception("Element is absent");
            }
            
        }
    }
}