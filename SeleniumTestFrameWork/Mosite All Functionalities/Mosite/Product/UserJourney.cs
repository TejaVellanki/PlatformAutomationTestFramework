using System;
using System.Threading;
using MoBankUI.Mosite.HomePage;
using MoBankUI.ObjectRepository;
using NUnit.Framework;
using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI.Mosite.Product
{
    public class UserJourneyTps : Driverdefining
    {
        private readonly Screenshot _screenshot = new Screenshot();
        //General user journey to the checkout page
        [Test]
        public void UserJourn(Datarow datarow, IWebDriver driver, string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);

                string categorylink;
                string cat;
                string products;
                string productlink;
                var uRl = driver.PageSource;
                if (uRl.Contains("user-scalable=yes"))
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

                var image = new Imagevalidation();
                new FooterTps();

                image.Homepageimage(driver, datarow);
                driver.Navigate().GoToUrl(url);

                Thread.Sleep(5000);
                new CookieDisclosure().Cookie(driver, datarow);

                driver.FindElement(By.XPath("" + categorylink + "" + cat + ""));
                driver.FindElement(By.XPath("" + categorylink + "" + cat + "")).Click();

                // Activate After Debug
                image.categoryimage(driver, datarow);

                // footer.Footer(driver, datarow);
                GetXpathCount(driver, categorylink);


                if (IsElementPresent(driver, By.XPath("" + categorylink + "[" + 1 + "]" + cat + "")))
                {
                    //*[@id="productList"]/article[1]/a/div[1]/img
                    // Category Image validation
                    image.categoryimage(driver, datarow);
                    driver.FindElement(By.XPath("" + categorylink + "[" + 1 + "]" + cat + "")).Click();

                    if (IsElementPresent(driver, By.XPath("" + products + "[" + 1 + "]" + productlink + "")))
                    {
                        driver.FindElement(By.XPath("" + products + "" + productlink + "")).Click();
                    }
                }


                var prod = new ProductsTps();
                prod.Product(driver, datarow);

                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Exception Is Not Expected", e, "FAIL", driver);
                _screenshot.Screenshotfailed(driver);
            }
        }
    }
}