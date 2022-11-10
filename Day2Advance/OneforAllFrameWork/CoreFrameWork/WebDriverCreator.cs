using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OneforAllFrameWork.CoreFrameWork
{
    internal class WebDriverCreator
    {

        public static IWebDriver CreateLocalDriver(String Browser, int ScreenWidth, int ScreenHight)
        {
            IWebDriver? Driver = null;
            if (Browser.SequenceEqual("firefox"))
            {
                Driver = new FirefoxDriver();
            }
            else if (Browser.SequenceEqual("chrome"))
            {
                Driver = new ChromeDriver();
            }
            else if (Browser.SequenceEqual("safari"))
            {
                Driver = new SafariDriver();
            }
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Size = new Size(ScreenWidth, ScreenHight);
            return Driver;
        }

        public static IWebDriver CreateBrowserstackDriver(String Browser, int ScreenWidth, int ScreenHight)
        {
            IWebDriver? Driver = null;
            if (Browser.SequenceEqual("firefox"))
            {
                Driver = new FirefoxDriver();
            }
            else if (Browser.SequenceEqual("chrome"))
            {
                Driver = new ChromeDriver();
            }
            else if (Browser.SequenceEqual("safari"))
            {
                Driver = new SafariDriver();
            }
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Size = new Size(ScreenWidth, ScreenHight);
            return Driver;
        }
    }
}
