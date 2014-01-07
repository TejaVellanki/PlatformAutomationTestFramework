using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MoBankUI.Mosite
{
    //This class Test the user as a guest. 
    internal class Guest : Driverdefining
    {
        public void guest(IWebDriver driver, Datarow datarow)
        {
            if (!IsElementPresent(driver, By.Id("at-GuestUser"))) return;
            driver.FindElement(By.Id("at-GuestUser")).Click();
            if (IsElementPresent(driver, By.XPath("//input[@value='Continue']")))
            {
                driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            }

            try
            {
                var count = GetXpathCount(driver, "//html/body/div[1]/div[2]/div/form/div");
                for (var i = 1; i <= count; i++)
                {
                    if (!IsElementPresent(driver, By.XPath("//html/body/div[1]/div[2]/div/form/div[" + i + "]/label")))
                        continue;
                    var valuet =
                        driver.FindElement(By.XPath("html/body/div[1]/div[2]/div/form/div[" + i + "]/label"))
                            .Text;
                    //if (valuet == "Telephone:")
                    //{
                    //    driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[" + i + "]/input")).SendKeys("123456789");
                    //}

                    if (valuet.Contains("*") || valuet != "Country: *" || valuet.Contains("Country") ||
                        valuet.Contains("Email") || valuet != "Continue")
                    {
                        try
                        {
                            driver.FindElement(
                                By.XPath("//html/body/div[1]/div[2]/div/form/div[" + i + "]/input"))
                                .SendKeys("TEST");
                            datarow.newrow("Registration Field Name", "", valuet, "PASS", driver);
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex);
                        }
                    }
                    if (valuet.Contains("Email"))
                    {
                        driver.FindElement(By.XPath("//html/body/div[1]/div[2]/div/form/div[" + i + "]/input"))
                            .SendKeys("test@test.com");
                    }

                    if (valuet == "Country: *" || valuet == "Country")
                    {
                        var con = driver.FindElement(By.Id("Country"));
                        IList<IWebElement> countries = con.FindElements(By.TagName("option"));


                        string values = null;
                        foreach (var value in countries)
                        {
                            values = values + "\r\n" + value;
                            new SelectElement(driver.FindElement(By.Id("Country"))).SelectByText(value.Text);
                        }
                        datarow.newrow("Registration Field Countries", "", values, "PASS", driver);
                    }

                    if (valuet == "Continue")
                    {
                        driver.FindElement(
                            By.XPath("//html/body/div[1]/div[2]/div/form/div[" + i + "]/div/input")).Click();
                    }
                }
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
            }
        }
    }
}