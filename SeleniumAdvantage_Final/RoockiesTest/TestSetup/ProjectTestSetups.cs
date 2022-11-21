using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalFramework.NUnitTestSetup;

namespace RoockiesTest.TestSetup
{
    public class ProjectTestSetups : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            driver.Url = "https://demoqa.com/";
        }
        [TearDown]
        public void TearDown()
        {
        }
    }
}