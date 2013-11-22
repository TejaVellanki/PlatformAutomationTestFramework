using System;
using ObjectRepository;
using WebDriver_Refining;
using MoBankUI;
using OpenQA.Selenium;

namespace MoBankUI

{
    class ProductPrice :driverdefining
    {

       
        public void price(IWebDriver driver, datarow datarow)
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
                datarow.newrow("Product Price", "Product Price is Expected", "Element Not Identified", "FAIL", driver);
            }
            else
            {
                datarow.newrow("Product Price", "Product Price is Expected", "Product Is Not Displayed", "FAIL", driver);
            }

            #endregion

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            new SocialMediaSharing().socialmediashare(driver,datarow);
        }

    }
}
