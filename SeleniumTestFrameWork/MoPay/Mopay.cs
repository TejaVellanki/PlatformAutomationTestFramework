// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;

namespace MoBankUI
{
    public class Mopay : Driverdefining
    {
        private readonly Datarow _datarow = new Datarow();
        private GeneralLibrary _generalLibrary;


        public void Dsecure(IWebDriver driver)
        {
            IWebElement frameElement = driver.FindElement(By.TagName("iframe"));
            driver.SwitchTo().Frame(frameElement);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            Thread.Sleep(0x1388);
            Thread.Sleep(0x1f40);
            string location = driver.Url;
            if (location.Contains("3DSecureState=Success"))
            {
                _datarow.newrow("3D secure", location, "3DSecureState=Success", "PASS", driver);
                if (IsElementPresent(driver, By.LinkText("start again")))
                {
                    driver.FindElement(By.LinkText("start again")).Click();
                }
                else
                {
                    driver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
                }
            }
            else
            {
                _datarow.newrow("3D secure", location, "3D secure Declined", "FAIL", driver);
                if (IsElementPresent(driver, By.LinkText("start again")))
                {
                    driver.FindElement(By.LinkText("start again")).Click();
                }
                else
                {
                    driver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
                }
            }
        }

        public void MoPay(IWebDriver driver)
        {
            _generalLibrary = new GeneralLibrary();
            DataSet excelData = _generalLibrary.GetExcelData(@"C:\\Input Data\CardDetails.xls", "CardDetails");
            DataSet set2 = _generalLibrary.GetExcelData(@"C:\\Input Data\CardDetails.xls", "Account");
            _datarow.col();
            DataTable table = excelData.Tables[0];
            DataTable table2 = set2.Tables[0];
            try
            {
                string actual = driver.FindElement(By.XPath("//div[@id='total-amount']/dl/dd")).Text;
                _datarow.newrow("Currency Validation", "\x00a3", actual, actual.Contains("\x00a3") ? "PASS" : "FAIL",
                    driver);
            }
            catch (Exception exception)
            {
                string str2 = exception.ToString();
                _datarow.newrow("Exception", "Exception Not Expected", str2, "FAIL", driver);
            }
            int count = table2.Rows.Count;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    string str3 = table2.Rows[i]["Account"].ToString();
                    string locator = table2.Rows[i]["Type"].ToString();
                    string str5 = table2.Rows[i]["E-mail"].ToString();
                    string str6 = table2.Rows[i]["FormData"].ToString();
                    string str7 = table2.Rows[i]["FormValue"].ToString();
                    string str8 = table2.Rows[i]["CookieData"].ToString();
                    string str9 = table2.Rows[i]["CookieValue"].ToString();
                    driver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15.0));
                    IWebElement element = driver.FindElement(By.XPath("//div[@id='ReferenceControl']/div/input"));
                    if (i <= 1)
                    {
                        driver.FindElement(By.Id("Account_13")).Click();
                    }
                    else
                    {
                        driver.FindElement(By.Id("id=Account_14")).Click();
                    }
                    driver.FindElement(By.Id(locator)).Click();
                    string attribute =
                        driver.FindElement(By.XPath("//div[@id='ReferenceControl']/div/input"))
                              .GetAttribute("Reference");
                    string str11 =
                        driver.FindElement(By.XPath("//div[@id='TotalAmountControl']/div/input")).GetAttribute("Amt");
                    string str12 =
                        driver.FindElement(By.XPath("//div[@id='CurrencyCodeControl']/div/select")).GetAttribute("Cur");
                    string input = table.Rows[0]["FirstName"].ToString();
                    string str14 = table.Rows[0]["LastName"].ToString();
                    Assert.AreEqual("The MoShop Sale",
                                    driver.FindElement(By.XPath("//div[@id='DescriptionControl']/div/textarea")).Text);
                    var screenshot = new Screenshot();
                    driver.FindElement(By.XPath("//div[@id='FirstNameControl']/div/input")).Clear();
                    driver.FindElement(By.XPath("//div[@id='FirstNameControl']/div/input")).SendKeys(input);
                    driver.FindElement(By.XPath("//div[@id='LastNameControl']/div/input")).Clear();
                    driver.FindElement(By.XPath("//div[@id='LastNameControl']/div/input")).SendKeys(str14);
                    driver.FindElement(By.XPath("//div[@id='EmailControl']/div/input")).Clear();
                    driver.FindElement(By.XPath("//div[@id='EmailControl']/div/input")).SendKeys(str5);
                    driver.FindElement(By.CssSelector("button")).Click();
                    driver.FindElement(By.Name("FormData[1].Key")).SendKeys(str6);
                    driver.FindElement(By.Name("FormData[1].Value")).SendKeys(str7);
                    driver.FindElement(By.CssSelector("#CookieData > button")).Click();
                    driver.FindElement(By.Name("CookieData[1].Key")).SendKeys(str8);
                    driver.FindElement(By.Name("CookieData[1].Value")).SendKeys(str9);
                    driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
                    _datarow.newrow("Account", "Type", locator, "PASS", driver);

