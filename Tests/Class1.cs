using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class Class1
    {
        IWebDriver driver = new ChromeDriver();
        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://www.citrus.ua/");
            //var popup = driver.FindElement(By.XPath("//div[@class='el-dialog__body']"));
            //if (popup.Displayed)
            //{
            //   driver.FindElement(By.XPath("//button[@class='el-dialog__headerbtn']")).Click();
            //}
        }



        [Test]
        public void SearchingByMacbook()
        {
            var item = "MacBook";
            driver.FindElement(By.XPath("//input[@type='search']")).SendKeys(item);
            driver.FindElement(By.XPath("//i[@class='el-icon-search']")).Click();
            var itemList = driver.FindElements(By.XPath("//div[@class='catalog__items']"));

            bool items = itemList.All(e => e.Equals(item));
            Assert.IsTrue(items, "There are some elements without 'MacBook' in title");

            driver.Quit();
        }

        [Test]
        public void SelectingLG()
        {
            var item = "LG";
            Actions action = new Actions(driver);
            IWebElement tv = driver.FindElement(By.XPath("//div[@class='menu--desktop__drop-list show']/ul/li/a[@href='/televizory/']"));
            action.MoveToElement(tv).Perform();
            Thread.Sleep(2000);
            IWebElement a = driver.FindElement(By.XPath("//*[@id='header']/div[3]/div/div[2]/div[2]/ul/li[8]/div/div/div[1]/ul/li[3]/a"));
            action.MoveToElement(a).Click();


            var listOfItems = driver.FindElements(By.XPath("//div[@class='catalog__items']"));

            bool items = listOfItems.All(e => e.Equals(item));
            Assert.IsTrue(items, "There are some elements without 'LG' in title");
            driver.Quit();
        }

        [Test]
        public void NameAndPriceDisplayedCorrect()
        {
            driver.FindElement(By.XPath("//div[@class='menu--desktop__drop-list show']/ul/li/a[@href='/televizory/']")).Click();
            Thread.Sleep(2000);
            var name = driver.FindElement(By.XPath("//div[@class='catalog__items']/descendant::a[contains(@title,'Skyworth 49')]/span")).Text;
            Thread.Sleep(2000);
            var price = driver.FindElement(By.XPath("//*[@id='__layout']/div/main/section/div[1]/div[2]/div[2]/div/div[2]/div/div[1]/div/div[2]/div[5]/div[1]/span[1]")).Text;
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@class='catalog__items']/descendant::a[contains(@title,'Skyworth 49')]/span")).Click();
            Assert.AreEqual("Skyworth 49\" 4K Smart TV (49Q3AI)", name);
            Assert.AreEqual("19 999", price);
           
        }

        

    }
}