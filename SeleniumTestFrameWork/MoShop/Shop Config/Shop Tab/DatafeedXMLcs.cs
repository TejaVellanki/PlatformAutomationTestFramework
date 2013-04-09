using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium;

namespace MoBankUI
{
    class DatafeedXML
    {
        public void datafeed(IWebDriver driver, ISelenium selenium,datarow datarow)
        {
            driver.FindElement(By.LinkText("MoShop")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.CssSelector("#IndexMenuLeaf3 > a")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.LinkText("TestShop")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.LinkText("Shop")).Click();           
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.LinkText("…")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.Id("File")).Clear();
            driver.FindElement(By.Id("File")).SendKeys("C:\\Users\\teja\\Documents\\GitHub\\PlatformAutomationTestFramework\\SeleniumTestFrameWork\\MoShop\\Shop Config\\Catalogue XML's\\test-catalogue-big.zip");
            driver.FindElement(By.CssSelector("div.box > p.right > input.button")).Click();
            selenium.WaitForPageToLoad("30000");
            string title = driver.Title.ToString();
            RunScrape run = new RunScrape();
            run.scarperead(driver, selenium, datarow, title);
            run.scrapeandfeedrunning(driver, selenium, datarow);
            links_TPS hom = new links_TPS();
            hom.Links(datarow, driver, selenium, "testshop.mobankdev.com");         


        }
    }
}
