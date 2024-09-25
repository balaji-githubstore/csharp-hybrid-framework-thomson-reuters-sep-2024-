using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomsonReuters.MedicalRecordAutomation.Base;

namespace ThomsonReuters.MedicalRecordAutomation
{
    public class LoginTest : AutomationWrapper
    {
        [Test]
        [TestCase("admin", "pass", "OpenEMR")]
        [TestCase("accountant", "accountant", "OpenEMR")]
        public void ValidLoginTest(string username, string password, string expectedValue)
        {
            driver.FindElement(By.Id("authUser")).SendKeys(username);
            driver.FindElement(By.CssSelector("#clearPass")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();

            //Assert the title  - OpenEMR
            Assert.That(driver.Title, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase("saul","saul234", "Invalid username or password")]
        public void invalidLoginTest(string username,string password,string expectedError)
        {
            driver.FindElement(By.Id("authUser")).SendKeys(username);
            driver.FindElement(By.CssSelector("#clearPass")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();

            //Assert the error - Invalid username or password
        }
    }
}
