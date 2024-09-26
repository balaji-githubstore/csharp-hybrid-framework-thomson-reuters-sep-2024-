using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomsonReuters.MedicalRecordAutomation.Pages
{
    public class AcknowledgmentsPage
    {
        private IWebDriver driver;

        public AcknowledgmentsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
