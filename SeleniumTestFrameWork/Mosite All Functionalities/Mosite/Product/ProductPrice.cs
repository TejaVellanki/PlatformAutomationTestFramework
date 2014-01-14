using System;
using MoBankUI.ObjectRepository;
using OpenQA.Selenium;

namespace MoBankUI.Mosite.Product

{
    internal class ProductPrice : Driverdefining
    {
        public void Price(IWebDriver driver, Datarow datarow)
        {
            try
            {
                var pg = driver.PageSource;
                var productprice = pg.Contains("user-scalable=yes") ? CollectionMapV2.ProductPrice : CollectionMapV1.ProductPrice;

                #region Product price

                // Product Price
                if (IsElementPresent(driver, By.ClassName(productprice)))
                {
                    var price = driver.FindElement(By.ClassName(productprice)).Text;
                    datarow.Newrow("Product Price", "", price, "PASS", driver);
                }
                else if (!IsElementPresent(driver, By.Id(productprice)))
                {
                    datarow.Newrow("Product Price", "Product Price is Expected", "Element Not Identified", "FAIL",
                                   driver);
                }
                else
                {
                    datarow.Newrow("Product Price", "Product Price is Expected", "Product Is Not Displayed", "FAIL",
                                   driver);
                }

                #endregion
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            new SocialMediaSharing().Socialmediashare(driver, datarow);
        }
    }
}