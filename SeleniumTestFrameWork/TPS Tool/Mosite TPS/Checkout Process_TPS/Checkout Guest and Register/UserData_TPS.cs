using System;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using System.Data;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Selenium;
using System.Data.OleDb;
using System.IO;
using System.Timers;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace MoBankUI
{
    class UserData_TPS
    {
        Screenshot screenshot = new Screenshot();
        public void userdata_TPS(IWebDriver driver,ISelenium selenium,datarow datarow)
        {
            try
            {
                
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement8 = driver.FindElement(By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/fieldset/div[2]/div/button"));

                decimal count = selenium.GetXpathCount("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div");
                if (count == 0)
                {
                    datarow.newrow("User Data Form Details", "Expected User Form Fields", "User Form Fields Doesnot Exist", "FAIL", driver, selenium);
                }
                //Populating Customer Details from Excel Sheet
                for (int i = 1; i <= count; i++)
                {
                    if (selenium.IsElementPresent("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[" + i + "]/label"))
                    {
                        var valuet = driver.FindElement(By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[" + i + "]/label")).Text;

                        if (!valuet.Contains("Country"))
                        {
                            driver.FindElement(By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[" + i + "]/input[2]")).Clear();
                            driver.FindElement(By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[" + i + "]/input[2]")).SendKeys("TEST");
                            datarow.newrow("Form Field", "", valuet, "PASS", driver, selenium);
                        }

                        // selecting the country
                        if (valuet.Contains("Country"))
                        {
                            try
                            {

                                int j = i - 1;
                                string id = "id=FormData_" + j + "__Value";
                                string[] varinats = selenium.GetSelectOptions("id=FormData_" + j + "__Value");
                                string values = null;
                                foreach (string value in varinats)
                                {
                                    if (!value.Contains("Please"))
                                    {
                                        if (value == "United Kingdom")
                                        {
                                            values = values + "\r\n" + value;
                                            new SelectElement(driver.FindElement(By.Id("FormData_" + j + "__Value"))).SelectByText(value);
                                            break;
                                        }
                                        else
                                        {
                                            values = values + "\r\n" + value;
                                            new SelectElement(driver.FindElement(By.Id("FormData_" + j + "__Value"))).SelectByText(value);
                                        }

                                    }

                                }
                                datarow.newrow("Country Field", "", values, "PASS", driver, selenium);
                            }
                            catch (Exception ex)
                            {
                                string e = ex.ToString();
                                datarow.newrow("Country Field Exception", "Exception Not Expected", e, "PASS", driver, selenium);
                            }
                        }                       

                        if (valuet.Contains("Email"))
                        {
                            try
                            {
                                driver.FindElement(By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[" + i + "]/input[2]")).Clear();
                                driver.FindElement(By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[" + i + "]/input[2]")).SendKeys("test@test.com");
                            }
                            catch (Exception ex)
                            {
                                string e = ex.ToString();
                                datarow.newrow("Email Field Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                                screenshot.screenshotfailed(driver, selenium);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception in DataForm", "Exception Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
            try
            {

                //Terms and Conditions
                if (selenium.IsElementPresent("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[11]/fieldset/div[2]/div/label/span/span[2]"))
                {
                    driver.FindElement(By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[11]/fieldset/div[2]/div/label/span/span[2]")).Click();
                }
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement9 = driver.FindElement(By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/fieldset/div[2]/div/button"));
                driver.FindElement(By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/fieldset/div[2]/div/button")).Click();
                selenium.WaitForPageToLoad("30000");
                string pagetitle = driver.Title.ToString();
                string basval = driver.FindElement(By.Id("BasketInfo")).Text;
                if(selenium.IsElementPresent("id=FormData_2__Value"))
                {
                driver.FindElement(By.Id("FormData_2__Value")).Click();
                }
                if(selenium.IsElementPresent("//html/body/div/div[2]/div/form/fieldset/div[2]/div/button"))
                {
                driver.FindElement(By.XPath("//html/body/div/div[2]/div/form/fieldset/div[2]/div/button")).Click();
                selenium.WaitForPageToLoad("30000");
                Thread.Sleep(2000);
                }
                string details = selenium.GetText("css=div.ui-content.ui-body-c > p");
                if (selenium.IsElementPresent("//html/body/div/div[2]/div[2]/div[2]/a/span/span"))
                {
                    driver.FindElement(By.XPath("//html/body/div/div[2]/div[2]/div[2]/a/span/span")).Click();
                    selenium.WaitForPageToLoad("30000");
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception in DataForm", "Exception Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
                                            
                
           
        }
    }
}
