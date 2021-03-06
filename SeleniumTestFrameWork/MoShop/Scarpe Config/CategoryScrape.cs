﻿// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe


using System;
using OpenQA.Selenium;

namespace MoBankUI.MoShop
{
    internal class CategoryScrape : Driverdefining
    {
        public void ScarpeCategory(IWebDriver driver, Datarow datarow)
        {
            try
            {
                driver.FindElement(By.Id("SubPages_0__Name")).Clear();
                driver.FindElement(By.Id("SubPages_0__Name")).SendKeys("Sub-Categories");
                Selectanoption(driver, By.Id("SubPages_0__ObjectTypeName"), "Category");
                //string[] Subcat = SelectElement.GetSelectOptions("SubPages_0__ObjectTypeName");

                driver.FindElement(By.Id("SubPages_0__ObjectTypeName")).SendKeys(Keys.Enter);
                driver.FindElement(By.Id("Selector")).Clear();
                driver.FindElement(By.Id("Selector")).SendKeys("/acatalog/gift-wrap.html");
                driver.FindElement(By.Id("Identifier")).Clear();
                driver.FindElement(By.Id("Identifier")).SendKeys("/acatalog/gift-wrap.html");
                driver.FindElement(By.Id("Selector")).Clear();
                driver.FindElement(By.Id("Selector")).SendKeys("#menu .lrga:gt(1)>a");
                driver.FindElement(By.Id("IdentifierTransformationPattern")).Clear();
                driver.FindElement(By.Id("IdentifierTransformationPattern"))
                      .SendKeys("\\/acatalog\\/([a-z0-9\\-_]*).html");
                driver.FindElement(By.Id("IdentifierTransformationReplacement")).Clear();
                driver.FindElement(By.Id("IdentifierTransformationReplacement")).SendKeys("$1");
                driver.FindElement(By.CssSelector("input.button")).Click();


                driver.FindElement(By.LinkText("Scrape Mappings")).Click();

                Selectanoption(driver, By.Id("MappingId"), "(new mappings)");
                //new SelectElement(driver.FindElement(By.Id("MappingId"))).SelectByText("(new mappings)");
                driver.FindElement(By.CssSelector("input.button")).Click();
                Selectanoption(driver, By.Id("MappingItems_0__DataPath"), "Name");
                driver.FindElement(By.Id("MappingItems_0__Selector")).Clear();
                driver.FindElement(By.Id("MappingItems_0__Selector")).SendKeys("a[class^='select']");

                Selectanoption(driver, By.Id("MappingItems_0__TransformationId"), "Content Trim");
                driver.FindElement(By.CssSelector("input.button")).Click();

                #region Validations

                var attribute = driver.FindElement(By.Id("Selector")).GetAttribute("Value");
                var actual = driver.FindElement(By.Id("Identifier")).GetAttribute("Value");
                var str3 =
                    driver.FindElement(By.CssSelector("#IdentifierTransformationPattern")).GetAttribute("Value");
                var str4 =
                    driver.FindElement(By.CssSelector("#IdentifierTransformationReplacement")).GetAttribute("Value");


                var selectedLabel = driver.FindElement(By.Id("MappingItems_0__DataPath")).Selected.ToString();
                var str6 = driver.FindElement(By.Id("MappingItems_0__TransformationId")).GetAttribute("Value");
                var str7 = driver.FindElement(By.Id("MappingItems_0__Selector")).GetAttribute("Value");
                var str8 = driver.FindElement(By.Id("SubPages_0__Name")).GetAttribute("Value");
                var str9 = driver.FindElement(By.Id("SubPages_0__ObjectTypeName")).GetAttribute("Value");

                datarow.Newrow("Selector", "#menu .lrga:gt(1)>a", attribute,
                    attribute == "#menu .lrga:gt(1)>a" ? "PASS" : "FAIL", driver);
                datarow.Newrow("Identifier", "/acatalog/gift-wrap.html", actual,
                    actual == "/acatalog/gift-wrap.html" ? "PASS" : "FAIL", driver);
                datarow.Newrow("Identifier Tarnsformation pattern", @"\/acatalog\/([a-z0-9\-_]*).html", str3,
                    str3 == @"\/acatalog\/([a-z0-9\-_]*).html" ? "PASS" : "FAIL",
                    driver);
                datarow.Newrow("Identifier Replacement", "$1", str4, str4 == "$1" ? "PASS" : "FAIL", driver);
                datarow.Newrow("DataPath", "Name", selectedLabel, selectedLabel == "Name" ? "PASS" : "FAIL", driver);
                datarow.Newrow("Transformation ID", "Content Trim", str6, str6 == "Content Trim" ? "PASS" : "FAIL",
                    driver);
                datarow.Newrow("Mapping Selector", "a[class^='select']", str7,
                    str7 == "a[class^='select']" ? "PASS" : "FAIL", driver);
                datarow.Newrow("Sub Pages", "Sub-Categories", str8, str8 == "Sub-Categories" ? "PASS" : "FAIL", driver);
                datarow.Newrow("Sub Category Type", "Category", str9, str9 == "Category" ? "PASS" : "FAIL", driver);

                #endregion

                driver.FindElement(By.XPath("(//a[contains(text(),'…')])[2]")).Click();
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.Newrow("Exception", "", e, "FAIL");
            }
            new SubCategory().Subcategoryscrape(driver, datarow);
        }
    }
}