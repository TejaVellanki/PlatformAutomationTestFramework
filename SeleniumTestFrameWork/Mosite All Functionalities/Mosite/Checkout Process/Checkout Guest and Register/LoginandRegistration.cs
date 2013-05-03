using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium;

namespace MoBankUI
{
    internal class LoginandRegistration_TPS
    {
        public void Login_TPS(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            var screenshot = new Screenshot();
            try
            {
                if (selenium.IsElementPresent("//form[@id='ctl00']/section/div/input"))
                {
                    driver.FindElement(By.XPath("//form[@id='ctl00']/section/div/input"))
                          .SendKeys("mopoweredtest@mobankgroup.com");
                    datarow.newrow("Login Name Element", "Login Name Field Is Expected", "Login Name Field Is Present",
                                   "PASS", driver, selenium);
                }
                else if (selenium.IsElementPresent("id=UserName"))
                {
                    driver.FindElement(By.Id("UserName")).SendKeys("mopoweredtest@mobankgroup.com");
                    datarow.newrow("Login Name Element", "Login Name Field Is Expected", "Login Name Field Is Present",
                                   "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Login Name Element", "Login Name Field Is Expected",
                                   "Blocker-Login Name Field Is Not Present", "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
                if (selenium.IsElementPresent("//form[@id='ctl00']/section/div[2]/input"))
                {
                    driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[2]/input")).SendKeys("M0Test08");
                    datarow.newrow("Login Name Element", "Login Password Field Is Expected",
                                   "Login Password Field Is Present", "PASS", driver, selenium);
                }
                else if (selenium.IsElementPresent("id=Password"))
                {
                    driver.FindElement(By.Id("Password")).SendKeys("M0Test08");
                    datarow.newrow("Login Name Element", "Login Password Field Is Expected",
                                   "Login Password Field Is Present", "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Login Password Element", "Login Password Field Is Expected",
                                   "Blocker - Login Password Field Is Not Present", "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
                if (selenium.IsElementPresent("//form[@id='ctl00']/section/div[3]/div/input"))
                {
                    driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[3]/div/input")).Click();
                    selenium.WaitForPageToLoad("30000");
                }
                else if (selenium.IsElementPresent("css=input.ui-btn-hidden"))
                {
                    selenium.Click("css=input.ui-btn-hidden");
                    selenium.WaitForPageToLoad("30000");
                }
                else
                {
                    datarow.newrow("Login Element", "Login Button Is Expected", "Blocker - Login Button Is Not Present",
                                   "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
                if (selenium.IsElementPresent("id=BasketInfo"))
                {
                    string basvalue = driver.FindElement(By.Id("BasketInfo")).Text;

                    if (basvalue == "(1)")
                    {
                        datarow.newrow("Basket Value", "(1)", basvalue, "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrow("Basket Value", "(1)", basvalue, "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                }
                else
                {
                    datarow.newrow("Basket Value", "(1)", "No Basket Information", "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }

                if (selenium.IsElementPresent("//html/body/div/div[2]/div[2]/form/section/p/a/span/span/span/span"))
                {
                    datarow.newrow("Change Details Element", "Change Details Button is Expected",
                                   "Change Details Button Is Present", "PASS", driver, selenium);
                    selenium.Click("//html/body/div/div[2]/div[2]/form/section/p/a/span/span/span/span");
                    selenium.WaitForPageToLoad("30000");
                    try
                    {
                        decimal count = selenium.GetXpathCount("//form[@id='ctl00']/section/div");
                        for (int i = 1; i <= count; i++)
                        {
                            if (selenium.IsElementPresent("//form[@id='ctl00']/section/div[" + i + "]/label"))
                            {
                                string valuet =
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
                                        datarow.newrow("Registration Field Name", "", valuet, "PASS", driver, selenium);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Write(ex);
                                    }
                                }

                                if (valuet == "Country: *")
                                {
                                    string[] varinats = selenium.GetSelectOptions("id=Pagecontent_ddlCountry");
                                    string values = null;
                                    foreach (string value in varinats)
                                    {
                                        values = values + "\r\n" + value;
                                        new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlCountry")))
                                            .SelectByText(value);
                                    }
                                    datarow.newrow("Registration Field Countries", "", values, "PASS", driver, selenium);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string e = ex.ToString();
                        datarow.newrow("Exception", "exception Not Expected", e, "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                }
                string loc = selenium.GetLocation();
                if (loc.Contains("Error"))
                {
                    datarow.newrow("Error Page", "Error Page After Logging Not Expected", loc, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }


                driver.Navigate().Back();
                selenium.WaitForPageToLoad("30000");


                //selecting delivery method
                try
                {
                    if (
                        selenium.IsElementPresent(
                            "//html/body/div/div[2]/div[2]/form/section/div[2]/fieldset/div/label/span/span"))
                    {
                        decimal count =
                            selenium.GetXpathCount("/html/body/div/div[2]/div[2]/form/section/div[2]/fieldset/div");
                        for (int i = 1; i < count; i++)
                        {
                            string text =
                                selenium.GetText("//html/body/div/div[2]/div[2]/form/section/div[2]/fieldset/div[" + i +
                                                 "]/label/span/span");
                            selenium.Click("//html/body/div/div[2]/div[2]/form/section/div[2]/fieldset/div[" + i +
                                           "]/label/span/span");
                            datarow.newrow("Delivery Method", "", text, "PASS", driver, selenium);
                        }
                    }
                    else
                    {
                        string loca = selenium.GetLocation();
                        datarow.newrow("Delivery Method", "Unexpected Format", loca, "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Delivery Method Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
                // Click continue to next page 
                try
                {
                    if (selenium.IsElementPresent("Pagecontent_ButtonCheckoutStep2"))
                    {
                        string location = selenium.GetLocation();
                        datarow.newrow("Checkout process url", "", location, "PASS", driver, selenium);
                        driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep2")).Click();
                        selenium.WaitForPageToLoad("30000");
                    }
                    else
                    {
                        datarow.newrow("Continue Button in Checkout Page", "Error Not Expected",
                                       "Pagecontent_ButtonCheckoutStep2-Element Not Present", "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Continue Button Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
                //Pay Button
                try
                {
                    if (selenium.IsElementPresent("id=Pagecontent_ButtonConfirmCheckout"))
                    {
                        driver.FindElement(By.Id("Pagecontent_ButtonConfirmCheckout")).Click();
                        selenium.WaitForPageToLoad("30000");
                        string title = driver.Title;
                        datarow.newrow("Mopay Title", "", title, "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrow("Confirm Button in Checkout page", "Error Not Expected",
                                       "Pagecontent_ButtonConfirmCheckout - Element Not Present", "FAIL", driver,
                                       selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Pay Button Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
            }
            catch (Exception ex)
            {
                string exc = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", exc, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }
    }
}