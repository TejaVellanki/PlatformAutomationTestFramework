﻿using System;
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
                if (url.Contains("user-scalable=yes"))
                {
                    checkout = CollectionMapV2.checkout;
                }
                else
                {
                    checkout = CollectionMapV1.checkout;
                }

                var basket = new DeleteBasket();
                basket.basket(driver, datarow);
            
                // Product unavailable
                if (driver.PageSource.Contains("Product unavailable"))
                {
                    for (int l = 2;; l++)
                    {
                        if (driver.PageSource.Contains("Product unavailable"))
                        {
                            datarow.newrow("Product Unavailable", "", "Product Unavilable", "FAIL",driver);
                            screenshot.screenshotfailed(driver);
                            productunavailabl(driver,l, datarow);
                            driver.FindElement(By.XPath(checkout)).Click();
                            
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
             string homeimage = null;
            string url = driver.PageSource;

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
                if (IsElementPresent(driver,By.XPath("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span")))
                {
                    driver.FindElement(By.XPath("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span")).Click();
                    
                }
                else if (IsElementPresent(driver,By.Id(deletebasket)))
                {
                    driver.FindElement(By.XPath(deletebasket)).Click();
                    
                }
                driver.FindElement(By.Id(homeimage)).Click();
                

                string url1 = driver.PageSource;
                string products = null;
                string productlink = null;
                string categorylink = null;
                string cat = null;
                if (url1.Contains("user-scalable=yes"))
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
                
                decimal categorycount = GetXpathCount(driver,categorylink);
                for (int i = 1;; i++)
                {
                    if (IsElementPresent(driver,By.XPath("" + categorylink + "[" + l + "]" + cat + "")))
                    {
                        driver.FindElement(By.XPath("" + categorylink + "[" + l + "]" + cat + "")).Click();
                        
                        string titlecategory = driver.Title;

                        if (IsElementPresent(driver,By.XPath(products)))
                        {
                            driver.FindElement(By.Id("" + products + "" + productlink + "")).Click();
                            
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