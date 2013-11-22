using System;
using OpenQA.Selenium;
using WebDriver_Refining;


namespace MoBankUI
{
    internal class DatafeedXML : driverdefining
    {
        public void datafeed(IWebDriver driver, datarow datarow)
        {
            try
            {

                driver.Navigate().GoToUrl("https://qaadmin.mobankdev.com");
                 waitforpagetoload(driver,30000);

            driver.FindElement(By.LinkText("MoShop")).Click();
            waitforpagetoload(driver,30000);
            driver.FindElement(By.CssSelector("#IndexMenuLeaf3 > a")).Click();
            waitforpagetoload(driver,30000);
            driver.FindElement(By.LinkText("testshop")).Click();
            waitforpagetoload(driver,30000);
            driver.FindElement(By.LinkText("Shop")).Click();
            waitforpagetoload(driver,30000);


          

                decimal count = driver.FindElements(By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr")).Count;
                for (int i = 1; i <= count; i++)
                {
                    decimal j= count;
                    if (i == 1)
                    {
                        driver.FindElement(By.Id("Catalogues_"+j+"__Name")).Clear();
                        driver.FindElement(By.Id("Catalogues_" + j + "__Name")).SendKeys("Datafeed");
                        driver.FindElement(By.Id("Catalogues_" + j + "__Name")).SendKeys(Keys.Enter);
                        waitforpagetoload(driver,30000);
                        driver.FindElement(By.CssSelector("input.button")).Click();
                        waitforpagetoload(driver,30000);
                    }

                    string name = GetValue(driver,By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr["+i+"]/td/input"),30);
                    if (name == "Datafeed")
                    {
                        driver.FindElement(By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr["+i+"]/th/input[4]")).Click();
                        driver.FindElement(By.CssSelector("input.button")).Click();
                        waitforpagetoload(driver,30000);


            if (driver.FindElement(By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr["+i+"]/th/input[4]")).Enabled)
            {
                datarow.newrow("Datafeed Catalogue Selection", "Datafeed Catalogue is expected to be selected",
                               "Datafeed Catalogue is selected", "PASS",driver);
            }
            else
            {
                driver.FindElement(By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr/th/input[4]")).Click();
                driver.FindElement(By.CssSelector("input.button")).Click();
                waitforpagetoload(driver,30000);
            }



            driver.FindElement(By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr["+i+"]/th[2]/a")).Click();
            waitforpagetoload(driver,30000);
            break;
                    }
                }
            driver.FindElement(By.Id("File"))
                  .SendKeys(
                      @"C:\Users\teja\Documents\GitHub\PlatformAutomationTestFramework\SeleniumTestFrameWork\MoShop\Shop Config\Catalogue XML's\TickleTest_WithProductGroups.xml");
            driver.FindElement(By.CssSelector("div.box > p.right > input.button")).Click();
            waitforpagetoload(driver,30000);
            string title = driver.Title;
            var run = new RunScrape();
            run.scarperead(driver, datarow, title);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception","Exception Not Expected",e,"FAIL");
            }
        }
    }
}