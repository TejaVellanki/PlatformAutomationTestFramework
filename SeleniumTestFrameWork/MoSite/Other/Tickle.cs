// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Threading;
using OpenQA.Selenium;

namespace MoBankUI.MoSite.Other
{
    internal class Tickle : Driverdefining
    {
        public void HomepageTabsTickle(Datarow datarow, IWebDriver driver, string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);

                Thread.Sleep(0xbb8);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                driver.FindElement(By.XPath("//body[@id='page-home-index']/div/div[2]/div/ul/li/div/div/a/h2"));
                driver.FindElement(By.XPath("//body[@id='page-home-index']/div/div[2]/div/ul/li/div/div/a/h2")).Click();

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                driver.FindElement(
                    By.XPath("//body[@id='page-categories-details']/div/div[2]/div/ul/li/div/div/a/h2"));
                driver.FindElement(By.XPath("//body[@id='page-categories-details']/div/div[2]/div/ul/li/div/div/a/h2"))
                      .Click();

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                driver.FindElement(By.XPath("//body[@id='page-categories-details']/div/div[2]/div/ul/li/div/div/a/p"));
                driver.FindElement(By.XPath("//body[@id='page-categories-details']/div/div[2]/div/ul/li/div/div/a/p"))
                      .Click();
            }
            catch (Exception exception)
            {
                var actual = exception.ToString();
                datarow.Newrow("Exception", "Not Expected", actual, "FAIL", driver);
            }
        }
    }
}