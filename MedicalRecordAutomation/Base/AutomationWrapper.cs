using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomsonReuters.MedicalRecordAutomation.Base
{
    public class AutomationWrapper
    {
        protected IWebDriver driver;

        [SetUp]
        public void BeforeTestMethod()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Navigate().GoToUrl("https://demo.openemr.io/b/openemr");
        }

        [TearDown]
        public void AfterTestMethod()
        {
            driver.Dispose();
        }
    }
}
