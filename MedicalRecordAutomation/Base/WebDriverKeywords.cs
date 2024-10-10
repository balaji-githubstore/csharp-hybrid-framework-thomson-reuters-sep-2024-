using OpenQA.Selenium;
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

        public WebDriverKeywords(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickElement(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public void TypeOnElement(By locator,string text)
        {
            driver.FindElement(locator).SendKeys(text);
        }

        public string GetText(By locator)
        {
            return driver.FindElement(locator).Text;
        }

        public string GetAttributeValue(By locator,string attributeName)
        {
            return driver.FindElement(locator).GetAttribute(attributeName);
        }
    }
}
