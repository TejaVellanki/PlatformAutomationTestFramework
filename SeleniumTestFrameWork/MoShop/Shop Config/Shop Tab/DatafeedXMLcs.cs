using System;
using OpenQA.Selenium;
using Selenium;

namespace MoBankUI
{
    internal class DatafeedXML
    {
        public void datafeed(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            try
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
          
            driver.FindElement(By.Id("File"))
                  .SendKeys(
                      "C:\\Users\\teja\\Documents\\GitHub\\PlatformAutomationTestFramework\\SeleniumTestFrameWork\\MoShop\\Shop Config\\Catalogue XML's\\test-catalogue-big.zip");
            driver.FindElement(By.CssSelector("div.box > p.right > input.button")).Click();
            selenium.WaitForPageToLoad("30000");
            string title = driver.Title;
            var run = new RunScrape();
            run.scarperead(driver, selenium, datarow, title);
            var hom = new links_TPS();
            hom.Links(datarow, driver, selenium, "testshop.mobankdev.com");
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception","Exception Not Expected",e,"FAIL");
            }
        }
    }
}