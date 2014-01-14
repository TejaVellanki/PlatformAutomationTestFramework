using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MoBankUI.MoShop
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

                var title = driver.Title;
                datarow.Newrow("Test Shop Title", "Shop : mobank.co.uk/MoShop", title,
                    title == "Shop : mobank.co.uk/MoShop" ? "PASS" : "FAIL", driver);

                if (driver.FindElement(By.Id("IsOffLine")).Enabled)
                {
                    datarow.Newrow("Shop Offline", "Shop should be offline", "Shop is Offline", "PASS", driver);
                    driver.FindElement(By.Id("IsOffLine")).Click();
                }
                else
                {
                    datarow.Newrow("Shop Offline", "Shop should be offline", "Shop is not set to Offline", "FAIL",
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
                    datarow.Newrow("Default Catalogue Selection", "Default Catalogue is expected to be selected",
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
                var e = ex.ToString();
                datarow.Newrow("Exception in Test Shop Page", "Exception not Expected", e, "FAIL");
            }
        }
    }
}