using System;
using NUnit.Framework;
using OpenQA.Selenium;
using WebDriver_Refining;

namespace MoBankUI
{
    public class CreateShop : Driverdefining
    {
        [Test]
        public void Testshop(IWebDriver driver, Datarow datarow)
        {
            try
            {
                const string shop = "testshop";
                driver.FindElement(By.LinkText("Shops")).Click();

                driver.FindElement(By.LinkText("Create")).Click();

                driver.FindElement(By.Id("Name")).Clear();
                driver.FindElement(By.Id("Name")).SendKeys(shop);
                driver.FindElement(By.CssSelector("input.button")).Click();

                string title = driver.Title;
                if (title == "Shop : mobank.co.uk/MoShop")
                {
                    datarow.newrow("Test Shop Title", "Shop : mobank.co.uk/MoShop", title, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Test Shop Title", "Shop : mobank.co.uk/MoShop", title, "FAIL", driver);
                }

                if (driver.FindElement(By.Id("IsOffLine")).Enabled)
                {
                    datarow.newrow("Shop Offline", "Shop should be offline", "Shop is Offline", "PASS", driver);
                    driver.FindElement(By.Id("IsOffLine")).Click();
                }
                else
                {
                    datarow.newrow("Shop Offline", "Shop should be offline", "Shop is not set to Offline", "FAIL",
                                   driver);
                }
                driver.FindElement(By.Id("IsOffLine")).Click();
                driver.FindElement(By.Id("IsOffLine")).Click();

                driver.FindElement(By.Id("Catalogues_1__Name")).Clear();
                driver.FindElement(By.Id("Catalogues_1__Name")).SendKeys("Default");
                driver.FindElement(By.CssSelector("input.button")).Click();

                driver.FindElement(By.Id("DefaultCatalogueId")).Click();
                driver.FindElement(By.CssSelector("input.button")).Click();

                driver.FindElement(By.Id("DefaultCatalogueId")).Click();
                driver.FindElement(By.CssSelector("input.button")).Click();

                if (driver.FindElement(By.Id("DefaultCatalogueId")).Enabled)
                {
                    datarow.newrow("Default Catalogue Selection", "Default Catalogue is expected to be selected",
                                   "Default Catalogue is selected", "PASS", driver);
                }
                else
                {
                    driver.FindElement(By.Id("DefaultCatalogueId")).Click();
                    driver.FindElement(By.CssSelector("input.button")).Click();
                }

                // Adding 30 mins Cache for the Site
                driver.FindElement(By.Id("CacheLength")).SendKeys("0");
                driver.FindElement(By.CssSelector("input.button")).Click();


                driver.FindElement(By.LinkText("Look & Feel")).Click();
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception in Test Shop Page", "Exception not Expected", e, "FAIL");
            }
        }
    }
}