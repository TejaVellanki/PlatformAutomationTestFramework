using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium;

namespace MoBankUI
{
    internal class AddressElements
    {
        public void elements(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            try
            {
                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Name")).Click();

                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Label")).SendKeys("First Name: *");
                new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_0__PropertyPath"))).SelectByText("FirstName");
                if (selenium.GetValue("id=LiveScrapeForm_Elements_0__Required") == "off")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Required")).Click();
                }

                driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Name")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Label")).SendKeys("Last Name: *");
                new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_1__PropertyPath"))).SelectByText("LastName");
                if (selenium.GetValue("id=LiveScrapeForm_Elements_1__Required") == "off")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Required")).Click();
                }

                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Name")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__LabelSelector")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__LabelSelector")).SendKeys(".actrequired:eq(1)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Label")).SendKeys("Post Code: *");
                new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_2__PropertyPath"))).SelectByText(
                    "PostCode");
                if (selenium.GetValue("id=LiveScrapeForm_Elements_2__Required") == "off")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Required")).Click();
                }

                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Name")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__LabelSelector")).SendKeys(".actrequired:eq(2)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Label")).SendKeys("Address Line 1: *");
                new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_3__PropertyPath"))).SelectByText(
                    "Address1");
                if (selenium.GetValue("id=LiveScrapeForm_Elements_3__Required") == "off")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Required")).Click();
                }
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Name")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__LabelSelector"))
                      .SendKeys("#idBothAddressesTable tr:eq(5) td:eq(0)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Label")).SendKeys("Address Line 2:");
                new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_4__PropertyPath"))).SelectByText(
                    "Address2");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Name")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__LabelSelector")).SendKeys(".actrequired:eq(3)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Label")).SendKeys("City/Town: *");
                new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_5__PropertyPath"))).SelectByText(
                    "BillingCity");
                if (selenium.GetValue("id=LiveScrapeForm_Elements_5__Required") == "off")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Required")).Click();
                }
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Name")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__LabelSelector"))
                      .SendKeys("#idBothAddressesTable tr:eq(7) td:eq(0)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Label")).SendKeys("Country: *");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__KeysValuesSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__KeysValuesSelector"))
                      .SendKeys("#lstInvoiceCountry option");
                new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_6__PropertyPath"))).SelectByText(
                    "Country");
                if (selenium.GetValue("id=LiveScrapeForm_Elements_6__Required") == "off")
                {
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Required")).Click();
                }
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__Name")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__LabelSelector"))
                      .SendKeys("#idBothAddressesTable tr:eq(8) td:eq(0)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_7__Label")).SendKeys("County:");
                new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_7__PropertyPath"))).SelectByText(
                    "County");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Name")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__LabelSelector"))
                      .SendKeys("#idBothAddressesTable tr:eq(9) td:eq(0)");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Label")).SendKeys("Phone Number:");
                new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_8__PropertyPath"))).SelectByText(
                    "Phone");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Name")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__LabelSelector")).SendKeys("#idINVOICEEMAILlabel");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Label")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Label")).SendKeys("Email Address: *");
                new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_9__PropertyPath"))).SelectByText("Email");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Required")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_10__Name")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_10__LabelSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_10__LabelSelector")).SendKeys("label[for=INVOICEUSERDEFINED]");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_10__Type")).Click();


                string[] Check = selenium.GetSelectOptions("id=LiveScrapeForm_Elements_10__Type");
                foreach(string check in Check)
                {
                    new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_10__Type"))).SelectByText(check);
                    if (check == "Check")
                    {
                        break;

                    }

                }
                driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Type")).Click();
                string[] Email = selenium.GetSelectOptions("id=LiveScrapeForm_Elements_9__Type");
                foreach (string email in Email)
                {
                    new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_9__Type"))).SelectByText(email);
                    if (email== "Email")
                    {
                       
                        break;

                    }
                }


                driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Type")).Click();
                string[] Phone = selenium.GetSelectOptions("id=LiveScrapeForm_Elements_8__Type");
                foreach (string phone in Phone)
                {
                    new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Type"))).SelectByText(phone);
                    if (phone == "Phone")
                    {
                       
                        break;

                    }
                }
                driver.FindElement(By.XPath("//select[@id='LiveScrapeForm_Elements_8__Type']/option[3]")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Type")).Click();

                string[] country = selenium.GetSelectOptions("id=LiveScrapeForm_Elements_6__Type");
                foreach (string contry in country)
                {
                    new SelectElement(driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Type"))).SelectByText(contry);
                    if (contry == "DropList")
                    {
                        
                        break;
                    }
                }
            }
            catch (NotFoundException ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Excepion Not Expected", e, "FAIL", driver, selenium);

            }
            driver.FindElement(By.CssSelector("input.button")).Click();
            selenium.WaitForPageToLoad("30000");
        }
    }
}