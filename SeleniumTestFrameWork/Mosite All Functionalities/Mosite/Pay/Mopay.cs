﻿using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;
using System.Collections.Generic;

//using System.Drawing;

namespace MoBankUI
{
    internal class Mopay_TPS : driverdefining
    {
        //Testing the Payment page. 
        // Two Payment methods do the same 
        private GeneralLibrary generalLibrary;
        private Screenshot screenshot = new Screenshot();
        [Test]
        public void Mopay(IWebDriver driver, datarow datarow)
        {
            string title1 = driver.Title;
            try
            {
                // payment selector id="Pagecontent_ddlPaymentOption"
                if (IsElementPresent(driver,By.Id("Pagecontent_TextBoxCardNumber")))
                {
                    if (IsElementPresent(driver,By.Id("Pagecontent_ddlPaymentOption")))
                    {
                         IWebElement elem = driver.FindElement(By.Id("Pagecontent_ddlPaymentOption"));
                         IList<IWebElement>  paymentoptions = elem.FindElements(By.TagName("option"));
                       
                        string values = null;
                        foreach (IWebElement payment in paymentoptions)
                        {
                            values = values + "\r\n" + payment;
                            new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlPaymentOption"))).SelectByText(
                                payment.Text);
                        }
                        datarow.newrow("Payment Options", "", values, "PASS",driver);
                    }
                   
                    else if (IsElementPresent(driver, By.Id("Pagecontent_ddlCardType")))
                    {
                         IWebElement elem = driver.FindElement(By.Id("Pagecontent_ddlCardType"));
                         IList<IWebElement> paymentoptions  = elem.FindElements(By.TagName("option"));
                        string values = null;
                        foreach (IWebElement payment in paymentoptions)
                        {
                            values = values + "\r\n" + payment;
                            new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlCardType"))).SelectByText(payment.Text);
                        }
                        datarow.newrow("Payment Options", "", values, "PASS",driver);
                    }
                    // payment card number = id="Pagecontent_TextBoxCardNumber"
                    if (IsElementPresent(driver,By.Id("Pagecontent_TextBoxCardNumber")))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxCardNumber")).SendKeys("4111111111111111");
                        datarow.newrow("Card Number", "", "4111111111111111", "PASS",driver);
                    }

                    // Expiry Month id="Pagecontent_ddlExpiryMonth"
                       IWebElement elems = driver.FindElement(By.Id("Pagecontent_ddlExpiryMonth"));
                         IList<IWebElement> Month  = elems.FindElements(By.TagName("option"));
                  
                    string valus = null;
                    foreach (IWebElement expirymonth in Month)
                    {
                        valus = valus + "\r\n" + expirymonth;
                        new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlExpiryMonth"))).SelectByText(
                            expirymonth.Text);
                    }
                    datarow.newrow("Payment Options", "", valus, "PASS",driver);

                    // Expiry Date  id="Pagecontent_ddlExpiryYear"
                
                         IWebElement  Date = driver.FindElement(By.Id("Pagecontent_ddlExpiryMonth"));
                         IList<IWebElement>  Dates = Date.FindElements(By.TagName("option"));
                
