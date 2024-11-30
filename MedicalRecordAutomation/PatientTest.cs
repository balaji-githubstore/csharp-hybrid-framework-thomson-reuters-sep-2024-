using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomsonReuters.MedicalRecordAutomation.Base;

namespace ThomsonReuters.MedicalRecordAutomation
{
    public class PatientTest : AutomationWrapper
    {
        [Test]
        public void AddValidPatientDetailTest()
        {
            driver.FindElement(By.Id("authUser")).SendKeys("admin");
            driver.FindElement(By.CssSelector("#clearPass")).SendKeys("pass");
            driver.FindElement(By.Id("login-button")).Click();

            driver.FindElement(By.XPath("//div[text()='Patient']")).Click();

            driver.FindElement(By.XPath("//div[text()='New/Search']")).Click();
        }
    }
}
