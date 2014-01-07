using System;
using MoBankUI.ObjectRepository;
using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI.Mosite.Product
{
    internal class DeleteBasket : Driverdefining
    {
        private readonly Screenshot _screenshot = new Screenshot();

        public void basket(IWebDriver driver, Datarow datarow)
        {
            try
            {
                var url = driver.PageSource;
                var deletebasket = url.Contains("user-scalable=yes") ? CollectionMapV2.deletebasket : CollectionMapV1.deletebasket;
                /*
                if (IsElementPresent(driver,By.XPath("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span"),05))
                {
                    driver.FindElement(By.XPath("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span")).Click();
                    
                    basketvalidation(driver, datarow);
                }#
                 */
                if (IsElementPresent(driver, By.XPath(deletebasket)))
                {
                    driver.FindElement(By.XPath(deletebasket)).Click();

                    basketvalidation(driver, datarow);
                }
                else
                {
                    datarow.newrow("Delete From Basket", "Delete Basket Element Expected",
                                   "//ul[@id='Basket']/li/a/span" + "Element Not Present", "FAIL", driver);
                    _screenshot.screenshotfailed(driver);
                }
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                _screenshot.screenshotfailed(driver);
            }
        }


        private void basketvalidation(IWebDriver driver, Datarow datarow)
        {
            string products;
            string productlink;
            string categorylink;
            string cat;
            string homeimage;
            var url = driver.PageSource;

            if (url.Contains("user-scalable=yes"))
            {
                categorylink = CollectionMapV2.Categorylink;
                cat = CollectionMapV2.cat;
                products = CollectionMapV2.products;
                homeimage = CollectionMapV2.homeimage;
                productlink = CollectionMapV2.productlink;
            }
            else
            {
                categorylink = CollectionMapV1.Categorylink;
                cat = CollectionMapV1.Cat;
                products = CollectionMapV1.products;
                homeimage = CollectionMapV1.homeimage;
                productlink = CollectionMapV1.productlink;
            }
            try
            {
                if (!url.Contains("user-scalable=yes"))
                {
                    var value = driver.FindElement(By.Id("BasketInfo")).Text;

                    if (value == "(0)")
                    {
                        datarow.newrow("Delete Basket Value", "(0)", value, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Delete Basket Value", "(0)", value, "FAIL", driver);
                        _screenshot.screenshotfailed(driver);
                    }
                }
                //.Click("//*[@id='UpdateBasketForm']/div/div[2]/a/span/span");
                // waitforpagetoload("30000");


                driver.FindElement(By.ClassName(homeimage)).Click();

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                var myDynamicElement1 = driver.FindElement(By.XPath("" + categorylink + "" + cat + ""));
                driver.FindElement(By.XPath("" + categorylink + "" + cat + "")).Click();

                var title = driver.Title;

                decimal categorycount = driver.FindElements(By.XPath(categorylink)).Count;
                for (var i = 1;; i++)
                {
                    if (IsElementPresent(driver, By.XPath("" + categorylink + "" + cat + ""), 30))
                    {
                        driver.FindElement(By.XPath("" + categorylink + "" + cat + "")).Click();

                        var titlecategory = driver.Title;
                        var url1 = driver.Url;

                        if (IsElementPresent(driver, By.XPath(products), 30))
                        {
                            driver.FindElement(By.XPath("" + products + "" + productlink + "")).Click();
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
                var prd = new ProductsTps();
                prd.product(driver, datarow);
                driver.FindElement(By.XPath("//a[@id='GoToCheckout']/span/span")).Click();
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                _screenshot.screenshotfailed(driver);
            }
        }
    }
}