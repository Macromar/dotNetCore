using mail;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ConsoleOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Tools tools = new Tools();
            string locatorsFile = Environment.CurrentDirectory.ToString();
            locatorsFile = Path.GetFullPath(Path.Combine(locatorsFile, @"..\..\..\..\locators.json"));
            string settingsFile = Path.GetFullPath(Path.Combine(locatorsFile, @"..\.\Settings.json"));
            Dictionary<string, string> xpathLocators = new Dictionary<string, string>(tools.JsonToDictionary(locatorsFile));
            Dictionary<string, string> settings = new Dictionary<string, string>(tools.JsonToDictionary(settingsFile));
            driver.Navigate().GoToUrl("http://mail.google.com");
            driver.FindElement(By.XPath(xpathLocators["Login"])).SendKeys(settings["Login"]);
            driver.FindElement(By.XPath(xpathLocators["LoginButton"])).Click();
            driver.FindElement(By.XPath(xpathLocators["Password"])).SendKeys(settings["Password"]);
            driver.FindElement(By.XPath(xpathLocators["PasswordButton"])).Click();

            IWebElement tableElement = driver.FindElement(By.Id(":34"));///////////////////////////////////////////
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
           // tools.EmailToConsole(driver, tableRow, 0);
            tools.EmailToConsole(driver, tableRow, tableRow.Count - 1);





            driver.Quit();
        }
        
    }

}
