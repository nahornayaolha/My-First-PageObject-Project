using NUnit.Framework;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Tests.UPD
{
    public class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            
        }


        [FindsBy(How = How.XPath, Using = "//input[@type='search']")]
        private IWebElement SearchField { get; set; }
       

        [FindsBy(How = How.XPath, Using = "//i[@class='el-icon-search']")]
        private IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='catalog__items']")]
        private IWebElement ItemCatalog { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='menu--desktop__drop-list show']/ul/li/a[@href='/televizory/']")]
        private IWebElement TVElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='header']/div[3]/div/div[2]/div[2]/ul/li[8]/div/div/div[1]/ul/li[3]/a/span")]
        private IWebElement LGElement { get; set; }


        public void Navigate(string URL)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(URL);
            
        }

        public void Search(string item)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => SearchField.Displayed);
            wait.Until(driver => SearchButton.Displayed);
            this.SearchField.Clear();
            this.SearchField.SendKeys(item);
            this.SearchButton.Click();
        }

        public void ValidateResults(string item)
        {
            Assert.IsTrue(this.ItemCatalog.Text.Contains(item), 
                "Catalog contains some wrong items");
        }

        public void LGFilter(string item)
        {
            Actions action = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => TVElement.Displayed);
            action.MoveToElement(TVElement).Perform();
            //wait.Until(driver => LGElement.Displayed);
            action.MoveToElement(LGElement).Click();
        }


    }
}
