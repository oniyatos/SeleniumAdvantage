using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;
using TestProject.SDK.Interfaces;

namespace RookiesTest.PageObject
{
    internal class ContactUsPage : WebDriverAction
    {
        public ContactUsPage(IWebDriver driver) : base(driver)
        {
        }

        public void verifyTitle(string expectedTitle)
        {
            try
            {           
                Assert.AreEqual(expectedTitle, getTitle());
                TestContext.Write("2 Title match");
            }
            catch (Exception ex)
            {
                TestContext.Write("2 Title not match");
                throw ex;
            }
        }
        public void back()
        {
            Back();
        }
    }
}
