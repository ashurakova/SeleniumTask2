using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTask2
{
    public static class ActionsWithTabs
    {
        public static void SwitchToFirstTab(IWebDriver driver)
        {
            List<string> handles = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(handles[0]);
        }

        public static void CloseCurrentTab(IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.close();");
        }
    }
}