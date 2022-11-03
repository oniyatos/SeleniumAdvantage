using CoreFramework.DriverCore;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CoreFramework.DriverCore;

public class NUnitTestSetup : WebDriverManager
{
    [TestFixture]
    public class NUnit_Test_Setup
    {
        public IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            WebDriverManager.InitDriver("chrome", 1920, 1080);
            driver = WebDriverManager.GetCurrentDriver();
        }

        [TearDown]
        public void TearDown()
        {
            //_driver?.Quit();
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus.Equals(TestStatus.Passed))
            {
                TestContext.WriteLine("Passed");
            }
            else if (testStatus.Equals(TestStatus.Failed))
            {
                TestContext.WriteLine("Failed");
            }
        }
    }
}
