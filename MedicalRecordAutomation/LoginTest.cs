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
using AventStack.ExtentReports;

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
            test.Log(Status.Info, "Entered username as " + username);

            login.EnterPassword(password);
            test.Log(Status.Info, "Entered password as " + username);

            login.ClickOnLogin();
            test.Log(Status.Info, "Clicked On Login");

            //Assert the title  - OpenEMR
            MainPage main = new MainPage(driver);
            Assert.That(main.GetMainPageTitle(), Is.EqualTo(expectedValue));

            test.Log(Status.Info, "Clicked on login and navigated to " + main.GetMainPageTitle());
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
