using System;
using ObjectRepository;
using WebDriver_Refining;
using OpenQA.Selenium;
    

//using System.Drawing;

namespace MoBankUI
{
    internal class DeleteBasket :driverdefining
    {
        private readonly Screenshot screenshot = new Screenshot();

        public void basket(IWebDriver driver, datarow datarow)
        {
            try
            {
                string deletebasket = null;
                string url = driver.PageSource;
                if (url.Contains("smallDevice"))
                {
                    deletebasket = CollectionMapV2.deletebasket;
                }
                else
                {
                    deletebasket = CollectionMapV1.deletebasket;
                }
                if (IsElementPresent(driver,By.XPath("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span"),30))
                {
                    driver.FindElement(By.XPath("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span")).Click();
                    waitforpagetoload(driver,30000);
                    basketvalidation(driver, datarow);
                }
                else if (IsElementPresent(driver,By.XPath(deletebasket),30))
                {
                    driver.FindElement(By.XPath(deletebasket)).Click();
                      waitforpagetoload(driver,30000);
                    basketvalidation(driver, datarow);
                }
                else
                {
                    datarow.newrow("Delete From Basket", "Delete Basket Element Expected",
                                   "//ul[@id='Basket']/li/a/span" + "Element Not Present", "FAIL",driver);
                    screenshot.screenshotfailed(driver);
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL",driver);
                screenshot.screenshotfailed(driver);
            }
        }


        private void basketvalidation(IWebDriver driver, datarow datarow)
        {
            string products = null;
            string productlink = null;
            string categorylink = null;
            string cat = null;
            string homeimage = null;
            string url = driver.PageSource;

            if (url.Contains("smallDevice"))
            {
                categorylink = CollectionMapV2.categorylink;
                cat = CollectionMapV2.cat;
                products = CollectionMapV2.products;
                homeimage = CollectionMapV2.homeimage;
                productlink = CollectionMapV2.productlink;
            }
            else
            {
                categorylink = CollectionMapV1.categorylink;
                cat = CollectionMapV1.cat;
                products = CollectionMapV1.products;
                homeimage = CollectionMapV1.homeimage;
                productlink = CollectionMapV1.productlink;
            }
            try
            {
                if (!url.Contains("smallDevice"))
                {
                    string value = driver.FindElement(By.Id("BasketInfo")).Text;

                    if (value == "(0)")
                    {
                        datarow.newrow("Delete Basket Value", "(0)", value, "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Delete Basket Value", "(0)", value, "FAIL",driver);
                        screenshot.screenshotfailed(driver);
                    }
                }
                //.Click("//*[@id='UpdateBasketForm']/div/div[2]/a/span/span");
                // waitforpagetoload("30000");


                driver.FindElement(By.CssSelector(homeimage)).Click(); 
                  waitforpagetoload(driver,30000);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement1 = driver.FindElement(By.XPath("" + categorylink + "" + cat + ""));
                driver.FindElement(By.XPath("" + categorylink + "" + cat + "")).Click();
                  waitforpagetoload(driver,30000);
                string title = driver.Title;

                decimal categorycount = driver.FindElements(By.XPath(categorylink)).Count;
                for (int i = 1;; i++)
                {
                    if (IsElementPresent(driver,By.XPath("" + categorylink + "" + cat + ""),30))
                    {
                        driver.FindElement(By.XPath("" + categorylink + "" + cat + "")).Click();
                        waitforpagetoload(driver,30000);
                        string titlecategory = driver.Title;
                        string url1 = driver.Url;

                        if (IsElementPresent(driver,By.XPath(products),30))
                        {
                            driver.FindElement(By.XPath("" + products + "" + productlink + "")).Click();
                              waitforpagetoload(driver,30000);
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
                var prd = new products_TPS();
                prd.product(driver, datarow);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL",driver);
                screenshot.screenshotfailed(driver);
            }
        }
    }
}