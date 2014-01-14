﻿// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Threading;
using OpenQA.Selenium;

namespace MoBankUI.MoShop.Checkout
{
    public class Checkout : Driverdefining
    {
        public void CheckouT(IWebDriver driver, Datarow datarow)
        {
            try
            {
                driver.FindElement(By.LinkText("Checkout")).Click();

                datarow.Newrow("", "", "CHECKOUT", "", driver);
                var actual = driver.Title;
                if (actual == "Checkout : mobank.co.uk/MoShop")
                {
                    datarow.Newrow("Checkout Title", "Checkout : mobank.co.uk/MoShop", actual, "PASS", driver);
                }
                else
                {
                    datarow.Newrow("Checkout Title", "Checkout : mobank.co.uk/MoShop", actual, "PASS", driver);
                }
                Thread.Sleep(3000);
                driver.FindElement(By.Id("CheckoutProcesses_0__Name")).Clear();
                driver.FindElement(By.Id("CheckoutProcesses_0__Name")).SendKeys("Tickle (copy of QA by SB)");
                driver.FindElement(By.Id("CheckoutProcesses_0__Name")).SendKeys(Keys.Enter);

                driver.FindElement(By.Id("GenerateUniqueReference")).Click();
                driver.FindElement(By.Id("PaymentAccountIdentifier")).Clear();
                driver.FindElement(By.Id("PaymentAccountIdentifier")).SendKeys("45af07ff-a7dc-4453-89b0-285b85deef2a");
                driver.FindElement(By.CssSelector("input.button")).Click();

                Thread.Sleep(3000);
                var attribute = driver.FindElement(By.Id("CheckoutProcesses_0__Name")).GetAttribute("Value");
                if (attribute == "")
                {
                    driver.FindElement(By.Id("CheckoutProcesses_0__Name")).SendKeys("Tickle (copy of QA by SB)");
                    driver.FindElement(By.CssSelector("input.button")).Click();

                    Thread.Sleep(3000);
                }
                var str3 = driver.FindElement(By.Id("PaymentAccountIdentifier")).GetAttribute("Value");
                datarow.Newrow("Checkout Name", "Tickle (copy of QA by SB)", attribute,
                    attribute == "Tickle (copy of QA by SB)" ? "PASS" : "FAIL", driver);
                datarow.Newrow("Payment Identifier", "45af07ff-a7dc-4453-89b0-285b85deef2a", str3,
                    str3 == "45af07ff-a7dc-4453-89b0-285b85deef2a" ? "PASS" : "FAIL", driver);
                Thread.Sleep(3000);
                driver.FindElement(By.Id("DefaultCheckoutProcessId")).Click();
                driver.FindElement(By.CssSelector("input.button")).Click();

                driver.FindElement(By.LinkText("…")).Click();

                var str4 = driver.Title;
                datarow.Newrow("Checkout Process Page Title", "Checkout Process : mobank.co.uk/MoShop", str4,
                    str4 == "Checkout Process : mobank.co.uk/MoShop" ? "PASS" : "FAIL",
                    driver);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.Newrow("Exception", "Excepion Not Expected", e, "FAIL", driver);
            }
            new ConfigureCheckout().Configure(driver, datarow);
        }
    }
}