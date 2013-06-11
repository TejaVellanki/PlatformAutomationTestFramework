using System;
using ObjectRepository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium;

namespace MoBankUI
{
    internal class Productpage
    {
       

        public void productPage(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            string url = driver.PageSource.ToString();

            string productprice = null;
            string productVarinat = null;
            string productdescription = null;
            string productdescriptiontab = null;
            string producttitle = null;
            string Detail = null;


            var Image = new Imagevalidation();
            var screenshot = new Screenshot();

            if (url.Contains("smallDevice"))
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
                datarow.newrow("Product Price", "", price, "PASS", driver, selenium);
            }
            catch (Exception)
            {
                
                throw;
            }

            //Deleted Click and  Expand Details Tab

            try
            {
                string detail = selenium.GetText(Detail);
                datarow.newrow("Product Detail", "", detail, "PASS", driver, selenium);

            }
            catch (Exception)
            {
                
                throw;
            }





            try
            {
                string titles = selenium.GetText(producttitle);
                datarow.newrow("Product Title", "", titles, "PASS", driver, selenium);
            }
            catch (Exception)
            {
                
                throw;
            }

            try
            {

           
            if (selenium.IsElementPresent("id=" + productVarinat + ""))
            {
                try
                {
                    decimal couent =selenium.GetXpathCount("//html/body/div/div[2]/div/div[4]/form/ul/li[2]/fieldset/div[2]/div/label/span");

                    if (couent != 1)
                    {
                        string[] varinats =
                            selenium.GetSelectOptions("id=" + productVarinat + "");
                        string values = null;
                        foreach (string value in varinats)
                        {
                            if (value != "Please Select")
                            {
                                values = values + "\r\n" + value;
                                new SelectElement(driver.FindElement(By.Id(productVarinat))).SelectByText(value);
                            }
                        }
                        datarow.newrow("Variants", "", values, "PASS", driver, selenium);
                    }

                    else
                    {
                        string varinats = selenium.GetValue("id=" + productVarinat + "");
                        datarow.newrow("Variants", "", varinats, "PASS", driver, selenium);
                    }

                }
                catch (Exception ex)
                {
                    string e = ex.ToString();

                    datarow.newrow("Exception Not Expected","Exception Not Expected",e,"FAIL");
                }


            }

            else if (selenium.IsElementPresent("id=" + productVarinat + "_0"))
            {
                string values = null;
                for (int q = 1;; q++)
                {
                    if (selenium.IsElementPresent("id=" + productVarinat + "" + q + ""))
                    {
                        string varinats = selenium.GetText("id=" + productVarinat + "" + q + "");
                        if (varinats != "Please Select" || varinats != null)
                        {
                            values = values + "\r\n" + varinats;
                            selenium.Click("id=" + productVarinat + "" + q + "");
                        }
                    }

                    else
                    {
                        break;
                    }
                }
                datarow.newrow("Variants", "", values, "PASS", driver, selenium);
            }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}