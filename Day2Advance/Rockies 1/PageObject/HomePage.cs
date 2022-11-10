using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;

namespace RookiesTest.PageObject

{
    public class HomePage : WebDriverAction
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }    
        private readonly String tfContactUs = "//*[@title=\"Contact us\"]";
        public void clickOnContactus()
        {
            Clicks(tfContactUs);
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
    }
}
