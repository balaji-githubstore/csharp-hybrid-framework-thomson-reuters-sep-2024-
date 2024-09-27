using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomsonReuters.MedicalRecordAutomation.Pages
{
    public class LoginPage 
    {
        private By usernameLocator = By.Id("authUser");
        private By passwordLocator = By.CssSelector("#clearPass");
        private By loginLocator = By.Id("login-button");
        private By errorLocator = By.XPath("//p[contains(text(),'Invalid')]");

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterUsername(string username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
        }

        public void ClickOnLogin()
        {
            driver.FindElement(loginLocator).Click();
        }

        //GetInvalidErrorMessage()
        public string GetInvalidErrorMessage()
        {
            return driver.FindElement(errorLocator).Text;
        }

        public string GetUsernamePlaceholder()
        {
            return driver.FindElement(usernameLocator).GetAttribute("placeholder");
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
