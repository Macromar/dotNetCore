using mail;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ConsoleOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            Tools tools = new Tools();

            tools.SettingsUpload();
            Console.Clear();
            Console.WriteLine("Please spicify the name from whom first and last email should be shown");
            string sender = Console.ReadLine();
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("http://mail.google.com");
            tools.Login(driver);

            //driver.FindElement(By.XPath("//div[@role='search']//input[@type='text']")).SendKeys("bet.pt");
            //driver.FindElement(By.XPath("//div[@role='search']//button")).Click();


            //IWebElement tableElement = driver.FindElement(By.XPath("//div[@role='main']//table"));///////////////////////////////////////////
            //IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
            //tools.EmailToConsole(driver, tableRow, 0);
            //driver.Navigate().Back();
            //Console.WriteLine("===============The next one is below===============");
            //tableElement = driver.FindElement(By.XPath("//div[@role='main']//table"));///////////////////////////////////////////
            //tableRow = tableElement.FindElements(By.TagName("tr"));
            //Thread.Sleep(1000);
            //tools.EmailToConsole(driver, tableRow, tableRow.Count - 1);
            
            
            IList<IWebElement> tableRow = tools.GetElement(driver,"EmailList").FindElements(By.TagName("tr"));
            Console.WriteLine("===============First Email From First tab===============");
            tools.EmailToConsole(driver, tableRow, 0);
            driver.Navigate().Back();

            Console.WriteLine("===============Last Email From First tab===============");
            tableRow = tools.GetElement(driver, "EmailList").FindElements(By.TagName("tr"));
            tools.EmailToConsole(driver, tableRow, tableRow.Count - 1);
            driver.Navigate().Back();

            tools.GetElement(driver, "SearchField").SendKeys(sender);
            tools.GetElement(driver, "SearchButton").Click(); ;

            Console.WriteLine("===============First {0}'s Email From First tab===============", sender);
            tableRow = tools.GetElement(driver, "EmailList").FindElements(By.TagName("tr"));
            tools.EmailToConsole(driver, tableRow, 0);
            driver.Navigate().Back();

            Console.WriteLine("===============Last {0}'s Email From First tab===============",sender);
            tableRow = tools.GetElement(driver, "EmailList").FindElements(By.TagName("tr"));
            tools.EmailToConsole(driver, tableRow, tableRow.Count - 1);
            driver.Navigate().Back();

            driver.Quit();
            Thread.Sleep(1000);

        }

    }
}
