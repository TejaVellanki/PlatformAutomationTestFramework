using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MoBankUI.ObjectRepository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MoBankUI.Mosite
{
    internal class UserDataTps : Driverdefining
    {
/*
        private readonly Screenshot screenshot = new Screenshot();
*/

        public void userdata_TPS(IWebDriver driver, Datarow datarow)
        {
            var url = driver.PageSource;

            string field;
            string fieldlabel;
            string fieldinput;
            string fieldcountry;
            string countryvalue;
            string submitbutton;
            string letters;
            string termsncond;
            string submitterms = null;
            string paybutton;


            var screenshot1 = new Screenshot();

            if (url.Contains("user-scalable=yes"))
            {
                field = AddressMapV2.field;
                fieldlabel = AddressMapV2.fieldlabel;
                fieldinput = AddressMapV2.fieldinput;
                fieldcountry = AddressMapV2.fieldcountry;
                countryvalue = AddressMapV2.coutryvalue;
                submitbutton = AddressMapV2.submitbutton;
                letters = AddressMapV2.terms;
                termsncond = CheckoutMapV2.termsncond;
                submitterms = CheckoutMapV2.submitterms;
                paybutton = CheckoutMapV2.paybutton;
            }
            else
            {
                field = AddressMapV1.field;
                fieldlabel = AddressMapV1.fieldlabel;
                fieldinput = AddressMapV1.fieldinput;
                fieldcountry = AddressMapV1.fieldcountry;
                countryvalue = AddressMapV1.coutryvalue;
                submitbutton = AddressMapV1.submitbutton;
                letters = AddressMapV1.sendletters;
                termsncond = CheckoutMapV1.termsncond;
                paybutton = CheckoutMapV1.paybutton;
            }
            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath(submitbutton));

                var count = GetXpathCount(driver, field);
                if (count == 0)
                {
                    datarow.newrow("User Data Form Details", "Expected User Form Fields",
                                   "User Form Fields Doesnot Exist", "FAIL", driver);
                }
                //Populating Customer Details from Excel Sheet
                for (var i = 1; i <= count; i++)
                {
                    if (!IsElementPresent(driver, By.XPath("" + field + "[" + i + "]" + fieldlabel + ""))) continue;
                    var valuet = driver.FindElement(By.XPath("" + field + "[" + i + "]" + fieldlabel + "")).Text;

                    if (!valuet.Contains("Country"))
                    {
                        driver.FindElement(By.XPath("" + field + "[" + i + "]" + fieldinput + "")).Clear();
                        driver.FindElement(By.XPath("" + field + "[" + i + "]" + fieldinput + "")).SendKeys("TEST");
                        datarow.newrow("Form Field", "", valuet, "PASS", driver);
                    }

                    #region Country

                    // selecting the country
                    if (valuet.Contains("Country"))
                    {
                        try
                        {
                            var j = i - 1;
                            var con =
                                driver.FindElement(By.Id("" + fieldcountry + "" + j + "" + countryvalue + ""));
                            IList<IWebElement> countries = con.FindElements(By.TagName("option"));

                            string values = null;
                            foreach (var value in countries.Where(value => !value.Text.Contains("Please") || value.Text != "Select country"))
                            {
                                if (value.Text == "United Kingdom")
                                {
                                    values = values + "\r\n" + value;
                                    new SelectElement(
                                        driver.FindElement(
                                            By.Id("" + fieldcountry + "" + j + "" + countryvalue + "")))
                                        .SelectByText(value.Text);
                                    break;
                                }

                                values = values + "\r\n" + value;
                                // new SelectElement(driver.FindElement(By.Id("" + fieldcountry + "" + j + "" + countryvalue + "")))  new SelectElement(driver.FindElement(By.Id(""))).SelectByText("");ByText(value);

                            }
                            datarow.newrow("Country Field", "", values, "PASS", driver);
                        }
                        catch (Exception ex)
                        {
                            var e = ex.ToString();
                            datarow.newrow("Country Field Exception", "Exception Not Expected", e, "PASS", driver
                                );
                        }
                    }

                    #endregion

                    #region Email

                    if (!valuet.Contains("Email")) continue;
                    try
                    {
                        driver.FindElement(By.XPath("" + field + "[" + i + "]" + fieldinput + "")).Clear();
                        driver.FindElement(By.XPath("" + field + "[" + i + "]" + fieldinput + ""))
                            .SendKeys("test@test.com");
                    }
                    catch (Exception ex)
                    {
                        var e = ex.ToString();
                        datarow.newrow("Email Field Exception", "Exception Not Expected", e, "FAIL", driver
                            );
                        screenshot1.screenshotfailed(driver);
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception in DataForm", "Exception Not Expected", e, "FAIL", driver);
                screenshot1.screenshotfailed(driver);
            }
            try
            {
                //Email/ Letter sending Confirmation
                if (IsElementPresent(driver, By.XPath("" + field + "[" + 11 + "]" + letters + "")))
                {
                    driver.FindElement(By.XPath("" + field + "[" + 11 + "]" + letters + "")).Click();
                }

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath(submitbutton));
                driver.FindElement(By.XPath(submitbutton)).Click();


                var basval = driver.FindElement(By.Id("BasketInfo")).Text;

                // Terms and Conditions
                if (IsElementPresent(driver, By.XPath(termsncond)))
                {
                    driver.FindElement(By.XPath(termsncond)).Click();
                }
                //Submit button
                if (IsElementPresent(driver, By.XPath(submitterms)))
                //*[@id="main-page"]/div[9]/div/div[2]/div/button
                {
                    //html/body/div/div[7]/div/div[2]/div/button
                    driver.FindElement(By.XPath(submitterms)).Click();

                    Thread.Sleep(2000);
                }
                //string details =  driver.FindElement(By.Id("")).Text;("css=div.ui-content.ui-body-c > p");

                //Pay Button 
                if (IsElementPresent(driver, By.XPath(paybutton)))
                {
                    //html/body/div/div[7]/div/div[2]/a/span/span
                    driver.FindElement(By.XPath(paybutton)).Click();
                }
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception in DataForm", "Exception Not Expected", e, "FAIL", driver);
                screenshot1.screenshotfailed(driver);
            }
        }
    }
}