using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoockiesTest.PageObject
{

    // Using Javascript to click links in order to avoid implicit waits from scrolling menu items into view.
    class ElementsMainPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = "https://demoqa.com/elements";
        private readonly string mainHeader = "Elements";

        public ElementsMainPage(IWebDriver driver)
        {
            this.Driver = driver;
        }
        public void LoadPage()
        {
            Driver.Navigate().GoToUrl(url);
            EnsurePageLoaded();
        }

        public void EnsurePageLoaded()
        {
            bool isLoaded = (Driver.Url == url) && (Driver.FindElement(By.ClassName("main-header")).Text == mainHeader);

            if (!isLoaded)
            {
                throw new Exception($"The requested page did not load correctly. The page url is: '{url}' The main header is: \r\n '{Driver.FindElement(By.ClassName("main-header")).Text}'");
            }
        }

        public WebTablesPage NavigateToWebTablesPage_SideMenu()
        {
            IWebElement webTablesMenuItem =
                Driver.FindElement(By.XPath("//div[contains(@class, 'element-group')][1]/div/ul/li[4]"));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", webTablesMenuItem);

            return new WebTablesPage(Driver);
        }
    }
}