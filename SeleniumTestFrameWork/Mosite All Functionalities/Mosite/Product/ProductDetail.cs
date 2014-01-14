using System;
using MoBankUI.ObjectRepository;
using OpenQA.Selenium;

namespace MoBankUI.Mosite.Product
{
    internal class ProductDetail : Driverdefining
    {
        public void Productdetail(IWebDriver driver, Datarow datarow)
        {
            string productdescription;
            string productdescriptiontab;
            string Detail;
            var pg = driver.PageSource;

            if (pg.Contains("user-scalable=yes"))
            {
                productdescription = CollectionMapV2.ProductDescription;
                productdescriptiontab = CollectionMapV2.ProductDescriptiontab;
                Detail = CollectionMapV2.Detail;
            }
            else
            {
                Detail = CollectionMapV1.Detail;
                productdescription = CollectionMapV1.ProductDescription;
                productdescriptiontab = CollectionMapV1.ProductDescriptiontab;
            }

            #region Product Detail

            try
            {
                //.Click(productdescriptiontab);

                if (IsElementPresent(driver, By.XPath(productdescription)))
                {
                    var detail = driver.FindElement(By.XPath(Detail)).Text;
                    datarow.newrow("Product Detail", "", detail, "PASS", driver);
                }
                else if (!IsElementPresent(driver, By.XPath(productdescriptiontab)))
                {
                    datarow.newrow("Product Detail", "Product Details Element Is Expected",
                                   "Product Detail Element Not identified", "FAIL", driver);
                }
                else
                {
                    driver.FindElement(By.XPath(productdescriptiontab)).Click();
                    if (IsElementPresent(driver, By.XPath(productdescription)))
                    {
                        var detail = driver.FindElement(By.XPath(Detail)).Text;
                        datarow.newrow("Product Detail", "", detail, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Product Detail", "Product Details are Expected",
                                       "Product Details Not identified", "FAIL", driver);
                    }
                }
            }
            catch (Exception)
            {
            }

            #endregion
        }
    }
}