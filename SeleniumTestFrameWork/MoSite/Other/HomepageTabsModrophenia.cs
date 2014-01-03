// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Threading;
using OpenQA.Selenium;
using WebDriver_Refining;

namespace MoBankUI
{
    internal class HomepageTabsModrophenia : driverdefining
    {
        public void HomepageTabsModro(string HomepageTitle, string aboutus, string shipping, string terms,
                                      datarow datarow, IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("img")).Click();

            decimal xpathCount = GetXpathCount(driver, "//body[@id='page-home-index']/div/div[3]/ul/li");
            for (int i = 1; i <= xpathCount; i++)
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                IWebElement element =
                    driver.FindElement(By.XPath("//body[@id='page-home-index']/div/div[3]/ul/li[" + i + "]/div/div/a"));
                driver.FindElement(By.XPath("//body[@id='page-home-index']/div/div[3]/ul/li[" + i + "]/div/div/a"))
                      .Click();


                Thread.Sleep(3000);
                string actual = driver.Title;
                if (i > 1)
                {
                    driver.Navigate().Back();
                }
                switch (i)
                {
                    case 1:
                        if (HomepageTitle == actual)
                        {
                            datarow.newrow("HomepageTitle", HomepageTitle, actual, "PASS", driver);
                        }
                        else
                        {
                            datarow.newrow("HomepageTitle", HomepageTitle, actual, "FAIL", driver);
                        }
                        break;

                    case 2:
                        if (aboutus == actual)
                        {
                            datarow.newrow("AboutUS", aboutus, actual, "PASS", driver);
                        }
                        else
                        {
                            datarow.newrow("AboutUS", aboutus, actual, "FAIL", driver);
                        }
                        break;

                    case 3:
                        if (shipping == actual)
                        {
                            datarow.newrow("Shipping", shipping, actual, "PASS", driver);
                        }
                        else
                        {
                            datarow.newrow("Shipping", shipping, actual, "FAIL", driver);
                        }
                        break;

                    case 4:
                        if (terms == actual)
                        {
                            datarow.newrow("Terms And Conditions", terms, actual, "PASS", driver);
                        }
                        else
                        {
                            datarow.newrow("Terms And Conditions", terms, actual, "FAIL", driver);
                        }
                        break;
                }
            }
        }
    }
}