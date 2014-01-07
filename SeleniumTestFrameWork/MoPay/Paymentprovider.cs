﻿// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MoBankUI.MoPay
{
    public class Paymentprovider : Driverdefining
    {
        private readonly Screenshot _screenshot = new Screenshot();
        private GeneralLibrary _genaralLibrary;

        public void Provider(IWebDriver driver, Datarow datarow)
        {
            _genaralLibrary = new GeneralLibrary();
            var table =
                _genaralLibrary.GetExcelData(@"C:\\Input Data\CardDetails.xls", "AccountCreation").Tables[0];
            var count = table.Rows.Count;
            var str = table.Rows[0]["AccountName"].ToString();
            var text = table.Rows[0]["Provider"].ToString();
            var str3 = table.Rows[0]["ProviderIdentifier"].ToString();
            var str4 = table.Rows[0]["ProviderUserName"].ToString();
            var str5 = table.Rows[0]["Implementation"].ToString();
            var str6 = table.Rows[0]["Allow3DSecure"].ToString();
            new SelectElement(driver.FindElement(By.Id("PayProvider_Id"))).SelectByText(text);
            var attribute = driver.FindElement(By.Id("PayProvider_Id")).GetAttribute("Value");
            datarow.newrow("Provider", text, attribute, text == attribute ? "PASS" : "FAIL", driver);
            new Paymentprovidertypes().Paymenttypes(driver, datarow);
            driver.FindElement(By.LinkText("…")).Click();

            new SelectElement(driver.FindElement(By.Id("Implementation"))).SelectByText(str5);
            var actual = driver.FindElement(By.Id("Allow3DSecure")).GetAttribute("value");
            if (actual == "false")
            {
                datarow.newrow("3Dsecure", "OFF", actual, "PASS", driver);
                if (IsElementPresent(driver, By.Id("Allow3DSecure")))
                {
                    driver.FindElement(By.Id("Allow3DSecure")).Click();
                    driver.FindElement(By.CssSelector("input.button")).Click();
                }
            }
            if (driver.FindElement(By.Id("Allow3DSecure")).GetAttribute("value") == "true")
            {
                datarow.newrow("3Dsecure", "ON", actual, "PASS", driver);
            }
            else
            {
                datarow.newrow("3Dsecure", "OFF", actual, "FAIL", driver);
                _screenshot.screenshotfailed(driver);
            }
            driver.FindElement(By.CssSelector("input.button")).Click();

            var expected = driver.FindElement(By.Id("Implementation")).GetAttribute("Value");
            datarow.newrow("Implementation", expected, str5, expected == str5 ? "PASS" : "FAIL", driver);
            driver.FindElement(
                By.XPath(("//html/body/div/div[2]/div/div/div/form/div[5]/div/div/table/tbody/tr/th[2]/a"))).Click();

            var str11 = driver.FindElement(By.Id("Name")).GetAttribute("value");
            if (str11 == "Visa Debit")
            {
                datarow.newrow("Card Type -Visa Debit", "Visa Debit", str11, "PASS", driver);
                new VisaDebit().Visadebit(driver, datarow);
            }
            driver.Navigate().Back();

            driver.FindElement(By.XPath("//div[@id='CardTypesControl']/div/table/tbody/tr[2]/th[2]/a")).Click();

            if (driver.FindElement(By.Id("Name")).GetAttribute("value") == "Mastercard")
            {
                datarow.newrow("Card Type -Mastercard", "Mastercard", str11, "PASS", driver);
                new Mastercard().Mastercardm(driver, datarow);
            }
            //MouseOver("//html/body/div/div/div/div[2]/ul/li/a");
            driver.Navigate().Back();
            Thread.Sleep(0x1388);
            driver.Navigate().Back();
            Thread.Sleep(0x2710);
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("Payment Provider")).Click();
            Thread.Sleep(0x1388);
            if (IsElementPresent(driver, By.Id("CardTypes_0____selector")))
            {
                var str13 = driver.FindElement(By.Id("CardTypes_0____selector")).GetAttribute("value");
                if (str13 == "false")
                {
                    datarow.newrow("Card1", "off", str13, "PASS", driver);
                    driver.FindElement(By.Id("CardTypes_0____selector")).Click();
                }
            }
            if (IsElementPresent(driver, By.Id("CardTypes_1____selector")))
            {
                var str14 = driver.FindElement(By.Id("CardTypes_1____selector")).GetAttribute("value");
                if (str14 == "false")
                {
                    datarow.newrow("Card2", "off", str14, "PASS", driver);
                    driver.FindElement(By.Id("CardTypes_1____selector")).Click();
                }
            }
            if (IsElementPresent(driver, By.Id("CardTypes_2____selector")))
            {
                var str15 = driver.FindElement(By.Id("CardTypes_2____selector")).GetAttribute("value");
                if (str15 == "true")
                {
                    datarow.newrow("Card3", "on", str15, "PASS", driver);
                    driver.FindElement(By.Id("CardTypes_2____selector")).Click();
                }
            }
            if (IsElementPresent(driver, By.Id("CardTypes_3____selector")))
            {
                var str16 = driver.FindElement(By.Id("CardTypes_3____selector")).GetAttribute("value");
                if (str16 == "true")
                {
                    datarow.newrow("Card4", "on", str16, "PASS", driver);
                    driver.FindElement(By.Id("CardTypes_3____selector")).Click();
                }
            }
            driver.FindElement(By.CssSelector("input.button")).Click();

            if (IsElementPresent(driver, By.Id("CardTypes_0____selector")))
            {
                var str17 = driver.FindElement(By.Id("CardTypes_0____selector")).GetAttribute("value");
                if (str17 == "false")
                {
                    datarow.newrow("Card1", "off", str17, "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                }
                else
                {
                    datarow.newrow("Card1", "on", str17, "PASS", driver);
                }
            }
            if (IsElementPresent(driver, By.Id("CardTypes_1____selector")))
            {
                var str18 = driver.FindElement(By.Id("CardTypes_1____selector")).GetAttribute("value");
                if (str18 == "false")
                {
                    datarow.newrow("Card2", "off", str18, "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                }
                else
                {
                    datarow.newrow("Card2", "on", str18, "PASS", driver);
                }
            }
            if (IsElementPresent(driver, By.Id("CardTypes_2____selector")))
            {
                var str19 = driver.FindElement(By.Id("CardTypes_2____selector")).GetAttribute("value");
                if (str19 == "true")
                {
                    datarow.newrow("Card3", "on", str19, "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                }
                else
                {
                    datarow.newrow("Card3", "off", str19, "PASS", driver);
                }
            }
        }
    }
}