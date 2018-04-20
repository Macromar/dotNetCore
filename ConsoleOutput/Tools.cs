using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mail
{
    class Tools
    {
        Dictionary<string, string> xpathLocators;
        public Dictionary<string, string> settings;

        public Dictionary<string,string> JsonToDictionary(string path) {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            StreamReader stream = new StreamReader(path);
            string jsonString = stream.ReadToEnd();
            dictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            
            return dictionary;
        }
        public void EmailToConsole(IWebDriver driver, IList<IWebElement> table, int numberOfEmail)
        {
            var k = table[numberOfEmail];
            IList<IWebElement> td = k.FindElements(By.TagName("tr"));
            k.Click();
            IWebElement element = driver.FindElement(By.XPath("//div[@style='display:']"));
            Console.WriteLine(element.Text);
        }
        public void Login(IWebDriver driver)
        {
            driver.FindElement(By.XPath(xpathLocators["Login"])).SendKeys(settings["Login"]);
            driver.FindElement(By.XPath(xpathLocators["LoginButton"])).Click();
            driver.FindElement(By.XPath(xpathLocators["Password"])).SendKeys(settings["Password"]);
            driver.FindElement(By.XPath(xpathLocators["PasswordButton"])).Click();
        }
        public void SettingsUpload() {
            string locatorsFile = Environment.CurrentDirectory.ToString();
            locatorsFile = Path.GetFullPath(Path.Combine(locatorsFile, @"..\..\..\..\locators.json"));
            string settingsFile = Path.GetFullPath(Path.Combine(locatorsFile, @"..\.\Settings.json"));
            xpathLocators = new Dictionary<string, string>(JsonToDictionary(locatorsFile));
            settings = new Dictionary<string, string>(JsonToDictionary(settingsFile));
        }

        public IWebElement GetElement(IWebDriver driver,string s) {
            return driver.FindElement(By.XPath(xpathLocators[s]));
        }
    }
}
