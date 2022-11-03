using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace CoreFramework.DriverCore
{
    public class WebDriverAction
    {
        public IWebDriver driver;

        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public By ByXpath(string locator)
        {
            return By.XPath(locator);
        }

        public string getTitle()
        {
            return driver.Title;
        }

        public IWebElement FindElementByXpath(string locator)
        {
            IWebElement e = driver.FindElement(ByXpath(locator));
            highlightElement(e);
            return e;
        }

        public IList<IWebElement> FindElementsByXPath(String locator)
        {
            return driver.FindElements(ByXpath(locator));
        }

        public IWebElement highlightElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("Argument[0].style.border='2px solid red", element);
            return element;
        }


        public void Click(IWebElement e)
        {
            try
            {
                highlightElement(e);
                e.Click();
                TestContext.WriteLine("click in to element" + e.ToString + "passed");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("click in to element" + e.ToString + "failed");
                throw ex;
            }
        }

        public void Click(String locator)
        {

            try
            {
                FindElementByXpath(locator).Click();
                TestContext.WriteLine("click into element" + locator + "passed");

            }
            catch (Exception ex)
            {

                TestContext.WriteLine("click into element" + locator + "failed");
                throw ex;
            }
        }

        public void SendKeys_(string locator, string key)
        {
            try
            {
                FindElementByXpath(locator).SendKeys(key);
                TestContext.WriteLine("sendkey into element" + locator + "passed");
            }
            catch (Exception ex)
            {

                TestContext.WriteLine("sendkey into element" + locator + "failed");
                throw ex;
            }
        }

        public void CapturedScreen()
        {
            throw new NotImplementedException();
        }
    }
}
