using DocumentFormat.OpenXml.Bibliography;
using MedicalRecordAutomation.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomsonReuters.MedicalRecordAutomation.Pages
{
    public class LoginPage : WebDriverKeywords
    {
        private By usernameLocator = By.Id("authUser");
        private By passwordLocator = By.CssSelector("#clearPass");
        private By loginLocator = By.Id("login-button");
        private By errorLocator = By.XPath("//p[contains(text(),'Invalid')]");

        private IWebDriver driver;

        public LoginPage(IWebDriver driver):base(driver)
        {
            this.driver = driver;
        }

        public void EnterUsername(string username)
        {
            //driver.FindElement(usernameLocator).SendKeys(username);
            base.TypeOnElement(usernameLocator, username);
        }

        public void EnterPassword(string password)
        {
            //driver.FindElement(passwordLocator).SendKeys(password);
            base.TypeOnElement(passwordLocator, password);
        }

        public void ClickOnLogin()
        {
            //driver.FindElement(loginLocator).Click();
            ClickElement(loginLocator);
        }

        //GetInvalidErrorMessage()
        public string GetInvalidErrorMessage()
        {
           // return driver.FindElement(errorLocator).Text;
           return base.GetText(errorLocator);
        }

        public string GetUsernamePlaceholder()
        {
            //return driver.FindElement(usernameLocator).GetAttribute("placeholder");
            return base.GetAttributeValue(usernameLocator, "placeholder");
        }

        public string GetPasswordPlaceholder()
        {
            return driver.FindElement(passwordLocator).GetAttribute("placeholder");
        }

        //SelectLanguage()
        //ClickOnAckLicCert()
        //GetApplicationDescription()

    }
}
