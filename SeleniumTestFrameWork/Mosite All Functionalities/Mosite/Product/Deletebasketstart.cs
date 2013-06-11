using System;
using System.Threading;
using ObjectRepository;
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
                string checkout = null;
                string url = driver.PageSource.ToString();
                if (url.Contains("smallDevice"))
                {
                    checkout = CollectionMapV2.checkout;
                }
                else
                {
                    checkout = CollectionMapV1.checkout;
                }
            
                var basket = new DeleteBasket();
                basket.basket(driver, selenium, datarow);

                var js = (IJavaScriptExecutor) driver;
                js.ExecuteScript("window.scrollBy(0,400)");
                js.ExecuteScript("window.scrollBy(0,80)");
                driver.FindElement(By.XPath(checkout)).Click();
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
                            driver.FindElement(By.XPath(checkout)).Click();
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
            string deletebasket = null;
            string products = null;
            string productlink = null;
            string categorylink = null;
            string cat = null;
            string homeimage = null;
            string url = driver.PageSource.ToString();
            if (url.Contains("smallDevice"))
            {            
               
                deletebasket= CollectionMapV2.deletebasket;
                homeimage = CollectionMapV2.homeimage;
            }
            else
            {
                deletebasket= CollectionMapV1.deletebasket;
                homeimage = CollectionMapV1.homeimage;
            }
              //body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span

            try
            {
                if (selenium.IsElementPresent("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span"))
                {
                    selenium.Click("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span");
                    selenium.WaitForPageToLoad("30000");
                }
                else if (selenium.IsElementPresent(deletebasket))
                {
                    driver.FindElement(By.XPath(deletebasket)).Click();
                    selenium.WaitForPageToLoad("30000");
                }
                selenium.Click(homeimage);
                selenium.WaitForPageToLoad("30000");
               
                string url1 = driver.PageSource.ToString();
                if (url1.Contains("smallDevice"))
                {

                    categorylink = CollectionMapV2.categorylink;
                    cat = CollectionMapV2.cat;
                    products = CollectionMapV2.products;
                    productlink = CollectionMapV2.productlink;
                }
                else
                {
                    categorylink = CollectionMapV1.categorylink;
                    cat = CollectionMapV1.cat;
                    products = CollectionMapV1.products;
                    productlink = CollectionMapV1.productlink;
                }
                //body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span

               
                driver.FindElement(By.XPath("" + categorylink + "" + cat + "")).Click();
                selenium.WaitForPageToLoad("30000");
                decimal categorycount = selenium.GetXpathCount(categorylink);
                for (int i = 1;; i++)
                {
                    if (selenium.IsElementPresent(""+categorylink+"[" + l + "]"+cat+""))
                    {
                        driver.FindElement(By.XPath(""+ categorylink + "[" + l + "]" + cat + "")).Click();
                        selenium.WaitForPageToLoad("30000");
                        string titlecategory = driver.Title;

                        if (selenium.IsElementPresent(products))
                        {
                            selenium.Click(""+products+""+productlink+"");
                            selenium.WaitForPageToLoad("30000");
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