// Generated by .NET Reflector from C:\Program Files\Default Company Name\Selenium Test Tool\MoBankUI.exe
namespace MoBankUI
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selenium;
    using System;
    using System.Data;
    using System.Text.RegularExpressions;
    using System.Threading;
    
    internal class Mopay_TPS
    {
        private GeneralLibrary generalLibrary;
        private MoBankUI.Screenshot screenshot = new MoBankUI.Screenshot();
        
        public void Mopay(IWebDriver driver, ISelenium selenium, datarow_TPS datarow)
        {
            try
            {
                if (selenium.IsElementPresent("id=Pagecontent_TextBoxCardNumber"))
                {
                    string[] strArray;
                    string str;
                    if (selenium.IsElementPresent("id=Pagecontent_ddlPaymentOption"))
                    {
                        strArray = selenium.GetSelectOptions("id=Pagecontent_ddlPaymentOption");
                        str = null;
                        foreach (string str2 in strArray)
                        {
                            str = str + "\r\n" + str2;
                            new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlPaymentOption"))).SelectByText(str2);
                        }
                        datarow.newrowTPS("Payment Options", "", str, "PASS", driver, selenium);
                    }
                    else if (selenium.IsElementPresent("id=Pagecontent_ddlCardType"))
                    {
                        strArray = selenium.GetSelectOptions("id=Pagecontent_ddlCardType");
                        str = null;
                        foreach (string str2 in strArray)
                        {
                            str = str + "\r\n" + str2;
                            new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlCardType"))).SelectByText(str2);
                        }
                        datarow.newrowTPS("Payment Options", "", str, "PASS", driver, selenium);
                    }
                    if (selenium.IsElementPresent("id=Pagecontent_TextBoxCardNumber"))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxCardNumber")).SendKeys("4111111111111111");
                        datarow.newrowTPS("Card Number", "", "4111111111111111", "PASS", driver, selenium);
                    }
                    string[] selectOptions = selenium.GetSelectOptions("id=Pagecontent_ddlExpiryMonth");
                    string actual = null;
                    foreach (string str4 in selectOptions)
                    {
                        actual = actual + "\r\n" + str4;
                        new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlExpiryMonth"))).SelectByText(str4);
                    }
                    datarow.newrowTPS("Payment Options", "", actual, "PASS", driver, selenium);
                    string[] strArray3 = selenium.GetSelectOptions("id=Pagecontent_ddlExpiryYear");
                    string str5 = null;
                    foreach (string str6 in strArray3)
                    {
                        str5 = actual + "\r\n" + str6;
                        new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlExpiryYear"))).SelectByText(str6);
                    }
                    datarow.newrowTPS("Payment Options", "", str5, "PASS", driver, selenium);
                    if (selenium.IsElementPresent("id=Pagecontent_TextBoxCardOwner"))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxCardOwner")).SendKeys("Test Name");
                        datarow.newrowTPS("Card Name", "", "Test Name", "PASS", driver, selenium);
                    }
                    if (selenium.IsElementPresent("id=Pagecontent_TextBoxCVV_Number"))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxCVV_Number")).SendKeys("123");
                        datarow.newrowTPS("CVV Number", "", "123", "PASS", driver, selenium);
                    }
                    if (selenium.IsElementPresent("id=Pagecontent_TextBoxAddress1"))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxAddress1")).SendKeys("Test Address1");
                        datarow.newrowTPS("Address 1", "", "Test Address1", "PASS", driver, selenium);
                    }
                    if (selenium.IsElementPresent("id=Pagecontent_TextBoxAddress2"))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxAddress2")).SendKeys("Test Address2");
                        datarow.newrowTPS("Test Address 2", "", "Test Address2", "PASS", driver, selenium);
                    }
                    if (selenium.IsElementPresent("id=Pagecontent_TextBoxAddress3"))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxAddress3")).SendKeys("Test Address3");
                        datarow.newrowTPS("Test Address 3", "", "Test Address 2", "PASS", driver, selenium);
                    }
                    if (selenium.IsElementPresent("id=Pagecontent_TextBoxCity"))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxCity")).SendKeys("Test City");
                        datarow.newrowTPS("Test City", "", "Test City", "PASS", driver, selenium);
                    }
                    if (selenium.IsElementPresent("id=Pagecontent_TextBoxState"))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxState")).SendKeys("Test State");
                        datarow.newrowTPS("Test State", "", "Test State", "PASS", driver, selenium);
                    }
                    if (selenium.IsElementPresent("id=Pagecontent_TextBoxPostalCode"))
                    {
                        driver.FindElement(By.Id("Pagecontent_TextBoxPostalCode")).SendKeys("Test Postcode");
                        datarow.newrowTPS("Test Postcode", "", "Test Postcode", "PASS", driver, selenium);
                    }
                    if (selenium.IsElementPresent("id=Pagecontent_ddlCountry"))
                    {
                        string[] strArray4 = selenium.GetSelectOptions("id=Pagecontent_ddlCountry");
                        string str7 = null;
                        foreach (string str8 in strArray4)
                        {
                            str7 = str7 + "\r\n" + str8;
                            new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlCountry"))).SelectByText(str8);
                        }
                        datarow.newrowTPS("Countries", "", str7, "PASS", driver, selenium);
                    }
                }
                else if (selenium.IsElementPresent("id=Card_Number"))
                {
                    this.MoPayTPS(driver, selenium, datarow);
                }
                else
                {
                    string Title = selenium.GetTitle();
                    if (Title == "Secure Payment Page")
                    {
                        datarow.newrowTPS("Mopay Method Not covered in Framework", "Expected", Title, "FAIL", driver, selenium);
                    }
                    else
                    {
                        datarow.newrowTPS("MoPay Page Validation", "Not Expected", Title + "-User Could Not Reach Mopay Page", "FAIL", driver, selenium);
                    }
                }
            }
            catch (Exception exception)
            {
                string str10 = exception.ToString();
                datarow.newrowTPS("Exception", "Exception Not Expected", str10, "FAIL", driver, selenium);
            }
        }
        
        public void MoPayTPS(IWebDriver driver, ISelenium selenium, datarow_TPS datarow)
        {
            this.generalLibrary = new GeneralLibrary();
            DataTable table = this.generalLibrary.GetExcelData(@"C:\Selenium\Input Data\CardDetails.xls", "CardDetails").Tables[0];
            MoBankUI.Screenshot screenshot = new MoBankUI.Screenshot();
            try
            {
                string actual = driver.FindElement(By.XPath("//div[@id='total-amount']/dl/dd")).Text;
                if (actual.Contains("\x00a3"))
                {
                    datarow.newrowTPS("Currency Validation", "\x00a3", actual, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrowTPS("Currency Validation", "\x00a3", actual, "FAIL", driver, selenium);
                }
            }
            catch (Exception exception)
            {
                string str2 = exception.ToString();
                datarow.newrowTPS("Exception", "Exception Not Expected", str2, "FAIL", driver, selenium);
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
                    new SelectElement(driver.FindElement(By.Id("Card_Type"))).SelectByText("Visa");
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
                        selenium.WaitForPageToLoad("30000");
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
                        string[] selectOptions = selenium.GetSelectOptions("id=BillingContact_Address_Country");
                        foreach (string str18 in selectOptions)
                        {
                            new SelectElement(driver.FindElement(By.Id("BillingContact_Address_Country"))).SelectByText(str18);
                            if (str18 == "")
                            {
                                break;
                            }
                        }
                    }
                    if (str17.Length > 0)
                    {
                        string[] strArray2 = selenium.GetSelectOptions("id=BillingContact_Address_Country");
                        foreach (string str19 in strArray2)
                        {
                            new SelectElement(driver.FindElement(By.Id("BillingContact_Address_Country"))).SelectByText(str19);
                            if (str19 == "United Kingdom")
                            {
                                break;
                            }
                        }
                    }
                    driver.FindElement(By.Name("PostAction[Complete]")).Click();
                    selenium.WaitForPageToLoad("30000");
                    Thread.Sleep(0xbb8);
                    if (Regex.IsMatch(str5, "^[0-9'']"))
                    {
                        datarow.newrowTPS("Card Number", str5, str5, "PASS", driver, selenium);
                    }
                    else if (selenium.IsTextPresent("Number required") || selenium.IsTextPresent("Number invalid"))
                    {
                        datarow.newrowTPS("Card Number", str5, "Number Invalid", "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrowTPS("Card Number", str5, "No Error Message Displayed", "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                    if (expected == null)
                    {
                        if (selenium.IsTextPresent("Type required"))
                        {
                            datarow.newrowTPS("Card Type", expected, "Type Required", "PASS", driver, selenium);
                        }
                        else
                        {
                            datarow.newrowTPS("Card Type", expected, expected, "FAIL", driver, selenium);
                            screenshot.screenshotfailed(driver, selenium);
                        }
                    }
                    else
                    {
                        datarow.newrowTPS("Card Type", "VISA", "VISA", "PASS", driver, selenium);
                    }
                    Regex regex = new Regex("^[0-9]{3}$");
                    if (regex.IsMatch(str6))
                    {
                        datarow.newrowTPS("Security Code", str6, "Valid 3 Digits", "PASS", driver, selenium);
                    }
                    else if (selenium.IsTextPresent("Security code required") || selenium.IsTextPresent("Security code invalid"))
                    {
                        datarow.newrowTPS("Security Code", str6, "Security code required", "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrowTPS("Security Code", str6, "No Error Message Displayed", "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                    if (Regex.IsMatch(str8, "^[a-zA-Z'']"))
                    {
                        datarow.newrowTPS("Name on Card", str8, str8, "PASS", driver, selenium);
                    }
                    else if (selenium.IsTextPresent("Name required"))
                    {
                        datarow.newrowTPS("Name on Card", str8, "Name Required", "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrowTPS("Name on Card", str8, "No Error Message Displayed", "PASS", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                    if (Regex.IsMatch(input, "^[a-zA-Z'']"))
                    {
                        datarow.newrowTPS("First Name", input, input, "PASS", driver, selenium);
                    }
                    else if (selenium.IsTextPresent("The First Name field is required."))
                    {
                        datarow.newrowTPS("First Name", input, "The First Name field is required.", "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrowTPS("First Name", input, "No Error Message Displayed", "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                    if (Regex.IsMatch(str4, "^[a-zA-Z'']"))
                    {
                        datarow.newrowTPS("Last Name", str4, str4, "PASS", driver, selenium);
                    }
                    else if (selenium.IsTextPresent("The Last Name field is required."))
                    {
                        datarow.newrowTPS("Last Name", str4, "The Last Name field is required.", "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrowTPS("Last Name", str4, "No Error message Displayed", "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                    if (Regex.IsMatch(str13, "^[a-zA-Z0-9'']"))
                    {
                        datarow.newrowTPS("Address", str13, str13, "PASS", driver, selenium);
                    }
                    else if (selenium.IsTextPresent("The Address field is required"))
                    {
                        datarow.newrowTPS("Address", str13, "The Address field is required", "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrowTPS("Address", str13, "No Error message Displayed", "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                    if (Regex.IsMatch(str15, "^[a-zA-Z0-9'']"))
                    {
                        datarow.newrowTPS("Post Code", str15, str15, "PASS", driver, selenium);
                    }
                    else if (selenium.IsTextPresent("The Postcode field is required"))
                    {
                        datarow.newrowTPS("Post Code", str15, "The Postcode field is required.", "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrowTPS("Post Code", str15, "No Error Message Displayed", "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                    if (Regex.IsMatch(str17, "^[a-zA-Z'']"))
                    {
                        datarow.newrowTPS("Country", str17, str17, "PASS", driver, selenium);
                    }
                    else if (selenium.IsTextPresent("The Country field is required."))
                    {
                        datarow.newrowTPS("Country", str17, "The Country field is required.", "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrowTPS("Country", str17, "No Error Message", "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                    if (selenium.GetTitle() == "Secure Payment Page")
                    {
                    }
                    string location = selenium.GetLocation();
                    string str22 = driver.Title.ToString();
                    if (location.Contains("State=Accepted") || str22.Contains("Payment Accepted"))
                    {
                        datarow.newrowTPS("Transaction", location, "State=Accepted", "PASS", driver, selenium);
                        break;
                    }
                    if (location.Contains("State=NotAccepted"))
                    {
                        datarow.newrowTPS("Transaction", location, "Transaction Declined", "FAIL", driver, selenium);
                        break;
                    }
                    if ((selenium.IsTextPresent("Checkout Declined") || selenium.IsTextPresent("Checkout Error")) || selenium.IsTextPresent("Not Found"))
                    {
                        datarow.newrowTPS("Checkout", "Checkout Declined", "Checkout Declined", "PASS", driver, selenium);
                        break;
                    }
                }
                catch (Exception exception2)
                {
                    Console.Write(exception2);
                    string str23 = exception2.ToString();
                    MoBankUI.Screenshot screenshot2 = new MoBankUI.Screenshot();
                    datarow.newrowTPS("Exception", "Exceptio not Expected", str23, "FAIL", driver, selenium);
                    screenshot2.screenshotfailed(driver, selenium);
                }
            }
        }
    }
}
