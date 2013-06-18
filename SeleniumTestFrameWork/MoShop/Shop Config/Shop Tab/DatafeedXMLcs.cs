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
            driver.FindElement(By.LinkText("testshop")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.LinkText("Shop")).Click();
            selenium.WaitForPageToLoad("30000");

            driver.FindElement(By.Id("Catalogues_2__Name")).Clear();
            driver.FindElement(By.Id("Catalogues_2__Name")).SendKeys("Datafeed");
            driver.FindElement(By.Id("Catalogues_2__Name")).SendKeys(Keys.Enter);
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.CssSelector("input.button")).Click();
            selenium.WaitForPageToLoad("30000");
                decimal count = selenium.GetXpathCount("//div[@id='CataloguesControl']/div/table/tbody/tr");
                for (int i = 1; i <= count; i++)
                {
                    string name = selenium.GetValue("//div[@id='CataloguesControl']/div/table/tbody/tr["+i+"]/td/input");
                    if (name == "Datafeed")
                    {
                        driver.FindElement(By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr["+i+"]/th/input[4]")).Click();
                        driver.FindElement(By.CssSelector("input.button")).Click();
                        selenium.WaitForPageToLoad("30000");
            if (selenium.IsChecked("//div[@id='CataloguesControl']/div/table/tbody/tr["+i+"]/th/input[4]"))
            {
                datarow.newrow("Datafeed Catalogue Selection", "Datafeed Catalogue is expected to be selected",
                               "Datafeed Catalogue is selected", "PASS", driver, selenium);
            }
            else
            {
                driver.FindElement(By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr/th/input[4]")).Click();
                driver.FindElement(By.CssSelector("input.button")).Click();
                selenium.WaitForPageToLoad("30000");
            }
            driver.FindElement(By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr["+i+"]/th[2]/a")).Click();
            selenium.WaitForPageToLoad("30000");
            break;
                    }
                }
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