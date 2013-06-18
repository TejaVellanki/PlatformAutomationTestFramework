using System;
using OpenQA.Selenium;
using Selenium;

namespace MoBankUI
{
    internal class shop
    {
        public void culture(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            try
            {
                driver.FindElement(By.LinkText("MoShop")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.CssSelector("#IndexMenuLeaf3 > a")).Click();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.LinkText("testshop")).Click();
                selenium.WaitForPageToLoad("30000");
                selenium.Click("link=Shop");
                selenium.WaitForPageToLoad("30000");
                try
                {
                    selenium.Click("css=h3.collapsible.collapsed");
                    selenium.WaitForPageToLoad("30000");
                    selenium.Click("css=h3.collapsible.collapsed");
                    selenium.WaitForPageToLoad("30000");
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                
                selenium.Type("id=CustomDomainName", "m.testshop.com");
                selenium.Click("css=input.button");
                selenium.WaitForPageToLoad("30000");
                selenium.Select("id=DefaultCultureSelected", "label=Telugu (India) - ₹ [te-IN]");
                driver.FindElement(By.CssSelector("input.button")).Click();
                selenium.WaitForPageToLoad("30000");
                selenium.Open("http://m.testshop.com");
                selenium.WaitForPageToLoad("30000");
                string url = selenium.GetLocation();
                if (url == "m.testshop.com")
                {
                    datarow.newrow("Customa Domain Name", "m.testshop.com", url, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Customa Domain Name", "m.testshop.com", url, "FAIL", driver, selenium);
                }

                selenium.Click("css=img");
                selenium.WaitForPageToLoad("30000");
                selenium.Click("//body[@id='page-home-index']/div/div[2]/div/ul/li/div/div/a");
                selenium.WaitForPageToLoad("30000");
                selenium.Click("//body[@id='page-categories-details']/div/div[2]/div/ul/li/div/div/a");
                selenium.WaitForPageToLoad("30000");
                selenium.Click("//body[@id='page-categories-details']/div/div[2]/div/ul/li/div/div/a/p[2]");
                selenium.WaitForPageToLoad("30000");
                string price = selenium.GetText("css=p.price");
                if (price.Contains("₹"))
                {
                    datarow.newrow("Culture Validation", "₹", price, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Culture Validation", "₹", price, "FAIL", driver, selenium);
                }
            }

            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Exopected", e, "PASS", driver, selenium);
            }
        }
    }
}