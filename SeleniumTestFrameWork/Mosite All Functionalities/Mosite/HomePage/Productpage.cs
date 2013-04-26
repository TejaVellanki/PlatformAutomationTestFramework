using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectRepository;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Selenium;
/*
namespace MoBankUI
{
    class Productpage
    {
        private CollectionMapV2 str;
        public void productPage(IWebDriver driver, ISelenium selenium,datarow datarow)
        {
          
            var Image = new Imagevalidation();
            Screenshot screenshot = new Screenshot();
            
            #region Product Details

            string productdescription = str.productdescription;
            string productdescriptiontab = str.productdescriptiontab;
            string productVarinat = str.productVarinat;
            string productprice = str.productprice;
            string producttitle = str.producttitle;
            string Detail = str.Detail;
            

          
            if (selenium.IsElementPresent(productprice))
            {
                string price = driver.FindElement(By.XPath(productprice)).Text;
                datarow.newrow("Product Price", "", price, "PASS", driver, selenium);
            }

            //Clik and  Expand Details Tab

            selenium.Click(productdescriptiontab);

            if (selenium.IsElementPresent(productdescription))
            {
                string detail = selenium.GetText(Detail);
                datarow.newrow("Product Detail", "", detail, "PASS", driver, selenium);
            }


            if (selenium.IsElementPresent(producttitle))
            {
                string titles = selenium.GetText(producttitle);
                datarow.newrow("Product Title", "", titles, "PASS", driver, selenium);
            }

            if (selenium.IsElementPresent("id=" + productVarinat + ""))
            {
                decimal couent = selenium.GetXpathCount("//html/body/div/div[2]/div/div[4]/form/ul/li[2]/fieldset/div[2]/div/label/span");
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

            else if (selenium.IsElementPresent("id=" + productVarinat + "_0"))
            {
                string values = null;
                for (int q = 1; ; q++)
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

            #endregion

            
        }
    }
}
*/