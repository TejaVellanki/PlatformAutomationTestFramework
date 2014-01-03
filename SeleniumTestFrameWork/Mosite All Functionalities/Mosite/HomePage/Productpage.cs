using System;
using System.Collections.Generic;
using ObjectRepository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;

namespace MoBankUI
{
    internal class Productpage : driverdefining
    {
        public void productPage(IWebDriver driver, datarow datarow)
        {
            string url = driver.PageSource;

            string productprice = null;
            string productVarinat = null;
            string productdescription = null;
            string productdescriptiontab = null;
            string producttitle = null;
            string Detail = null;


            var Image = new Imagevalidation();
            var screenshot = new Screenshot();

            if (url.Contains("user-scalable=yes"))
            {
                productprice = CollectionMapV2.ProductPrice;
                productdescription = CollectionMapV2.productDescription;
                productdescriptiontab = CollectionMapV2.ProductDescriptiontab;
                producttitle = CollectionMapV2.producttitle;
                Detail = CollectionMapV2.detail;
                productVarinat = CollectionMapV2.productVariant;
            }
            else
            {
                productprice = CollectionMapV1.ProductPrice;
                productdescription = CollectionMapV1.productDescription;
                productdescriptiontab = CollectionMapV1.ProductDescriptiontab;
                producttitle = CollectionMapV1.producttitle;
                Detail = CollectionMapV1.detail;
                productVarinat = CollectionMapV1.productVariant;
            }


            try
            {
                string price = driver.FindElement(By.XPath(productprice)).Text;
                datarow.newrow("Product Price", "", price, "PASS", driver);
            }
            catch (Exception)
            {
                throw;
            }

            //Deleted Click and  Expand Details Tab

            try
            {
                string detail = driver.FindElement(By.XPath(Detail)).Text;
                datarow.newrow("Product Detail", "", detail, "PASS", driver);
            }
            catch (Exception)
            {
                throw;
            }


            try
            {
                string titles = driver.FindElement(By.XPath(producttitle)).Text;
                datarow.newrow("Product Title", "", titles, "PASS", driver);
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                if (IsElementPresent(driver, By.Id("" + productVarinat + ""), 30))
                {
                    try
                    {
                        decimal couent =
                            driver.FindElements(
                                By.XPath(
                                    "//html/body/div/div[2]/div/div[4]/form/ul/li[2]/fieldset/div[2]/div/label/span"))
                                  .Count;

                        if (couent != 1)
                        {
                            IWebElement element = driver.FindElement(By.Id("" + productVarinat + ""));
                            IList<IWebElement> AllDropDownList = element.FindElements(By.XPath("option"));


                            string values = null;
                            foreach (IWebElement value in AllDropDownList)
                            {
                                if (value.Text != "Please Select")
                                {
                                    values = values + "\r\n" + value;
                                    new SelectElement(driver.FindElement(By.Id(productVarinat))).SelectByText(value.Text);
                                }
                            }
                            datarow.newrow("Variants", "", values, "PASS", driver);
                        }

                        else
                        {
                            string varinats = driver.FindElement(By.Id("" + productVarinat + "")).GetAttribute("Value");
                            datarow.newrow("Variants", "", varinats, "PASS", driver);
                        }
                    }
                    catch (Exception ex)
                    {
                        string e = ex.ToString();

                        datarow.newrow("Exception Not Expected", "Exception Not Expected", e, "FAIL");
                    }
                }

                else if (IsElementPresent(driver, By.Id("" + productVarinat + "_0"), 30))
                {
                    string values = null;
                    for (int q = 1;; q++)
                    {
                        if (IsElementPresent(driver, By.Id("" + productVarinat + "" + q + ""), 30))
                        {
                            string varinats = driver.FindElement(By.Id("" + productVarinat + "" + q + "")).Text;
                            if (varinats != "Please Select" || varinats != null)
                            {
                                values = values + "\r\n" + varinats;
                                driver.FindElement(By.Id("" + productVarinat + "" + q + "")).Click();
                            }
                        }

                        else
                        {
                            break;
                        }
                    }
                    datarow.newrow("Variants", "", values, "PASS", driver);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}