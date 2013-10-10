using System;
using System.Threading;
using NUnit.Framework;
using ObjectRepository;
using OpenQA.Selenium;
using WebDriver_Refining;

//using System.Drawing;

namespace MoBankUI
{
    public class Deletebasketstart : driverdefining
    {
        private readonly Screenshot screenshot = new Screenshot();

        [Test]
        public void deletebasstart(IWebDriver driver, datarow datarow)
        {
            try
            {
                string checkout = null;
                string url = driver.PageSource;
                if (url.Contains("smallDevice"))
                {
                    checkout = CollectionMapV2.checkout;
                }
                else
                {
                    checkout = CollectionMapV1.checkout;
                }

                var basket = new DeleteBasket();
                basket.basket(driver, datarow);

                var js = (IJavaScriptExecutor) driver;
                js.ExecuteScript("window.scrollBy(0,400)");
                js.ExecuteScript("window.scrollBy(0,80)");
                driver.FindElement(By.XPath(checkout)).Click();
                waitforpagetoload(driver,30000);
                Thread.Sleep(2000);
                // Product unavailable
                if ( driver.PageSource.Contains("Product unavailable"))
                {
                    for (int l = 2;; l++)
                    {
                        if ( driver.PageSource.Contains("Product unavailable"))
                        {
                            datarow.newrow("Product Unavailable", "", "Product Unavilable", "FAIL",driver);
                            screenshot.screenshotfailed(driver);
                            productunavailabl(driver,l, datarow);
                            driver.FindElement(By.XPath(checkout)).Click();
                            waitforpagetoload(driver,30000);
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
                datarow.newrow("Exception", "Not Expected", e, "FAIL",driver);
                screenshot.screenshotfailed(driver);
            }
        }

        //Tests if the product is Unavailable
         [Test]
        public void productunavailabl(IWebDriver driver , int l, datarow datarow)
        {
            string deletebasket = null;
            string products = null;
            string productlink = null;
            string categorylink = null;
            string cat = null;
            string homeimage = null;
            string url = driver.PageSource;
            if (url.Contains("smallDevice"))
            {
                deletebasket = CollectionMapV2.deletebasket;
                homeimage = CollectionMapV2.homeimage;
            }
            else
            {
                deletebasket = CollectionMapV1.deletebasket;
                homeimage = CollectionMapV1.homeimage;
            }
            //body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span

            try
            {
                if (IsElementPresent(driver,By.XPath("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span")))
                {
                    driver.FindElement(By.XPath("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span")).Click();
                    waitforpagetoload(driver,30000);
                }
                else if (IsElementPresent(driver,By.Id(deletebasket)))
                {
                    driver.FindElement(By.XPath(deletebasket)).Click();
                    waitforpagetoload(driver,30000);
                }
                driver.FindElement(By.Id(homeimage)).Click();
                waitforpagetoload(driver,30000);

                string url1 = driver.PageSource;
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
                waitforpagetoload(driver,30000);
                decimal categorycount = GetXpathCount(driver,categorylink);
                for (int i = 1;; i++)
                {
                    if (IsElementPresent(driver,By.XPath("" + categorylink + "[" + l + "]" + cat + "")))
                    {
                        driver.FindElement(By.XPath("" + categorylink + "[" + l + "]" + cat + "")).Click();
                        waitforpagetoload(driver,30000);
                        string titlecategory = driver.Title;

                        if (IsElementPresent(driver,By.XPath(products)))
                        {
                            driver.FindElement(By.Id("" + products + "" + productlink + "")).Click();
                            waitforpagetoload(driver,30000);
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                var product = new products_TPS();
                product.product(driver, datarow);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Not Expected", e, "FAIL",driver);
                screenshot.screenshotfailed(driver);
            }
        }
    }
}