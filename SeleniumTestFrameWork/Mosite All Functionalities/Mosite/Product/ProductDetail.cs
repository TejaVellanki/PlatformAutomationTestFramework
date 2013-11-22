using System;
using ObjectRepository;
using WebDriver_Refining;
using System.Windows.Forms.VisualStyles;
using MoBankUI;
using OpenQA.Selenium;

namespace MoBankUI
{
    class ProductDetail : driverdefining
    {
        public void productdetail(IWebDriver driver, datarow datarow) 
        {

            string productdescription = null;
            string productdescriptiontab = null;
            string Detail = null;
              string pg = driver.PageSource;
         
            if (pg.Contains("user-scalable=yes"))
            {
                productdescription = CollectionMapV2.productDescription;
                productdescriptiontab = CollectionMapV2.ProductDescriptiontab;
                Detail = CollectionMapV2.detail;
            }
            else
            {
                Detail = CollectionMapV1.detail;
                productdescription = CollectionMapV1.productDescription;
                productdescriptiontab = CollectionMapV1.ProductDescriptiontab;
                
            }

         

            #region Product Detail

            try
            {
                //.Click(productdescriptiontab);

                if (IsElementPresent(driver, By.XPath(productdescription)))
                {
                    string detail = driver.FindElement(By.XPath(Detail)).Text;
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
                        string detail = driver.FindElement(By.XPath(Detail)).Text;
                        datarow.newrow("Product Detail", "", detail, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Product Detail", "Product Details are Expected",
                                       "Product Details Not identified", "FAIL", driver);
                    }
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }

            #endregion
        }
    }
}
