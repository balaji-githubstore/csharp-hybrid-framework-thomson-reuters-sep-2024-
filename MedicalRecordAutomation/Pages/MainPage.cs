using MedicalRecordAutomation.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomsonReuters.MedicalRecordAutomation.Pages
{
    /// <summary>
    /// All common elements like menu, profile which gets displayed on all pages 
    /// will be handled here
    /// </summary>
    public class MainPage : WebDriverKeywords
    {
        private By patientMenuLocator = By.XPath("//div[text()='Patient']");
        private By newSearchMenuLocator = By.XPath("//div[text()='New/Search']");

        private IWebDriver driver;

        public MainPage(IWebDriver driver):base(driver) 
        {
            this.driver = driver;
        }

        public string GetMainPageTitle()
        {
            return driver.Title;
        }

        public void ClickOnPatientMenu()
        {
            //driver.FindElement(patientMenuLocator).Click();
            ClickElement(patientMenuLocator);
        }

        public void ClickOnNewSearchMenu()
        {
            driver.FindElement(newSearchMenuLocator).Click();
        }

        
    }
}
