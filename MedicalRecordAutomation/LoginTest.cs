using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomsonReuters.MedicalRecordAutomation.Base;
using ThomsonReuters.MedicalRecordAutomation.Utilities;
using ThomsonReuters.MedicalRecordAutomation.Pages;

namespace ThomsonReuters.MedicalRecordAutomation
{
    public class LoginTest : AutomationWrapper
    {
        [Test]
        [TestCaseSource(typeof(DataSource), nameof(DataSource.ValidLoginDataExcel))]
        public void ValidLoginTest(string username, string password, string expectedValue)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.ClickOnLogin();

            //Assert the title  - OpenEMR
            Assert.That(driver.Title, Is.EqualTo(expectedValue));
        }

        [Test]
        //[TestCaseSource(typeof(DataSource), nameof(DataSource.InvalidLoginDataExcel))]
        [TestCase("saul", "saul234", "Invalid username or password")]
        public void InvalidLoginTest(string username, string password, string expectedError)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.ClickOnLogin();

            //Assert the error - Invalid username or password
            string actualError = login.GetInvalidErrorMessage();
            Assert.That(actualError.Contains(expectedError)); //expect true
        }
    }
}
