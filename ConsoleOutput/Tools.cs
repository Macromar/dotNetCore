using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mail
{
    class Tools
    {
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
            IList<IWebElement> td = k.FindElements(By.TagName("td"));
            k.Click();
            IWebElement element = driver.FindElement(By.XPath("//div[@style='display:']"));
            //driver.FindElement(By.XPath("//div[3]/div/div[2]/div/div[2]/div/div/div/div/div[2]/div/div/div/div[2]/div/table"));/////////////////////////////////////////////////////
            //element= element.FindElement(By.XPath("//div[@style='display:']"));
            Console.WriteLine(element.Text);
            //IList<IWebElement> tableRow1 = tableElement1.FindElements(By.TagName("tr"));
            //foreach (var row in tableRow1)
            //{
            //    IList<IWebElement> td1 = row.FindElements(By.TagName("td"));
            //        Console.WriteLine(td1[0].Text);
            //}
        }
    }
}
