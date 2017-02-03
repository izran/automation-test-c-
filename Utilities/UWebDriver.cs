using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Test.Utility {
    class UWebDriver {

        public static IWebDriver GetDriver() {
            IWebDriver oDriver = new ChromeDriver();
            oDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            oDriver.Url = ConfigurationManager.AppSettings["Url"];
            return oDriver;
        }
    }
}
