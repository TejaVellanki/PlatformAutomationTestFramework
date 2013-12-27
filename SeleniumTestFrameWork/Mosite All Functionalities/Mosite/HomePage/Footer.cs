using System;
using ObjectRepository;
using OpenQA.Selenium;
using WebDriver_Refining;

//using System.Drawing;

namespace MoBankUI
{
    internal class Footer_TPS :driverdefining
    {
        private readonly Screenshot screenshot = new Screenshot();

        public void Footerhome(IWebDriver driver, string url, datarow datarow)
        {
            try
            {
                Footer(driver, datarow, url);
                var Image = new Imagevalidation();
                Image.homepageimage(driver, datarow);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL",driver);
                screenshot.screenshotfailed(driver);
            }
        }

        public void Footer(IWebDriver driver, datarow datarow, string url)
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

                string title = driver.Title;
                var screenshot = new Screenshot();

                if (pagesource.Contains("user-scalable=yes"))
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
                    decimal count = GetXpathCount(driver,footer);
                    for (int i = 1; i <= count; i++)
                    {
                        driver.FindElement(By.XPath("" + footer + "[" + i + "]" + footerlink + "")).Click();
                        waitforpagetoload(driver,30000);
                        string Title = driver.Title;
                        datarow.newrow("Footer Title", "", Title, "PASS",driver);
                        driver.Navigate().Back();
                        waitforpagetoload(driver,30000);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Exception", "Exception Not Expected", e, "FAIL",driver);
                    screenshot.screenshotfailed(driver);
                }

                try
                {
                    decimal count1 = GetXpathCount(driver,sociallin);
                    for (int i = 1; i <= count1; i++)
                    {
                        driver.FindElement(By.XPath("" + sociallin + "[" + i + "]" + sociallink + "")).Click();
                        waitforpagetoload(driver,30000);
                        string tile = driver.Title;
                        datarow.newrow("Footer Social Image Title", "", tile, "PASS",driver);
                        if (title == "testshop")
                        {
                            driver.Navigate().GoToUrl(url);
                            waitforpagetoload(driver,30000);
                        }
                        else
                        {
                            driver.Navigate().Back();
                            waitforpagetoload(driver,30000);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Exception", "Exception Not Expected", e, "FAIL",driver);
                    screenshot.screenshotfailed(driver);
                }

                try
                {
                    decimal count3 = GetXpathCount(driver,lowerfooter);
                    for (int i = 1; i <= count3; i++)
                    {
                        driver.FindElement(By.XPath("" + lowerfooter + "[" + i + "]" + lowerfooterlink + "")).Click();
                        waitforpagetoload(driver,30000);
                        string tile = driver.Title;
                        datarow.newrow("Lower Footer Title", "", tile, "PASS",driver);
                        if (title == "testshop")
                        {
                        }
                        else
                        {
                            driver.Navigate().Back();
                            waitforpagetoload(driver,30000);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Exception", "Exception Not Expected", e, "FAIL",driver);
                    screenshot.screenshotfailed(driver);
                }
                try
                {
                    if (IsElementPresent(driver,By.Name(mopowered)))
                    {
                        driver.FindElement(By.XPath(mopowered)).Click();
                        waitforpagetoload(driver,30000);
                        string tile = driver.Title;
                        datarow.newrow("Footer Title", "", tile, "PASS",driver);
                        if (title == "testshop")
                        {
                            driver.Navigate().GoToUrl(url);
                            waitforpagetoload(driver,30000);
                        }
                        else
                        {
                            driver.Navigate().Back();
                            waitforpagetoload(driver,30000);
                        }
                    }
                    else
                    {
                        datarow.newrow("Footer Element", "", "Footer Element Not Present" + mopowered, "FAIL", driver
                                       );
                        screenshot.screenshotfailed(driver);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Exception", "Exception Not Expected", e, "FAIL",driver);
                    screenshot.screenshotfailed(driver);
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL",driver);
                screenshot.screenshotfailed(driver);
            }

            #endregion
        }
    }
}