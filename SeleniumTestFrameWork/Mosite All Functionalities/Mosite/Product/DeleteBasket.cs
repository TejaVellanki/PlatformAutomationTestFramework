using System;
using OpenQA.Selenium;
using Selenium;
//using System.Drawing;

namespace MoBankUI
{
    internal class DeleteBasket_TPS
    {
        private readonly Screenshot screenshot = new Screenshot();

        public void basket(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            try
            {
                if (selenium.IsElementPresent("//ul[@id='Basket']/li/a/span"))
                {
                    driver.FindElement(By.XPath("//ul[@id='Basket']/li/a/span")).Click();
                    selenium.WaitForPageToLoad("30000");

                    string value = driver.FindElement(By.Id("BasketInfo")).Text;

                    if (value == "(0)")
                    {
                        datarow.newrow("Delete Basket Value", "(0)", value, "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrow("Delete Basket Value", "(0)", value, "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                    selenium.Click("//*[@id='UpdateBasketForm']/div/div[2]/a/span/span");
                    selenium.WaitForPageToLoad("30000");

                    selenium.Click("css=img");
                    selenium.WaitForPageToLoad("30000");
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    IWebElement myDynamicElement1 =
                        driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li/div/div/a/h2"));
                    driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li/div/div/a/h2")).Click();
                    selenium.WaitForPageToLoad("30000");
                    string title = driver.Title;

                    decimal categorycount = selenium.GetXpathCount("//html/body/div/div[2]/div/ul/li");
                    for (int i = 1;; i++)
                    {
                        if (selenium.IsElementPresent("//html/body/div/div[2]/div/ul/li/div/div/a/h2"))
                        {
                            driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li/div/div/a/h2")).Click();
                            selenium.WaitForPageToLoad("30000");
                            string titlecategory = driver.Title;
                            string url1 = selenium.GetLocation();

                            if (url1.Contains("category"))
                            {
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    var prd = new products_TPS();
                    prd.product(driver, selenium, datarow);
                }
                else
                {
                    datarow.newrow("Delete From Basket", "Delete Basket Element Expected",
                                   "//ul[@id='Basket']/li/a/span" + "Element Not Present", "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
            }

            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }
    }
}