using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomsonReuters.MedicalRecordAutomation.Utilities
{
    /// <summary>
    /// Class dedicated to keep all the test data required for the test methods.
    /// Create all testcase source static method to keep the test data
    /// </summary>
    public class DataSource
    {
        /// <summary>
        /// Testdata for ValidLoginTest
        /// </summary>
        /// <returns>object[]</returns>
        public static object[] ValidLoginData()
        {
            string[] dataSet1 = new string[3];
            dataSet1[0] = "admin";
            dataSet1[1] = "pass";
            dataSet1[2] = "OpenEMR";

            string[] dataSet2 = new string[3];
            dataSet2[0] = "accountant";
            dataSet2[1] = "accountant";
            dataSet2[2] = "OpenEMR";

            object[] finalData = new object[2];
            finalData[0] = dataSet1;
            finalData[1] = dataSet2;
            return finalData;
        }


    }
}
