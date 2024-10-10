using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Support.Extensions;

namespace ThomsonReuters.MedicalRecordAutomation.Base
{
    public class AutomationWrapper
    {
        protected IWebDriver driver;

        protected ExtentTest test;
        private static ExtentReports extent;
        public static string projectPath;

        [OneTimeSetUp]
        public void Init()
        {
            if (extent == null)
            {
                projectPath = TestContext.CurrentContext.TestDirectory;
                projectPath = projectPath.Remove(projectPath.IndexOf("bin"));
      

                var reporter = new ExtentSparkReporter(projectPath+ @"\Reports\spark.html");
                extent = new ExtentReports();
                extent.AttachReporter(reporter);
            }
        }

        [OneTimeTearDown]
        public void End()
        {
            extent.Flush();
        }

        [SetUp]
        public void BeforeTestMethod()
        {

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);


            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Navigate().GoToUrl("https://demo.openemr.io/b/openemr");
        }

        [TearDown]
        public void AfterTestMethod()
        {
            string testName = TestContext.CurrentContext.Test.Name;

            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed)
            {
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;

                test.Log(Status.Fail, stackTrace + errorMessage);

               Screenshot sc= driver.TakeScreenshot();

                test.AddScreenCaptureFromBase64String(sc.AsBase64EncodedString, testName+" failed");

            }
            else if (status == TestStatus.Passed)
            {
                test.Log(Status.Pass, "Passed - Snapshot below:");
            }
            else if (status == TestStatus.Skipped)
            {
                test.Log(Status.Skip, "Skipped - " + testName);
            }



            driver.Dispose();
        }
    }
}
