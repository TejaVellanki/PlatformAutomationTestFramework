using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium;
using OpenQA.Selenium.Support.UI;


namespace MoBankUI
{
    class createShop
    {
        public void Testshop(IWebDriver driver,ISelenium selenium,datarow datarow)
        {
            try
            {

                driver.FindElement(By.LinkText("Shops")).Click();
                selenium.WaitForPageToLoad("30000");

                driver.FindElement(By.LinkText("Create")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("Name")).Clear();
                driver.FindElement(By.Id("Name")).SendKeys("Test Shop");
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

                driver.FindElement(By.Id("Catalogues_1__Name")).Clear();
                driver.FindElement(By.Id("Catalogues_1__Name")).SendKeys("Default");
                driver.FindElement(By.CssSelector("input.button")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.Id("DefaultCatalogueId")).Click();
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
