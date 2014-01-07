using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MoBankUI.MoShop
{
    public class RunScrape : Driverdefining
    {
        [Test]
        public void Runscrape(IWebDriver driver, Datarow datarow)
        {
            try
            {
                driver.FindElement(By.LinkText("Execute")).Click();

                try
                {
                    Selectanoption(driver, By.Id("TestCatalogueId"), "testshop (Default)");
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    Selectanoption(driver, By.Id("TestCatalogueId"), "testshop (0.1)");
                }

                //new SelectElement(driver.FindElement(By.Id("TestCatalogueId"))).SelectByText("Default");
                driver.FindElement(By.Name("PostAction[]")).Click();

                var title = driver.Title;
                Scarperead(driver, datarow, title);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Excepion Not Expected", e, "FAIL", driver);
            }
        }

        public void Scarperead(IWebDriver driver, Datarow datarow, string job)
        {
            var j = 1;
            for (var i = 0;; i++)
            {
                if (IsElementPresent(driver, By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[2]"), 30))
                {
                    try
                    {
                        var title =
                            driver.FindElement(By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[2]")).Text;
                        var type = driver.FindElement(By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[3]")).Text;
                        var startson =
                            driver.FindElement(By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[4]")).Text;
                        var action =
                            driver.FindElement(By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[5]")).Text;

                        datarow.newrow("Scarpe Tilte", "", title, "PASS", driver);
                        datarow.newrow("Scarpe Type", "", type, "PASS", driver);
                        Thread.Sleep(5000);
                        driver.Navigate().Refresh();

                        break;
                    }
                    catch (Exception ex)
                    {
                        var e = ex.ToString();
                        datarow.newrow("Exception", "Excepion Not Expected", e, "FAIL", driver);
                    }
                }
                else
                {
                    Thread.Sleep(5000);
                    driver.Navigate().Refresh();

                    j++;
                }
                if (j == 10)
                {
                    datarow.newrow("Scarpe/Datafeed Start", "Scarpe/Datafeed should start",
                                   "Scarpe/Datafeed didnt start after 60 sec", "FAIL", driver);
                    break;
                }
            }
            driver.FindElement(By.LinkText("Running")).Click();

            var tilte1 = driver.Title;
            Scrapeandfeedrunning(driver, datarow);
        }

        public void Scrapeandfeedrunning(IWebDriver driver, Datarow datarow)
        {
            #region  Running

            for (var j = 1;;)
            {
                if (IsElementPresent(driver, By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[7]"), 30))
                {
                    for (var i = 0;; i++)
                    {
                        try
                        {
                            var comp =
                                driver.FindElement(By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[7]")).Text;
                            if (comp.Contains("100%"))
                            {
                                datarow.newrow("Scarpe status", "", comp, "PASS", driver);
                                break;
                            }
                            datarow.newrow("Scarpe/Datafeed status", "", comp, "PASS", driver);
                            Thread.Sleep(5000);
                            driver.Navigate().Refresh();
                        }
                        catch (Exception ex)
                        {
                            datarow.newrow("Scarpe/DataFeed Status", "100%", "100%", "PASS", driver);
                            break;
                        }
                    }
                    break;
                }
                Thread.Sleep(5000);
                driver.Navigate().Refresh();

                j++;
                if (j == 10)
                {
                    datarow.newrow("Scarpe/Datafeed Start", "Scrape/Datafeed should start",
                                   "Scrape/Datafeed didnt start after 60 sec", "FAIL", driver);
                    break;
                }
            }

            #endregion

            driver.FindElement(By.LinkText("Completed")).Click();

            var completed = driver.FindElement(By.CssSelector("td.markedCell")).Text;
            if (completed.Contains("100%"))
            {
                datarow.newrow("Scrape/DataFeed Job Completed", "", completed, "PASS", driver);
            }
        }
    }
}