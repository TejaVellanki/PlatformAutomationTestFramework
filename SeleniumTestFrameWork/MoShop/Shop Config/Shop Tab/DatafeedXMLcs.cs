using System;
using OpenQA.Selenium;

namespace MoBankUI.MoShop
{
    internal class DatafeedXml : Driverdefining
    {
        public void Datafeed(IWebDriver driver, Datarow datarow)
        {
            try
            {
                driver.Navigate().GoToUrl("https://qaadmin.mobankdev.com");


                driver.FindElement(By.LinkText("MoShop")).Click();

                driver.FindElement(By.CssSelector("#IndexMenuLeaf3 > a")).Click();

                driver.FindElement(By.LinkText("testshop")).Click();

                driver.FindElement(By.LinkText("Shop")).Click();


                decimal count = driver.FindElements(By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr")).Count;
                for (var i = 1; i <= count; i++)
                {
                    var j = count;
                    if (i == 1)
                    {
                        driver.FindElement(By.Id("Catalogues_" + j + "__Name")).Clear();
                        driver.FindElement(By.Id("Catalogues_" + j + "__Name")).SendKeys("Datafeed");
                        driver.FindElement(By.Id("Catalogues_" + j + "__Name")).SendKeys(Keys.Enter);

                        driver.FindElement(By.CssSelector("input.button")).Click();
                    }

                    var name = GetValue(driver,
                                           By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr[" + i +
                                                    "]/td/input"), 30);
                    if (name != "Datafeed") continue;
                    driver.FindElement(
                        By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr[" + i + "]/th/input[4]"))
                        .Click();
                    driver.FindElement(By.CssSelector("input.button")).Click();


                    if (
                        driver.FindElement(
                            By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr[" + i + "]/th/input[4]"))
                            .Enabled)
                    {
                        datarow.newrow("Datafeed Catalogue Selection",
                            "Datafeed Catalogue is expected to be selected",
                            "Datafeed Catalogue is selected", "PASS", driver);
                    }
                    else
                    {
                        driver.FindElement(By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr/th/input[4]"))
                            .Click();
                        driver.FindElement(By.CssSelector("input.button")).Click();
                    }


                    driver.FindElement(
                        By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr[" + i + "]/th[2]/a")).Click();

                    break;
                }
                driver.FindElement(By.Id("File"))
                      .SendKeys(
                          @"C:\Users\teja\Documents\GitHub\PlatformAutomationTestFramework\SeleniumTestFrameWork\MoShop\Shop Config\Catalogue XML's\TickleTest_WithProductGroups.xml");
                driver.FindElement(By.CssSelector("div.box > p.right > input.button")).Click();

                var title = driver.Title;
                var run = new RunScrape();
                run.Scarperead(driver, datarow, title);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL");
            }
        }
    }
}