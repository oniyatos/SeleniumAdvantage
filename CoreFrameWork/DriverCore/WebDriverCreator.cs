using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFrameWork.DriverCore
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
            else if (Browser.SequenceEqual("Chrome")) 
            {

                Driver = new ChromeDriver();

            }
            else if (Browser.SequenceEqual("Safari")) 
            {

                Driver = new SafariDriver();

            }

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Size = new Size(ScreenWidth, ScreenHight);
            return Driver;

        }
        public static IWebDriver CreateBrowserStackDriver(String Browser, int ScreenWidth, int ScreenHight)
        {
            IWebDriver? Driver = null;
            if (Browser.SequenceEqual("firefox"))
            {

                Driver = new FirefoxDriver();

            }
            else if (Browser.SequenceEqual("Chrome"))
            {

                Driver = new ChromeDriver();

            }
            else if (Browser.SequenceEqual("Safari"))
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
