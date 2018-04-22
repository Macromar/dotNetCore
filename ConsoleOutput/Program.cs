using mail;
using Microsoft.Extensions.Configuration;
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
        public static IConfiguration Configuration { get; set; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Settings.json");
            Configuration = builder.Build();

            Tools tools = new Tools();
            Locators locators = new Locators();
            Console.Clear();

            string sender = Configuration["Sender"];

            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Navigate().GoToUrl(Configuration["Url"]);
            tools.LoginPass(driver, Configuration["Login"]);
            tools.PasswordPass(driver,  Configuration["Password"]);
            Console.Clear();

            IList<IWebElement> tableRow = tools.GetElement(driver,locators.EmailList).FindElements(locators.TableRow);
            Console.WriteLine("===============First Email From First tab===============");
            tools.EmailToConsole(driver, tableRow, 0);
            driver.Navigate().Back();

            Console.WriteLine("===============Last Email From First tab===============");
            tableRow = tools.GetElement(driver, locators.EmailList).FindElements(locators.TableRow);
            tools.EmailToConsole(driver, tableRow, tableRow.Count - 1);
            driver.Navigate().Back();

            tools.GetElement(driver, locators.SearchField).SendKeys(sender);
            tools.GetElement(driver, locators.SearchButton).Click(); ;

            Console.WriteLine("===============First {0}'s Email From First tab===============", sender);
            tableRow = tools.GetElement(driver, locators.FilteredEmailList).FindElements(locators.TableRow);
            tools.EmailToConsole(driver, tableRow, 0);
            driver.Navigate().Back();

            Console.WriteLine("===============Last {0}'s Email From First tab===============",sender);
            tableRow = tools.GetElement(driver, locators.FilteredEmailList).FindElements(locators.TableRow);
            tools.EmailToConsole(driver, tableRow, tableRow.Count - 1);
            driver.Navigate().Back();
            driver.Quit();
            Console.ReadLine();
        }

    }
}
