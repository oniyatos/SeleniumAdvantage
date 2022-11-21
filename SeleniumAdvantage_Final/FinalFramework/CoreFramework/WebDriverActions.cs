using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFramework.CoreFramework
{
    public class WebDriverActions


    {
        public IWebDriver driver;

        public WebDriverActions(IWebDriver driver)
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
                TestContext.WriteLine("Click into element " + e.ToString + " Successfuly");

            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Click into element " + e.ToString + " Failed");
                throw ex;
            }
        }

        public void Click(String locator)
        {
            try
            {
                FindElementByXpath(locator).Click();
                TestContext.WriteLine("Click into element " + locator + " Successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Click into element " + locator + " Failed");
                throw ex;
            }
        }
        public void SendKeys(IWebElement e, string key)
        {
            try
            {
                e.SendKeys(key);
                TestContext.WriteLine("Sendkey into element " + e.ToString + " Successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Sendkey into element " + e.ToString + " Failed");
                throw ex;
            }
        }
        public void SendKeys(String locator, String key)
        {
            try
            {
                FindElementByXpath(locator).SendKeys(key);
                TestContext.WriteLine("Sendkey into element " + locator + " Successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Sendkey into element " + locator + " Failed");
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
                TestContext.WriteLine("Select element " + locator + " Successfuly with " + key);
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Select element " + locator + " Failed with " + key);
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
                TestContext.WriteLine("Take screen shot Successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Take screen shot Failed");
                throw ex;
            }
        }

        public String GetText(string locator)
        {
            string e = FindElementByXpath(locator).Text;
            return e;

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