using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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


            
                decimal count = selenium.GetXpathCount("//div[@id='CataloguesControl']/div/table/tbody/tr");
                for (int i = 1; i <= count; i++)
                {

                    string name =selenium.GetValue("//div[@id='CataloguesControl']/div/table/tbody/tr[" + i + "]/td/input");
                    if (name == "Default")
                    {
                        driver.FindElement(By.XPath("//*[@id='CataloguesControl']/div/table/tbody/tr["+i+"]/th[2]/a")).Click();
                        driver.FindElement(By.CssSelector("input.button")).Click();
                        selenium.WaitForPageToLoad("30000");
                        new SelectElement(driver.FindElement(By.Id("Culture_Value"))).SelectByText("Telugu (India) - ₹ [te-IN]");
                        driver.FindElement(By.CssSelector("input.button")).Click();
                        selenium.WaitForPageToLoad("30000");
                        break;
                        

                    }
                }

                selenium.Open("http://m.testshop.com");
                selenium.WaitForPageToLoad("30000");
                string url = selenium.GetLocation();
                if (url == "http://m.testshop.com")
                {
                    datarow.newrow("Customa Domain Name", "http://m.testshop.com/", url, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Customa Domain Name", "http://m.testshop.com/", url, "FAIL", driver, selenium);
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