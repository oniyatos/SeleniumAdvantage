using CoreFramework.DriverCore;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace RookiesTest.TestSetup
{ 
public class NUnitTestSetup : WebDriverManager
{
    public IWebDriver? driver;
    public WebDriverAction? driverBaseAction;

    [SetUp]
    public void Setup()
    {
        WebDriverManager.InitDriver("chrome", 1920, 1080);
        driver = WebDriverManager.GetCurrentDriver();
    }

    [TearDown]
    public void TearDown()
    {
        // _driver?.Quit();
        TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        if (testStatus.Equals(TestStatus.Passed))
        {
            TestContext.WriteLine("Passed");
        }
        else if (testStatus.Equals(TestStatus.Failed))
        {
            TestContext.WriteLine("Failed");
                driverBaseAction.CapturedScreen();
        }
    }

}
}