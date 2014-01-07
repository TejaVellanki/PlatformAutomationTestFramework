﻿using System;
using ObjectRepository;
using OpenQA.Selenium;
using WebDriver_Refining;

namespace MoBankUI
{
    internal class LinksExpand : Driverdefining
    {
        public void AllLink(IWebDriver driver, Datarow datarow)
        {
            string url = driver.PageSource;
            string categorylink = null;
            string cat = null;
            string products = null;
            string productlink = null;
            if (url.Contains("user-scalable=yes"))
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
            // This method counts the categories,sub-categories, product pages and validate every product link
            var screenshot = new Screenshot();

            try
            {
                var Image = new Imagevalidation();
                //Home Page Image validation

                Image.homepageimage(driver, datarow);
                //Counting the number of Categories 
                decimal linkcount = driver.FindElements(By.XPath(categorylink)).Count;
                if (linkcount == 0)
                {
                    datarow.newrow("Category Validation in Home Page", "Atleast One Category/product is Expected",
                                   "No Categories/Products are Identified", "FAIL", driver);
                }
                int j = 0;
                int s = 1;

                //Running the loop through the category links
                for (int i = 1; i <= linkcount; i++)
                {
                    try
                    {
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                        IWebElement myDynamicElement1 =
                            driver.FindElement(By.XPath("" + categorylink + "[" + i + "]" + cat + ""));
                        driver.FindElement(By.XPath("" + categorylink + "[" + i + "]" + cat + "")).Click();

                        string title = driver.Title;
                    }
                    catch (Exception ex)
                    {
                        string e = ex.ToString();
                        datarow.newrow("Category Element Exception", "Exception Not Expected", e, "FAIL", driver);
                        screenshot.screenshotfailed(driver);
                    }
                    decimal categorycount = GetXpathCount(driver, categorylink);
                    if (categorycount == 0)
                    {
                        datarow.newrow("Category Validation in  Page", "Atleast One Category/product",
                                       "No Categories/Products", "FAIL", driver);
                        screenshot.screenshotfailed(driver);
                    }
                    //Running the loop through sub category pages. 
                    for (int k = 1;; k++)
                    {
                        try
                        {
                            if (IsElementPresent(driver, By.XPath("" + categorylink + "[" + k + "]" + cat + "")))
                            {
                                //*[@id="productList"]/article[1]/a/div[1]/img
                                string location = driver.Url;
                                // Category Image validation
                                Image.categoryimage(driver, datarow);
                                driver.FindElement(By.XPath("" + categorylink + "[" + k + "]" + cat + "")).Click();

                                string titlecategory = driver.Title;
                                string url1 = driver.Url;

                                // Sub-Category Image validation
                                Image.subcategoryimage(driver, datarow);

                                try
                                {
                                    if (IsElementPresent(driver,
                                                         By.XPath("" + products + "[" + 1 + "]" + productlink + "")))
                                    {
                                        datarow.newrow("Product Title", "", titlecategory, "PASS", driver);
                                        //This is to test the product page
                                        decimal productcount = GetXpathCount(driver, products);
                                        for (int p = 1; p <= productcount; p++)
                                        {
                                            driver.FindElement(By.XPath("" + products + "[" + p + "]" + productlink + ""))
                                                  .Click();

                                            try
                                            {
                                                var page = new Productpage();
                                                page.ProductPage(driver, datarow);
                                            }
                                            catch (Exception ex)
                                            {
                                                string e = ex.ToString();
                                            }

                                            driver.Navigate().Back();
                                        }
                                    }
                                    else
                                    {
                                        datarow.newrow("Category Title", "", titlecategory, "PASS", driver);
                                        k = 0;
                                    }
                                }
                                catch (Exception exc)
                                {
                                    string e = exc.ToString();
                                    datarow.newrow("Exception For Product Details", "Exception Not Expected", e, "FAIL",
                                                   driver);
                                    screenshot.screenshotfailed(driver);
                                }
                            }

                            k = s;
                            driver.Navigate().Back();

                            s++;
                            string url2 = driver.Url;
                            if (url2.Contains("category"))
                            {
                                datarow.newrow("Category URL", "", url2, "PASS", driver);
                            }
                            else
                            {
                                s = 1;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            string e = ex.ToString();
                            datarow.newrow("Category/Product Link Exception", "Exception Not Expected", e, "FAIL",
                                           driver);
                            screenshot.screenshotfailed(driver);
                        }
                    }

                    j++;

                    //driver.Navigate().Back();
                    //  
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver);
                screenshot.screenshotfailed(driver);
            }
        }
    }
}