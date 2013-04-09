using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium;
using NUnit.Framework;
using System.Threading;

namespace MoBankUI
{
    class RunScrape
    {
        public void runscrape(IWebDriver driver, ISelenium selenium,datarow datarow)
        {
            try
            {              

                driver.FindElement(By.LinkText("Execute")).Click();
                selenium.WaitForPageToLoad("30000");
                string[] catalogues = selenium.GetSelectOptions("TestCatalogueId");

                foreach (string lt in catalogues)
                {  
                    new SelectElement(driver.FindElement(By.Id("TestCatalogueId"))).SelectByText(lt);
                    if(lt.Contains("Default"))
                    {
                        break;
                    }
                }
                   
              

                driver.FindElement(By.Name("PostAction[]")).Click();
                selenium.WaitForPageToLoad("30000");
                string title = driver.Title.ToString();
                scarperead(driver, selenium, datarow, title);
                selenium.Click("link=Running");
                selenium.WaitForPageToLoad("30000");
                string tilte1 = driver.Title.ToString();
                scarperead(driver, selenium, datarow, tilte1);
                scrapeandfeedrunning(driver, selenium, datarow);

               
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Excepion Not Expected", e, "FAIL", driver, selenium);
            }
        }
        public void scarperead(IWebDriver driver, ISelenium selenium, datarow datarow,string job)
        {
            int j = 1;
            for (int i = 0; ; i++)
            {
                if (selenium.IsElementPresent("//div[@id='Grid']/div[2]/table/tbody/tr/td[2]"))
                {
                    try
                    {
                        
                        string title = selenium.GetText("//div[@id='Grid']/div[2]/table/tbody/tr/td[2]");
                        string type = selenium.GetText("//div[@id='Grid']/div[2]/table/tbody/tr/td[3]");
                        string startson = selenium.GetText("//div[@id='Grid']/div[2]/table/tbody/tr/td[4]");                       
                        string Action = selenium.GetText("//div[@id='Grid']/div[2]/table/tbody/tr/td[5]");
                      
                       
                        datarow.newrow("Scarpe Tilte", "", title, "PASS", driver, selenium);
                        datarow.newrow("Scarpe Type", "", type, "PASS", driver, selenium);
                        break;
                    }
                    catch (Exception ex)
                    {
                        string e = ex.ToString();
                        datarow.newrow("Exception", "Excepion Not Expected", e, "FAIL", driver, selenium);

                    }


                }
                else
                {
                    Thread.Sleep(5000);
                    selenium.Refresh();
                    selenium.WaitForPageToLoad("30000");
                    j++;

                }
                if (j == 10)
                {
                    datarow.newrow("Scarpe Start", "Scrape should start", "Scrape didnt start after 60 sec", "FAIL", driver, selenium);
                    break;

                }
            }
            
        }
        public void scrapeandfeedrunning(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            #region  Running
            if (selenium.IsElementPresent("//div[@id='Grid']/div[2]/table/tbody/tr/td[7]"))
            {
                for (int i = 0; ; i++)
                {
                    try
                    {
                        string comp = selenium.GetText("//div[@id='Grid']/div[2]/table/tbody/tr/td[7]");
                        if (comp.Contains("100%"))
                        {
                            datarow.newrow("Scarpe status", "", comp, "PASS", driver, selenium);
                            break;
                        }
                        else
                        {
                            datarow.newrow("Scarpe/Datafeed status", "", comp, "PASS", driver, selenium);
                            Thread.Sleep(5000);
                            selenium.Refresh();
                            selenium.WaitForPageToLoad("30000");
                        }
                    }
                    catch (Exception ex)
                    {
                        datarow.newrow("Scarpe/DataFeed Status", "100%", "100%", "PASS", driver, selenium);
                        break;
                    }
                }
            }
            #endregion
            selenium.Click("link=Completed");
            selenium.WaitForPageToLoad("30000");
            string completed = selenium.GetText("css=td.markedCell");
            if (completed.Contains("100%"))
            {
                datarow.newrow("Scrape/DataFeed Job Completed", "", completed, "PASS", driver, selenium);
            }
        }
    }
}
