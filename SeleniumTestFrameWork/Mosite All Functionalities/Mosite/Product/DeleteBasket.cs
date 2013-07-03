using System;
using ObjectRepository;
using OpenQA.Selenium;
using Selenium;

//using System.Drawing;

namespace MoBankUI
{
    internal class DeleteBasket
    {
        private readonly Screenshot screenshot = new Screenshot();

        public void basket(IWebDriver driver, ISelenium selenium, datarow datarow)
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
                if (selenium.IsElementPresent("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span"))
                {
                    selenium.Click("//body[@id='Top']/div/div[2]/div[2]/ul/li[2]/a/span");
                    selenium.WaitForPageToLoad("30000");
                    basketvalidation(driver, selenium, datarow);
                }
                else if (selenium.IsElementPresent(deletebasket))
                {
                    driver.FindElement(By.XPath(deletebasket)).Click();
                    selenium.WaitForPageToLoad("30000");
                    basketvalidation(driver, selenium, datarow);
                }
                else
                {
                    datarow.newrow("Delete From Basket", "Delete Basket Element Expected",
                                   "//ul[@id='Basket']/li/a/span" + "Element Not Present", "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }


        private void basketvalidation(IWebDriver driver, ISelenium selenium, datarow datarow)
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
                        datarow.newrow("Delete Basket Value", "(0)", value, "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrow("Delete Basket Value", "(0)", value, "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                }
                //selenium.Click("//*[@id='UpdateBasketForm']/div/div[2]/a/span/span");
                //  selenium.WaitForPageToLoad("30000");


                selenium.Click(homeimage);
                selenium.WaitForPageToLoad("30000");
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement1 = driver.FindElement(By.XPath("" + categorylink + "" + cat + ""));
                driver.FindElement(By.XPath("" + categorylink + "" + cat + "")).Click();
                selenium.WaitForPageToLoad("30000");
                string title = driver.Title;

                decimal categorycount = selenium.GetXpathCount(categorylink);
                for (int i = 1;; i++)
                {
                    if (selenium.IsElementPresent("" + categorylink + "" + cat + ""))
                    {
                        driver.FindElement(By.XPath("" + categorylink + "" + cat + "")).Click();
                        selenium.WaitForPageToLoad("30000");
                        string titlecategory = driver.Title;
                        string url1 = selenium.GetLocation();

                        if (selenium.IsElementPresent(products))
                        {
                            selenium.Click("" + products + "" + productlink + "");
                            selenium.WaitForPageToLoad("30000");
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
                prd.product(driver, selenium, datarow);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }
    }
}