using CoreFramework.UnitTestSetup;
using NUnit.Framework;

namespace RookiesTest.TestSetup
{
    public class ProjectNUnitTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://www.google.com.vn/";
        }
        [TearDown]
        public void TearDown()
        {
           
        }
    }
}
