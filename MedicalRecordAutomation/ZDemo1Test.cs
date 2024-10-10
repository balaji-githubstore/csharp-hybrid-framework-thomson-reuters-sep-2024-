using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using ClosedXML.Excel;

namespace MedicalRecordAutomation
{
    /// <summary>
    /// Will be deleted
    /// </summary>
    public class ZDemo1Test
    {

        public static object[] ValidData()
        {
            //testcase1 
            //size - number of arguments
            string[] dataSet1 = new string[2];
            dataSet1[0] = "saul";
            dataSet1[1] = "saul123";

            //testcase1
            string[] dataSet2 = new string[2];
            dataSet2[0] = "peter";
            dataSet2[1] = "peter123";

            //testcase1
            string[] dataSet3 = new string[2];
            dataSet3[0] = "kim";
            dataSet3[1] = "kim123";

            string[] dataSet4 = new string[2];
            dataSet4[0] = "bala";
            dataSet4[1] = "bala123";

            //size - number of test case
            object[] finalData = new object[4];
            finalData[0] = dataSet1;
            finalData[1] = dataSet2;
            finalData[2] = dataSet3;
            finalData[3] = dataSet4;

            return finalData;

        }

        [Test]
        [TestCaseSource(nameof(ValidData))]
        public void ValidTest(string username, string password)
        {
            Console.WriteLine("hello" + username + password);
        }


        /// <summary>
        /// Will be deleted. Just for understanding excel read
        /// </summary>
        [Test]
        public void ReadExcelTest()
        {
            var book = new XLWorkbook(@"C:\Mine\Company\Thomson Reuters Sep 2024\AutomationFrameworkSolution\MedicalRecordAutomation\TestData\openemr_data.xlsx");
            var sheet = book.Worksheet("ValidLoginTest");
            var range = sheet.RangeUsed();
            int rowCount = range.RowCount();
            int cellCount = range.ColumnCount();

            //size - number of testcase
            object[] finalData = new object[rowCount - 1];

            for (int r = 2; r <= rowCount; r++)
            {
                //size - number of arguments/columncount
                string[] dataSet = new string[cellCount];

                for (int c = 1; c <= cellCount; c++)
                {
                    string value = range.Cell(r, c).GetString();
                    Console.WriteLine(value);
                    dataSet[c - 1] = value;
                }
                finalData[r - 2] = dataSet;
            }
            book.Dispose();
        }


        [Test]
        public void DemoExtentReport()
        {
            // start reporters //initialization of report config // run once before all test starts
            var reporter = new ExtentSparkReporter("spark.html");
            var extent = new ExtentReports();
            extent.AttachReporter(reporter);


            // creates a test // run before each [Test]
            var test = extent.CreateTest("Valid Login Test");

            // log(Status, details)
            test.Log(Status.Info, "This step shows usage of log(status, details)");

            // info(details)
            test.Info("This step shows usage of info(details)");


            // log with snapshot //run after each [Test]
            test.Pass("details");


            // runs at the end after all [Test] completes
            extent.Flush();
        }
    }
}
