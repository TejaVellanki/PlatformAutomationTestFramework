using System;
using System.Collections.Generic;
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
            string Detail;


            var Image = new Imagevalidation();
            var screenshot = new Screenshot();

            if (url.Contains("user-scalable=yes"))
            {
                productprice = CollectionMapV2.ProductPrice;
                producttitle = CollectionMapV2.producttitle;
                Detail = CollectionMapV2.detail;
                productVarinat = CollectionMapV2.productVariant;
            }
            else
            {
                productprice = CollectionMapV1.ProductPrice;
                producttitle = CollectionMapV1.producttitle;
                Detail = CollectionMapV1.detail;
                productVarinat = CollectionMapV1.productVariant;
            }


            var price = driver.FindElement(By.XPath(productprice)).Text;
            datarow.newrow("Product Price", "", price, "PASS", driver);

            //Deleted Click and  Expand Details Tab

            var detail = driver.FindElement(By.XPath(Detail)).Text;
            datarow.newrow("Product Detail", "", detail, "PASS", driver);


            var titles = driver.FindElement(By.XPath(producttitle)).Text;
            datarow.newrow("Product Title", "", titles, "PASS", driver);

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
                        foreach (var value in AllDropDownList)
                        {
                            if (value.Text == "Please Select") continue;
                            values = values + "\r\n" + value;
                            new SelectElement(driver.FindElement(By.Id(productVarinat))).SelectByText(value.Text);
                        }
                        datarow.newrow("Variants", "", values, "PASS", driver);
                    }

                    else
                    {
                        var varinats = driver.FindElement(By.Id("" + productVarinat + "")).GetAttribute("Value");
                        datarow.newrow("Variants", "", varinats, "PASS", driver);
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();

                    datarow.newrow("Exception Not Expected", "Exception Not Expected", e, "FAIL");
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
                        if (false) continue;
                        values = values + "\r\n" + varinats;
                        driver.FindElement(By.Id("" + productVarinat + "" + q + "")).Click();
                    }

                    else
                    {
                        break;
                    }
                }
                datarow.newrow("Variants", "", values, "PASS", driver);
            }
        }
    }
}