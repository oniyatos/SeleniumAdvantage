using CoreFramework.UnitTestSetup;
using NUnit.Framework;

namespace RookiesTest.TestSetup
{
    public class ProjectNUnitTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "http://automationpractice.com/index.php";
        }
        [TearDown]
        public void TearDown()
        {
           
        }
    }
}
