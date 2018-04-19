﻿﻿using mail.LoginPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;



namespace mail
{
    [TestFixture]
    public class TestsLoginPage
    {
        IWebDriver driver;
        Tools tools = new Tools();
        Dictionary<string, string> xpathLocators = new Dictionary<string, string>();
        Dictionary<string, string> settings = new Dictionary<string, string>();
        string locatorsFile;
        string settingsFile;

        [SetUp]
        public void InitialActions()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            locatorsFile = Environment.CurrentDirectory.ToString();
            locatorsFile = Path.GetFullPath(Path.Combine(locatorsFile, @"..\..\..\..\locators.json"));
            settingsFile = Path.GetFullPath(Path.Combine(locatorsFile, @"..\.\Settings.json"));
            xpathLocators = tools.JsonToDictionary(locatorsFile);
            settings = tools.JsonToDictionary(settingsFile);
            driver.Navigate().GoToUrl("http://mail.google.com");
        }

        [Test(Description ="Full success flow for login")]
        public void SuccessLogin()
        {
            driver.FindElement(By.XPath(xpathLocators["Login"])).SendKeys(settings["Login"]);
            driver.FindElement(By.XPath(xpathLocators["LoginButton"])).Click();
            driver.FindElement(By.XPath(xpathLocators["Password"])).SendKeys(settings["Password"]);
            driver.FindElement(By.XPath(xpathLocators["PasswordButton"])).Click();
            Assert.IsTrue(driver.FindElement(By.Id(":5")).Displayed);
        }

        [Test(Description = "Language switcher")]
        public void LanguageSwitcher() {
            driver.FindElement(By.XPath(xpathLocators["LanguageToSelect"])).Click();
            driver.FindElement(By.XPath(xpathLocators["EnglishToSelect"])).Click();
            string text =driver.FindElement(By.XPath(xpathLocators["TextSignIn"])).Text;
            Assert.AreEqual("Sign in", text);
        }



        [TearDown]
        public void AtTheEnd() {
            driver.Quit();
           // driver.Close();
        }
    }
}