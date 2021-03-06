// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MoBankUI.MoPay
{
    internal class Paymentprovidertypes : Driverdefining
    {
        private readonly Screenshot _screenshot = new Screenshot();
        private GeneralLibrary _genaralLibrary;

        public void Paymenttypes(IWebDriver driver, Datarow datarow)
        {
            _genaralLibrary = new GeneralLibrary();
            var table =
                _genaralLibrary.GetExcelData(@"C:\\Input Data\CardDetails.xls", "AccountCreation").Tables[0];
            var count = table.Rows.Count;
            for (var i = 0; i < count; i++)
            {
                string attribute;
                string str6;
                string str8;
                string str9;
                string str10;
                string str11;
                decimal xpathCount;
                int num4;
                var str = table.Rows[i]["Provider"].ToString();
                var str2 = table.Rows[0]["ProviderIdentifier"].ToString();
                var str3 = table.Rows[0]["ProviderUserName"].ToString();
                switch (str)
                {
                    case "WorldVision":
                        new SelectElement(driver.FindElement(By.Id("PayProvider_Id"))).SelectByText("WorldVision");
                        break;

                    case "Secure Trading (offline)":
                        {
                            new SelectElement(driver.FindElement(By.Id("PayProvider_Id"))).SelectByText(
                                "Secure Trading (offline)");
                            Thread.Sleep(0xbb8);
                            driver.FindElement(By.Id("Credentials_TypeModel_SiteReference")).Clear();
                            driver.FindElement(By.Id("Credentials_TypeModel_SiteReference"))
                                  .SendKeys("test_mobankgroup45556");
                            driver.FindElement(By.Id("Credentials_TypeModel_UserName")).Clear();
                            driver.FindElement(By.Id("Credentials_TypeModel_UserName"))
                                  .SendKeys("webservices@mobankgroup.com");
                            driver.FindElement(By.Id("Credentials_TypeModel_Password")).Clear();
                            driver.FindElement(By.Id("Credentials_TypeModel_Password")).SendKeys("wj3JWWFX");
                            driver.FindElement(By.CssSelector("input.button")).Click();

                            attribute =
                                driver.FindElement(By.Id("Credentials_TypeModel_SiteReference")).GetAttribute("value");
                            str6 = driver.FindElement(By.Id("Credentials_TypeModel_UserName")).GetAttribute("value");
                            var expected =
                                driver.FindElement(By.Id("Credentials_TypeModel_Password")).GetAttribute("value");
                            if (driver.PageSource.Contains("An unexpected error has occured, please try again"))
                            {
                                datarow.Newrow("Capturing Error Message",
                                               "An unexpected error has occured, please try again",
                                               "An unexpected error has occured, please try again", "PASS", driver
                                    );
                            }
                            str8 = GetValue(driver, By.Id("CardTypes_0____selector"));
                            str9 = GetValue(driver, By.Id("CardTypes_1____selector"));
                            if (str8 == "true")
                            {
                                driver.FindElement(By.Id("CardTypes_0____selector")).Click();
                            }
                            if (str9 == "true")
                            {
                                driver.FindElement(By.Id("CardTypes_1____selector")).Click();
                            }

                            str10 = GetValue(driver, By.Id("CardTypes_0____selector"));
                            str11 = GetValue(driver, By.Id("CardTypes_1____selector"));
                            if ((str10 == "false") && (str11 == "false"))
                            {
                                driver.FindElement(By.CssSelector("input.button")).Click();

                                if (driver.PageSource.Contains("An unexpected error has occured, please try again"))
                                {
                                    datarow.Newrow("Capturing Error Message",
                                                   "An unexpected error has occured, please try again",
                                                   "An unexpected error has occured, please try again", "FAIL", driver
                                        );
                                }
                            }
                            driver.FindElement(By.Id("CardTypes_0____selector")).Click();
                            driver.FindElement(By.CssSelector("input.button")).Click();

                            if (attribute == "test_mobankgroup45556")
                            {
                                datarow.Newrow("PayProviderUserName", "mobank", "mobank", "PASS", driver);
                            }
                            else
                            {
                                datarow.Newrow("PayProviderUserName", "mobank", "mobank", "FAIL", driver);
                                _screenshot.Screenshotfailed(driver);
                            }
                            if (str6 == "webservices@mobankgroup.com")
                            {
                                datarow.Newrow("PayProviderIdentifier", "mobank", "mobank", "PASS", driver);
                            }
                            else
                            {
                                datarow.Newrow("PayProviderIdentifier", "mobank", "mobank", "FAIL", driver);
                                _screenshot.Screenshotfailed(driver);
                            }
                            if (expected == "wj3JWWFX")
                            {
                                datarow.Newrow("Password", expected, "wj3JWWFX", "PASS", driver);
                            }
                            else
                            {
                                datarow.Newrow("Password", expected, "wj3JWWFX", "FAIL", driver);
                                _screenshot.Screenshotfailed(driver);
                            }
                            break;
                        }
                    case "Sage Pay (non-live)":
                        new SelectElement(driver.FindElement(By.Id("PayProvider_Id"))).SelectByText(
                            "Sage Pay (non-live)");
                        Thread.Sleep(0xbb8);
                        driver.FindElement(By.CssSelector("input.button")).Click();


                        if (driver.PageSource.Contains("An unexpected error has occured, please try again"))
                        {
                            datarow.Newrow("Capturing Error Message",
                                           "An unexpected error has occured, please try again",
                                           "An unexpected error has occured, please try again", "PASS", driver);
                        }
                        str8 = GetValue(driver, By.Id("CardTypes_0____selector"));
                        str9 = GetValue(driver, By.Id("CardTypes_1____selector"));
                        if (str8 == "true")
                        {
                            driver.FindElement(By.Id("CardTypes_0____selector")).Click();
                        }
                        if (str9 == "true")
                        {
                            driver.FindElement(By.Id("CardTypes_1____selector")).Click();
                        }
                        str10 = GetValue(driver, By.Id("CardTypes_0____selector"));
                        str11 = GetValue(driver, By.Id("CardTypes_1____selector"));
                        if ((str10 == "false") && (str11 == "false"))
                        {
                            driver.FindElement(By.CssSelector("input.button")).Click();

                            if (driver.PageSource.Contains("An unexpected error has occured, please try again"))
                            {
                                datarow.Newrow("Capturing Error Message",
                                               "An unexpected error has occured, please try again",
                                               "An unexpected error has occured, please try again", "FAIL", driver
                                    );
                            }
                        }
                        driver.FindElement(By.Id("CardTypes_0____selecto")).Click();
                        driver.FindElement(By.CssSelector("input.button")).Click();

                        break;

                    case "RealEx Test (MTC)":
                        new SelectElement(driver.FindElement(By.Id("PayProvider_Id"))).SelectByText("RealEx Test (MTC)");
                        Thread.Sleep(0xbb8);
                        driver.FindElement(By.Id("Credentials_TypeModel_MerchantId")).Clear();
                        driver.FindElement(By.Id("Credentials_TypeModel_MerchantId")).SendKeys("mobank");
                        driver.FindElement(By.Id("Credentials_TypeModel_Password")).Clear();
                        driver.FindElement(By.Id("Credentials_TypeModel_Password")).SendKeys("secret");
                        driver.FindElement(By.CssSelector("input.button")).Click();

                        if (driver.PageSource.Contains("An unexpected error has occured, please try again"))
                        {
                            datarow.Newrow("Capturing Error Message",
                                           "An unexpected error has occured, please try again",
                                           "An unexpected error has occured, please try again", "PASS", driver);
                        }
                        xpathCount = GetXpathCount(driver, "//div[@id='CardTypesControl']/div/div/ul/li");
                        num4 = 0;
                        while (num4 < xpathCount)
                        {
                            if (GetValue(driver, By.Id("CardTypes_" + num4 + "____selector")) == "true")
                            {
                                driver.FindElement(By.Id("CardTypes_" + num4 + "____selector")).Click();
                            }
                            num4++;
                        }
                        if (GetValue(driver, By.Id("CardTypes_0____selector")) == "false")
                        {
                            driver.FindElement(By.CssSelector("input.button")).Click();

                            if (driver.PageSource.Contains("An unexpected error has occured, please try again"))
                            {
                                datarow.Newrow("Capturing Error Message",
                                               "An unexpected error has occured, please try again",
                                               "An unexpected error has occured, please try again", "FAIL", driver
                                    );
                            }
                        }
                        attribute = driver.FindElement(By.Id("Credentials_TypeModel_MerchantId")).GetAttribute("value");
                        str6 = driver.FindElement(By.Id("Credentials_TypeModel_Password")).GetAttribute("value");
                        if (attribute == "mobank")
                        {
                            datarow.Newrow("PayProviderUserName", "mobank", "mobank", "PASS", driver);
                        }
                        else
                        {
                            datarow.Newrow("PayProviderUserName", "mobank", "mobank", "FAIL", driver);
                            _screenshot.Screenshotfailed(driver);
                        }
                        if (str6 == "secret")
                        {
                            datarow.Newrow("PayProviderPassword", str6, "secret", "PASS", driver);
                        }
                        else
                        {
                            datarow.Newrow("PayProviderPassword", str6, "secret", "FAIL", driver);
                            _screenshot.Screenshotfailed(driver);
                        }
                        break;
                }
                driver.FindElement(By.Id("CardTypes_0____selector")).Click();
                driver.FindElement(By.CssSelector("input.button")).Click();

                if (str == "Mobank Test Provider")
                {
                    new SelectElement(driver.FindElement(By.Id("PayProvider_Id"))).SelectByText("PayPal Provider");
                }
                if (str != "WorldPay Business/Corporate (offline)") continue;
                new SelectElement(driver.FindElement(By.Id("PayProvider_Id"))).SelectByText(
                    "WorldPay Business/Corporate (offline)");
                Thread.Sleep(0xbb8);
                if (IsElementPresent(driver, By.Name("Credentials_TypeModel_MerchantCode")))
                {
                    driver.FindElement(By.Id("Credentials_TypeModel_MerchantCode")).Clear();
                    driver.FindElement(By.Id("Credentials_TypeModel_MerchantCode")).SendKeys(str2);
                    driver.FindElement(By.Id("Credentials_TypeModel_XmlUserName")).Clear();
                    driver.FindElement(By.Id("Credentials_TypeModel_XmlUserName")).SendKeys(str3);
                    driver.FindElement(By.Id("Credentials_TypeModel_XmlPassword")).Clear();
                    driver.FindElement(By.Id("Credentials_TypeModel_XmlPassword")).SendKeys(str3);
                    driver.FindElement(By.CssSelector("input.button")).Click();

                    if (driver.PageSource.Contains("An unexpected error has occured, please try again"))
                    {
                        datarow.Newrow("Capturing Error Message",
                            "An unexpected error has occured, please try again",
                            "An unexpected error has occured, please try again", "PASS", driver);
                    }
                    xpathCount = GetXpathCount(driver, "//div[@id='CardTypesControl']/div/div/ul/li");
                    for (num4 = 0; num4 < xpathCount; num4++)
                    {
                        if (GetValue(driver, By.Id("CardTypes_" + num4 + "____selector")) == "true")
                        {
                            driver.FindElement(By.Id("CardTypes_" + num4 + "____selector")).Click();
                        }
                    }
                    if (GetValue(driver, By.Id("CardTypes_0____selector")) == "false" + "")
                    {
                        driver.FindElement(By.CssSelector("input.button")).Click();

                        if (driver.PageSource.Contains("An unexpected error has occured, please try again"))
                        {
                            datarow.Newrow("Capturing Error Message",
                                "An unexpected error has occured, please try again",
                                "An unexpected error has occured, please try again", "FAIL", driver
                                );
                        }
                    }
                    attribute = driver.FindElement(By.Id("Credentials_TypeModel_MerchantCode"))
                        .GetAttribute("value");
                    str6 = driver.FindElement(By.Id("Credentials_TypeModel_XmlUserName")).GetAttribute("value");
                    if (attribute == str3)
                    {
                        datarow.Newrow("PayProviderUserName", "mobank", "mobank", "PASS", driver);
                    }
                    else
                    {
                        datarow.Newrow("PayProviderUserName", "mobank", "mobank", "FAIL", driver);
                        _screenshot.Screenshotfailed(driver);
                    }
                    if (str6 == str2)
                    {
                        datarow.Newrow("PayProviderIdentifier", "mobank", "mobank", "PASS", driver);
                    }
                    else
                    {
                        datarow.Newrow("PayProviderIdentifier", "mobank", "mobank", "FAIL", driver);
                        _screenshot.Screenshotfailed(driver);
                    }
                }
                driver.FindElement(By.Id("CardTypes_0____selector")).Click();
                driver.FindElement(By.CssSelector("input.button")).Click();
            }
        }
    }
}