using GLib;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V104.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Libs.MediaFoundation.Interop;
using CoreFrameWork.DriverCore;
using PayPal.Manager;

namespace CoreFramework.DriverCore
{
    internal class WebDriverManager
    {
        private static AsyncLocal<IWebDriver> driver = new AsyncLocal<IWebDriver>();

        public static void InitDriver(String Browser, int Width, int Height)
        {
            IWebDriver newDriver = null;
            newDriver = WebDriverCreator.CreateLocalDriver(Browser, Width, Height);

            if (newDriver == null)
                throw new Exception($"{Browser} browser is not supported");
            driver.Value = newDriver;
        }

        public static IWebDriver GetCurrentDriver()
        {
            return driver.Value;
        }

        public static void CloseDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();

            }
        }
    }
}

