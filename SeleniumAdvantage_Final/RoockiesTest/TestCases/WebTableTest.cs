using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RoockiesTest.PageObject;
using RoockiesTest.TestSetup;

namespace RoockiesTest.TestCases
{
    public class WebTableTest : ProjectTestSetups
    {
        [Test]
        public void AddNewEntryToTable()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var webTablesPage = new WebTablesPage(driver);
                webTablesPage.LoadPage();
                webTablesPage.CreateNewEntry();
            }
        }

        [Test]
        public void EditExistingEntry()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var webTablesPage = new WebTablesPage(driver);
                webTablesPage.LoadPage();
                webTablesPage.EditExistingEntry();
            }
        }

        [Test]
        public void DeleteExistingEntry()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var webTablesPage = new WebTablesPage(driver);
                webTablesPage.LoadPage();
                webTablesPage.CreateNewEntry();
                webTablesPage.DeleteExistingEntry();
            }
        }
    }
}
