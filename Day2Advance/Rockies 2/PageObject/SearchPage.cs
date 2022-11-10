using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;

namespace RookiesTest.PageObject

{
    public class SearchPage : WebDriverAction
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
        }
        private readonly String tfSearchBox = "//*[@class='gLFyf gsfi']";
        public void inputSearchKey(string Key)
        {
            SendKeys_(tfSearchBox, Key);
        }
        public void getResultPage()
        {
            SendKeys_(tfSearchBox, Keys.Enter);
        }
    }
}

