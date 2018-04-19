using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace mail.LoginPage
{
    class LoginElements
    {
        [FindsBy(How = How.XPath, Using = "//div/input[contains(@aria-label,'Email or phone')]")]
        public IWebElement login;


    }
}