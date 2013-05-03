using System;
using System.Threading;
using OpenQA.Selenium;
using Selenium;
//using System.Drawing;

namespace MoBankUI
{
    internal class Deletebasketstart
    {
        private readonly Screenshot screenshot = new Screenshot();

        public void deletebasstart(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            try
            {
                var basket = new DeleteBasket_TPS();
                basket.basket(driver, selenium, datarow);

                var js = (IJavaScriptExecutor) driver;
                js.ExecuteScript("window.scrollBy(0,400)");
                js.ExecuteScript("window.scrollBy(0,80)");
                driver.FindElement(By.Id("GoToCheckout")).Click();
                selenium.WaitForPageToLoad("30000");
                Thread.Sleep(2000);
                // Product unavailable
                if (selenium.IsTextPresent("Product unavailable"))
                {
                    for (int l = 2;; l++)
                    {
                        if (selenium.IsTextPresent("Product unavailable"))
                        {
                            datarow.newrow("Product Unavailable", "", "Product Unavilable", "FAIL", driver, selenium);
                            screenshot.screenshotfailed(driver, selenium);
                            productunavailabl(selenium, driver, l, datarow);
                            driver.FindElement(By.XPath("//a[@id='GoToCheckout']/span")).Click();
                            selenium.WaitForPageToLoad("30000");
                        }

                        else
                        {
                            break;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }

        //Tests if the product is Unavailable
        public void productunavailabl(ISelenium selenium, IWebDriver driver, int l, datarow datarow)
        {
//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span


            try
            {
                if (selenium.IsElementPresent("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span"))
                {
                    selenium.Click("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span");
                    selenium.WaitForPageToLoad("30000");
                }
                else if (selenium.IsElementPresent("//ul[@id='Basket']/li/a/span"))
                {
                    driver.FindElement(By.XPath("//ul[@id='Basket']/li/a/span")).Click();
                    selenium.WaitForPageToLoad("30000");
                }
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
                    if (selenium.IsElementPresent("//html/body/div/div[2]/div/ul/li[" + l + "]/div/div/a/h2"))
                    {
                        driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li[" + l + "]/div/div/a/h2")).Click();
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
                    else
                    {
                        break;
                    }
                }
                var product = new products_TPS();
                product.product(driver, selenium, datarow);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }
    }
}