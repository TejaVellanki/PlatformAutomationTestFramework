﻿// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using OpenQA.Selenium;
using WebDriver_Refining;

namespace MoBankUI
{
    internal class Confirmtab : Driverdefining
    {
        public void Confirm(IWebDriver driver, Datarow datarow)
        {
            try
            {
                datarow.newrow("", "", "CONFIRM CONFIGURATION", "", driver);
                string confirm = driver.FindElement(By.XPath("//*[@id='Pages_1__Name']")).Text;

                driver.FindElement(By.XPath("(//a[contains(text(),'…')])[2]")).Click();


                driver.FindElement(By.Id("Url")).Clear();
                driver.FindElement(By.Id("Url")).SendKeys("https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl");
                driver.FindElement(By.Id("Parameters")).Clear();
                driver.FindElement(By.Id("Parameters"))
                      .SendKeys("RANDOM=0.825800705309124&ACTION=GETPSPFORM&PAYMENTMETHOD=4");
                driver.FindElement(By.Id("Sequence")).Clear();
                driver.FindElement(By.Id("Sequence")).SendKeys("30");
                /*
                driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__Selector")).Clear();
                driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__Selector")).SendKeys("input[name=ORDERNUMBER]");
                driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__Attribute")).Clear();
                driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__Attribute")).SendKeys("value");
                new SelectElement(driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__PropertyPath")))  new SelectElement(driver.FindElement(By.Id(""))).SelectByText("");ByText("Reference");
                driver.FindElement(By.CssSelector("input.button")).Click();
                  
                 * */
                driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__Selector")).Clear();
                driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__Selector"))
                      .SendKeys("input[name='CALLBACKURLUSER']");
                driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__Attribute")).Clear();
                driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__Attribute")).SendKeys("value");
                Selectanoption(driver, By.Id("ScrapedDataValueConfigurations_0__PropertyPath"), "PaymentAcceptedUrl");
                // new SelectElement(driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__PropertyPath"))).SelectByText("PaymentAcceptedUrl");
                driver.FindElement(By.CssSelector("input.button")).Click();

                #region validations

                string attribute = driver.FindElement(By.Id("Url")).GetAttribute("Value");
                string actual = driver.FindElement(By.Id("Parameters")).GetAttribute("Value");
                string str3 = driver.FindElement(By.Id("Sequence")).GetAttribute("Value");
                string str4 =
                    driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__Selector")).GetAttribute("Value");
                string str5 =
                    driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__Attribute")).GetAttribute("Value");
                //string str6 =driver.FindElement(By.Id("ScrapedDataValueConfigurations_1__Selector")).GetAttribute("Value");
                // string str7 =driver.FindElement(By.Id("ScrapedDataValueConfigurations_1__Attribute")).GetAttribute("Value");

                if (attribute == "https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl")
                {
                    datarow.newrow("URL", "https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl", attribute, "PASS",
                                   driver);
                }
                else
                {
                    datarow.newrow("URL", "https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl", attribute, "FAIL",
                                   driver);
                }
                if (actual == "RANDOM=0.825800705309124&ACTION=GETPSPFORM&PAYMENTMETHOD=4")
                {
                    datarow.newrow("Parameters", "RANDOM=0.825800705309124&ACTION=GETPSPFORM&PAYMENTMETHOD=4", actual,
                                   "PASS", driver);
                }
                else
                {
                    datarow.newrow("Parameters", "RANDOM=0.825800705309124&ACTION=GETPSPFORM&PAYMENTMETHOD=4", actual,
                                   "PASS", driver);
                }
                if (str3 == "30")
                {
                    datarow.newrow("Sequence", "30", str3, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Sequence", "30", str3, "FAIL", driver);
                }
                if (str4 == "input[name='CALLBACKURLUSER']")
                {
                    datarow.newrow("Scraped Data", "input[name='CALLBACKURLUSER']", str4, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Scraped Data", "input[name='CALLBACKURLUSER']", str4, "FAIL", driver);
                }
                if (str5 == "value")
                {
                    datarow.newrow("Scrapped Data Configuration", "value", str5, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Scrapped Data Configuration", "value", str5, "FAIL", driver);
                }
                /*
                if (str6 == "input[name=\"CALLBACKURLUSER\"]")
                {
                    datarow.newrow("Scraped Data Selector1", "input[name=\"CALLBACKURLUSER\"]", str6, "PASS", driver,
                                   );
                }
                else
                {
                    datarow.newrow("Scraped Data Selector1", "input[name=\"CALLBACKURLUSER\"]", str6, "PASS", driver,
                                   );
                }
                /*
                if (str7 == "value")
                {
                    datarow.newrow("Scraped Data Configuration1", "value", str7, "PASS",driver);
                }
                else
                {
                    datarow.newrow("Scraped Data Configuration1", "value", str7, "FAIL",driver);
                }
                */

                #endregion
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Excepion Not Expected", e, "FAIL", driver);
            }
        }
    }
}