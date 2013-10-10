// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;
namespace MoBankUI
{
    public class Mopaysite :driverdefining
    {
        private datarow datarow = new datarow();
        private GeneralLibrary generalLibrary;
        
        public void MoPay(IWebDriver driver, datarow datarow)
        {
            generalLibrary = new GeneralLibrary();
            DataTable table =
                generalLibrary.GetExcelData(@"C:\\Input Data\CardDetails.xls", "CardDetails").Tables[0];
            var screenshot = new Screenshot();
            try
            {
                string actual = driver.FindElement(By.XPath("//div[@id='total-amount']/dl/dd")).Text;
                if (actual.Contains("\x00a3"))
                {
                    datarow.newrow("Currency Validation", "\x00a3", actual, "PASS",driver);
                }
                else
                {
                    datarow.newrow("Currency Validation", "\x00a3", actual, "FAIL",driver);
                }
            }
            catch (Exception exception)
            {
                string str2 = exception.ToString();
                datarow.newrow("Exception", "Exception Not Expected", str2, "FAIL",driver);
            }
            int num = 0;
            int count = table.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                try
                {
                    string input = table.Rows[i]["FirstName"].ToString();
                    string str4 = table.Rows[i]["LastName"].ToString();
                    string str5 = table.Rows[i]["Card Number"].ToString();
                    string str6 = table.Rows[i]["Security Code"].ToString();
                    string expected = table.Rows[i]["CardType"].ToString();
                    string str8 = table.Rows[i]["Name on Card"].ToString();
                    string text = table.Rows[i]["ExpiryMonth"].ToString();
                    string str10 = table.Rows[i]["Expiry Year"].ToString();
                    string str11 = table.Rows[i]["E-mail"].ToString();
                    string str12 = table.Rows[i]["Phone Number"].ToString();
                    string str13 = table.Rows[i]["Address"].ToString();
                    string str14 = table.Rows[i]["City"].ToString();
                    string str15 = table.Rows[i]["Post Code"].ToString();
                    string str16 = table.Rows[i]["County"].ToString();
                    string str17 = table.Rows[i]["Country"].ToString();
                    new SelectElement(driver.FindElement(By.Id("Card_Type"))).SelectByText("Visa Debit");
                    driver.FindElement(By.Id("Card_Number")).Clear();
                    driver.FindElement(By.Id("Card_Number")).SendKeys(str5);
                    driver.FindElement(By.Id("Card_SecurityCode")).Clear();
                    driver.FindElement(By.Id("Card_SecurityCode")).SendKeys(str6);
                    driver.FindElement(By.Id("Card_Name")).Clear();
                    driver.FindElement(By.Id("Card_Name")).SendKeys(str8);
                    new SelectElement(driver.FindElement(By.Id("Card_ExpiryDate_Month"))).SelectByText(text);
                    new SelectElement(driver.FindElement(By.Id("Card_ExpiryDate_Year"))).SelectByText(str10);
                    if (num < 1)
                    {
                        driver.FindElement(By.Id("change-address")).Click();
                        waitforpagetoload(driver,30000);
                        num++;
                    }
                    driver.FindElement(By.Id("BillingContact_FirstName")).Clear();
                    driver.FindElement(By.Id("BillingContact_FirstName")).SendKeys(input);
                    driver.FindElement(By.Id("BillingContact_LastName")).Clear();
                    driver.FindElement(By.Id("BillingContact_LastName")).SendKeys(str4);
                    driver.FindElement(By.Id("BillingContact_Email")).Clear();
                    driver.FindElement(By.Id("BillingContact_Email")).SendKeys(str11);
                    driver.FindElement(By.Id("BillingContact_Phone_Number")).Clear();
                    driver.FindElement(By.Id("BillingContact_Phone_Number")).SendKeys(str12);
                    driver.FindElement(By.Id("BillingContact_Address_Line1")).Clear();
                    driver.FindElement(By.Id("BillingContact_Address_Line1")).SendKeys(str13);
                    driver.FindElement(By.Id("BillingContact_Address_Line2")).Clear();
                    driver.FindElement(By.Id("BillingContact_Address_Line2")).SendKeys("Address2");
                    driver.FindElement(By.Id("BillingContact_Address_Postcode")).Clear();
                    driver.FindElement(By.Id("BillingContact_Address_Postcode")).SendKeys(str15);
                    driver.FindElement(By.Id("BillingContact_Address_Town")).Clear();
                    driver.FindElement(By.Id("BillingContact_Address_Town")).SendKeys(str14);
                    driver.FindElement(By.Id("BillingContact_Address_County")).Clear();
                    driver.FindElement(By.Id("BillingContact_Address_County")).SendKeys(str16);
                    if (str17.Length == 0)
                    {
                         IWebElement elem = driver.FindElement(By.Id("BillingContact_Address_Country"));
                         IList<IWebElement> options = elem.FindElements(By.TagName("option"));
                        foreach (IWebElement str18 in options)
                        {
                            new SelectElement(driver.FindElement(By.Id("BillingContact_Address_Country"))).SelectByText(
                                str18.Text);
                            if (str18.Text == "")
                            {
                                break;
                            }
                        }
                    }
                    if (str17.Length > 0)
                    {
                         IWebElement elem = driver.FindElement(By.Id("BillingContact_Address_Country"));
                         IList<IWebElement> options = elem.FindElements(By.TagName("option"));
                       
                        foreach (IWebElement str19 in options)
                        {
                            new SelectElement(driver.FindElement(By.Id("BillingContact_Address_Country"))).SelectByText(
                                str19.Text);
                            if (str19.Text == "United Kingdom")
                            {
                                break;
                            }
                        }
                    }
                    driver.FindElement(By.Name("PostAction[Complete]")).Click();
                    waitforpagetoload(driver,30000);
                    Thread.Sleep(0xbb8);
                    if (Regex.IsMatch(str5, "^[0-9'']"))
                    {
                        datarow.newrow("Card Number", str5, str5, "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("Number required") ||  driver.PageSource.Contains("Number invalid"))
                    {
                        datarow.newrow("Card Number", str5, "Number Invalid", "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Card Number", str5, "No Error Message Displayed", "FAIL",driver);
                        screenshot.screenshotfailed(driver);
                    }
                    if (expected == null)
                    {
                        if ( driver.PageSource.Contains("Type required"))
                        {
                            datarow.newrow("Card Type", expected, "Type Required", "PASS",driver);
                        }
                        else
                        {
                            datarow.newrow("Card Type", expected, expected, "FAIL",driver);
                            screenshot.screenshotfailed(driver);
                        }
                    }
                    else
                    {
                        datarow.newrow("Card Type", "Visa Debit", "Visa Debit", "PASS",driver);
                    }
                    var regex = new Regex("^[0-9]{3}$");
                    if (regex.IsMatch(str6))
                    {
                        datarow.newrow("Security Code", str6, "Valid 3 Digits", "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("Security code required") ||
                              driver.PageSource.Contains("Security code invalid"))
                    {
                        datarow.newrow("Security Code", str6, "Security code required", "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Security Code", str6, "No Error Message Displayed", "FAIL",driver);
                        screenshot.screenshotfailed(driver);
                    }
                    if (Regex.IsMatch(str8, "^[a-zA-Z'']"))
                    {
                        datarow.newrow("Name on Card", str8, str8, "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("Name required"))
                    {
                        datarow.newrow("Name on Card", str8, "Name Required", "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Name on Card", str8, "No Error Message Displayed", "PASS",driver);
                        screenshot.screenshotfailed(driver);
                    }
                    if (Regex.IsMatch(input, "^[a-zA-Z'']"))
                    {
                        datarow.newrow("First Name", input, input, "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("The First Name field is required."))
                    {
                        datarow.newrow("First Name", input, "The First Name field is required.", "PASS", driver
                                       );
                    }
                    else
                    {
                        datarow.newrow("First Name", input, "No Error Message Displayed", "FAIL",driver);
                        screenshot.screenshotfailed(driver);
                    }
                    if (Regex.IsMatch(str4, "^[a-zA-Z'']"))
                    {
                        datarow.newrow("Last Name", str4, str4, "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("The Last Name field is required."))
                    {
                        datarow.newrow("Last Name", str4, "The Last Name field is required.", "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Last Name", str4, "No Error message Displayed", "FAIL",driver);
                        screenshot.screenshotfailed(driver);
                    }
                    if (Regex.IsMatch(str13, "^[a-zA-Z0-9'']"))
                    {
                        datarow.newrow("Address", str13, str13, "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("The Address field is required"))
                    {
                        datarow.newrow("Address", str13, "The Address field is required", "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Address", str13, "No Error message Displayed", "FAIL",driver);
                        screenshot.screenshotfailed(driver);
                    }
                    if (Regex.IsMatch(str15, "^[a-zA-Z0-9'']"))
                    {
                        datarow.newrow("Post Code", str15, str15, "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("The Postcode field is required"))
                    {
                        datarow.newrow("Post Code", str15, "The Postcode field is required.", "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Post Code", str15, "No Error Message Displayed", "FAIL",driver);
                        screenshot.screenshotfailed(driver);
                    }
                    if (Regex.IsMatch(str17, "^[a-zA-Z'']"))
                    {
                        datarow.newrow("Country", str17, str17, "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("The Country field is required."))
                    {
                        datarow.newrow("Country", str17, "The Country field is required.", "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Country", str17, "No Error Message", "FAIL",driver);
                        screenshot.screenshotfailed(driver);
                    }
                    if (driver.Title == "Secure Payment Page")
                    {
                    }
                    string location = driver.Url;
                    string str22 = driver.Title;
                    if (location.Contains("State=Accepted") || str22.Contains("Payment Accepted"))
                    {
                        datarow.newrow("Transaction", location, "State=Accepted", "PASS",driver);
                        break;
                    }
                    if (location.Contains("State=NotAccepted"))
                    {
                        datarow.newrow("Transaction", location, "Transaction Declined", "FAIL",driver);
                        break;
                    }
                    if (( driver.PageSource.Contains("Checkout Declined") ||  driver.PageSource.Contains("Checkout Error")) ||
                         driver.PageSource.Contains("Not Found"))
                    {
                        datarow.newrow("Checkout", "Checkout Declined", "Checkout Declined", "PASS",driver);
                        break;
                    }
                }
                catch (Exception exception2)
                {
                    Console.Write(exception2);
                    string str23 = exception2.ToString();
                    var screenshot2 = new Screenshot();
                    datarow.newrow("Exception", "Exceptio not Expected", str23, "FAIL",driver);
                    screenshot2.screenshotfailed(driver);
                }
            }
        }
    }
}