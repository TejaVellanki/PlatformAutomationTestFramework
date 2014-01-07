using System;
using MoBankUI.ObjectRepository;
using NUnit.Framework;
using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI.Mosite.Product
{
    public class Deletebasketstart : Driverdefining
    {
        private readonly Screenshot _screenshot = new Screenshot();

        [Test]
        public void deletebasstart(IWebDriver driver, Datarow datarow)
        {
            try
            {
                var url = driver.PageSource;
                var checkout = url.Contains("user-scalable=yes") ? CollectionMapV2.checkout : CollectionMapV1.checkout;

                var basket = new DeleteBasket();
                basket.basket(driver, datarow);

                // Product unavailable
                if (!driver.PageSource.Contains("Product unavailable")) return;
                for (var l = 2;; l++)
                {
                    if (driver.PageSource.Contains("Product unavailable"))
                    {
                        datarow.newrow("Product Unavailable", "", "Product Unavilable", "FAIL", driver);
                        _screenshot.screenshotfailed(driver);
                        productunavailabl(driver, l, datarow);
                        driver.FindElement(By.XPath(checkout)).Click();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Not Expected", e, "FAIL", driver);
                _screenshot.screenshotfailed(driver);
            }
        }

        //Tests if the product is Unavailable
        [Test]
        public void productunavailabl(IWebDriver driver, int l, Datarow datarow)
        {
            string deletebasket;
            string homeimage;
            var url = driver.PageSource;

            if (url.Contains("user-scalable=yes"))
            {
                deletebasket = CollectionMapV2.deletebasket;
                homeimage = CollectionMapV2.homeimage;
            }
            else
            {
                deletebasket = CollectionMapV1.deletebasket;
                homeimage = CollectionMapV1.homeimage;
            }

            try
            {
                if (IsElementPresent(driver, By.XPath("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span")))
                {
                    driver.FindElement(By.XPath("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span")).Click();
                }
                else if (IsElementPresent(driver, By.Id(deletebasket)))
                {
                    driver.FindElement(By.XPath(deletebasket)).Click();
                }
                driver.FindElement(By.Id(homeimage)).Click();


                var url1 = driver.PageSource;
                string products;
                string productlink;
                string categorylink;
                string cat;
                if (url1.Contains("user-scalable=yes"))
                {
                    categorylink = CollectionMapV2.Categorylink;
                    cat = CollectionMapV2.cat;
                    products = CollectionMapV2.products;
                    productlink = CollectionMapV2.productlink;
                }
                else
                {
                    categorylink = CollectionMapV1.Categorylink;
                    cat = CollectionMapV1.Cat;
                    products = CollectionMapV1.products;
                    productlink = CollectionMapV1.productlink;
                }
                //body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span


                driver.FindElement(By.XPath("" + categorylink + "" + cat + "")).Click();

                var categorycount = GetXpathCount(driver, categorylink);
                for (var i = 1;; i++)
                {
                    if (IsElementPresent(driver, By.XPath("" + categorylink + "[" + l + "]" + cat + "")))
                    {
                        driver.FindElement(By.XPath("" + categorylink + "[" + l + "]" + cat + "")).Click();

                        var titlecategory = driver.Title;

                        if (!IsElementPresent(driver, By.XPath(products))) continue;
                        driver.FindElement(By.Id("" + products + "" + productlink + "")).Click();
                    }
                    break;
                }
                var product = new ProductsTps();
                product.product(driver, datarow);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Not Expected", e, "FAIL", driver);
                _screenshot.screenshotfailed(driver);
            }
        }
    }
}