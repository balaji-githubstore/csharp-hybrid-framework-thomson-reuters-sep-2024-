using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomsonReuters.MedicalRecordAutomation
{
    /// <summary>
    /// Login UI Test Cases
    /// </summary>
    public class LoginUITest
    {
        IWebDriver driver;

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


        [Test]
        public void TitleTest()
        {
            string actualTitle = driver.Title;
            Assert.That(actualTitle, Is.EqualTo("OpenEMR Login"));
        }

        [Test]
        public void ApplicationDescriptionTest()
        {
            //Assert the text --> "The most popular open-source Electronic Health Record and Medical Practice Management solution."
            string actualDescription = driver.FindElement(By.XPath("//p[contains(text(),'most')]")).Text;
            Assert.That(actualDescription, Is.EqualTo("The most popular open-source Electronic Health Record and Medical Practice Management solution."));
        }
    }
}
