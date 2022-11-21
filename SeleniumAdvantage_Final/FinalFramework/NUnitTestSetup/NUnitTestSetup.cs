using FinalFramework.CoreFramework;
using FinalFramework.Reporter;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;


namespace FinalFramework.NUnitTestSetup
{
    [TestFixture]
    public class NUnitTestSetup
    {
        public IWebDriver? driver;
        public WebDriverActions driverBaseAction;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            HtmlReport.createTest(TestContext.CurrentContext.Test.ClassName);
        }
        [SetUp]
        public void SetUp()
        {

            HtmlReport.createNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name);
            WebDriverManager.InitDriver("chrome", 1920, 1080);
            driver = WebDriverManager.GetCurrentDriver();

        }
        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus.Equals(TestStatus.Passed))
            {
                TestContext.WriteLine("passed");
            }
            else if (testStatus.Equals(TestStatus.Failed))
            {
                TestContext.WriteLine("failed");
            }
            HtmlReport.flush();
        }
    }
}
