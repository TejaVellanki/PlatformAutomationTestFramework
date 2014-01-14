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
        public void Deletebasstart(IWebDriver driver, Datarow datarow)
        {
            try
            {
                var url = driver.PageSource;
                var checkout = url.Contains("user-scalable=yes") ? CollectionMapV2.Checkout : CollectionMapV1.Checkout;

                var basket = new DeleteBasket();
                basket.Basket(driver, datarow);

                // Product unavailable
                if (!driver.PageSource.Contains("Product unavailable")) return;
                for (var l = 2;; l++)
                {
                    if (driver.PageSource.Contains("Product unavailable"))
                    {
                        datarow.newrow("Product Unavailable", "", "Product Unavilable", "FAIL", driver);
                        _screenshot.Screenshotfailed(driver);
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
                _screenshot.Screenshotfailed(driver);
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
                homeimage = CollectionMapV2.Homeimage;
            }
            else
            {
                deletebasket = CollectionMapV1.Deletebasket;
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
                    cat = CollectionMapV2.Cat;
                    products = CollectionMapV2.Products;
                    productlink = CollectionMapV2.Productlink;
                }
                else
                {
                    categorylink = CollectionMapV1.Categorylink;
                    cat = CollectionMapV1.Cat;
                    products = CollectionMapV1.Products;
                    productlink = CollectionMapV1.Productlink;
                }
                //body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span


                driver.FindElement(By.XPath("" + categorylink + "" + cat + "")).Click();

                GetXpathCount(driver, categorylink);
                for (var i = 1;; i++)
                {
                    if (IsElementPresent(driver, By.XPath("" + categorylink + "[" + l + "]" + cat + "")))
                    {
                        driver.FindElement(By.XPath("" + categorylink + "[" + l + "]" + cat + "")).Click();

                        if (!IsElementPresent(driver, By.XPath(products))) continue;
                        driver.FindElement(By.Id("" + products + "" + productlink + "")).Click();
                    }
                    break;
                }
                var product = new ProductsTps();
                product.Product(driver, datarow);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Not Expected", e, "FAIL", driver);
                _screenshot.Screenshotfailed(driver);
            }
        }
    }
}