                    int num3 = table.Columns.Count;
                    for (int j = 0; j < num3; j++)
                    {
                        string str15 = table.Rows[j]["Card Number"].ToString();
                        string str16 = table.Rows[j]["Security Code"].ToString();
                        string expected = table.Rows[j]["CardType"].ToString();
                        string str18 = table.Rows[j]["Name on Card"].ToString();
                        string optionLocator = table.Rows[j]["ExpiryMonth"].ToString();
                        string str20 = table.Rows[j]["Expiry Year"].ToString();
                        string str21 = table.Rows[j]["Phone Number"].ToString();
                        string str22 = table.Rows[j]["Address"].ToString();
                        string str23 = table.Rows[j]["City"].ToString();
                        string str24 = table.Rows[j]["Post Code"].ToString();
                        string str25 = table.Rows[j]["County"].ToString();
                        string str26 = table.Rows[j]["Country"].ToString();
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60.0));
                        IWebElement element2 = driver.FindElement(By.XPath("//div[@id='Card.NameControl']/input"));
                        Assert.AreEqual("Secure Payment Page", driver.Title);

                        driver.FindElement(By.XPath("//*[@id='Card_Number']")).SendKeys(str15);
                        driver.FindElement(By.XPath("//*[@id='Card_SecurityCode']")).SendKeys(str16);
                        new SelectElement(driver.FindElement(By.Id("Card_Type"))).SelectByText("Visa Debit");
                        new SelectElement(driver.FindElement(By.Id("Card_ExpiryDate_Month"))).SelectByText(optionLocator);
                        new SelectElement(driver.FindElement(By.Id("Card_ExpiryDate_Year"))).SelectByText(str20);

                        driver.FindElement(By.XPath("//div[@id='Card.NameControl']/input")).SendKeys(str18);
                        if (IsElementPresent(driver, By.Id("change-address")))
                        {
                            driver.FindElement(By.Id("change-address")).Click();
                        }
                        switch (locator)
                        {
                            case "id=actionPay":

                                driver.FindElement(By.Id("BillingContact_Phone_Number")).Clear();
                                driver.FindElement(By.Id("BillingContact_Phone_Number")).SendKeys(str21);
                                driver.FindElement(By.Id("BillingContact_Address_Line1")).Clear();
                                driver.FindElement(By.Id("BillingContact_Address_Line1")).SendKeys(str22);
                                driver.FindElement(By.XPath("//div[@id='BillingContact.Address.Line2Control']/input"))
                                      .SendKeys("Test Address2");
                                driver.FindElement(By.Id("BillingContact_Address_Postcode")).Clear();
                                driver.FindElement(By.Id("BillingContact_Address_Postcode")).SendKeys(str24);
                                driver.FindElement(By.XPath("//div[@id='BillingContact.Address.TownControl']/input"))
                                      .Clear();
                                driver.FindElement(By.XPath("//div[@id='BillingContact.Address.TownControl']/input"))
                                      .SendKeys(str23);
                                driver.FindElement(By.Id("BillingContact_Address_County")).Clear();
                                driver.FindElement(By.Id("BillingContact_Address_County")).SendKeys(str25);
                                new SelectElement(
                                    driver.FindElement(
                                        By.XPath("//div[@id='BillingContact.Address.CountryControl']/div/div/select")))
                                    .SelectByText(str26);

                                break;

                            case "id=actionToken":
                                driver.FindElement(By.Id("Contact_Phone_Number")).Clear();
                                driver.FindElement(By.Id("Contact_Phone_Number")).SendKeys(str21);
                                driver.FindElement(By.Id("Contact_Address_Line1")).Clear();
                                driver.FindElement(By.Id("Contact_Address_Line1")).SendKeys(str22);
                                driver.FindElement(By.XPath("//div[@id='Contact.Address.Line2Control']/input"))
                                      .SendKeys("Addres2");
                                driver.FindElement(By.Id("Contact_Address_Postcode")).Clear();
                                driver.FindElement(By.Id("Contact_Address_Postcode")).SendKeys(str24);
                                driver.FindElement(By.XPath("//div[@id='Contact.Address.TownControl']/input")).Clear();
                                driver.FindElement(By.XPath("//div[@id='Contact.Address.TownControl']/input"))
                                      .SendKeys(str23);
                                driver.FindElement(By.XPath("Contact_Address_County")).Clear();
                                driver.FindElement(By.Id("Contact_Address_County")).SendKeys(str25);
                                new SelectElement(
                                    driver.FindElement(
                                        By.XPath("//div[@id='Contact.Address.CountryControl']/div/div/select")))
                                    .SelectByText(str26);
                                break;
                        }
                        driver.FindElement(By.Name("PostAction[Complete]")).Click();

                        Thread.Sleep(3000);
                        if (Regex.IsMatch(str15, "^[0-9'']"))
                        {
                            _datarow.newrow("Card Number", str15, str15, "PASS", driver);
                        }
                        else if (driver.PageSource.Contains("Number required") ||
                                 driver.PageSource.Contains("Number invalid"))
                        {
                            _datarow.newrow("Card Number", str15, "Number Invalid", "PASS", driver);
                        }
                        else
                        {
                            _datarow.newrow("Card Number", str15, "No Error Message Displayed", "FAIL", driver);
                            screenshot.screenshotfailed(driver);
                        }
                        if (expected == null)
                        {
                            if (driver.PageSource.Contains("Type required"))
                            {
                                _datarow.newrow("Card Type", expected, "Type Required", "PASS", driver);
                            }
                            else
                            {
                                _datarow.newrow("Card Type", expected, expected, "FAIL", driver);
                                screenshot.screenshotfailed(driver);
                            }
                        }
                        else
                        {
                            _datarow.newrow("Card Type", expected, expected, "PASS", driver);
                        }
                        var regex = new Regex("^[0-9]{3}$");
                        if (regex.IsMatch(str16))
                        {
                            _datarow.newrow("Security Code", str16, "Valid 3 Digits", "PASS", driver);
                        }
                        else if (driver.PageSource.Contains("Security code required") ||
                                 driver.PageSource.Contains("Security code invalid"))
                        {
                            _datarow.newrow("Security Code", str16, "Security code required", "PASS", driver
                                );
                        }
                        else
                        {
                            _datarow.newrow("Security Code", str16, "No Error Message Displayed", "FAIL", driver
                                );
                            screenshot.screenshotfailed(driver);
                        }
                        if (Regex.IsMatch(str18, "^[a-zA-Z'']"))
                        {
                            _datarow.newrow("Name on Card", str18, str18, "PASS", driver);
                        }
                        else if (driver.PageSource.Contains("Name required"))
                        {
                            _datarow.newrow("Name on Card", str18, "Name Required", "PASS", driver);
                        }
                        else
                        {
                            _datarow.newrow("Name on Card", str18, "No Error Message Displayed", "PASS", driver);
                            screenshot.screenshotfailed(driver);
                        }
                        if (Regex.IsMatch(input, "^[a-zA-Z'']"))
                        {
                            _datarow.newrow("First Name", input, input, "PASS", driver);
                        }
                        else if (driver.PageSource.Contains("The First Name field is required."))
                        {
                            _datarow.newrow("First Name", input, "The First Name field is required.", "PASS", driver
                                );
                        }
                        else
                        {
                            _datarow.newrow("First Name", input, "No Error Message Displayed", "FAIL", driver);
                            screenshot.screenshotfailed(driver);
                        }
                        if (Regex.IsMatch(str14, "^[a-zA-Z'']"))
                        {
                            _datarow.newrow("Last Name", str14, str14, "PASS", driver);
                        }
                        else if (driver.PageSource.Contains("The Last Name field is required."))
                        {
                            _datarow.newrow("Last Name", str14, "The Last Name field is required.", "PASS", driver
                                );
                        }
                        else
                        {
                            _datarow.newrow("Last Name", str14, "No Error message Displayed", "FAIL", driver);
                            screenshot.screenshotfailed(driver);
                        }
                        if (Regex.IsMatch(str22, "^[a-zA-Z0-9'']"))
                        {
                            _datarow.newrow("Address", str22, str22, "PASS", driver);
                        }
                        else if (driver.PageSource.Contains("The Address field is required"))
                        {
                            _datarow.newrow("Address", str22, "The Address field is required", "PASS", driver);
                        }
                        else
                        {
                            _datarow.newrow("Address", str22, "No Error message Displayed", "FAIL", driver);
                            screenshot.screenshotfailed(driver);
                        }
                        if (Regex.IsMatch(str24, "^[a-zA-Z0-9'']"))
                        {
                            _datarow.newrow("Post Code", str24, str24, "PASS", driver);
                        }
                        else if (driver.PageSource.Contains("The Postcode field is required"))
                        {
                            _datarow.newrow("Post Code", str24, "The Postcode field is required.", "PASS", driver
                                );
                        }
                        else
                        {
                            _datarow.newrow("Post Code", str24, "No Error Message Displayed", "FAIL", driver);
                            screenshot.screenshotfailed(driver);
                        }
                        if (Regex.IsMatch(str26, "^[a-zA-Z'']"))
                        {
                            _datarow.newrow("Country", str26, str26, "PASS", driver);
                        }
                        else if (driver.PageSource.Contains("The Country field is required."))
                        {
                            _datarow.newrow("Country", str26, "The Country field is required.", "PASS", driver);
                        }
                        else
                        {
                            _datarow.newrow("Country", str26, "No Error Message", "FAIL", driver);
                            screenshot.screenshotfailed(driver);
                        }

                        string Title = driver.Title;
                        if (Title != "Secure Payment Page")
                        {
                            if (Title == "Redirect to External")
                            {
                                Dsecure(driver);
                                break;
                            }
                            if (driver.PageSource.Contains("Checkout Accepted"))
                            {
                                Normaltransaction(driver);
                                break;
                            }
                            if (driver.PageSource.Contains("Checkout Declined") ||
                                driver.PageSource.Contains("Checkout Error"))
                            {
                                _datarow.newrow("Checkout", "Checkout Declined", "Checkout Declined", "PASS", driver
                                    );
                                if (IsElementPresent(driver, By.LinkText("start again")))
                                {
                                    driver.FindElement(By.LinkText("start again")).Click();
                                }
                                else
                                {
                                    driver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
                                }
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception exception2)
            {
                Console.Write(exception2);
                string str28 = exception2.ToString();
                var screenshot2 = new Screenshot();
                _datarow.newrow("Checkout", "Server Error", str28, "FAIL", driver);
                screenshot2.screenshotfailed(driver);
            }
            finally
            {
                string emails = null;
                new Screenshot().Screenshotnotifications(driver);
                _datarow.excelsave("MoPayReport", driver, "teja.vellanki@mobankgroup.com");
                new GenerateEmail().SendEMail("MoPayReport", emails);
                driver.Quit();
            }
        }

        public void Normaltransaction(IWebDriver driver)
        {
            string location = driver.Url;
            if (location.Contains("State=Accepted"))
            {
                _datarow.newrow("Transaction", location, "State=Accepted", "PASS", driver);
                if (IsElementPresent(driver, By.LinkText("start again")))
                {
                    driver.FindElement(By.LinkText("start again")).Click();
                }
                else
                {
                    driver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
                }
            }
            else
            {
                _datarow.newrow("Transaction", location, "Transaction Declined", "FAIL", driver);
                if (IsElementPresent(driver, By.LinkText("start again")))
                {
                    driver.FindElement(By.LinkText("start again")).Click();
                }
                else
                {
                    driver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
                }
            }
        }
    }
}