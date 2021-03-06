﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MoBankUI.Mosite
{
    internal class LoginandRegistrationTps : Driverdefining
    {
        public void Login_TPS(IWebDriver driver, Datarow datarow)
        {
            var screenshot = new Screenshot();
            try
            {
                if (IsElementPresent(driver, By.XPath("//form[@id='ctl00']/section/div/input"), 30))
                {
                    driver.FindElement(By.XPath("//form[@id='ctl00']/section/div/input"))
                          .SendKeys("mopoweredtest@mobankgroup.com");
                    datarow.Newrow("Login Name Element", "Login Name Field Is Expected", "Login Name Field Is Present",
                                   "PASS", driver);
                }
                else if (IsElementPresent(driver, By.Id("UserName"), 30))
                {
                    driver.FindElement(By.Id("UserName")).SendKeys("mopoweredtest@mobankgroup.com");
                    datarow.Newrow("Login Name Element", "Login Name Field Is Expected", "Login Name Field Is Present",
                                   "PASS", driver);
                }
                else
                {
                    datarow.Newrow("Login Name Element", "Login Name Field Is Expected",
                                   "Blocker-Login Name Field Is Not Present", "FAIL", driver);
                    screenshot.Screenshotfailed(driver);
                }
                if (IsElementPresent(driver, By.XPath("//form[@id='ctl00']/section/div[2]/input"), 30))
                {
                    driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[2]/input")).SendKeys("M0Test08");
                    datarow.Newrow("Login Name Element", "Login Password Field Is Expected",
                                   "Login Password Field Is Present", "PASS", driver);
                }
                else if (IsElementPresent(driver, By.Id("Password"), 30))
                {
                    driver.FindElement(By.Id("Password")).SendKeys("M0Test08");
                    datarow.Newrow("Login Name Element", "Login Password Field Is Expected",
                                   "Login Password Field Is Present", "PASS", driver);
                }
                else
                {
                    datarow.Newrow("Login Password Element", "Login Password Field Is Expected",
                                   "Blocker - Login Password Field Is Not Present", "FAIL", driver);
                    screenshot.Screenshotfailed(driver);
                }
                if (IsElementPresent(driver, By.XPath("//form[@id='ctl00']/section/div[3]/div/input"), 30))
                {
                    driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[3]/div/input")).Click();
                }
                else if (IsElementPresent(driver, By.CssSelector("input.ui-btn-hidden"), 30))
                {
                    driver.FindElement(By.CssSelector("input.ui-btn-hidden")).Click();
                }
                else
                {
                    datarow.Newrow("Login Element", "Login Button Is Expected", "Blocker - Login Button Is Not Present",
                                   "FAIL", driver);
                    screenshot.Screenshotfailed(driver);
                }
                if (IsElementPresent(driver, By.Id("BasketInfo"), 30))
                {
                    var basvalue = driver.FindElement(By.Id("BasketInfo")).Text;

                    if (basvalue == "(1)")
                    {
                        datarow.Newrow("Basket Value", "(1)", basvalue, "PASS", driver);
                    }
                    else
                    {
                        datarow.Newrow("Basket Value", "(1)", basvalue, "FAIL", driver);
                        screenshot.Screenshotfailed(driver);
                    }
                }
                else
                {
                    datarow.Newrow("Basket Value", "(1)", "No Basket Information", "FAIL", driver);
                    screenshot.Screenshotfailed(driver);
                }

                if (IsElementPresent(driver,
                                     By.XPath("//html/body/div/div[2]/div[2]/form/section/p/a/span/span/span/span"), 30))
                {
                    datarow.Newrow("Change Details Element", "Change Details Button is Expected",
                                   "Change Details Button Is Present", "PASS", driver);
                    driver.FindElement(By.XPath("//html/body/div/div[2]/div[2]/form/section/p/a/span/span/span/span"))
                          .Click();

                    try
                    {
                        decimal count = driver.FindElements(By.XPath("//form[@id='ctl00']/section/div")).Count;
                        for (var i = 1; i <= count; i++)
                        {
                            if (!IsElementPresent(driver, By.XPath("//form[@id='ctl00']/section/div[" + i + "]/label"),
                                30)) continue;
                            var valuet =
                                driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[" + i + "]/label"))
                                    .Text;
                            //if (valuet == "Telephone:")
                            //{
                            //    driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[" + i + "]/input")).SendKeys("123456789");
                            //}

                            if (valuet.Contains("*") || valuet != "Country: *")
                            {
                                try
                                {
                                    driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[" + i + "]/input"))
                                        .SendKeys("TEST");
                                    datarow.Newrow("Registration Field Name", "", valuet, "PASS", driver);
                                }
                                catch (Exception ex)
                                {
                                    Console.Write(ex);
                                }
                            }

                            if (valuet != "Country: *") continue;
                            var element = driver.FindElement(By.Id("Pagecontent_ddlCountry"));
                            IList<IWebElement> alllist = element.FindElements(By.TagName("option"));

                            string values = null;
                            foreach (var value in alllist)
                            {
                                values = values + "\r\n" + value;
                                new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlCountry")))
                                    .SelectByText(value.Text);
                            }
                            datarow.Newrow("Registration Field Countries", "", values, "PASS", driver);
                        }
                    }
                    catch (Exception ex)
                    {
                        var e = ex.ToString();
                        datarow.Newrow("Exception", "exception Not Expected", e, "FAIL", driver);
                        screenshot.Screenshotfailed(driver);
                    }
                }
                var loc = driver.Url;
                if (loc.Contains("Error"))
                {
                    datarow.Newrow("Error Page", "Error Page After Logging Not Expected", loc, "FAIL", driver);
                    screenshot.Screenshotfailed(driver);
                }


                driver.Navigate().Back();


                //selecting delivery method
                try
                {
                    if (IsElementPresent(driver,
                                         By.XPath(
                                             "//html/body/div/div[2]/div[2]/form/section/div[2]/fieldset/div/label/span/span"),
                                         30))
                    {
                        decimal count =
                            driver.FindElements(By.XPath("/html/body/div/div[2]/div[2]/form/section/div[2]/fieldset/div"))
                                  .Count;
                        for (var i = 1; i < count; i++)
                        {
                            var text =
                                driver.FindElement(
                                    By.XPath("//html/body/div/div[2]/div[2]/form/section/div[2]/fieldset/div[" + i +
                                             "]/label/span/span")).Text;
                            driver.FindElement(
                                By.XPath("//html/body/div/div[2]/div[2]/form/section/div[2]/fieldset/div[" + i +
                                         "]/label/span/span")).Click();
                            datarow.Newrow("Delivery Method", "", text, "PASS", driver);
                        }
                    }
                    else
                    {
                        var loca = driver.Url;
                        datarow.Newrow("Delivery Method", "Unexpected Format", loca, "FAIL", driver);
                        screenshot.Screenshotfailed(driver);
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    datarow.Newrow("Delivery Method Exception", "Exception Not Expected", e, "FAIL", driver);
                    screenshot.Screenshotfailed(driver);
                }
                // Click continue to next page 
                try
                {
                    if (IsElementPresent(driver, By.XPath("Pagecontent_ButtonCheckoutStep2"), 30))
                    {
                        var location = driver.Url;
                        datarow.Newrow("Checkout process url", "", location, "PASS", driver);
                        driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep2")).Click();
                    }
                    else
                    {
                        datarow.Newrow("Continue Button in Checkout Page", "Error Not Expected",
                                       "Pagecontent_ButtonCheckoutStep2-Element Not Present", "FAIL", driver);
                        screenshot.Screenshotfailed(driver);
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    datarow.Newrow("Continue Button Exception", "Exception Not Expected", e, "FAIL", driver);
                    screenshot.Screenshotfailed(driver);
                }
                //Pay Button
                try
                {
                    if (IsElementPresent(driver, By.Id("Pagecontent_ButtonConfirmCheckout"), 30))
                    {
                        driver.FindElement(By.Id("Pagecontent_ButtonConfirmCheckout")).Click();

                        var title = driver.Title;
                        datarow.Newrow("Mopay Title", "", title, "PASS", driver);
                    }
                    else
                    {
                        datarow.Newrow("Confirm Button in Checkout page", "Error Not Expected",
                                       "Pagecontent_ButtonConfirmCheckout - Element Not Present", "FAIL", driver);
                        screenshot.Screenshotfailed(driver);
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    datarow.Newrow("Pay Button Exception", "Exception Not Expected", e, "FAIL", driver);
                    screenshot.Screenshotfailed(driver);
                }
            }
            catch (Exception ex)
            {
                var exc = ex.ToString();
                datarow.Newrow("Exception", "Exception Not Expected", exc, "FAIL", driver);
                screenshot.Screenshotfailed(driver);
            }
        }
    }
}