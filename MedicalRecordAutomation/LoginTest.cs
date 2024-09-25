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
        public void ValidLoginTest()
        {
            driver.FindElement(By.Id("authUser")).SendKeys("admin");
            driver.FindElement(By.CssSelector("#clearPass")).SendKeys("pass");
            driver.FindElement(By.Id("login-button")).Click();

            //Assert the title  - OpenEMR
            Assert.That(driver.Title, Is.EqualTo("OpenEMR"));
        }

    }
}
