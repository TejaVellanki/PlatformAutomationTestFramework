﻿using System;
using System.Threading;
using NUnit.Framework;
using ObjectRepository;
using OpenQA.Selenium;
using Selenium;

//using System.Drawing;

namespace MoBankUI
{
    public class UserJourney_TPS
    {
        private readonly Screenshot screenshot = new Screenshot();
        //General user journey to the checkout page
        [Test]
        public void UserJourn(datarow datarow, IWebDriver driver, ISelenium selenium, string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                selenium.WaitForPageToLoad("30000");
                string categorylink = null;
                string cat = null;
                string products = null;
                string productlink = null;
                string URL = driver.PageSource;
                if (URL.Contains("smallDevice"))
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
                driver.Navigate().Back();
                driver.Navigate().GoToUrl(url);

                // Image.homepageimage(driver, selenium, datarow);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement1 = driver.FindElement(By.XPath("" + categorylink + "" + cat + ""));
                driver.FindElement(By.XPath("" + categorylink + "" + cat + "")).Click();
                selenium.WaitForPageToLoad("30000");
                string title = driver.Title;


                // Activate After Debug
                // Image.categoryimage(driver, selenium, datarow);
                // footer.Footer(driver, selenium, datarow);
                decimal categorycount = selenium.GetXpathCount(categorylink);


                if (selenium.IsElementPresent("" + categorylink + "[" + 1 + "]" + cat + ""))
                {
                    //*[@id="productList"]/article[1]/a/div[1]/img
                    string location = selenium.GetLocation();
                    // Category Image validation
                    Image.categoryimage(driver, selenium, datarow);
                    driver.FindElement(By.XPath("" + categorylink + "[" + 1 + "]" + cat + "")).Click();
                    selenium.WaitForPageToLoad("30000");
                    string titlecategory = driver.Title;
                    string url1 = selenium.GetLocation();
                    if (selenium.IsElementPresent("" + products + "[" + 1 + "]" + productlink + ""))
                    {
                        string url2 = driver.Title;
                        selenium.Click("" + products + "" + productlink + "");
                        selenium.WaitForPageToLoad("30000");
                    }
                }


                var prod = new products_TPS();
                prod.product(driver, selenium, datarow);

                string BasketPage = driver.PageSource;
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Is Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }
    }
}