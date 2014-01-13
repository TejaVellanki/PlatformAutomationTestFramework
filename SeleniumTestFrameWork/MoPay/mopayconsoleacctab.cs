﻿// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Threading;
using OpenQA.Selenium;

namespace MoBankUI.MoPay
{
    public class Mopayconsoleacctab : Driverdefining
    {
        private readonly Screenshot _screenshot = new Screenshot();

        public void acctabs(IWebDriver driver, Datarow datarow)
        {
            driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
            try
            {
                string str;
                driver.FindElement(By.CssSelector("#IndexMenu > ul > li.selected > ul > li > a")).Click();

                if (driver.PageSource.Contains("Test Client Account"))
                {
                    driver.FindElement(By.LinkText("Test Client Account")).Click();
                    datarow.newrow("Test Client Tab", "Test Client Tab", "Test Client Account", "PASS", driver);
                }
                if (driver.PageSource.Contains("Test Client Account"))
                {
                    driver.FindElement(By.LinkText("Test Client Account")).Click();
                    datarow.newrow("Test Client Tab", "Test Client Tab", "Test Client Account", "PASS", driver);
                }
                else
                {
                    str = "Test Client Account TabNot Present";
                    datarow.newrow("Test Client Account Link", str, "Test Client Account Link", "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                var actual = driver.Title;
                if (actual == "Details : mopowered.co.uk")
                {
                    datarow.newrow("Details Tab", "Details : mopowered.co.uk", actual, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Details Tab", "Details : mopowered.co.uk", actual, "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                if (driver.PageSource.Contains("Payment Provider"))
                {
                    driver.FindElement(By.LinkText("Payment Provider")).Click();
                    datarow.newrow("Payment Provider Tab", "Payment Provider Tab", "Payment Provider", "PASS", driver
                        );
                }
                else
                {
                    str = "Payment Provider TabNot Present";
                    datarow.newrow("Payment Provider Link", str, "Payment Provider Link", "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }

                var str3 = driver.Title;
                if (str3 == "Payment Provider : mopowered.co.uk")
                {
                    datarow.newrow("Payment Provider Tab", "Payment Provider : mopowered.co.uk", str3, "PASS", driver
                        );
                    new Paymentprovider().Provider(driver, datarow);
                }
                else
                {
                    datarow.newrow("Payment Provider Tab", "Payment Provider : mopowered.co.uk", str3, "FAIL", driver
                        );
                    _screenshot.screenshotfailed(driver);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                if (driver.PageSource.Contains("Notifications"))
                {
                    driver.FindElement(By.LinkText("Notifications")).Click();
                    datarow.newrow("Notifications Tab", "Notifications Tab", "Notifications", "PASS", driver);
                    new Notificationtab().Notifications(driver, datarow);
                }
                else
                {
                    datarow.newrow("Notifications Link", "Notifications TabNot Present", "Notifications Link", "FAIL",
                                   driver);
                    _screenshot.screenshotfailed(driver);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }

                var str4 = driver.Title;
                if (str4 == "Notifications : mopowered.co.uk")
                {
                    datarow.newrow("Notifications Tab", "Notifications : mopowered.co.uk", str4, "PASS", driver
                        );
                }
                else
                {
                    datarow.newrow("Notifications Tab", "Notifications : mopowered.co.uk", str4, "FAIL", driver
                        );
                    _screenshot.screenshotfailed(driver);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                Thread.Sleep(0x1388);
                if (driver.PageSource.Contains("Transactions"))
                {
                    driver.FindElement(By.LinkText("Transactions")).Click();
                    datarow.newrow("Transactions Tab", "Transactions Tab", "Transactions", "PASS", driver);
                }
                else
                {
                    str = "Transactions TabNot Present";
                    datarow.newrow("Transactions Link", str, "Transactions Link", "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }

                var str5 = driver.Title;
                if (str5 == "Transactions : mopowered.co.uk")
                {
                    datarow.newrow("Transactions Tab", "Transactions : mopowered.co.uk", str5, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Transactions Tab", "Transactions : mopowered.co.uk", str5, "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                if (driver.PageSource.Contains("History"))
                {
                    driver.FindElement(By.LinkText("History")).Click();
                    datarow.newrow("History Tab", "History Tab", "History", "PASS", driver);
                }
                else
                {
                    str = "History TabNot Present";
                    datarow.newrow("History Link", str, "History Link", "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }

                var str6 = driver.Title;
                if (str6 == "History : mopowered.co.uk")
                {
                    datarow.newrow("History Tab", "History : mopowered.co.uk", str6, "PASS", driver);
                }
                else
                {
                    datarow.newrow("History Tab", "History : mopowered.co.uk", str6, "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                driver.FindElement(By.LinkText("Payment Provider"));
                driver.FindElement(By.LinkText("Payment Provider")).Click();

                var str7 = driver.Title;
                if (str7 == "Payment Provider : mopowered.co.uk")
                {
                    datarow.newrow("Payment Provider Tab", "Payment Provider : mopowered.co.uk", str7, "PASS", driver
                        );
                }
                else
                {
                    datarow.newrow("Payment Provider Tab", "Payment Provider : mopowered.co.uk", str7, "FAIL", driver
                        );
                    _screenshot.screenshotfailed(driver);
                }
                if (driver.PageSource.Contains("…"))
                {
                    driver.FindElement(By.LinkText("…")).Click();

                    datarow.newrow("Update Tab", "Update Tab", "Update", "PASS", driver);
                }
                else
                {
                    str = "Update TabNot Present";
                    datarow.newrow("Update Link", str, "Update Link", "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                var str8 = driver.Title;
                if (str8 == "Update : mopowered.co.uk")
                {
                    datarow.newrow("Update Tab", "Update : mopowered.co.uk", str8, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Update Tab", "Update : mopowered.co.uk", str8, "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                }

                var str9 = driver.Title;
                if (str9 == "Update : mopowered.co.uk")
                {
                    datarow.newrow("Update Tab", "Update : mopowered.co.uk", str9, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Update Tab", "Update : mopowered.co.uk", str9, "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                }
                driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");

                if (driver.PageSource.Contains("Users"))
                {
                    driver.FindElement(By.LinkText("Users")).Click();
                    datarow.newrow("Users Tab", "Users Tab", "Users", "PASS", driver);
                }
                else
                {
                    str = "Users TabNot Present";
                    datarow.newrow("Users Link", str, "Users Link", "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }

                var str10 = driver.Title;
                if (str10 == "Users : mopowered.co.uk")
                {
                    datarow.newrow("Users Tab", "Users : mopowered.co.uk", str10, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Users Tab", "Users : mopowered.co.uk", str10, "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
            }
            catch (Exception exception)
            {
                var str11 = exception.ToString();
                Console.Write(exception);
                datarow.newrow("Exception", "Exception Not Expected", str11, "FAIL", driver);
            }
            finally
            {
                _screenshot.screenshotfailed(driver);
                datarow.excelsave("MopayConsole", driver, "teja.vellanki@mobankgroup.com");
                driver.Quit();
            }
        }
    }
}