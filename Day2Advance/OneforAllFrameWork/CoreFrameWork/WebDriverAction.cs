using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneforAllFrameWork.CoreFrameWork
{
        public class WebDriverAction
    

        {
            public IWebDriver driver;

            public WebDriverAction(IWebDriver driver)
            {
                this.driver = driver;

            }

            public By ByXpath(String locator)
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

            public IList<IWebElement> FindElementsByXpath(String locator)
            {
                return driver.FindElements(ByXpath(locator));
            }

            public void Click(IWebElement e)
            {
                try
                {
                    highlightElement(e);
                    e.Click();
                    TestContext.WriteLine("Click into element " + e.ToString + " successfuly");

                }
                catch (Exception ex)
                {
                    TestContext.WriteLine("Click into element " + e.ToString + " failed");
                    throw ex;
                }
            }

            public void Click(String locator)
            {
                try
                {
                    FindElementByXpath(locator).Click();
                    TestContext.WriteLine("Click into element " + locator + " successfuly");
                }
                catch (Exception ex)
                {
                    TestContext.WriteLine("Click into element " + locator + " failed");
                    throw ex;
                }
            }
            public void SendKeys(IWebElement e, string key)
            {
                try
                {
                    e.SendKeys(key);
                    TestContext.WriteLine("Sendkey into element " + e.ToString + " successfuly");
                }
                catch (Exception ex)
                {
                    TestContext.WriteLine("Sendkey into element " + e.ToString + " failed");
                    throw ex;
                }
            }
            public void SendKeys(String locator, String key)
            {
                try
                {
                    FindElementByXpath(locator).SendKeys(key);
                    TestContext.WriteLine("Sendkey into element " + locator + " successfuly");
                }
                catch (Exception ex)
                {
                    TestContext.WriteLine("Sendkey into element " + locator + " failed");
                    throw ex;
                }
            }
            // action select option
            public void SelectOption(String locator, String key)
            {
                try
                {
                    IWebElement mySelectOption = FindElementByXpath(locator);
                    SelectElement dropdown = new SelectElement(mySelectOption);
                    dropdown.SelectByText(key);
                    TestContext.WriteLine("Select element " + locator + " successfuly with " + key);
                }
                catch (Exception ex)
                {
                    TestContext.WriteLine("Select element " + locator + " failed with " + key);
                    throw ex;
                }
            }
            // action get screenshot
            public void CapturedScreen()
            {
                try
                {

                    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                    ss.SaveAsFile("Test.jpg", ScreenshotImageFormat.Jpeg);
                    TestContext.WriteLine("Take screen shot successfully");
                }
                catch (Exception ex)
                {
                    TestContext.WriteLine("Take screen shot failed");
                    throw ex;
                }
            }
            public IWebElement highlightElement(IWebElement element)
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].style.border='2px solid red'", element);
                return element;
            }

            public void Back()
            {
            driver.Navigate().Back();
            }
            

        }
}
