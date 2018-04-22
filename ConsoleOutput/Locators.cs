using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOutput
{
    public class Locators
    {
        public By Login =               By.XPath("//input[@type='email']");
        public By Password =            By.XPath("//input[@type='password']");
        public By LoginHint =           By.XPath("//form/div[@role='presentation']//div[@aria-live='assertive']");
        public By LoginButton =         By.XPath("//div[@id='identifierNext']");
        public By PasswordButton =      By.XPath("//div[@id='passwordNext']");
        public By LanguageToSelect =    By.XPath("//div[@id='lang-chooser']");
        public By EnglishToSelect =     By.XPath("//div[@id='lang-chooser']/div[contains(@jsaction,'click')]//div[@data-value='en']");
        public By TextSignIn =          By.XPath("//content/h1[@id='headingText']");
        public By SearchField =         By.XPath("//div[@role='search']//input[@type='text']");
        public By SearchButton =        By.XPath("//div[@role='search']//button");
        public By EmailContent =        By.XPath("//div[@style='display:']");
        public By EmailList =           By.XPath("//div[@role='tabpanel']//table");
        public By FilteredEmailList =   By.XPath("//div[@role='main']//table");
        public By TableRow =            By.TagName("tr");
    }
}
