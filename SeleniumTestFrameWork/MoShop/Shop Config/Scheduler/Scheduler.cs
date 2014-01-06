// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Threading;
using OpenQA.Selenium;
using WebDriver_Refining;

namespace MoBankUI
{
    internal class Scheduler : driverdefining
    {
        public void Schedule(IWebDriver driver, datarow datarow)
        {
            try
            {
                int num;
                string str4;
                string str5;
                string str6;
                string str7;
                string str8;
                string str9;
                string str10;
                string str11;
                string str12;
                string str13;
                driver.FindElement(By.LinkText("Shops")).Click();
                driver.FindElement(By.LinkText("testshop")).Click();

                driver.FindElement(By.LinkText("Scheduler")).Click();

                datarow.newrow("", "", "SCHEDULER", "", driver);
                if (IsElementPresent(driver, By.CssSelector("h3.collapsible.collapsed"), 30))
                {
                    driver.FindElement(By.CssSelector("h3.collapsible.collapsed")).Click();
                }
                string str = GetValue(driver, By.Id("Jobs_0__JobType"), 30);
                if (str == null)
                {
                    Selectanoption(driver, By.Id("Jobs_0__JobType"), "Scrape");
                    //new SelectElement(driver.FindElement(By.Id("Jobs_0__JobType"))).SelectByText("Scrape");
                    driver.FindElement(By.CssSelector("input.button")).Click();

                    string attribute = driver.FindElement(By.Id("Jobs_0__JobType")).GetAttribute("Value");
                    if (attribute == "Scrape")
                    {
                        datarow.newrow("Job Type", "Scrape", attribute, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Job Type", "Scrape", attribute, "FAIL", driver);
                    }
                    driver.FindElement(By.Id("Jobs_0__Active")).Click();
                    driver.FindElement(By.Id("Jobs_0__StartOn")).Clear();
                    driver.FindElement(By.Id("Jobs_0__StartOn")).SendKeys("7/31/2012 11:19:00 AM");
                    driver.FindElement(By.Id("Jobs_0__EndOn")).Clear();
                    driver.FindElement(By.Id("Jobs_0__EndOn")).SendKeys("7/31/2013 11:19:00 AM");
                    driver.FindElement(By.Id("Jobs_0__RepeatInterval_Days")).Clear();
                    driver.FindElement(By.Id("Jobs_0__RepeatInterval_Days")).SendKeys("1");
                    driver.FindElement(By.Id("Jobs_0__RepeatInterval_Hours")).Clear();
                    driver.FindElement(By.Id("Jobs_0__RepeatInterval_Hours")).SendKeys("0");
                    driver.FindElement(By.CssSelector("input.button")).Click();

                    Selectanoption(driver, By.Id("Jobs_1__JobType"), "Data Feed");
                    //new SelectElement(driver.FindElement(By.Id("Jobs_1__JobType"))).SelectByText("Data Feed");
                    driver.FindElement(By.CssSelector("input.button")).Click();

                    Thread.Sleep(0x1388);
                    string str3 = GetValue(driver, By.Id("Jobs_1__Active"), 30);
                    num = 0;
                    if (str3 == "true")
                    {
                        num = 1;
                    }
                    str4 = driver.FindElement(By.Id("Jobs_" + num + "__Active")).GetAttribute("Value");
                    str5 = driver.FindElement(By.Id("Jobs_" + num + "__StartOn")).GetAttribute("Value");
                    str6 = driver.FindElement(By.Id("Jobs_" + num + "__EndOn")).GetAttribute("Value");
                    str7 = driver.FindElement(By.Id("Jobs_" + num + "__RepeatInterval_Days")).GetAttribute("Value");
                    str8 = driver.FindElement(By.Id("Jobs_" + num + "__RepeatInterval_Hours")).GetAttribute("Value");

                    #region validation

                    if (str4 == "true")
                    {
                        datarow.newrow("Scheduler Scrape Activation", "Scrape Activated", str4, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Scheduler Scrape Activation", "Scrape Not Activated", str4, "FAIL", driver);
                    }
                    if (str5 == "31 Jul 2012 11:19")
                    {
                        datarow.newrow("Schduler Start Time", "31 Jul 2012 11:19", str5, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Schduler Start Time", "31 Jul 2012 11:19", str5, "FAIL", driver);
                    }
                    if (str6 == "31 Jul 2013 11:19")
                    {
                        datarow.newrow("Schduler End Time", "31 Jul 2013 11:19", str6, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Schduler End Time", "31 Jul 2013 11:19", str6, "PASS", driver);
                    }
                    if (str7 == "1")
                    {
                        datarow.newrow("Repeat interval Days", "1", str7, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Repeat interval Days", "1", str7, "FAIL", driver);
                    }
                    if (str8 == "0")
                    {
                        datarow.newrow("Repeat interval Hours", "0", str8, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Repeat interval Hours", "0", str8, "FAIL", driver);
                    }

                    #endregion

                    if (str3 == "false")
                    {
                        driver.FindElement(By.Id("Jobs_1__Active")).Click();
                        driver.FindElement(By.Id("Jobs_1__Url")).Clear();
                        driver.FindElement(By.Id("Jobs_1__Url"))
                              .SendKeys("https://dl.dropbox.com/u/93702113/test-catalogue-small.xml");
                        driver.FindElement(By.Id("Jobs_1__StartOn")).Clear();
                        driver.FindElement(By.Id("Jobs_1__StartOn")).SendKeys("7/31/2012 11:20:00 AM");
                        driver.FindElement(By.Id("Jobs_1__EndOn")).Clear();
                        driver.FindElement(By.Id("Jobs_1__EndOn")).SendKeys("7/31/2013 11:20:00 AM");
                        driver.FindElement(By.Id("Jobs_1__RepeatInterval_Days")).Clear();
                        driver.FindElement(By.Id("Jobs_1__RepeatInterval_Days")).SendKeys("1");
                        driver.FindElement(By.Id("Jobs_1__RepeatInterval_Hours")).Clear();
                        driver.FindElement(By.Id("Jobs_1__RepeatInterval_Hours")).SendKeys("1");
                        driver.FindElement(By.CssSelector("input.button")).Click();
                    }
                    else
                    {
                        driver.FindElement(By.Id("Jobs_0__Active")).Click();
                        driver.FindElement(By.Id("Jobs_0__Url")).Clear();
                        driver.FindElement(By.Id("Jobs_0__Url"))
                              .SendKeys("https://dl.dropbox.com/u/93702113/test-catalogue-small.xml");
                        driver.FindElement(By.Id("Jobs_0__StartOn")).Clear();
                        driver.FindElement(By.Id("Jobs_0__StartOn")).SendKeys("7/31/2012 11:20:00 AM");
                        driver.FindElement(By.Id("Jobs_0__EndOn")).Clear();
                        driver.FindElement(By.Id("Jobs_0__EndOn")).SendKeys("7/31/2013 11:20:00 AM");
                        driver.FindElement(By.Id("Jobs_0__RepeatInterval_Days")).Clear();
                        driver.FindElement(By.Id("Jobs_0__RepeatInterval_Days")).SendKeys("1");
                        driver.FindElement(By.Id("Jobs_0__RepeatInterval_Hours")).Clear();
                        driver.FindElement(By.Id("Jobs_0__RepeatInterval_Hours")).SendKeys("1");
                        driver.FindElement(By.CssSelector("input.button")).Click();
                    }
                    int num2 = 0;
                    if (str3 == "false")
                    {
                        num2 = 1;
                    }
                    str9 = driver.FindElement(By.Id("Jobs_" + num2 + "__Active")).GetAttribute("Value");
                    str10 = driver.FindElement(By.Id("Jobs_" + num2 + "__StartOn")).GetAttribute("Value");
                    str11 = driver.FindElement(By.Id("Jobs_" + num2 + "__EndOn")).GetAttribute("Value");
                    str12 = driver.FindElement(By.Id("Jobs_" + num2 + "__RepeatInterval_Days")).GetAttribute("Value");
                    str13 = driver.FindElement(By.Id("Jobs_" + num2 + "__RepeatInterval_Hours")).GetAttribute("Value");

                    #region validations

                    if (str9 == "true")
                    {
                        datarow.newrow("Scheduler DataFeed Activation", "DataFeed Activated", str9, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Scheduler DataFeed Activation", "DataFeed Not Activated", str9, "FAIL", driver);
                    }
                    if (str10 == "31 Jul 2012 11:20")
                    {
                        datarow.newrow("Scheduler Start Time", "31 Jul 2012 11:20", str10, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Scheduler Start Time", "31 Jul 2012 11:20", str10, "FAIL", driver);
                    }
                    if (str11 == "31 Jul 2012 11:19")
                    {
                        datarow.newrow("Scheduler End Time", "31 Jul 2012 11:20", str11, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Scheduler End Time", "31 Jul 2012 11:20", str11, "PASS", driver);
                    }
                    if (str12 == "1")
                    {
                        datarow.newrow("Repeat interval Days", "1", str12, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Repeat interval Days", "1", str12, "FAIL", driver);
                    }
                    if (str13 == "1")
                    {
                        datarow.newrow("Repeat interval Hours", "1", str13, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Repeat interval Hours", "1", str13, "FAIL", driver);
                    }

                    #endregion
                }
                else if (str != null)
                {
                    #region Validations

                    num = 0;
                    str4 = driver.FindElement(By.Id("Jobs_" + num + "__Active")).GetAttribute("Value");
                    str5 = driver.FindElement(By.Id("Jobs_" + num + "__StartOn")).GetAttribute("Value");
                    str6 = driver.FindElement(By.Id("Jobs_" + num + "__EndOn")).GetAttribute("Value");
                    str7 = driver.FindElement(By.Id("Jobs_" + num + "__RepeatInterval_Days")).GetAttribute("Value");
                    str8 = driver.FindElement(By.Id("Jobs_" + num + "__RepeatInterval_Hours")).GetAttribute("Value");

                    if (str4 == "true")
                    {
                        datarow.newrow("Scheduler Scrape Activation", "Scrape Activated", str4, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Scheduler Scrape Activation", "Scrape Not Activated", str4, "FAIL", driver);
                    }
                    if (str5 == "31 Jul 2012 11:19")
                    {
                        datarow.newrow("Schduler Start Time", "31 Jul 2012 11:19", str5, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Schduler Start Time", "31 Jul 2012 11:19", str5, "FAIL", driver);
                    }
                    if (str6 == "31 Jul 2012 11:19")
                    {
                        datarow.newrow("Schduler End Time", "31 Jul 2012 11:19", str6, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Schduler End Time", "31 Jul 2012 11:19", str6, "PASS", driver);
                    }
                    if (str7 == "1")
                    {
                        datarow.newrow("Repeat interval Days", "1", str7, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Repeat interval Days", "1", str7, "FAIL", driver);
                    }
                    if (str8 == "1")
                    {
                        datarow.newrow("Repeat interval Hours", "1", str8, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Repeat interval Hours", "1", str8, "FAIL", driver);
                    }

                    const int num3 = 1;
                    str9 = driver.FindElement(By.Id("Jobs_" + num3 + "__Active")).GetAttribute("Value");
                    str10 = driver.FindElement(By.Id("Jobs_" + num3 + "__StartOn")).GetAttribute("Value");
                    str11 = driver.FindElement(By.Id("Jobs_" + num3 + "__EndOn")).GetAttribute("Value");
                    str12 = driver.FindElement(By.Id("Jobs_" + num3 + "__RepeatInterval_Days")).GetAttribute("Value");
                    str13 = driver.FindElement(By.Id("Jobs_" + num3 + "__RepeatInterval_Hours")).GetAttribute("Value");
                    if (str9 == "true")
                    {
                        datarow.newrow("Scheduler Scrape Activation", "Scrape Activated", str4, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Scheduler Scrape Activation", "Scrape Not Activated", str4, "FAIL", driver);
                    }
                    if (str10 == "31 Jul 2012 11:19")
                    {
                        datarow.newrow("Schduler Start Time", "31 Jul 2012 11:19", str5, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Schduler Start Time", "31 Jul 2012 11:19", str5, "FAIL", driver);
                    }
                    if (str11 == "31 Jul 2012 11:19")
                    {
                        datarow.newrow("Schduler End Time", "31 Jul 2012 11:19", str6, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Schduler End Time", "31 Jul 2012 11:19", str6, "PASS", driver);
                    }
                    if (str12 == "1")
                    {
                        datarow.newrow("Repeat interval Days", "1", str7, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Repeat interval Days", "1", str7, "FAIL", driver);
                    }
                    if (str13 == "24")
                    {
                        datarow.newrow("Repeat interval Hours", "1", str8, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Repeat interval Hours", "1", str8, "FAIL", driver);
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Excepion Not Expected", e, "FAIL", driver);
            }
            new Checkout().checkout(driver, datarow);
        }
    }
}