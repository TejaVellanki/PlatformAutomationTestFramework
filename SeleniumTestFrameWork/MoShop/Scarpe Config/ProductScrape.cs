﻿// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriver_Refining;
   

namespace MoBankUI
{
    internal class ProductScrape : driverdefining
    {
        public void productscrape(IWebDriver driver, datarow datarow)
        {
            try
            {
                driver.FindElement(By.XPath("(//a[contains(text(),'…')])[3]")).Click();
                waitforpagetoload(driver,30000);
                driver.FindElement(By.LinkText("Target Pages")).Click();
                waitforpagetoload(driver,30000);
                driver.FindElement(By.Id("Selector")).Clear();
                driver.FindElement(By.Id("Selector")).SendKeys("div[class^='singleproduct']>a");
                driver.FindElement(By.Id("Identifier")).Clear();
                driver.FindElement(By.Id("Identifier")).SendKeys("/acatalog/glitter-tree-wrapping-paper.html");
                driver.FindElement(By.Id("IdentifierTransformationPattern")).Clear();
                driver.FindElement(By.Id("IdentifierTransformationPattern")).SendKeys(@"\/acatalog\/([a-z0-9\-_]+).html");
                driver.FindElement(By.Id("IdentifierTransformationReplacement")).Clear();
                driver.FindElement(By.Id("IdentifierTransformationReplacement")).SendKeys("$1");
                driver.FindElement(By.CssSelector("input.button")).Click();
                waitforpagetoload(driver,30000);
               
                driver.FindElement(By.LinkText("Scrape Mappings")).Click();
                waitforpagetoload(driver,30000);
                Selectanoption(driver,By.Id("MappingId"),"(new mappings)");
                //new SelectElement(driver.FindElement(By.Id("MappingId"))).SelectByText("(new mappings)");
                driver.FindElement(By.CssSelector("input.button")).Click();
                waitforpagetoload(driver,30000);

              
                driver.FindElement(By.Id("MappingItems_0__Selector")).Clear();
                driver.FindElement(By.Id("MappingItems_0__Selector")).SendKeys("h1");
                Selectanoption(driver, By.Id("MappingItems_0__DataPath"), "Name");
                driver.FindElement(By.Id("MappingItems_0__Selector")).SendKeys(Keys.Enter);
                Selectanoption(driver, By.Id("MappingItems_0__TransformationId"), "Content Trim");
                waitforpagetoload(driver, 30000);
                driver.FindElement(By.CssSelector("input.button")).Click();
                waitforpagetoload(driver,30000);

              
                driver.FindElement(By.Id("MappingItems_1__Selector")).Clear();
                driver.FindElement(By.Id("MappingItems_1__Selector")).SendKeys("#contentTab1,#contentTab2");
                Selectanoption(driver, By.Id("MappingItems_1__DataPath"),"Description");
                driver.FindElement(By.Id("MappingItems_1__Selector")).SendKeys(Keys.Enter);
                driver.FindElement(By.CssSelector("input.button")).Click();
                waitforpagetoload(driver, 30000);
                Selectanoption(driver, By.Id("MappingItems_1__TransformationId"), "Content Trim");
                 //new SelectElement(driver.FindElement(By.Id("MappingItems_1__DataPath"))).SelectByText("Description");
                 //new SelectElement(driver.FindElement(By.Id("MappingItems_1__TransformationId"))).SelectByText("Content Trim");
                driver.FindElement(By.CssSelector("input.button")).Click();
                waitforpagetoload(driver, 30000);
              
                
                driver.FindElement(By.Id("MappingItems_2__Selector")).Clear();
                driver.FindElement(By.Id("MappingItems_2__Selector")).SendKeys(".MagicZoomPlus");
                Selectanoption(driver, By.Id("MappingItems_2__DataPath"), "MainImage");
                driver.FindElement(By.Id("MappingItems_2__DataPath")).SendKeys(Keys.Enter);
                driver.FindElement(By.CssSelector("input.button")).Click();
                waitforpagetoload(driver, 30000);
                Selectanoption(driver, By.Id("MappingItems_2__TransformationId"), "Content Trim");
                //new SelectElement(driver.FindElement(By.Id("MappingItems_2__DataPath"))).SelectByText("MainImage");
               // new SelectElement(driver.FindElement(By.Id("MappingItems_2__TransformationId"))).SelectByText("Content Trim");   
                driver.FindElement(By.CssSelector("input.button")).Click();
                  waitforpagetoload(driver,30000);
                  driver.FindElement(By.Id("MappingItems_2__Selector")).SendKeys(Keys.Enter);
               
                
                
                driver.FindElement(By.Id("MappingItems_3__Selector")).Clear();
                driver.FindElement(By.Id("MappingItems_3__Selector")).SendKeys("[retail_price_prompt]:first");
                Selectanoption(driver, By.Id("MappingItems_3__DataPath"), "Price");
                driver.FindElement(By.Id("MappingItems_3__DataPath")).SendKeys(Keys.Enter);
                driver.FindElement(By.CssSelector("input.button")).Click();
                waitforpagetoload(driver, 30000);
                Selectanoption(driver, By.Id("MappingItems_3__TransformationId"), "Tickle Price");
                 //new SelectElement(driver.FindElement(By.Id("MappingItems_3__DataPath"))).SelectByText("Price");
                 //new SelectElement(driver.FindElement(By.Id("MappingItems_3__TransformationId"))).SelectByText("Tickle Price");
                driver.FindElement(By.Id("MappingItems_3__Selector")).SendKeys(Keys.Enter);
                driver.FindElement(By.CssSelector("input.button")).Click();
                  waitforpagetoload(driver,30000);
               
                
                
                driver.FindElement(By.Id("MappingItems_4__Selector")).Clear();
                driver.FindElement(By.Id("MappingItems_4__Selector")).SendKeys("[PROD_REF]:first");
                driver.FindElement(By.Id("MappingItems_4__Attribute")).Clear();
                driver.FindElement(By.Id("MappingItems_4__Attribute")).SendKeys("PROD_REF");
                Selectanoption(driver, By.Id("MappingItems_4__DataPath"), "Code");
                driver.FindElement(By.Id("MappingItems_4__DataPath")).SendKeys(Keys.Enter);
                driver.FindElement(By.CssSelector("input.button")).Click();
                waitforpagetoload(driver, 30000);
                Selectanoption(driver, By.Id("MappingItems_4__TransformationId"), "Trim");
               // new SelectElement(driver.FindElement(By.Id("MappingItems_4__DataPath"))).SelectByText("Code");
               // new SelectElement(driver.FindElement(By.Id("MappingItems_4__TransformationId"))).SelectByText( "Trim");
                driver.FindElement(By.Id("MappingItems_4__Selector")).SendKeys(Keys.Enter);
                driver.FindElement(By.CssSelector("input.button")).Click();
                  waitforpagetoload(driver,30000);
               
               
                
                driver.FindElement(By.Id("MappingItems_5__Selector")).Clear();
                driver.FindElement(By.Id("MappingItems_5__Selector")).SendKeys(".itemAddtional strong:has([retail_price_prompt]):prev()");
                Selectanoption(driver, By.Id("MappingItems_5__DataPath"), "PriceOriginal");
                driver.FindElement(By.Id("MappingItems_5__DataPath")).SendKeys(Keys.Enter);
                driver.FindElement(By.CssSelector("input.button")).Click();
                waitforpagetoload(driver, 30000);
                Selectanoption(driver, By.Id("MappingItems_5__TransformationId"), "Price");
                // new SelectElement(driver.FindElement(By.Id("MappingItems_5__DataPath"))).SelectByText("PriceOriginal");
                // new SelectElement(driver.FindElement(By.Id("MappingItems_5__TransformationId"))).SelectByText("Price");
                driver.FindElement(By.Id("MappingItems_5__Selector")).SendKeys(Keys.Enter);
                driver.FindElement(By.CssSelector("input.button")).Click();
                  waitforpagetoload(driver,30000);
              

                #region Validations

                string attribute = driver.FindElement(By.Id("Selector")).GetAttribute("Value");
                string actual = driver.FindElement(By.Id("Identifier")).GetAttribute("Value");
                string str3 = driver.FindElement(By.Id("IdentifierTransformationPattern")).GetAttribute("Value");
                string str4 = driver.FindElement(By.Id("IdentifierTransformationReplacement")).GetAttribute("Value");
                string str5 = driver.FindElement(By.Id("MappingItems_0__Selector")).GetAttribute("Value");
                string str6 = driver.FindElement(By.Id("MappingItems_1__Selector")).GetAttribute("Value");
                string str7 = driver.FindElement(By.Id("MappingItems_2__Selector")).GetAttribute("Value");
                string str8 = driver.FindElement(By.Id("MappingItems_3__Selector")).GetAttribute("Value");
                string str9 = driver.FindElement(By.Id("MappingItems_4__Selector")).GetAttribute("Value");
                string str10 = driver.FindElement(By.Id("MappingItems_5__Selector")).GetAttribute("Value");

                if (attribute == "div[class^='singleproduct']>a")
                {
                    datarow.newrow("Product selector", "div[class^='singleproduct']>a", attribute, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Product selector", "div[class^='singleproduct']>a", attribute, "FAIL", driver);
                }
                if (actual == "/acatalog/glitter-tree-wrapping-paper.html")
                {
                    datarow.newrow("Products Identifier", "/acatalog/glitter-tree-wrapping-paper.html", actual, "PASS",driver);
                }
                else
                {
                    datarow.newrow("Products Identifier", "/acatalog/glitter-tree-wrapping-paper.html", actual, "FAIL",driver);
                }
                if (str3 == @"\/acatalog\/([a-z0-9\-_]+).html")
                {
                    datarow.newrow("Products Idntifier Transformation", @"\/acatalog\/([a-z0-9\-_]+).html", str3, "PASS",driver);
                }
                else
                {
                    datarow.newrow("Products Idntifier Transformation", @"\/acatalog\/([a-z0-9\-_]+).html", str3, "FAIL",driver);
                }
                if (str4 == "$1")
                {
                    datarow.newrow("Products Identifier Replacement", "$1", str4, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Products Identifier Replacement", "$1", str4, "FAIL", driver);
                }
                if (str5 == "h1")
                {
                    datarow.newrow("Product Mapping selector", "h1", str5, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Product Mapping selector", "h1", str5, "FAIL", driver);
                }
                if (str6 == "#contentTab1,#contentTab2")
                {
                    datarow.newrow("Products Mapping Selector1", "#contentTab1,#contentTab2", str6, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Products Mapping Selector1", "#contentTab1,#contentTab2", str6, "FAIL", driver);
                }
                if (str7 == ".MagicZoomPlus")
                {
                    datarow.newrow("Products Mapping selector2", ".MagicZoomPlus", str7, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Products Mapping selector2", ".MagicZoomPlus", str7, "FAIL", driver);
                }
                if (str8 == "[retail_price_prompt]:first")
                {
                    datarow.newrow("Products Mapping Selector3", "[retail_price_prompt]:first", str8, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Products Mapping Selector3", "[retail_price_prompt]:first", str8, "FAIL", driver);
                }
                if (str9 == "[PROD_REF]:first")
                {
                    datarow.newrow("Products Mapping selector4", "[PROD_REF]:first", str9, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Products Mapping selector4", "[PROD_REF]:first", str9, "FAIL", driver);
                }
                if (str10 == ".itemAddtional strong:has([retail_price_prompt]):prev()")
                {
                    datarow.newrow("Products Mapping selector5",".itemAddtional strong:has([retail_price_prompt]):prev()", str10, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Products Mapping selector5",".itemAddtional strong:has([retail_price_prompt]):prev()", str10, "FAIL", driver);
                }

                #endregion
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception Not Expected", "", e,"FAIL");
            }
              driver.FindElement(By.LinkText("Scrape")).Click();
              waitforpagetoload(driver,30000);
        }
    }
}