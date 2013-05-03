using System;
using OpenQA.Selenium;
using Selenium;
//using System.Drawing;

namespace MoBankUI
{
    internal class Footer_TPS
    {
        private readonly Screenshot screenshot = new Screenshot();

        public void Footerhome(IWebDriver driver, ISelenium selenium, string url, datarow datarow)
        {
            try
            {
                Footer(driver, selenium, datarow);
                var Image = new Imagevalidation();
                Image.homepageimage(driver, selenium, datarow);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }

        public void Footer(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            // Generic Method to test footer links on all the sites. 

            #region

            try
            {
                try
                {
                    decimal count = selenium.GetXpathCount("//html/body/div/div[3]/ul/li");
                    for (int i = 1; i <= count; i++)
                    {
                        driver.FindElement(By.XPath("//html/body/div/div[3]/ul/li[" + i + "]/div/div/a")).Click();
                        selenium.WaitForPageToLoad("30000");
                        string Title = driver.Title;
                        datarow.newrow("Footer Title", "", Title, "PASS", driver, selenium);
                        driver.Navigate().Back();
                        selenium.WaitForPageToLoad("30000");
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }

                try
                {
                    decimal count1 = selenium.GetXpathCount("//html/body/div/div[3]/div/a");
                    for (int i = 1; i <= count1; i++)
                    {
                        driver.FindElement(By.XPath("//html/body/div/div[3]/div/a[" + i + "]/img")).Click();
                        selenium.WaitForPageToLoad("30000");
                        string tile = driver.Title;
                        datarow.newrow("Footer Image Title", "", tile, "PASS", driver, selenium);
                        driver.Navigate().Back();
                        selenium.WaitForPageToLoad("30000");
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
                try
                {
                    if (selenium.IsElementPresent("//html/body/div/div[3]/p/a"))
                    {
                        driver.FindElement(By.XPath("//html/body/div/div[3]/p/a")).Click();
                        selenium.WaitForPageToLoad("30000");
                        string tile = driver.Title;
                        datarow.newrow("Footer Title", "", tile, "PASS", driver, selenium);
                        driver.Navigate().Back();
                        selenium.WaitForPageToLoad("30000");
                    }
                    else
                    {
                        datarow.newrow("Fotter Element", "", "Footer Element Not Present" + "//html/body/div/div[3]/p/a",
                                       "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
                try
                {
                    decimal count3 = selenium.GetXpathCount("//html/body/div/div[3]/p[2]/a");
                    for (int i = 1; i <= count3; i++)
                    {
                        driver.FindElement(By.XPath("//html/body/div/div[3]/p[2]/a[" + i + "]")).Click();
                        selenium.WaitForPageToLoad("30000");
                        string tile = driver.Title;
                        datarow.newrow("Lower Footer Title", "", tile, "PASS", driver, selenium);
                        driver.Navigate().Back();
                        selenium.WaitForPageToLoad("30000");
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }

            #endregion
        }
    }
}