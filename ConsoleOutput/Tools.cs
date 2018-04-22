using ConsoleOutput;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace mail
{
    class Tools
    {
        Locators locators = new Locators();

        public void EmailToConsole(IWebDriver driver, IList<IWebElement> table, int numberOfEmail)
        {
            var k = table[numberOfEmail];
            k.Click();
            IWebElement element = driver.FindElement(locators.EmailContent);
            Console.WriteLine(element.Text);
        }

        public void PasswordPass(IWebDriver driver, string password)
        {
            driver.FindElement(locators.Password).SendKeys(password);
            driver.FindElement(locators.PasswordButton).Click();
        }
        public void LoginPass(IWebDriver driver, string login) {
            driver.FindElement(locators.Login).SendKeys(login);
            driver.FindElement(locators.LoginButton).Click();
        }

        public IWebElement GetElement(IWebDriver driver,By s) {
            return driver.FindElement(s);
        }
    }
}
