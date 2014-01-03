using System;
using OpenQA.Selenium;
using WebDriver_Refining;

namespace MoBankUI
{
    internal class AddressElements : driverdefining
    {
        public void elements(IWebDriver driver, datarow datarow)
        {
            try
            {
                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Label")).SendKeys("First Name: *");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_0__PropertyPath"), "FirstName");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Name")).Click();
                if (GetValue(driver, By.Id("LiveScrapeForm_Elements_0__Required"), 30) == "false")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Name")).Click();
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Required")).Click();
                }
                try
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Name")).Click();
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Label")).SendKeys("Last Name: *");
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Name")).Click();
                    Selectanoption(driver, By.Id("LiveScrapeForm_Elements_1__PropertyPath"), "LastName");
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Name")).Click();
                    //new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_1__PropertyPath"))).SelectByText("LastName");
                    if (GetValue(driver, By.Id("LiveScrapeForm_Elements_1__Required"), 30) == "false")
                    {
                        driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Name")).Click();
                        driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Required")).Click();
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                }

                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__LabelSelector")).SendKeys(".actrequired:eq(1)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Label")).SendKeys("Post Code: *");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_2__PropertyPath"), "PostCode");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Name")).Click();
                if (GetValue(driver, By.Id("LiveScrapeForm_Elements_2__Required"), 30) == "false")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Name")).Click();
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Required")).Click();
                }

                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__LabelSelector")).SendKeys(".actrequired:eq(2)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Label")).SendKeys("Address Line 1: *");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_3__PropertyPath"), "Address1");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Name")).Click();
                if (GetValue(driver, By.Id("LiveScrapeForm_Elements_3__Required"), 30) == "false")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Name")).Click();
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Required")).Click();
                }


                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__LabelSelector"))
                      .SendKeys("#idBothAddressesTable tr:eq(5) td:eq(0)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Label")).SendKeys("Address Line 2:");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_4__PropertyPath"), "Address2");


                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__LabelSelector")).SendKeys(".actrequired:eq(3)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Label")).SendKeys("City/Town: *");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_5__PropertyPath"), "BillingCity");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Name")).Click();
                if (GetValue(driver, By.Id("LiveScrapeForm_Elements_5__Required"), 30) == "false")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Name")).Click();
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Required")).Click();
                }


                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__LabelSelector"))
                      .SendKeys("#idBothAddressesTable tr:eq(7) td:eq(0)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Label")).SendKeys("Country: *");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__KeysValuesSelector"))
                      .SendKeys("#lstInvoiceCountry option");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_6__PropertyPath"), "Country");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Name")).Click();
                if (GetValue(driver, By.Id("LiveScrapeForm_Elements_6__Required"), 30) == "false")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Name")).Click();
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Required")).Click();
                }


                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__LabelSelector"))
                      .SendKeys("#idBothAddressesTable tr:eq(8) td:eq(0)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__Label")).SendKeys("County:");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_7__PropertyPath"), "County");


                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__LabelSelector"))
                      .SendKeys("#idBothAddressesTable tr:eq(9) td:eq(0)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Label")).SendKeys("Phone Number:");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_8__PropertyPath"), "Phone");

                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__LabelSelector")).SendKeys("#idINVOICEEMAILlabel");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Label")).SendKeys("Email Address: *");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_9__PropertyPath"), "Email");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Required")).Click();


                driver.FindElement(By.Id("LiveScrapeForm_Elements_10__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_10__LabelSelector"))
                      .SendKeys("label[for=INVOICEUSERDEFINED]");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_10__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_10__Type")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_10__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_10__Type"), "Check");


                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_9__Type"), "Email");
                // new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Type"))).SelectByText("Email");

                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_8__Type"), "Phone");


                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_6__Type"), "DropList");
                //new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Type"))).SelectByText("DropList");
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Excepion Not Expected", e, "FAIL", driver);
            }
            driver.FindElement(By.CssSelector("input.button")).Click();
        }
    }
}