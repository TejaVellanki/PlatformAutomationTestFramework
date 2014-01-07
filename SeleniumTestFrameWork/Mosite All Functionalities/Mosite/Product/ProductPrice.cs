﻿using System;
using ObjectRepository;
using OpenQA.Selenium;
using WebDriver_Refining;

namespace MoBankUI

{
    internal class ProductPrice : Driverdefining
    {
        public void Price(IWebDriver driver, Datarow datarow)
        {
            try
            {
                string pg = driver.PageSource;
                string productprice = null;
                if (pg.Contains("user-scalable=yes"))
                {
                    productprice = CollectionMapV2.ProductPrice;
                }
                else
                {
                    productprice = CollectionMapV1.ProductPrice;
                }

                #region Product price

                // Product Price
                if (IsElementPresent(driver, By.ClassName(productprice)))
                {
                    string price = driver.FindElement(By.ClassName(productprice)).Text;
                    datarow.newrow("Product Price", "", price, "PASS", driver);
                }
                else if (!IsElementPresent(driver, By.Id(productprice)))
                {
                    datarow.newrow("Product Price", "Product Price is Expected", "Element Not Identified", "FAIL",
                                   driver);
                }
                else
                {
                    datarow.newrow("Product Price", "Product Price is Expected", "Product Is Not Displayed", "FAIL",
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