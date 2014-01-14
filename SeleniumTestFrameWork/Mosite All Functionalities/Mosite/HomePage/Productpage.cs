using System;
using System.Collections.Generic;
using System.Linq;
using MoBankUI.ObjectRepository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MoBankUI.Mosite.HomePage
{
    internal class Productpage : Driverdefining
    {
        public void ProductPage(IWebDriver driver, Datarow datarow)
        {
            var url = driver.PageSource;

            string productprice;
            string productVarinat;
            string producttitle;
            string detaiL;


            new Imagevalidation();
            new Screenshot();

            if (url.Contains("user-scalable=yes"))
            {
                productprice = CollectionMapV2.ProductPrice;
                producttitle = CollectionMapV2.Producttitle;
                detaiL = CollectionMapV2.Detail;
                productVarinat = CollectionMapV2.ProductVariant;
            }
            else
            {
                productprice = CollectionMapV1.ProductPrice;
                producttitle = CollectionMapV1.Producttitle;
                detaiL = CollectionMapV1.Detail;
                productVarinat = CollectionMapV1.ProductVariant;
            }


            var price = driver.FindElement(By.XPath(productprice)).Text;
            datarow.Newrow("Product Price", "", price, "PASS", driver);

            //Deleted Click and  Expand Details Tab

            var detail = driver.FindElement(By.XPath(detaiL)).Text;
            datarow.Newrow("Product Detail", "", detail, "PASS", driver);


            var titles = driver.FindElement(By.XPath(producttitle)).Text;
            datarow.Newrow("Product Title", "", titles, "PASS", driver);

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
                        var element = driver.FindElement(By.Id("" + productVarinat + ""));
                        IList<IWebElement> AllDropDownList = element.FindElements(By.XPath("option"));


                        string values = null;
                        foreach (var value in AllDropDownList.Where(value => value.Text != "Please Select"))
                        {
                            values = values + "\r\n" + value;
                            new SelectElement(driver.FindElement(By.Id(productVarinat))).SelectByText(value.Text);
                        }
                        datarow.Newrow("Variants", "", values, "PASS", driver);
                    }

                    else
                    {
                        var varinats = driver.FindElement(By.Id("" + productVarinat + "")).GetAttribute("Value");
                        datarow.Newrow("Variants", "", varinats, "PASS", driver);
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();

                    datarow.Newrow("Exception Not Expected", "Exception Not Expected", e, "FAIL");
                }
            }

            else if (IsElementPresent(driver, By.Id("" + productVarinat + "_0"), 30))
            {
                string values = null;
                for (var q = 1;; q++)
                {
                    if (IsElementPresent(driver, By.Id("" + productVarinat + "" + q + ""), 30))
                    {
                        var varinats = driver.FindElement(By.Id("" + productVarinat + "" + q + "")).Text;
                        values = values + "\r\n" + varinats;
                        driver.FindElement(By.Id("" + productVarinat + "" + q + "")).Click();
                    }

                    else
                    {
                        break;
                    }
                }
                datarow.Newrow("Variants", "", values, "PASS", driver);
            }
        }
    }
}