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

            Console.WriteLine("===============First Email From First tab===============");
            tools.PublishEmail(driver, false, 0);

            Console.WriteLine("===============Last Email From First tab===============");
            tools.PublishEmail(driver, false, -1);

            tools.GetElement(driver, locators.SearchField).SendKeys(sender);
            tools.GetElement(driver, locators.SearchButton).Click();

            Console.WriteLine("===============First {0}'s Email From First tab===============", sender);
            tools.PublishEmail(driver, true, 0);

            Console.WriteLine("===============Last {0}'s Email From First tab===============",sender);
            tools.PublishEmail(driver, true, -1);

            driver.Quit();
            Console.ReadLine();
        }

    }
}
