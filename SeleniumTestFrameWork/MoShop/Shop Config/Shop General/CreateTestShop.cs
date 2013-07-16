using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium;

namespace MoBankUI
{
   public class createShop
    {
       [Test]
        public void Testshop(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            try
            {
               
                string shop = "testshop";
                driver.FindElement(By.LinkText("Shops")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.LinkText("Create")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("Name")).Clear();
                driver.FindElement(By.Id("Name")).SendKeys(shop);
                driver.FindElement(By.CssSelector("input.button")).Click();
                selenium.WaitForPageToLoad("30000");
                string title = driver.Title;
                if (title == "Shop : mobank.co.uk/MoShop")
                {
                    datarow.newrow("Test Shop Title", "Shop : mobank.co.uk/MoShop", title, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Test Shop Title", "Shop : mobank.co.uk/MoShop", title, "FAIL", driver, selenium);
                }

                if (selenium.IsChecked("id=IsOffLine"))
                {
                    datarow.newrow("Shop Offline", "Shop should be offline", "Shop is Offline", "PASS", driver, selenium);
                    driver.FindElement(By.Id("IsOffLine")).Click();
                }
                else
                {
                    datarow.newrow("Shop Offline", "Shop should be offline", "Shop is not set to Offline", "FAIL",driver, selenium);
                }
                driver.FindElement(By.Id("IsOffLine")).Click();
                driver.FindElement(By.Id("IsOffLine")).Click();

                driver.FindElement(By.Id("Catalogues_1__Name")).Clear();
                driver.FindElement(By.Id("Catalogues_1__Name")).SendKeys("Default");
                driver.FindElement(By.CssSelector("input.button")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("DefaultCatalogueId")).Click();
                driver.FindElement(By.CssSelector("input.button")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("DefaultCatalogueId")).Click();
                driver.FindElement(By.CssSelector("input.button")).Click();
                selenium.WaitForPageToLoad("30000");
                if (selenium.IsChecked("id=DefaultCatalogueId"))
                {
                    datarow.newrow("Default Catalogue Selection", "Default Catalogue is expected to be selected","Default Catalogue is selected", "PASS", driver, selenium);
                }
                else
                {
                    driver.FindElement(By.Id("DefaultCatalogueId")).Click();
                    driver.FindElement(By.CssSelector("input.button")).Click();
                    selenium.WaitForPageToLoad("30000");
                }

                // Adding 30 mins Cache for the Site
                driver.FindElement(By.Id("CacheLength")).SendKeys("30");
                driver.FindElement(By.CssSelector("input.button")).Click();
                selenium.WaitForPageToLoad("30000");


                driver.FindElement(By.LinkText("Look & Feel")).Click();
                selenium.WaitForPageToLoad("30000");
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
        }
    }
}