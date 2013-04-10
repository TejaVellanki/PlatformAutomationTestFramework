// Generated by .NET Reflector from C:\Program Files\Default Company Name\Selenium Test Tool\MoBankUI.exe
namespace MoBankUI
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selenium;
    using System;
    using System.Threading;
    
    internal class CategoryScrape
    {
        public void ScarpeCategory(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            driver.FindElement(By.Id("SubPages_0__Name")).Clear();
            driver.FindElement(By.Id("SubPages_0__Name")).SendKeys("Sub-Categories");
            string[] Subcat = selenium.GetSelectOptions("SubPages_0__ObjectTypeName");
            foreach (string subca in Subcat)
            {
                new SelectElement(driver.FindElement(By.Id("SubPages_0__ObjectTypeName"))).SelectByText(subca);
                if (subca == "Category")
                {
                    break;
                }
            }
            driver.FindElement(By.Id("SubPages_0__ObjectTypeName")).SendKeys(Keys.Enter);
            driver.FindElement(By.Id("Selector")).Clear();
            driver.FindElement(By.Id("Selector")).SendKeys("/acatalog/gift-wrap.html");
            driver.FindElement(By.Id("Identifier")).Clear();
            driver.FindElement(By.Id("Identifier")).SendKeys("/acatalog/gift-wrap.html");
            driver.FindElement(By.Id("Selector")).Clear();
            driver.FindElement(By.Id("Selector")).SendKeys("#menu .lrga:gt(1)>a");
            driver.FindElement(By.Id("IdentifierTransformationPattern")).Clear();
            driver.FindElement(By.Id("IdentifierTransformationPattern")).SendKeys("\\/acatalog\\/([a-z0-9\\-_]*).html");
            driver.FindElement(By.Id("IdentifierTransformationReplacement")).Clear();
            driver.FindElement(By.Id("IdentifierTransformationReplacement")).SendKeys("$1");
            driver.FindElement(By.CssSelector("input.button")).Click();
            selenium.WaitForPageToLoad("30000");
        
            driver.FindElement(By.LinkText("Scrape Mappings")).Click();
            selenium.WaitForPageToLoad("30000");
            new SelectElement(driver.FindElement(By.Id("MappingId"))).SelectByText("(new mappings)");
            driver.FindElement(By.CssSelector("input.button")).Click();
            string[] data = selenium.GetSelectOptions("id=MappingItems_0__DataPath");
            foreach (string dat in data)
            {
                new SelectElement(driver.FindElement(By.Id("MappingItems_0__DataPath"))).SelectByText(dat);
                if (dat == "Name")
                {
                    break;
                }
            }
            driver.FindElement(By.Id("MappingItems_0__Selector")).Clear();
            driver.FindElement(By.Id("MappingItems_0__Selector")).SendKeys("a[class^='select']");
            string[] dta = selenium.GetSelectOptions("id=MappingItems_0__TransformationId");
            foreach (string aa in dta)
            {

                new SelectElement(driver.FindElement(By.Id("MappingItems_0__TransformationId"))).SelectByText(aa);
                if (aa == "Content Trim")
                {
                    break;
                }
            }
            driver.FindElement(By.CssSelector("input.button")).Click();
            #region Validations
            string attribute = driver.FindElement(By.Id("Selector")).GetAttribute("Value");
            string actual = driver.FindElement(By.Id("Identifier")).GetAttribute("Value");
            string str3 = driver.FindElement(By.CssSelector("#IdentifierTransformationPattern")).GetAttribute("Value");
            string str4 = driver.FindElement(By.CssSelector("#IdentifierTransformationReplacement")).GetAttribute("Value");
            string selectedLabel = selenium.GetSelectedLabel("id=MappingItems_0__DataPath");
            string str6 = selenium.GetSelectedLabel("MappingItems_0__TransformationId");
            string str7 = driver.FindElement(By.Id("MappingItems_0__Selector")).GetAttribute("Value");
            string str8 = driver.FindElement(By.Id("SubPages_0__Name")).GetAttribute("Value");
            string str9 = selenium.GetSelectedLabel("SubPages_0__ObjectTypeName");
            
            if (attribute == "#menu .lrga:gt(1)>a")
            {
                datarow.newrow("Selector", "#menu .lrga:gt(1)>a", attribute, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("Selector", "#menu .lrga:gt(1)>a", attribute, "FAIL", driver, selenium);
            }
            if (actual == "/acatalog/gift-wrap.html")
            {
                datarow.newrow("Identifier", "/acatalog/gift-wrap.html", actual, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("Identifier", "/acatalog/gift-wrap.html", actual, "FAIL", driver, selenium);
            }
            if (str3 == @"\/acatalog\/([a-z0-9\-_]*).html")
            {
                datarow.newrow("Identifier Tarnsformation pattern", @"\/acatalog\/([a-z0-9\-_]*).html", str3, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("Identifier Tarnsformation pattern", @"\/acatalog\/([a-z0-9\-_]*).html", str3, "FAIL", driver, selenium);
            }
            if (str4 == "$1")
            {
                datarow.newrow("Identifier Replacement", "$1", str4, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("Identifier Replacement", "$1", str4, "FAIL", driver, selenium);
            }
            if (selectedLabel == "Name")
            {
                datarow.newrow("DataPath", "Name", selectedLabel, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("DataPath", "Name", selectedLabel, "FAIL", driver, selenium);
            }
            if (str6 == "Content Trim")
            {
                datarow.newrow("Transformation ID", "Content Trim", str6, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("Transformation ID", "Content Trim", str6, "FAIL", driver, selenium);
            }
            if (str7 == "a[class^='select']")
            {
                datarow.newrow("Mapping Selector", "a[class^='select']", str7, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("Mapping Selector", "a[class^='select']", str7, "FAIL", driver, selenium);
            }
            if (str8 == "Sub-Categories")
            {
                datarow.newrow("Sub Pages", "Sub-Categories", str8, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("Sub Pages", "Sub-Categories", str8, "FAIL", driver, selenium);
            }
            if (str9 == "Category")
            {
                datarow.newrow("Sub Category Type", "Category", str9, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("Sub Category Type", "Category", str9, "FAIL", driver, selenium);
            }
            #endregion
            driver.FindElement(By.XPath("(//a[contains(text(),'…')])[2]")).Click();
            selenium.WaitForPageToLoad("30000");
            new SubCategory().subcategoryscrape(driver, selenium, datarow);
        }
    }
}