                    string vlus = null;
                    foreach (IWebElement expirydate in Dates)
                    {
                        vlus = valus + "\r\n" + expirydate;
                        new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlExpiryYear"))).SelectByText(
                            expirydate.Text);
                    }
                    datarow.newrow("Payment Options", "", vlus, "PASS",driver);
                    // Name id="Pagecontent_TextBoxCardOwner"
                    if (IsElementPresent(driver,By.Id("Pagecontent_TextBoxCardOwner")))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxCardOwner")).SendKeys("Test Name");
                        datarow.newrow("Card Name", "", "Test Name", "PASS",driver);
                    }
                    // 3 Digits id="Pagecontent_TextBoxCVV_Number" 
                    if (IsElementPresent(driver,By.Id("Pagecontent_TextBoxCVV_Number")))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxCVV_Number")).SendKeys("123");
                        datarow.newrow("CVV Number", "", "123", "PASS",driver);
                    }
                    // Address 1 id="Pagecontent_TextBoxAddress1"
                    if (IsElementPresent(driver,By.Id("Pagecontent_TextBoxAddress1")))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxAddress1")).SendKeys("Test Address1");
                        datarow.newrow("Address 1", "", "Test Address1", "PASS",driver);
                    }
                    // Text box Address 2 id="Pagecontent_TextBoxAddress2" 
                    if (IsElementPresent(driver,By.Id("Pagecontent_TextBoxAddress2")))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxAddress2")).SendKeys("Test Address2");
                        datarow.newrow("Test Address 2", "", "Test Address2", "PASS",driver);
                    }
                    // Address 3 id="Pagecontent_TextBoxAddress3"
                    if (IsElementPresent(driver,By.Id("Pagecontent_TextBoxAddress3")))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxAddress3")).SendKeys("Test Address3");
                        datarow.newrow("Test Address 3", "", "Test Address 2", "PASS",driver);
                    }
                    //Test City id="Pagecontent_TextBoxCity"
                    if (IsElementPresent(driver,By.Id("Pagecontent_TextBoxCity")))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxCity")).SendKeys("Test City");
                        datarow.newrow("Test City", "", "Test City", "PASS",driver);
                    }
                    //Test State id="Pagecontent_TextBoxState"
                    if (IsElementPresent(driver,By.Id("Pagecontent_TextBoxState")))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxState")).SendKeys("Test State");
                        datarow.newrow("Test State", "", "Test State", "PASS",driver);
                    }
                    //Test PostCode id="Pagecontent_TextBoxPostalCode"
                    if (IsElementPresent(driver,By.Id("Pagecontent_TextBoxPostalCode")))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxPostalCode")).SendKeys("Test Postcode");
                        datarow.newrow("Test Postcode", "", "Test Postcode", "PASS",driver);
                    }
                    //Test Country id="Pagecontent_ddlCountry"
                    if (IsElementPresent(driver,By.Id("Pagecontent_ddlCountry")))
                    {
                         IWebElement con = driver.FindElement(By.Id("Pagecontent_ddlCountry"));
                         IList<IWebElement> contry = con.FindElements(By.TagName("option"));
                       
                        string vaus = null;
                        foreach (IWebElement country in contry)
                        {
                            vaus = vaus + "\r\n" + country;
                            new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlCountry"))).SelectByText(country.Text);
                        }
                        datarow.newrow("Countries", "", vaus, "PASS",driver);
                    }
                }

                else if (IsElementPresent(driver,By.Id("Card_Number")) || title1 == "Index")
                {
                    MoPayTPS(driver, datarow);
                }
                else
                {
                    string url = driver.Title;
                    if (url == "Secure Payment Page")
                    {
                        datarow.newrow("Mopay Method Not covered in Framework", "Expected", url, "FAIL", driver
                                       );
                    }
                    else
                    {
                        datarow.newrow("MoPay Page Validation", "Not Expected",
                                       url + "-" + "User Could Not Reach Mopay Page", "FAIL",driver);
                    }
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL",driver);
            }
        }
         [Test]
        public void MoPayTPS(IWebDriver driver, datarow datarow)
        {
            generalLibrary = new GeneralLibrary();
            DataSet dss = generalLibrary.GetExcelData(@"C:\\Input Data\CardDetails.xls", "CardDetails");

            DataTable personaldata = dss.Tables[0];
            var screenshot = new Screenshot();
            try
            {
                string totalamount = driver.FindElement(By.XPath("//div[@id='total-amount']/dl/dd")).Text;
                if (totalamount.Contains("₹"))
                {
                    datarow.newrow("Currency Validation", "₹", totalamount, "PASS",driver);
                }
                else
                {
                    datarow.newrow("Currency Validation", "₹", totalamount, "FAIL",driver);
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL",driver);
            }
            int j = 0;
            int n = personaldata.Rows.Count;

            for (int icount = 0; icount < n; icount++)
            {
                try
                {
                    #region Read Excel

                    string FirstName = personaldata.Rows[icount]["FirstName"].ToString();
                    string LastName = personaldata.Rows[icount]["LastName"].ToString();
                    string CardNumber = personaldata.Rows[icount]["Card Number"].ToString();
                    string SecurityCode = personaldata.Rows[icount]["Security Code"].ToString();
                    string CardType = personaldata.Rows[icount]["CardType"].ToString();
                    string NameonCard = personaldata.Rows[icount]["Name on Card"].ToString();
                    string Expirymonth = personaldata.Rows[icount]["ExpiryMonth"].ToString();
                    string Expiryyear = personaldata.Rows[icount]["Expiry Year"].ToString();
                    string Email = personaldata.Rows[icount]["E-mail"].ToString();
                    string PhoneNumber = personaldata.Rows[icount]["Phone Number"].ToString();
                    string Address = personaldata.Rows[icount]["Address"].ToString();
                    string City = personaldata.Rows[icount]["City"].ToString();
                    string PostCode = personaldata.Rows[icount]["Post Code"].ToString();
                    string County = personaldata.Rows[icount]["County"].ToString();
                    string Country = personaldata.Rows[icount]["Country"].ToString();

                    #endregion
                    Selectanoption(driver, By.Id("Card_Type"),CardType);
                   // new SelectElement(driver.FindElement(By.Id("Card_Type"))).SelectByText(CardType);
                    driver.FindElement(By.Id("Card_Number")).Clear();
                    driver.FindElement(By.Id("Card_Number")).SendKeys(CardNumber);
                    driver.FindElement(By.Id("Card_SecurityCode")).Clear();
                    driver.FindElement(By.Id("Card_SecurityCode")).SendKeys(SecurityCode);
                    driver.FindElement(By.Id("Card_Name")).Clear();
                    driver.FindElement(By.Id("Card_Name")).SendKeys(NameonCard);
                    Selectanoption(driver, By.Id("Card_ExpiryDate_Month"), Expirymonth);
                    // new SelectElement(driver.FindElement(By.Id("Card_ExpiryDate_Month"))).SelectByText(Expirymonth);
                    Selectanoption(driver, By.Id("Card_ExpiryDate_Year"),Expiryyear);
                    new SelectElement(driver.FindElement(By.Id("Card_ExpiryDate_Year"))).SelectByText(Expiryyear);

                    if (j < 1)
                    {
                        driver.FindElement(By.Id("change-address")).Click();
                        waitforpagetoload(driver,30000);
                        j++;
                    }
                    driver.FindElement(By.Id("BillingContact_FirstName")).Clear();
                    driver.FindElement(By.Id("BillingContact_FirstName")).SendKeys(FirstName);
                    driver.FindElement(By.Id("BillingContact_LastName")).Clear();
                    driver.FindElement(By.Id("BillingContact_LastName")).SendKeys(LastName);
                    driver.FindElement(By.Id("BillingContact_Email")).Clear();
                    driver.FindElement(By.Id("BillingContact_Email")).SendKeys(Email);
                    driver.FindElement(By.Id("BillingContact_Phone_Number")).Clear();
                    driver.FindElement(By.Id("BillingContact_Phone_Number")).SendKeys(PhoneNumber);
                    driver.FindElement(By.Id("BillingContact_Address_Line1")).Clear();
                    driver.FindElement(By.Id("BillingContact_Address_Line1")).SendKeys(Address);
                    driver.FindElement(By.Id("BillingContact_Address_Line2")).Clear();
                    driver.FindElement(By.Id("BillingContact_Address_Line2")).SendKeys("Address2");
                    driver.FindElement(By.Id("BillingContact_Address_Postcode")).Clear();
                    driver.FindElement(By.Id("BillingContact_Address_Postcode")).SendKeys(PostCode);
                    driver.FindElement(By.Id("BillingContact_Address_Town")).Clear();
                    driver.FindElement(By.Id("BillingContact_Address_Town")).SendKeys(City);
                    driver.FindElement(By.Id("BillingContact_Address_County")).Clear();
                    driver.FindElement(By.Id("BillingContact_Address_County")).SendKeys(County);
                    if (Country.Length == 0)
                    {
                         IWebElement con = driver.FindElement(By.Id("BillingContact_Address_Country"));
                         IList<IWebElement> contry = con.FindElements(By.TagName("option"));
                    
                        foreach (IWebElement cou in contry )
                        {
                            new SelectElement(driver.FindElement(By.Id("BillingContact_Address_Country"))).SelectByText(
                                cou.Text);
                            if (cou.Text == "")
                            {
                                break;
                            }
                        }
                    }

                    if (Country.Length > 0)

                    {
                          IWebElement con = driver.FindElement(By.Id("BillingContact_Address_Country"));
                         IList<IWebElement> countries = con.FindElements(By.TagName("option"));
                    
                    
                        foreach (IWebElement country in countries)
                        {
                            new SelectElement(driver.FindElement(By.Id("BillingContact_Address_Country"))).SelectByText(
                                country.Text);
                            if (country.Text == "United Kingdom")
                            {
                                break;
                            }
                        }
                    }
                    driver.FindElement(By.Name("PostAction[Complete]")).Click();
                    waitforpagetoload(driver,30000);
                    Thread.Sleep(3000);

                    #region Validation

                    if (Regex.IsMatch(CardNumber, "^[0-9'']"))
                    {
                        datarow.newrow("Card Number", CardNumber, CardNumber, "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("Number required") ||  driver.PageSource.Contains("Number invalid"))
                    {
                        datarow.newrow("Card Number", CardNumber, "Number Invalid", "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Card Number", CardNumber, "No Error Message Displayed", "FAIL",driver);
                        screenshot.screenshotfailed(driver);
                    }


                    if (CardType.Length == 0)
                    {
                        if ( driver.PageSource.Contains("Type required"))
                        {
                            datarow.newrow("Card Type", CardType, "Type Required", "PASS",driver);
                        }
                        else
                        {
                            datarow.newrow("Card Type", CardType, CardType, "FAIL",driver);

                            screenshot.screenshotfailed(driver);
                        }
                    }

                    else
                    {
                        datarow.newrow("Card Type", "Visa Debit", "Visa Debit", "PASS",driver);
                    }


                    var reg = new Regex("^[0-9]{3}$");
                    if (reg.IsMatch(SecurityCode))
                    {
                        datarow.newrow("Security Code", SecurityCode, "Valid 3 Digits", "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("Security code required") ||
                              driver.PageSource.Contains("Security code invalid"))
                    {
                        datarow.newrow("Security Code", SecurityCode, "Security code required", "PASS", driver
                                       );
                    }
                    else
                    {
                        datarow.newrow("Security Code", SecurityCode, "No Error Message Displayed", "FAIL", driver
                                       );

                        screenshot.screenshotfailed(driver);
                    }

                    if (Regex.IsMatch(NameonCard, "^[a-zA-Z'']"))
                    {
                        datarow.newrow("Name on Card", NameonCard, NameonCard, "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("Name required"))
                    {
                        datarow.newrow("Name on Card", NameonCard, "Name Required", "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Name on Card", NameonCard, "No Error Message Displayed", "PASS", driver
                                       );

                        screenshot.screenshotfailed(driver);
                    }
                    if (Regex.IsMatch(FirstName, "^[a-zA-Z'']"))
                    {
                        datarow.newrow("First Name", FirstName, FirstName, "PASS",driver);
                    }

                    else if ( driver.PageSource.Contains("The First Name field is required."))
                    {
                        datarow.newrow("First Name", FirstName, "The First Name field is required.", "PASS", driver
                                       );
                    }
                    else
                    {
                        datarow.newrow("First Name", FirstName, "No Error Message Displayed", "FAIL",driver);

                        screenshot.screenshotfailed(driver);
                    }

                    if (Regex.IsMatch(LastName, "^[a-zA-Z'']"))
                    {
                        datarow.newrow("Last Name", LastName, LastName, "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("The Last Name field is required."))
                    {
                        datarow.newrow("Last Name", LastName, "The Last Name field is required.", "PASS", driver
                                       );
                    }
                    else
                    {
                        datarow.newrow("Last Name", LastName, "No Error message Displayed", "FAIL",driver);

                        screenshot.screenshotfailed(driver);
                    }

                    if (Regex.IsMatch(Address, "^[a-zA-Z0-9'']"))
                    {
                        datarow.newrow("Address", Address, Address, "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("The Address field is required"))
                    {
                        datarow.newrow("Address", Address, "The Address field is required", "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Address", Address, "No Error message Displayed", "FAIL",driver);

                        screenshot.screenshotfailed(driver);
                    }

                    if (Regex.IsMatch(PostCode, "^[a-zA-Z0-9'']"))
                    {
                        datarow.newrow("Post Code", PostCode, PostCode, "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("The Postcode field is required"))
                    {
                        datarow.newrow("Post Code", PostCode, "The Postcode field is required.", "PASS", driver
                                       );
                    }
                    else
                    {
                        datarow.newrow("Post Code", PostCode, "No Error Message Displayed", "FAIL",driver);

                        screenshot.screenshotfailed(driver);
                    }

                    if (Regex.IsMatch(Country, "^[a-zA-Z'']"))
                    {
                        datarow.newrow("Country", Country, Country, "PASS",driver);
                    }
                    else if ( driver.PageSource.Contains("The Country field is required."))
                    {
                        datarow.newrow("Country", Country, "The Country field is required.", "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Country", Country, "No Error Message", "FAIL",driver);
                        screenshot.screenshotfailed(driver);
                    }

                    #endregion

                    string title = driver.Title;
                    if (title == "Secure Payment Page")
                    {
                    }

                    string url = driver.Url;
                    string title1 = driver.Title;
                    if (url.Contains("State=Accepted") || title1.Contains("Payment Accepted"))
                    {
                        datarow.newrow("Transaction", url, "State=Accepted", "PASS",driver);
                        break;
                    }

                    if (url.Contains("State=NotAccepted"))
                    {
                        datarow.newrow("Transaction", url, "Transaction Declined", "FAIL",driver);
                        break;
                    }

                    if ( driver.PageSource.Contains("Checkout Declined") ||  driver.PageSource.Contains("Error") ||
                         driver.PageSource.Contains("Not Found"))
                    {
                        datarow.newrow("Checkout", "Checkout Declined", "Checkout Declined", "PASS",driver);
                        break;
                    }
                }

                catch (Exception e)
                {
                    Console.Write(e);
                    string ex = e.ToString();
                    var scree = new Screenshot();
                    datarow.newrow("Exception", "Exceptio not Expected", ex, "FAIL",driver);
                    scree.screenshotfailed(driver);
                }
            }
        }
    }
}