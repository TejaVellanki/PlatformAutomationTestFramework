using System;
using ObjectRepository;
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
                Footer(driver, selenium, datarow, url);
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

        public void Footer(IWebDriver driver, ISelenium selenium, datarow datarow, string url)
        {
            // Generic Method to test footer links on all the sites. 
            try
            {
                string pagesource = driver.PageSource;

                string footer = null;
                string footerlink = null;
                string sociallin = null;
                string sociallink = null;
                string mopowered = null;
                string lowerfooter = null;
                string lowerfooterlink = null;

                #region

                string title = selenium.GetTitle();
                var screenshot = new Screenshot();

                if (pagesource.Contains("smallDevice"))
                {
                    footer = FooterV2.footer;
                    footerlink = FooterV2.footerlink;
                    sociallink = FooterV2.sociallink;
                    sociallin = FooterV2.sociallin;
                    mopowered = FooterV2.mopowered;
                    lowerfooter = FooterV2.lowerfooter;
                    lowerfooterlink = FooterV2.lowerfooterlink;
                }
                else
                {
                    footer = FooterV1.footer;
                    footerlink = FooterV1.footerlink;
                    sociallink = FooterV1.sociallink;
                    sociallin = FooterV1.sociallin;
                    mopowered = FooterV1.mopowered;
                    lowerfooter = FooterV1.lowerfooter;
                    lowerfooterlink = FooterV1.lowerfooterlink;
                }
                try
                {
                    decimal count = selenium.GetXpathCount(footer);
                    for (int i = 1; i <= count; i++)
                    {
                        driver.FindElement(By.XPath("" + footer + "[" + i + "]" + footerlink + "")).Click();
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
                    decimal count1 = selenium.GetXpathCount(sociallin);
                    for (int i = 1; i <= count1; i++)
                    {
                        driver.FindElement(By.XPath("" + sociallin + "[" + i + "]" + sociallink + "")).Click();
                        selenium.WaitForPageToLoad("30000");
                        string tile = driver.Title;
                        datarow.newrow("Footer Social Image Title", "", tile, "PASS", driver, selenium);
                        if (title == "testshop")
                        {
                            driver.Navigate().GoToUrl(url);
                            selenium.WaitForPageToLoad("30000");
                        }
                        else
                        {
                            driver.Navigate().Back();
                            selenium.WaitForPageToLoad("30000");
                        }
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
                    decimal count3 = selenium.GetXpathCount(lowerfooter);
                    for (int i = 1; i <= count3; i++)
                    {
                        driver.FindElement(By.XPath("" + lowerfooter + "[" + i + "]" + lowerfooterlink + "")).Click();
                        selenium.WaitForPageToLoad("30000");
                        string tile = driver.Title;
                        datarow.newrow("Lower Footer Title", "", tile, "PASS", driver, selenium);
                        if (title == "testshop")
                        {
                        }
                        else
                        {
                            driver.Navigate().Back();
                            selenium.WaitForPageToLoad("30000");
                        }
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
                    if (selenium.IsElementPresent(mopowered))
                    {
                        driver.FindElement(By.XPath(mopowered)).Click();
                        selenium.WaitForPageToLoad("30000");
                        string tile = driver.Title;
                        datarow.newrow("Footer Title", "", tile, "PASS", driver, selenium);
                        if (title == "testshop")
                        {
                            driver.Navigate().GoToUrl(url);
                            selenium.WaitForPageToLoad("30000");
                        }
                        else
                        {
                            driver.Navigate().Back();
                            selenium.WaitForPageToLoad("30000");
                        }
                    }
                    else
                    {
                        datarow.newrow("Footer Element", "", "Footer Element Not Present" + mopowered, "FAIL", driver,
                                       selenium);
                        screenshot.screenshotfailed(driver, selenium);
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