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
    //This class Test the user as a guest. 
    class Guest
    {
        public void guest(IWebDriver driver, ISelenium selenium,datarow datarow)
        {
            if (selenium.IsElementPresent("id=at-GuestUser"))
            {
                selenium.Click("id=at-GuestUser");
                if (selenium.IsElementPresent("//input[@value='Continue']"))
                {
                    selenium.Click("//input[@value='Continue']");
                    selenium.WaitForPageToLoad("30000");
                }             
                    
                    try
                    {
                        decimal count = selenium.GetXpathCount("//html/body/div[1]/div[2]/div/form/div");
                        for (int i = 1; i <= count; i++)
                        {
                            if (selenium.IsElementPresent("//html/body/div[1]/div[2]/div/form/div["+i+"]/label"))
                            {
                                var valuet = driver.FindElement(By.XPath("html/body/div[1]/div[2]/div/form/div[" + i + "]/label")).Text;
                                //if (valuet == "Telephone:")
                                //{
                                //    driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[" + i + "]/input")).SendKeys("123456789");
                                //}

                                if (valuet.Contains("*") || valuet != "Country: *"|| valuet.Contains("Country")||valuet.Contains("Email")|| valuet!="Continue")
                                {
                                    try
                                    {
                                        driver.FindElement(By.XPath("//html/body/div[1]/div[2]/div/form/div[" + i + "]/input")).SendKeys("TEST");
                                        datarow.newrow("Registration Field Name", "", valuet, "PASS", driver, selenium);

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Write(ex);
                                    }
                                }
                                if (valuet.Contains("Email"))
                                {
                                    driver.FindElement(By.XPath("//html/body/div[1]/div[2]/div/form/div[" + i + "]/input")).SendKeys("test@test.com");
                                }
                                
                                if (valuet == "Country: *"||valuet=="Country")
                                {
                                   
                                        string[] varinats = selenium.GetSelectOptions("id=Country");

                                        string values = null;
                                        foreach (string value in varinats)
                                        {

                                            values = values + "\r\n" + value;
                                            new SelectElement(driver.FindElement(By.Id("Country"))).SelectByText(value);

                                        }
                                        datarow.newrow("Registration Field Countries", "", values, "PASS", driver, selenium);
                                   
                                }

                                if (valuet=="Continue")
                                {
                                    selenium.Click("//html/body/div[1]/div[2]/div/form/div[" + i + "]/div/input");
                                    selenium.WaitForPageToLoad("30000");
                                }
                            }
                        }
                   
                   
                    }
                    catch (Exception ex)
                    {
                        string e = ex.ToString();
                        datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver, selenium);


                    }

                
            }
        }
    }
}
