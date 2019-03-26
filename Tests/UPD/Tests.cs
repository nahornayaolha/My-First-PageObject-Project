using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.UPD
{
    class Tests
    {
        IWebDriver driver = new DriverFactory().GetDriver("Chrome");
        
        [Test]
        public void SearchingByMacbook()
        {
            HomePage hp1 = new HomePage(driver);
            string item = "MacBook";
            string URL = "https://www.citrus.ua/";
            hp1.Navigate(URL);
            hp1.Search(item);
            hp1.ValidateResults(item);
            driver.Quit();
        }

        [Test]
        public void SelectingLG()
        {
            HomePage hp1 = new HomePage(driver);
            string item = "LG";
            string URL = "https://www.citrus.ua/";
            hp1.Navigate(URL);
            hp1.LGFilter(item);
            hp1.ValidateResults(item);
            driver.Quit();
        }
    }
}
