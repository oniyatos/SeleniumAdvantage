
using OpenQA.Selenium;
using CoreFrameWork.DriverCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.DriverCore;

namespace RookieTest.PageObject
{
    public class LoginPage : WebDriverAction
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private readonly String tfUsername = "//input[@name='uid']";

        public void InputUserName(String UserName)
        {
            SendKeys_(tfUsername, UserName);
        }
    }
}
