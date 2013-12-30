// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe


using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining; 


namespace MoBankUI
{
    internal class SubCategory : driverdefining
    {
        public void subcategoryscrape(IWebDriver driver, datarow datarow)
        {
            try
            {
            driver.FindElement(By.Id("Identifier")).Clear();
            driver.FindElement(By.Id("Identifier")).SendKeys("/acatalog/wrapping-paper-everyday.html");
            driver.FindElement(By.LinkText("Target Pages")).Click();
              
            driver.FindElement(By.Id("Selector")).Clear();
            driver.FindElement(By.Id("Selector")).SendKeys("div[class^='leftNav'] a,.bdr a");
            driver.FindElement(By.CssSelector("input.button")).Click();
                                                       
            driver.FindElement(By.Id("IdentifierTransformationPattern")).Clear();
            driver.FindElement(By.Id("IdentifierTransformationPattern")).SendKeys(@"\/([a-z0-9\-_]+).html");
            driver.FindElement(By.Id("IdentifierTransformationReplacement")).Clear();
            driver.FindElement(By.Id("IdentifierTransformationReplacement")).SendKeys("$1");
            driver.FindElement(By.CssSelector("input.button")).Click();
              
            driver.FindElement(By.LinkText("Scrape Mappings")).Click();
              
              Selectanoption(driver, By.Id("MappingId"), "(new mappings)");
            //  new SelectElement(driver.FindElement(By.Id("MappingId"))).SelectByText("(new mappings)");
            driver.FindElement(By.CssSelector("input.button")).Click();
              
              Selectanoption(driver, By.Id("MappingItems_0__DataPath"), "Name");
            driver.FindElement(By.Id("MappingItems_0__Selector")).Clear();
            driver.FindElement(By.Id("MappingItems_0__Selector")).SendKeys("h1,h2 :first");
            Selectanoption(driver, By.Id("MappingItems_0__TransformationId"), "Content Trim");
            // new SelectElement(driver.FindElement(By.Id("MappingItems_0__TransformationId"))).SelectByText("Content Trim");
            Selectanoption(driver, By.Id("MappingItems_1__DataPath"), "Description");
           // new SelectElement(driver.FindElement(By.Id("MappingItems_1__DataPath"))).SelectByText( "Description");
         
            driver.FindElement(By.Id("MappingItems_1__Selector")).Clear();
            driver.FindElement(By.Id("MappingItems_1__Selector")).SendKeys("#banner");
            Selectanoption(driver, By.Id("MappingItems_1__TransformationId"), "Content Trim");
           // new SelectElement(driver.FindElement(By.Id("MappingItems_1__TransformationId"))).SelectByText("Content Trim");
            
            driver.FindElement(By.CssSelector("input.button")).Click();
            

            driver.FindElement(By.Id("SubPages_0__Name")).SendKeys("products");
            driver.FindElement(By.Id("SubPages_0__Name")).SendKeys(Keys.Enter);
           
            Selectanoption(driver, By.Id("SubPages_0__ObjectTypeName"), "Product");

            driver.FindElement(By.CssSelector("input.button")).Click();
           


            #region Validation

            string attribute = driver.FindElement(By.Id("Selector")).GetAttribute("Value");
            string actual = driver.FindElement(By.Id("Identifier")).GetAttribute("Value");
            string str3 = driver.FindElement(By.Id("IdentifierTransformationPattern")).GetAttribute("Value");
            string str4 = driver.FindElement(By.Id("IdentifierTransformationReplacement")).GetAttribute("Value");
            string str5 = driver.FindElement(By.Id("MappingItems_0__Selector")).GetAttribute("Value");
            string str6 = driver.FindElement(By.Id("MappingItems_1__Selector")).GetAttribute("Value");


            if (attribute == "div[class^='leftNav'] a,.bdr a")
            {
                datarow.newrow("Subcategory Selector", "div[class^='leftNav'] a,.bdr a", attribute, "PASS", driver);
            }
            else
            {
                datarow.newrow("Subcategory Selector", "div[class^='leftNav'] a,.bdr a", attribute, "FAIL", driver);
            }
            if (actual == "/acatalog/wrapping-paper-everyday.html")
            {
                datarow.newrow("Sub-Category Identifier", "/acatalog/wrapping-paper-everyday.html", actual, "PASS",driver);
            }
            else
            {
                datarow.newrow("Sub-Category Identifier", "/acatalog/wrapping-paper-everyday.html", actual, "FAIL",driver);
            }
            if (str3 == @"\/([a-z0-9\-_]+).html")
            {
                datarow.newrow("Sub-Category Identifier Transformation", @"\/([a-z0-9\-_]+).html", str3,"PASS", driver);
            }
            else
            {
                datarow.newrow("Sub-Category Identifier Transformation", @"\/([a-z0-9\-_]+).html", str3,"FAIL", driver);
            }
            if (str4 == "$1")
            {
                datarow.newrow("Sub-Category Identifier Replacement", "$1", str4, "PASS", driver);
            }
            else
            {
                datarow.newrow("Sub-Category Identifier Replacement", "$1", str4, "FAIL", driver);
            }
            if (str5 == "h1,h2 :first")
            {
                datarow.newrow("Sub Category mapping Selector", "h1,h2 :first", str5, "PASS", driver);
            }
            else
            {
                datarow.newrow("Sub-Category mapping Selector", "h1,h2 :first", str5, "FAIL", driver);
            }
            if (str6 == "#banner")
            {
                datarow.newrow("Sub-category mapping selector2", "#banner", str6, "PASS", driver);
            }
            else
            {
                datarow.newrow("Sub-category mapping selector2", "#banner", str6, "FAIL", driver);
            }

            #endregion
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception Not Expected", "", e, "FAIL");
            }
            new ProductScrape().productscrape(driver,datarow);
        }
    }
}