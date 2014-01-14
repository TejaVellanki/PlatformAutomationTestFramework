using System;
using System.Threading;
using MoBankUI.ObjectRepository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

//using System.Drawing;

namespace MoBankUI.Mosite.Product
{
    internal class ProductsTps : Driverdefining
    {
        private readonly Screenshot _screenshot = new Screenshot();
        //Product page validations
        public void Product(IWebDriver driver, Datarow datarow)
        {
            var image = new Imagevalidation();
            try
            {
                var url = driver.PageSource;


                string producttitle;
                string addToBasket;
                string checkout;
                string basketvalue;
                var screenshot1 = new Screenshot();

                #region object reading

                if (url.Contains("user-scalable=yes"))
                {
                    producttitle = CollectionMapV2.Producttitle;
                    addToBasket = CollectionMapV2.addtobasket;
                    checkout = CollectionMapV2.Checkout;
                    basketvalue = BasketV2.basketvalue;
                }
                else
                {
                    producttitle = CollectionMapV1.Producttitle;
                    addToBasket = CollectionMapV1.Addtobasket;
                    checkout = CollectionMapV1.Checkout;
                    basketvalue = BasketV1.basketvalue;
                }

                #endregion

                image.productImage(driver, datarow);
                new ProductDetail().Productdetail(driver, datarow);
                new ProductPrice().Price(driver, datarow);

                #region Product Title

                // Product Title
                var title = driver.FindElement(By.ClassName(producttitle)).Text;
                datarow.Newrow("Product Title", "", title, "PASS", driver);

                if (IsElementPresent(driver, By.ClassName(producttitle)) == false)
                {
                    datarow.Newrow("Product Title", "Product Title Element is Expected",
                                   "Product Title Element Not Found", "FAIL", driver);
                }

                #endregion

                #region Product Variant

                /*
                // Product Variants
                if(IsElementPresent(driver,By.Id("" + productVarinat + "")))
                {
                    try
                    {
                        decimal couent =GetXpathCount(driver,"//html/body/div/div[2]/div/div[4]/form/ul/li[2]/fieldset/div[2]/div/label/span");

                        if (couent != 1)
                        {
                                  IWebElement con = driver.FindElement(By.Id(" + productVarinat + "));
                                  IList<IWebElement> selectOptions = con.FindElements(By.TagName("option"));
                         
                            string values = null;
                            foreach (IWebElement value in selectOptions)
                            {
                                if (value.Text != "Please Select")
                                {
                                    values = values + "\r\n" + value;
                                    new SelectElement(driver.FindElement(By.Id(productVarinat))).SelectByText(value.Text);
                                }
                            }
                            datarow.newrow("Variants", "", values, "PASS",driver);
                        }

                        else
                        {
                            string varinats = GetValue(driver, By.Id("" + productVarinat + ""));
                            datarow.newrow("Variants", "", varinats, "PASS",driver);
                        }
                    }
                    catch (Exception ex)
                    {
                        string e = ex.ToString();

                        datarow.newrow("Exception Not Expected", "Exception Not Expected", e, "FAIL");
                    }
                }

                else if(IsElementPresent(driver,By.Id("" + productVarinat + "_0")))
                {
                    try
                    {
                        string values = null;
                        for (int q = 1;; q++)
                        {
                            if (IsElementPresent(driver,By.Id("" + productVarinat + "" + q + "")))
                            {
                                string varinats =  driver.FindElement(By.Id("" + productVarinat + "" + q + "")).Text;
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
                        datarow.newrow("Variants", "", values, "PASS",driver);
                    }
                    catch (Exception ex)
                    {
                        string e = ex.ToString();
                        throw;
                    }
                }
                else
                {
                    datarow.newrow("Variants", "", "No Variants", "PASS", driver);
                }

                #endregion

                #region V2 Product Variant

                if (url.Contains("user-scalable=yes"))
                {
                    if (IsElementPresent(driver,By.XPath("//a[@id='showOptions']/span")))
                    {
                        driver.FindElement(By.XPath("//a[@id='showOptions']/span")).Click();
                        
                   
                        IWebElement con = driver.FindElement(By.Id("Variants_1__OptionValue"));
                         IList<IWebElement> vainats = con.FindElements(By.TagName("option"));
                       ;
                        string vales = null;
                        foreach (IWebElement value in vainats)
                        {
                            if (value.Text != "Please Select")
                            {
                                vales = vales + "\r\n" + value;
                                new SelectElement(driver.FindElement(By.Id("Variants_1__OptionValue"))).SelectByText(value.Text);
                            }
                        }

                        datarow.newrow("Variants", "", vales, "PASS",driver);
                        if (IsElementPresent(driver,By.Id("" + productvariant2 + "_0")))
                        {
                            string values = null;
                            for (int q = 1;; q++)
                            {
                                if (IsElementPresent(driver,By.Id("" + productvariant2 + "_" + q + "")))
                                {
                                    string varinats =  driver.FindElement(By.Id("" + productvariant2 + "_" + q + "")).Text;
                                    if (varinats != "Please Select" || varinats != null)
                                    {
                                        values = values + "\r\n" + varinats;
                                        driver.FindElement(By.Id("" + productvariant2 + "_" + q + "")).Click();
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
*/

                #endregion

                try
                {
                    driver.FindElement(By.XPath(addToBasket)).Click();

                    datarow.Newrow("Add to Basket Button", "Add To Basket Button is Expected",
                                   addToBasket + "Add To Basket Element Is Present", "PASS", driver);
                    new SuccessMessage().Message(driver, datarow);
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    datarow.Newrow("Add to Basket Button", "Add To Basket Button is Expected", e, "FAIL", driver);
                    screenshot1.Screenshotfailed(driver);
                }


                var basval = driver.FindElement(By.XPath(basketvalue)).Text;

                if (basval == "(1)")
                {
                    datarow.Newrow("Basket Value", "(1)", basval, "PASS", driver);
                }
                else
                {
                    datarow.Newrow("Basket Value", "(1)", basval, "FAIL", driver);
                    screenshot1.Screenshotfailed(driver);
                }

                //Footer_TPS footer = new Footer_TPS();
                //footer.Footer(driver, datarow);

                driver.FindElement(By.Id("BasketInfo")).Click();

                new SelectElement(driver.FindElement(By.Id("Items_0__Quantity")));


                // driver.FindElement(By.Id()).Click();("css=option");
                var pric = driver.FindElement(By.CssSelector("strong")).Text;
                new SelectElement(driver.FindElement(By.Id("Items_0__Quantity"))).SelectByText("4");


                Thread.Sleep(3000);
                var prirc = driver.FindElement(By.CssSelector("strong")).Text;

                datarow.Newrow("Price Change with Quantity in Basket Page", pric, prirc, pric == prirc ? "FAIL" : "PASS",
                    driver);

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath(checkout));
                if (url.Contains("user-scalable=yes") == false)
                {
                    var value1 = driver.FindElement(By.Id("BasketInfo")).Text;

                    if (value1 == "(4)")
                    {
                        datarow.Newrow("Basket Value", "(4)", value1, "PASS", driver);
                    }
                    else
                    {
                        datarow.Newrow("Basket Value", "(4)", value1, "FAIL", driver);
                        screenshot1.Screenshotfailed(driver);
                    }
                }
                new SelectElement(driver.FindElement(By.Id("Items_0__Quantity")));
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.Newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                _screenshot.Screenshotfailed(driver);
            }
        }
    }
}