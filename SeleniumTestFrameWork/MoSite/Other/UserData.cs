// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;

namespace MoBankUI
{
    internal class UserData : driverdefining
    {
        public void Userdata(datarow datarow, IWebDriver driver)
        {
            try
            {
                var library = new GeneralLibrary();
                var screenshot = new Screenshot();
                DataTable table = library.GetExcelData(@"C:\\Input Data\Billing Details.xls", "Login").Tables[0];
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                IWebElement element =
                    driver.FindElement(
                        By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/fieldset/div[2]/div/button"));
                string str = driver.PageSource;
                int count = table.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (table.Rows.Count > 0)
                    {
                        string expected = table.Rows[i]["FirstName"].ToString();
                        string str3 = table.Rows[i]["Last Name"].ToString();
                        string str4 = table.Rows[i]["Country"].ToString();
                        string str5 = table.Rows[i]["Address"].ToString();
                        string str6 = table.Rows[i]["City"].ToString();
                        string str7 = table.Rows[i]["County"].ToString();
                        string str8 = table.Rows[i]["PostCode"].ToString();
                        string str9 = table.Rows[i]["Email"].ToString();
                        string str10 = table.Rows[i]["Telephone Number"].ToString();
                        string str11 = table.Rows[i]["Custome Note"].ToString();
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div/input[2]"))
                              .Clear();
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div/input[2]"))
                              .SendKeys(expected.TrimStart(new char[0]));
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[2]/input[2]"))
                              .Clear();
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[2]/input[2]"))
                              .SendKeys(str3);
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[3]/input[2]"))
                              .Clear();
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[3]/input[2]"))
                              .SendKeys(str8);
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[4]/input[2]"))
                              .Clear();
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[4]/input[2]"))
                              .SendKeys(str5);
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[5]/input[2]"))
                              .Clear();
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[5]/input[2]"))
                              .SendKeys(str6);
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[6]/input[2]"))
                              .Clear();
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[6]/input[2]"))
                              .SendKeys(str7);
                        new SelectElement(driver.FindElement(By.Id("FormData_6__Value"))).SelectByText(str4);
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[9]/input[2]"))
                              .Clear();
                        driver.FindElement(
                            By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[9]/input[2]"))
                              .SendKeys(str10);
                        driver.FindElement(By.Id("FormData_9__Value")).Clear();
                        driver.FindElement(By.Id("FormData_9__Value")).SendKeys(str9);
                        var executor = (IJavaScriptExecutor) driver;
                        executor.ExecuteScript("window.scrollBy(0,100)", new object[0]);
                        executor.ExecuteScript("window.scrollBy(0,100)", new object[0]);
                        driver.FindElement(
                            By.XPath(
                                "//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[11]/fieldset/div[2]/div/label/span/span[2]"))
                              .Click();
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                        IWebElement element2 =
                            driver.FindElement(
                                By.XPath(
                                    "//body[@id='page-checkout-process']/div/div[2]/div/form/fieldset/div[2]/div/button"));
                        driver.FindElement(
                            By.XPath(
                                "//body[@id='page-checkout-process']/div/div[2]/div/form/fieldset/div[2]/div/button"))
                              .Click();
                        waitforpagetoload(driver,30000);
                        if (!(driver.Title == "Checkout - Address - QA - The Tickle Company"))
                        {
                            break;
                        }
                        string attribute =
                            driver.FindElement(
                                By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/section/div/input[2]"))
                                  .GetAttribute("value");
                        string input =
                            driver.FindElement(
                                By.XPath(
                                    "//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[2]/input[2]"))
                                  .GetAttribute("value");
                        string str15 =
                            driver.FindElement(
                                By.XPath(
                                    "//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[4]/input[2]"))
                                  .GetAttribute("value");
                        string str16 =
                            driver.FindElement(
                                By.XPath(
                                    "//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[3]/input[2]"))
                                  .GetAttribute("value");
                        string str17 =
                            driver.FindElement(
                                By.XPath(
                                    "//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[5]/input[2]"))
                                  .GetAttribute("value");
                        string str18 =
                            driver.FindElement(
                                By.XPath(
                                    "//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[6]/input[2]"))
                                  .GetAttribute("value");
                        string str19 =
                            driver.FindElement(
                                By.XPath(
                                    "//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[9]/input[2]"))
                                  .GetAttribute("value");
                        string selectedValue = driver.FindElement(By.Id("FormData_6__Value")).GetAttribute("Value");
                        string str21 = driver.FindElement(By.Id("FormData_9__Value")).GetAttribute("Value");
                        if (Regex.IsMatch(attribute, "^[a-zA-Z'']"))
                        {
                            datarow.newrow("FirstName", expected, attribute, "PASS",driver);
                        }
                        else
                        {
                            datarow.newrow("FirstName", "FirstName-Not in Expected Format", attribute, "PASS", driver
                                           );
                        }
                        if (Regex.IsMatch(input, "^[a-zA-Z'']"))
                        {
                            datarow.newrow("Last Name", str3, input, "PASS",driver);
                        }
                        else
                        {
                            datarow.newrow("Last Name", "LastName-Not in Expected Format", input, "PASS", driver
                                           );
                        }
                        if (Regex.IsMatch(str15, "^[a-zA-Z0-9'']"))
                        {
                            datarow.newrow("Address", str5, str15, "PASS",driver);
                        }
                        else
                        {
                            datarow.newrow("Address", "Address-Not in Expected Format", str15, "PASS",driver);
                        }
                        if (Regex.IsMatch(str16, "^[a-zA-Z0-9'']"))
                        {
                            datarow.newrow("Post Code", str8, str16, "PASS",driver);
                        }
                        else
                        {
                            datarow.newrow("Post Code", "PostCode-Not in Expected Format", str16, "PASS", driver
                                           );
                        }
                        if (Regex.IsMatch(str17, "^[a-zA-Z'']"))
                        {
                            datarow.newrow("City/Town", str6, str17, "PASS",driver);
                        }
                        else
                        {
                            datarow.newrow("City/Town", "City-Not in Expected Format", str17, "PASS",driver);
                        }
                        if (Regex.IsMatch(selectedValue, "^[a-zA-Z'']"))
                        {
                            datarow.newrow("Country", str4, selectedValue, "PASS",driver);
                        }
                        else
                        {
                            datarow.newrow("Country", "Country-Not in Expected Format", selectedValue, "PASS", driver
                                           );
                        }
                        if (Regex.IsMatch(str21,
                                          "^(?(\")(\"[^\"]+?\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9]{2,17}))$"))
                        {
                            datarow.newrow("EMAIL", str9, str21, "PASS",driver);
                        }
                        else
                        {
                            datarow.newrow("EMAIL", "Email-Not in Expected Format", str21, "PASS",driver);
                        }
                    }
                }
                if (driver.FindElement(By.Id("BasketInfo")).Text == "(1)")
                {
                    datarow.newrow("Basket Value", "(1)", "(1)", "PASS",driver);
                }
                else
                {
                    datarow.newrow("Basket Value", "(1)", "(1)", "FAIL",driver);
                }
                string str23 = driver.PageSource;
                var executor2 = (IJavaScriptExecutor) driver;
                executor2.ExecuteScript("window.scrollBy(0,100)", new object[0]);
                Thread.Sleep(3000);
                driver.FindElement(By.Id("FormData_2__Value")).Click();
                Thread.Sleep(3000);
                executor2.ExecuteScript("window.scrollBy(0,200)", new object[0]);
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//html/body/div/div[2]/div/form/fieldset/div[2]/div/button")).Click();
                   waitforpagetoload(driver,30000);
                Thread.Sleep(3000);
                string text =  driver.FindElement(By.CssSelector("div.ui-content.ui-body-c > p")).Text;
                if (text == "TestFirstname,TestLastName, 0123456789, Test Address1, TestCity, TestCounty, TestPostcode")
                {
                    datarow.newrow("Details in Process summary page",
                                   "TestFirstname TestLastName, 0123456789, Test Address1, TestCity, TestCounty, TestPostcode",
                                   text, "PASS",driver);
                }
                else
                {
                    datarow.newrow("Details in Process summary page",
                                   "TestFirstname,TestLastName, 0123456789, Test Address1, TestCity, TestCounty, TestPostcode",
                                   text, "FAIL",driver);
                }
                executor2.ExecuteScript("window.scrollBy(0,200)", new object[0]);
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//html/body/div/div[2]/div[2]/div[2]/a/span/span")).Click();
                waitforpagetoload(driver,30000);
            }
            catch (Exception exception)
            {
                string actual = exception.ToString();
                datarow.newrow("Exception", "Not Expected", actual, "FAIL",driver);
            }
        }
    }
}