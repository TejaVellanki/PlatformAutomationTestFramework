using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;

namespace MoBankUI
{
    public class RunScrape : driverdefining
    {
     [Test]
        public void runscrape(IWebDriver driver, datarow datarow)
        {
            try
            {
                driver.FindElement(By.LinkText("Execute")).Click();
                  waitforpagetoload(driver,30000);
                  Selectanoption(driver, By.Id("TestCatalogueId"), "Default");
                //new SelectElement(driver.FindElement(By.Id("TestCatalogueId"))).SelectByText("Default");
                driver.FindElement(By.Name("PostAction[]")).Click();
                  waitforpagetoload(driver,30000);
                string title = driver.Title;
                scarperead(driver,datarow, title);
               
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Excepion Not Expected", e, "FAIL", driver);
            }
        }

        public void scarperead(IWebDriver driver, datarow datarow, string job)
        {
            int j = 1;
            for (int i = 0;; i++)
            {
                if (IsElementPresent(driver,By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[2]"),30))
                {
                    try
                    {
                        string title = driver.FindElement(By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[2]")).Text;
                        string type = driver.FindElement(By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[3]")).Text;
                        string startson = driver.FindElement(By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[4]")).Text;
                        string Action =driver.FindElement(By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[5]")).Text;

                        datarow.newrow("Scarpe Tilte", "", title, "PASS", driver);
                        datarow.newrow("Scarpe Type", "", type, "PASS", driver);
                        Thread.Sleep(5000);
                        driver.Navigate().Refresh();
                          waitforpagetoload(driver,30000);
                        break;
                    }
                    catch (Exception ex)
                    {
                        string e = ex.ToString();
                        datarow.newrow("Exception", "Excepion Not Expected", e, "FAIL", driver);
                    }
                }
                else
                {
                    Thread.Sleep(5000);
                     driver.Navigate().Refresh();
                       waitforpagetoload(driver,30000);
                    j++;
                }
                if (j == 10)
                {
                    datarow.newrow("Scarpe/Datafeed Start", "Scarpe/Datafeed should start", "Scarpe/Datafeed didnt start after 60 sec", "FAIL", driver);
                    break;
                }
            }
            driver.FindElement(By.LinkText("Running")).Click();
              waitforpagetoload(driver,30000);
            string tilte1 = driver.Title;
            scrapeandfeedrunning(driver,datarow);
        }

        public void scrapeandfeedrunning(IWebDriver driver, datarow datarow)
        {
            #region  Running

            for (int j = 1;;)
            {
                if (IsElementPresent(driver,By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[7]"),30))
                {
                    for (int i = 0;; i++)
                    {
                        try
                        {
                            string comp = driver.FindElement(By.XPath("//div[@id='Grid']/div[2]/table/tbody/tr/td[7]")).Text;
                            if (comp.Contains("100%"))
                            {
                                datarow.newrow("Scarpe status", "", comp, "PASS", driver);
                                break;
                            }
                            else
                            {
                                datarow.newrow("Scarpe/Datafeed status", "", comp, "PASS", driver);
                                Thread.Sleep(5000);
                                driver.Navigate().Refresh();
                                  waitforpagetoload(driver,30000);
                            }
                        }
                        catch (Exception ex)
                        {
                            datarow.newrow("Scarpe/DataFeed Status", "100%", "100%", "PASS", driver);
                            break;
                        }
                    }
                    break;
                }
                else
                {
                    Thread.Sleep(5000);
                    driver.Navigate().Refresh();
                       waitforpagetoload(driver,30000);
                    j++;
                }
                if (j == 10)
                {
                    datarow.newrow("Scarpe/Datafeed Start", "Scrape/Datafeed should start", "Scrape/Datafeed didnt start after 60 sec", "FAIL", driver);
                    break;
                }
            }

            #endregion

            driver.FindElement(By.LinkText("Completed")).Click();
              waitforpagetoload(driver,30000);
            string completed = driver.FindElement(By.CssSelector("td.markedCell")).Text;
            if (completed.Contains("100%"))
            {
                datarow.newrow("Scrape/DataFeed Job Completed", "", completed, "PASS", driver);
            }
        }
    }
}