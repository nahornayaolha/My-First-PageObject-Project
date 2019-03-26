using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UPD
{
    public class DriverSingleton
    {
        private static IWebDriver driver;
        private DriverSingleton() { }

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    driver = new DriverFactory().GetDriver("Chrome");
                }
                return driver;
            }
        }
    }
}
