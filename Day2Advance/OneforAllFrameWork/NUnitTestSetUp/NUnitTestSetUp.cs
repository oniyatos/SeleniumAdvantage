using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OneforAllFrameWork.CoreFrameWork;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Authentication.ExtendedProtection;
using AventStack.ExtentReports;
using CoreFramework.Reporter;

namespace OneforAllFrameWork.NUnitTestSetUp;

public class NUnitTestSetup
{
    public IWebDriver? driver;
    public WebDriverAction? driverBaseAction;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
            
        HtmlReport.createTest(TestContext.CurrentContext.Test.ClassName);
    }

    [SetUp]
    public void Setup()
    {
        HtmlReport.createNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name);
        WebDriverManager_.InitDriver("chrome", 1920, 1080);
        driver = WebDriverManager_.GetCurrentDriver();
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