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
                var image = new Imagevalidation();
                image.Homepageimage(driver, datarow);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.Newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                _screenshot.Screenshotfailed(driver);
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
                    footer = FooterV2.Footer;
                    footerlink = FooterV2.Footerlink;
                    sociallink = FooterV2.Sociallink;
                    sociallin = FooterV2.Sociallin;
                    mopowered = FooterV2.Mopowered;
                    lowerfooter = FooterV2.Lowerfooter;
                    lowerfooterlink = FooterV2.lowerfooterlink;
                }
                else
                {
                    footer = FooterV1.Footer;
                    footerlink = FooterV1.Footerlink;
                    sociallink = FooterV1.Sociallink;
                    sociallin = FooterV1.Sociallin;
                    mopowered = FooterV1.Mopowered;
                    lowerfooter = FooterV1.Lowerfooter;
                    lowerfooterlink = FooterV1.Lowerfooterlink;
                }
                try
                {
                    var count = GetXpathCount(driver, footer);
                    for (var i = 1; i <= count; i++)
                    {
                        driver.FindElement(By.XPath("" + footer + "[" + i + "]" + footerlink + "")).Click();

                        var Title = driver.Title;
                        datarow.Newrow("Footer Title", "", Title, "PASS", driver);
                        driver.Navigate().Back();
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    datarow.Newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                    screenshot.Screenshotfailed(driver);
                }

                try
                {
                    var count1 = GetXpathCount(driver, sociallin);
                    for (var i = 1; i <= count1; i++)
                    {
                        driver.FindElement(By.XPath("" + sociallin + "[" + i + "]" + sociallink + "")).Click();

                        var tile = driver.Title;
                        datarow.Newrow("Footer Social Image Title", "", tile, "PASS", driver);
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
                    datarow.Newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                    screenshot.Screenshotfailed(driver);
                }

                try
                {
                    var count3 = GetXpathCount(driver, lowerfooter);
                    for (var i = 1; i <= count3; i++)
                    {
                        driver.FindElement(By.XPath("" + lowerfooter + "[" + i + "]" + lowerfooterlink + "")).Click();

                        var tile = driver.Title;
                        datarow.Newrow("Lower Footer Title", "", tile, "PASS", driver);
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
                    datarow.Newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                    screenshot.Screenshotfailed(driver);
                }
                try
                {
                    if (IsElementPresent(driver, By.Name(mopowered)))
                    {
                        driver.FindElement(By.XPath(mopowered)).Click();

                        var tile = driver.Title;
                        datarow.Newrow("Footer Title", "", tile, "PASS", driver);
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
                        datarow.Newrow("Footer Element", "", "Footer Element Not Present" + mopowered, "FAIL", driver
                            );
                        screenshot.Screenshotfailed(driver);
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    datarow.Newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                    screenshot.Screenshotfailed(driver);
                }
            }
            catch (Exception)
            {
                datarow.Newrow("Exception", "", "Exception Not Expected", "FAIL", driver);
                _screenshot.Screenshotfailed(driver);
            }

            #endregion
        }
    }
}