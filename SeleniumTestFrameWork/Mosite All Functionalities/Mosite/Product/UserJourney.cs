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
        private readonly Screenshot screenshot = new Screenshot();
        //General user journey to the checkout page
        [Test]
        public void UserJourn(Datarow datarow, IWebDriver driver, string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);

                string categorylink = null;
                string cat = null;
                string products = null;
                string productlink = null;
                var URL = driver.PageSource;
                if (URL.Contains("user-scalable=yes"))
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

                var Image = new Imagevalidation();
                var footer = new FooterTps();

                Image.homepageimage(driver, datarow);
                driver.Navigate().GoToUrl(url);

                Thread.Sleep(5000);
                new CookieDisclosure().Cookie(driver, datarow);

                var myDynamicElement1 = driver.FindElement(By.XPath("" + categorylink + "" + cat + ""));
                driver.FindElement(By.XPath("" + categorylink + "" + cat + "")).Click();

                var title = driver.Title;

                // Activate After Debug
                Image.categoryimage(driver, datarow);

                // footer.Footer(driver, datarow);
                var categorycount = GetXpathCount(driver, categorylink);


                if (IsElementPresent(driver, By.XPath("" + categorylink + "[" + 1 + "]" + cat + "")))
                {
                    //*[@id="productList"]/article[1]/a/div[1]/img
                    var location = driver.Url;
                    // Category Image validation
                    Image.categoryimage(driver, datarow);
                    driver.FindElement(By.XPath("" + categorylink + "[" + 1 + "]" + cat + "")).Click();

                    var titlecategory = driver.Title;
                    var url1 = driver.Url;
                    if (IsElementPresent(driver, By.XPath("" + products + "[" + 1 + "]" + productlink + "")))
                    {
                        var url2 = driver.Title;
                        driver.FindElement(By.XPath("" + products + "" + productlink + "")).Click();
                    }
                }


                var prod = new ProductsTps();
                prod.product(driver, datarow);

                var BasketPage = driver.PageSource;
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Exception Is Not Expected", e, "FAIL", driver);
                screenshot.screenshotfailed(driver);
            }
        }
    }
}