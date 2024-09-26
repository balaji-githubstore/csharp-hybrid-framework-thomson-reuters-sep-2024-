using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomsonReuters.MedicalRecordAutomation.Utilities
{
    public class ExcelSource
    {
        /// <summary>
        /// Convert the given excel file and sheet into object[]
        /// </summary>
        /// <param name="file"></param>
        /// <param name="sheetname"></param>
        /// <returns>object[]</returns>
        public static object[] GetSheetIntoObjectArray(string file, string sheetname)
        {
            var book = new XLWorkbook(file);
            var sheet = book.Worksheet(sheetname);
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
                    dataSet[c - 1] = range.Cell(r, c).GetString(); 
                }
                finalData[r - 2] = dataSet;
            }
            book.Dispose();

            return finalData;
        }
    }
}
