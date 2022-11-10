using NUnit.Framework;
using NUnit.Framework.Internal;
using RookiesTest.TestSetup;
using RookiesTest.PageObject;

namespace RookiesTest.TestCase 
{
    public class SimpleTest : ProjectNUnitTestSetup
    {
        [Test]
        public void simpleTest()
        {
            HomePage homePage = new HomePage(_driver);
            ContactUsPage contactUsPage = new ContactUsPage(_driver);
            
            homePage.clickOnContactus();            
            contactUsPage.verifyTitle("Contact us - My Store");
            contactUsPage.back();
            homePage.verifyTitle("My Store");

        }
        
    }
}
