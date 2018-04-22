using ConsoleOutput;
using mail;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
namespace TestLoginPage
{
    class LoginPage
    {
        IWebDriver driver;
        Tools tools = new Tools();
        Locators locators = new Locators();
        public static IConfiguration Configuration { get; set; }
        public LoginPage() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Settings.json");
            Configuration = builder.Build();
        }
        

        [SetUp]
        public void InitialActions()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.Navigate().GoToUrl(Configuration["Url"]);
        }

        [Test(Description = "Full success flow for login")]
        //[Repeat(10)]
        public void SuccessLogin()
        {
            tools.LoginPass(driver, Configuration["Login"]);
            tools.PasswordPass(driver, Configuration["Password"]);
            Assert.IsTrue(driver.FindElement(locators.SearchField).Displayed);
            
        }

        [Test(Description = "Language switcher")]
        //[Repeat(10)]
        public void LanguageSwitcher()
        {
            driver.FindElement(locators.LanguageToSelect).Click();
            driver.FindElement(locators.EnglishToSelect).Click();
            string text = driver.FindElement(locators.TextSignIn).Text;
            Assert.AreEqual("Sign in", text);
        }

        [Test(Description = "Hint on absent user")]
        //[Repeat(10)]
        public void HintOnAbsent()
        {
            driver.FindElement(locators.LanguageToSelect).Click();
            driver.FindElement(locators.EnglishToSelect).Click();
            tools.LoginPass(driver,"aaa");
            string hint = driver.FindElement(locators.LoginHint).Text;
            Assert.IsTrue(hint.Contains("Couldn't find your Google Account"));
        }

        [Test(Description = "MegaTest")]
        //[Repeat(10)]
        public void TitleName() {
            Assert.AreEqual("Gmail", driver.Title);
        }

        [TearDown]
        public void AtTheEnd()
        {
            driver.Quit();
        }
    }
}



