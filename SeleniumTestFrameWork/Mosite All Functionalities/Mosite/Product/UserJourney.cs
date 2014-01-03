﻿using System;
using System.Threading;
using NUnit.Framework;
using ObjectRepository;
using OpenQA.Selenium;
using WebDriver_Refining;

//using System.Drawing;

namespace MoBankUI
{
    public class UserJourney_TPS : driverdefining
    {
        private readonly Screenshot screenshot = new Screenshot();
        //General user journey to the checkout page
        [Test]
        public void UserJourn(datarow datarow, IWebDriver driver, string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);

                string categorylink = null;
                string cat = null;
                string products = null;
                string productlink = null;
                string URL = driver.PageSource;
                if (URL.Contains("user-scalable=yes"))
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

                var Image = new Imagevalidation();
                var footer = new Footer_TPS();

                Image.homepageimage(driver, datarow);
                driver.Navigate().GoToUrl(url);

                Thread.Sleep(5000);
                new CookieDisclosure().cookie(driver, datarow);

                IWebElement myDynamicElement1 = driver.FindElement(By.XPath("" + categorylink + "" + cat + ""));
                driver.FindElement(By.XPath("" + categorylink + "" + cat + "")).Click();

                string title = driver.Title;

                // Activate After Debug
                Image.categoryimage(driver, datarow);

                // footer.Footer(driver, datarow);
                decimal categorycount = GetXpathCount(driver, categorylink);


                if (IsElementPresent(driver, By.XPath("" + categorylink + "[" + 1 + "]" + cat + "")))
                {
                    //*[@id="productList"]/article[1]/a/div[1]/img
                    string location = driver.Url;
                    // Category Image validation
                    Image.categoryimage(driver, datarow);
                    driver.FindElement(By.XPath("" + categorylink + "[" + 1 + "]" + cat + "")).Click();

                    string titlecategory = driver.Title;
                    string url1 = driver.Url;
                    if (IsElementPresent(driver, By.XPath("" + products + "[" + 1 + "]" + productlink + "")))
                    {
                        string url2 = driver.Title;
                        driver.FindElement(By.XPath("" + products + "" + productlink + "")).Click();
                    }
                }


                var prod = new products_TPS();
                prod.product(driver, datarow);

                string BasketPage = driver.PageSource;
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Is Not Expected", e, "FAIL", driver);
                screenshot.screenshotfailed(driver);
            }
        }
    }
}