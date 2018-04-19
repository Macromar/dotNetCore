using mail;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace FirstLastToConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Tools tools = new Tools();
            Dictionary<string, string> xpathLocators = new Dictionary<string, string>();
            Dictionary<string, string> settings = new Dictionary<string, string>();
            string locatorsFile = Environment.CurrentDirectory.ToString();
            locatorsFile = Path.GetFullPath(Path.Combine(locatorsFile, @"..\..\..\locators.json"));
            string settingsFile = Path.GetFullPath(Path.Combine(locatorsFile, @"..\.\Settings.json"));
            xpathLocators = tools.JsonToDictionary(locatorsFile);
            settings = tools.JsonToDictionary(settingsFile);

            Dictionary<string, string> xpathLocators1 = new Dictionary<string, string>(tools.JsonToDictionary(locatorsFile));
            Console.WriteLine("12");
        }
    }
}
