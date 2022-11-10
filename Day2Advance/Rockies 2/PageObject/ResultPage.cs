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
    internal class ResultPage : WebDriverAction
    {
        public ResultPage(IWebDriver driver) : base(driver)
        {
        }
        private readonly String tfFirtResult = "//*[@class='LC20lb MBeuO DKV0Md'][1]";
        private readonly String tfSearchBox = "//*[@class='DocSearch-Button-Placeholder']";
        public void verifySearchTitle(string expectedTitle)
        {
            try
            {           
                Assert.AreEqual(expectedTitle+ " - Tìm trên Google", getTitle());
                TestContext.Write("2 Title match");
            }
            catch (Exception ex)
            {
                TestContext.Write("2 Title not match");
                throw ex;
            }
        }
        public void clickOnFirstResult()
        {
            Clicks(tfFirtResult);
        }
        public String getTextOfPageSearchBox()
        {
            return GetText(tfSearchBox);         
        }
        public void verifyPageSearchBoxText(string expectedText)
        {
            try
            {
                Assert.AreEqual(expectedText, getTextOfPageSearchBox());
                TestContext.Write("Text is" + expectedText);
            }
            catch (Exception ex)
            {
                TestContext.Write("Text not match");
                throw ex;
            }
        }

    }
}
