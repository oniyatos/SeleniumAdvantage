using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalFramework.APICore;
using AventStack.ExtentReports.MarkupUtils;

namespace FinalFramework.Reporter
{
    internal class HtmlReport
    {
        public static int testCaseIndex;
        public static ExtentReports report;
        public static ExtentTest extentTestSuite;
        public static ExtentTest extentTestCase;


        public static ExtentReports createReport()
        {
            if (report == null)
            {
                report = createInstance();
            }
            return report;
        }
        public static ExtentReports createInstance()
        {
            HtmlReportDirectory.InitReportDirection();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(HtmlReportDirectory.Report_File_Path);
            htmlReporter.Config.DocumentTitle = "Automation Test Report";
            htmlReporter.Config.ReportName = "Automation Test Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlReporter.Config.Encoding = "UTF-8";

            ExtentReports report = new ExtentReports();
            report.AttachReporter(htmlReporter);
            return report;

        }
        public static void flush()
        {
            if (report != null)
            {
                report.Flush();
            }

        }
        public static ExtentTest createTest(string className, string classDescription = "")
        {
            if (report == null)
            {
                report = createInstance();
            }
            extentTestSuite = report.CreateTest(className, classDescription);

            return extentTestSuite;
        }
        public static ExtentTest createNode(string className, string testCase, string description = "")
        {

            if (extentTestSuite == null)
            {
                extentTestSuite = createTest(className);
            }

            extentTestCase = extentTestSuite.CreateNode(testCase, description);

            return extentTestCase;
        }
        public static ExtentTest GetParent()
        {
            return extentTestSuite;
        }
        public static ExtentTest GetNode()
        {
            return extentTestCase;
        }
        public static ExtentTest GetTest()
        {
            if (GetNode() == null)
            {
                return GetParent();
            }
            return GetNode();
        }
        public static void Pass(string des)
        {
            GetTest().Pass(des);
            TestContext.WriteLine(des);
        }
        public static void Fail(string des, string path)
        {
            GetTest().Fail(MarkupHelper.CreateLabel(des, ExtentColor.Green)).AddScreenCaptureFromPath(path);
        }
        public static void Fail(string des, string ex, string path)
        {
            GetTest().Fail(des).Fail(ex).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }
        public static void Info(string des)
        {
            GetTest().Info(des);
            TestContext.WriteLine(des);
        }
        public static void Warning(string des)
        {
            GetTest().Warning(des);
            TestContext.WriteLine(des);
        }
        public static void Skip(string des)
        {
            GetTest().Skip(des);
            TestContext.WriteLine(des);
        }

        public static void MarkUpJson()
        {
            var json = "{'name':'LONGTAU', 'age':20, 'car':'BMW'}";
            GetTest().Info(MarkupHelper.CreateCodeBlock(json, CodeLanguage.Json));
        }

        public static void MarkUpTable()
        {
            string[][] table = new string[][] { new string[]
            { "TestID", "TestName", "Description" },
            new string[]
            { "01", "Login Test", "Login with exist user name and password" },
            new string[]
            { "02", "Register Test", "Creat new account" },
            new string[]
            { "03", "Logout Test", "Logout" }
            };
            GetTest().Info(MarkupHelper.CreateTable(table));
        }

        internal static void CreateAPIRequestLog(APIRequest aPIRequest, APIResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
