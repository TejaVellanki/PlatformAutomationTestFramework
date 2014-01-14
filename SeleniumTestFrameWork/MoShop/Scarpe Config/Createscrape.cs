﻿// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MoBankUI.MoShop
{
    public class Createscrape : Driverdefining
    {
        [Test]
        public void CreateScrape(IWebDriver driver, Datarow datarow)
        {
            try
            {
                driver.FindElement(By.LinkText("MoShop")).Click();

                var actual = driver.Title;
                datarow.Newrow("HomePage Title", "mobank.co.uk/MoShop", actual,
                    actual == "mobank.co.uk/MoShop" ? "PASS" : "FAIL", driver);
                driver.FindElement(By.LinkText("Scrapes")).Click();

                var str2 = driver.Title;
                datarow.Newrow("Scrape Page Title", "Scrapes :  mobank.co.uk/MoShop", str2,
                    str2 == "Scrapes : mobank.co.uk/MoShop" ? "PASS" : "FAIL", driver);


                driver.FindElement(By.LinkText("Create")).Click();
                driver.FindElement(By.Id("Name")).Clear();
                driver.FindElement(By.Id("Name")).SendKeys("TestShop-Scrape");
                driver.FindElement(By.CssSelector("p.submit.submitInline > input.button")).Click();

                Selectanoption(driver, By.Id("Profiles_0__Shop_Value"), "testshop");
                //new SelectElement(driver.FindElement(By.Id("Profiles_0__Shop_Value"))).SelectByText("testshop");
                driver.FindElement(By.CssSelector("input.button")).Click();


                var str3 = driver.Title;
                datarow.Newrow("Scrape Title", "Scrape :  mobank.co.uk/MoShop", str3,
                    str3 == "Scrape : mobank.co.uk/MoShop" ? "PASS" : "FAIL", driver);
                driver.FindElement(By.Id("Profiles_0__RootUrl")).Clear();
                driver.FindElement(By.Id("Profiles_0__RootUrl")).SendKeys("http://www.the-tickle-company.co.uk/");
                Selectanoption(driver, By.Id("Profiles_0__Encoding"), "iso-8859-1 - Western European (ISO)");
                //new SelectElement(driver.FindElement(By.Id("Profiles_0__Encoding"))).SelectByText("iso-8859-1 - Western European (ISO)");
                driver.FindElement(By.CssSelector("input.button")).Click();

                var attribute = driver.FindElement(By.Id("Profiles_0__RootUrl")).GetAttribute("Value");
                driver.FindElement(By.Id("Profiles_0__Encoding")).GetAttribute("Value");
                datarow.Newrow("Root URL", "http://www.the-tickle-company.co.uk/", attribute,
                    attribute == "http://www.the-tickle-company.co.uk/" ? "PASS" : "FAIL", driver);
                driver.FindElement(By.Id("Pages_0__Name")).Clear();
                driver.FindElement(By.Id("Pages_0__Name")).SendKeys("Categories");
                Selectanoption(driver, By.Id("Pages_0__ObjectTypeName"), "Category");
                //new SelectElement(driver.FindElement(By.Id("Pages_0__ObjectTypeName"))).SelectByText("Category");
                driver.FindElement(By.CssSelector("input.button")).Click();

                var str6 = driver.FindElement(By.Id("Pages_0__Name")).GetAttribute("Value");
                driver.FindElement(By.Id("Pages_0__ObjectTypeName")).GetAttribute("option value");
                datarow.Newrow("Page Name", "Categories", str6, str6 == "Categories" ? "PASS" : "FAIL", driver);
                driver.FindElement(By.XPath("(//a[contains(text(),'…')])[2]")).Click();

                if (driver.PageSource.Contains("Server Error in '/' Application."))
                {
                    driver.Navigate().Back();

                    driver.FindElement(By.CssSelector("input.button")).Click();

                    driver.FindElement(By.XPath("(//a[contains(text(),'…')])[2]")).Click();
                }
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.Newrow("Exception", "", e, "FAIL");
            }
            new CategoryScrape().ScarpeCategory(driver, datarow);
        }
    }
}