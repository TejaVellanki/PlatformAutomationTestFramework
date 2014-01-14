using System;
using MoBankUI.ObjectRepository;
using OpenQA.Selenium;

namespace MoBankUI.Mosite.HomePage
{
    internal class LinksExpand : Driverdefining
    {
        public void AllLink(IWebDriver driver, Datarow datarow)
        {
            var url = driver.PageSource;
            string categorylink;
            string cat;
            string products;
            string productlink;
            if (url.Contains("user-scalable=yes"))
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
            // This method counts the categories,sub-categories, product pages and validate every product link
            var screenshot = new Screenshot();

            try
            {
                var Image = new Imagevalidation();
                //Home Page Image validation

                Image.Homepageimage(driver, datarow);
                //Counting the number of Categories 
                decimal linkcount = driver.FindElements(By.XPath(categorylink)).Count;
                if (linkcount == 0)
                {
                    datarow.newrow("Category Validation in Home Page", "Atleast One Category/product is Expected",
                                   "No Categories/Products are Identified", "FAIL", driver);
                }
                var j = 0;
                var s = 1;

                //Running the loop through the category links
                for (var i = 1; i <= linkcount; i++)
                {
                    try
                    {
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                        driver.FindElement(By.XPath("" + categorylink + "[" + i + "]" + cat + ""));
                        driver.FindElement(By.XPath("" + categorylink + "[" + i + "]" + cat + "")).Click();
                    }
                    catch (Exception ex)
                    {
                        var e = ex.ToString();
                        datarow.newrow("Category Element Exception", "Exception Not Expected", e, "FAIL", driver);
                        screenshot.Screenshotfailed(driver);
                    }
                    var categorycount = GetXpathCount(driver, categorylink);
                    if (categorycount == 0)
                    {
                        datarow.newrow("Category Validation in  Page", "Atleast One Category/product",
                                       "No Categories/Products", "FAIL", driver);
                        screenshot.Screenshotfailed(driver);
                    }
                    //Running the loop through sub category pages. 
                    for (var k = 1; ; k++)
                    {
                        try
                        {
                            if (IsElementPresent(driver, By.XPath("" + categorylink + "[" + k + "]" + cat + "")))
                            {
                                //*[@id="productList"]/article[1]/a/div[1]/img
                                // Category Image validation
                                Image.categoryimage(driver, datarow);
                                driver.FindElement(By.XPath("" + categorylink + "[" + k + "]" + cat + "")).Click();

                                var titlecategory = driver.Title;

                                // Sub-Category Image validation
                                Image.subcategoryimage(driver, datarow);

                                try
                                {
                                    if (IsElementPresent(driver,
                                                         By.XPath("" + products + "[" + 1 + "]" + productlink + "")))
                                    {
                                        datarow.newrow("Product Title", "", titlecategory, "PASS", driver);
                                        //This is to test the product page
                                        var productcount = GetXpathCount(driver, products);
                                        for (var p = 1; p <= productcount; p++)
                                        {
                                            driver.FindElement(By.XPath("" + products + "[" + p + "]" + productlink + ""))
                                                  .Click();


                                            var page = new Productpage();
                                            page.ProductPage(driver, datarow);


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
                                    var e = exc.ToString();
                                    datarow.newrow("Exception For Product Details", "Exception Not Expected", e, "FAIL",
                                                   driver);
                                    screenshot.Screenshotfailed(driver);
                                }
                            }

                            k = s;
                            driver.Navigate().Back();

                            s++;
                            var url2 = driver.Url;
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
                            var e = ex.ToString();
                            datarow.newrow("Category/Product Link Exception", "Exception Not Expected", e, "FAIL",
                                           driver);
                            screenshot.Screenshotfailed(driver);
                        }
                    }

                    j++;

                    //driver.Navigate().Back();
                    //  
                }
            }
            catch (Exception)
            {
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver);
                screenshot.Screenshotfailed(driver);
            }
        }
    }
}