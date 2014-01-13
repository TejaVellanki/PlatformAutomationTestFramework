using System;
using MoBankUI.ObjectRepository;
using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI.Mosite.HomePage
{
    internal class FooterTps : Driverdefining
    {
        private readonly Screenshot _screenshot = new Screenshot();

        public void Footerhome(IWebDriver driver, string url, Datarow datarow)
        {
            try
            {
                Footer(driver, datarow, url);
                var Image = new Imagevalidation();
                Image.homepageimage(driver, datarow);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                _screenshot.screenshotfailed(driver);
            }
        }

        public void Footer(IWebDriver driver, Datarow datarow, string url)
        {
            // Generic Method to test footer links on all the sites. 
            try
            {
                var pagesource = driver.PageSource;

                string footer;
                string footerlink;
                string sociallin;
                string sociallink;
                string mopowered;
                string lowerfooter;
                string lowerfooterlink;

                #region

                var title = driver.Title;
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
                    var count = GetXpathCount(driver, footer);
                    for (var i = 1; i <= count; i++)
                    {
                        driver.FindElement(By.XPath("" + footer + "[" + i + "]" + footerlink + "")).Click();

                        var Title = driver.Title;
                        datarow.newrow("Footer Title", "", Title, "PASS", driver);
                        driver.Navigate().Back();
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                    screenshot.screenshotfailed(driver);
                }

                try
                {
                    var count1 = GetXpathCount(driver, sociallin);
                    for (var i = 1; i <= count1; i++)
                    {
                        driver.FindElement(By.XPath("" + sociallin + "[" + i + "]" + sociallink + "")).Click();

                        var tile = driver.Title;
                        datarow.newrow("Footer Social Image Title", "", tile, "PASS", driver);
                        if (title == "testshop")
                        {
                            driver.Navigate().GoToUrl(url);
                        }
                        else
                        {
                            driver.Navigate().Back();
                        }
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                    screenshot.screenshotfailed(driver);
                }

                try
                {
                    var count3 = GetXpathCount(driver, lowerfooter);
                    for (var i = 1; i <= count3; i++)
                    {
                        driver.FindElement(By.XPath("" + lowerfooter + "[" + i + "]" + lowerfooterlink + "")).Click();

                        var tile = driver.Title;
                        datarow.newrow("Lower Footer Title", "", tile, "PASS", driver);
                        if (title == "testshop")
                        {
                        }
                        else
                        {
                            driver.Navigate().Back();
                        }
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                    screenshot.screenshotfailed(driver);
                }
                try
                {
                    if (IsElementPresent(driver, By.Name(mopowered)))
                    {
                        driver.FindElement(By.XPath(mopowered)).Click();

                        var tile = driver.Title;
                        datarow.newrow("Footer Title", "", tile, "PASS", driver);
                        if (title == "testshop")
                        {
                            driver.Navigate().GoToUrl(url);
                        }
                        else
                        {
                            driver.Navigate().Back();
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
                    var e = ex.ToString();
                    datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                    screenshot.screenshotfailed(driver);
                }
            }
            catch (Exception)
            {
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver);
                _screenshot.screenshotfailed(driver);
            }

            #endregion
        }
    }
}