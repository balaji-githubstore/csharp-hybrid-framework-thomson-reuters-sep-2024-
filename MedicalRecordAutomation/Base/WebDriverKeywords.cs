using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRecordAutomation.Base
{
    public class WebDriverKeywords
    {
        private IWebDriver driver;
        private DefaultWait<IWebDriver> wait;

        public WebDriverKeywords(IWebDriver driver)
        {
            this.driver = driver;

            wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(Exception));
            wait.Timeout = TimeSpan.FromSeconds(40);
        }

        public void ClickElement(By locator)
        {
            //driver.FindElement(locator).Click();
            wait.Until(x => x.FindElement(locator)).Click();
        }

        public void TypeOnElement(By locator, string text)
        {
            //driver.FindElement(locator).SendKeys(text);
            wait.Until(x => x.FindElement(locator)).SendKeys(text);
        }

        public string GetText(By locator)
        {
            return driver.FindElement(locator).Text;
        }

        public string GetAttributeValue(By locator, string attributeName)
        {
            return driver.FindElement(locator).GetAttribute(attributeName);
        }
        public void SwitchToWindowByTitle(string title)
        {
            foreach (string window in driver.WindowHandles)
            {
                driver.SwitchTo().Window(window);
                if (driver.Title.Equals(title))
                {
                    break;
                }
            }
        }
    }
}
