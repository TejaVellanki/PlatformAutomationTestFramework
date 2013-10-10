
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
    using WebDriver_Refining ;

namespace MoBankUI
{ 
    internal class AddressElements : driverdefining
    {
        public void elements(IWebDriver driver, datarow datarow)
        {
            try
            {
                  driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Name")).Click();
                  waitforpagetoload(driver,30000);
                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Label")).SendKeys("First Name: *");
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_0__PropertyPath"), "FirstName");
               // new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_0__PropertyPath"))).SelectByText("FirstName");
                if (GetValue(driver,By.Id("LiveScrapeForm_Elements_0__Required"),30) == "false")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Required")).Click();
                }
                try
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Name")).Click();
                    waitforpagetoload(driver, 30000);
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Label")).Clear();
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Label")).SendKeys("Last Name: *");
                    Selectanoption(driver, By.Id("LiveScrapeForm_Elements_1__PropertyPath"), "LastName");
                    //new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_1__PropertyPath"))).SelectByText("LastName");
                    if (GetValue(driver, By.Id("LiveScrapeForm_Elements_1__Required"), 30) == "false")
                    {
                        driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Required")).Click();
                    }


                }
                catch (Exception ex)
                {

                    string e = ex.ToString();

                }
               
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Name")).Click();
                  waitforpagetoload(driver,30000);
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__LabelSelector")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__LabelSelector")).SendKeys(".actrequired:eq(1)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Label")).SendKeys("Post Code: *");
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_2__PropertyPath"), "PostCode");
               // new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_2__PropertyPath"))).SelectByText("PostCode");
                if (GetValue(driver, By.Id("LiveScrapeForm_Elements_2__Required"), 30) == "false")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Required")).Click();
                }

                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Name")).Click();
                  waitforpagetoload(driver,30000);
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__LabelSelector")).SendKeys(".actrequired:eq(2)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Label")).SendKeys("Address Line 1: *");
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_3__PropertyPath"), "Address1");
                //new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_3__PropertyPath"))).SelectByText("Address1");
                if (GetValue(driver, By.Id("LiveScrapeForm_Elements_3__Required"), 30) == "false")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Required")).Click();
                }
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Name")).Click();
                  waitforpagetoload(driver,30000);
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__LabelSelector"))
                      .SendKeys("#idBothAddressesTable tr:eq(5) td:eq(0)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Label")).SendKeys("Address Line 2:");
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_4__PropertyPath"), "Address2");
               //new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_4__PropertyPath"))).SelectByText("Address2");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Name")).Click();
                  waitforpagetoload(driver,30000);
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__LabelSelector")).SendKeys(".actrequired:eq(3)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Label")).SendKeys("City/Town: *");
             
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_5__PropertyPath"), "BillingCity");
                //new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_5__PropertyPath"))).SelectByText("BillingCity");
                if (GetValue(driver, By.Id("LiveScrapeForm_Elements_5__Required"), 30) == "false")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Required")).Click();
                }
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Name")).Click();
                waitforpagetoload(driver,30000);
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__LabelSelector"))
                      .SendKeys("#idBothAddressesTable tr:eq(7) td:eq(0)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Label")).SendKeys("Country: *");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__KeysValuesSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__KeysValuesSelector"))
                      .SendKeys("#lstInvoiceCountry option");
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_6__PropertyPath"), "Country");
                //  new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_6__PropertyPath"))).SelectByText("Country");
                if (GetValue(driver, By.Id("LiveScrapeForm_Elements_6__Required"), 30) == "false")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Required")).Click();
                }
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__Name")).Click();
                  waitforpagetoload(driver,30000);
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__LabelSelector"))
                      .SendKeys("#idBothAddressesTable tr:eq(8) td:eq(0)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__Label")).SendKeys("County:");
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_7__PropertyPath"),"County");
                //new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_7__PropertyPath"))).SelectByText("County");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Name")).Click();
                  waitforpagetoload(driver,30000);
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__LabelSelector"))
                      .SendKeys("#idBothAddressesTable tr:eq(9) td:eq(0)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Label")).SendKeys("Phone Number:");
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_8__PropertyPath"),"Phone");
                //new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_8__PropertyPath"))).SelectByText("Phone");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Name")).Click();
                  waitforpagetoload(driver,30000);
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__LabelSelector")).SendKeys("#idINVOICEEMAILlabel");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Label")).SendKeys("Email Address: *");
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_9__PropertyPath"), "Email");
               // new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_9__PropertyPath"))).SelectByText("Email");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Required")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_10__Name")).Click();
                  waitforpagetoload(driver,30000);
                driver.FindElement(By.Id("LiveScrapeForm_Elements_10__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_10__LabelSelector")).SendKeys("label[for=INVOICEUSERDEFINED]");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_10__Type")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_10__Type"), "Check");
               // new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_10__Type"))).SelectByText("Check");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Type")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_9__Type"), "Email");
                // new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Type"))).SelectByText("Email");
                 driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Type")).Click();
                 Selectanoption(driver, By.Id("LiveScrapeForm_Elements_8__Type"), "Phone");
                // new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Type"))).SelectByText("Phone");
                driver.FindElement(By.XPath("//select[@id='LiveScrapeForm_Elements_8__Type']/option[3]")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Type")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_6__Type"), "DropList");
                //new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Type"))).SelectByText("DropList");
                
            }
            catch (NotFoundException ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Excepion Not Expected", e, "FAIL", driver);

            }
            driver.FindElement(By.CssSelector("input.button")).Click();
               waitforpagetoload(driver,30000);
        }
    }
}