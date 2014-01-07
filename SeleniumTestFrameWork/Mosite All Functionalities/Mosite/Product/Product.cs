using System;
using System.Threading;
using ObjectRepository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;

//using System.Drawing;

namespace MoBankUI
{
    internal class ProductsTps : Driverdefining
    {
        private readonly Screenshot screenshot = new Screenshot();
        //Product page validations
        public void product(IWebDriver driver, Datarow datarow)
        {
            var Image = new Imagevalidation();
            try
            {
                string url = driver.PageSource;


                string productVarinat = null;
                string producttitle = null;
                string AddToBasket = null;
                string checkout = null;
                string basketvalue = null;
                string productvariant2 = null;
                var screenshot = new Screenshot();

                #region object reading

                if (url.Contains("user-scalable=yes"))
                {
                    producttitle = CollectionMapV2.producttitle;
                    productVarinat = CollectionMapV2.productVariant;
                    productvariant2 = CollectionMapV2.productvariant2;
                    AddToBasket = CollectionMapV2.addtobasket;
                    checkout = CollectionMapV2.checkout;
                    basketvalue = BasketV2.basketvalue;
                }
                else
                {
                    producttitle = CollectionMapV1.producttitle;
                    productVarinat = CollectionMapV1.productVariant;
                    AddToBasket = CollectionMapV1.addtobasket;
                    checkout = CollectionMapV1.checkout;
                    basketvalue = BasketV1.basketvalue;
                }

                #endregion

                Image.productImage(driver, datarow);
                new ProductDetail().Productdetail(driver, datarow);
                new ProductPrice().Price(driver, datarow);

                #region Product Title

                // Product Title
                try
                {
                    string title = driver.FindElement(By.ClassName(producttitle)).Text;
                    datarow.newrow("Product Title", "", title, "PASS", driver);
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                }
                if (IsElementPresent(driver, By.ClassName(producttitle)) == false)
                {
                    datarow.newrow("Product Title", "Product Title Element is Expected",
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

                string product = driver.PageSource;
                try
                {
                    driver.FindElement(By.XPath(AddToBasket)).Click();

                    datarow.newrow("Add to Basket Button", "Add To Basket Button is Expected",
                                   AddToBasket + "Add To Basket Element Is Present", "PASS", driver);
                    new SuccessMessage().Message(driver, datarow);
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Add to Basket Button", "Add To Basket Button is Expected", e, "FAIL", driver);
                    screenshot.screenshotfailed(driver);
                }


                string basval = driver.FindElement(By.XPath(basketvalue)).Text;

                if (basval == "(1)")
                {
                    datarow.newrow("Basket Value", "(1)", basval, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Basket Value", "(1)", basval, "FAIL", driver);
                    screenshot.screenshotfailed(driver);
                }

                //Footer_TPS footer = new Footer_TPS();
                //footer.Footer(driver, datarow);

                driver.FindElement(By.Id("BasketInfo")).Click();

                new SelectElement(driver.FindElement(By.Id("Items_0__Quantity")));


                // driver.FindElement(By.Id()).Click();("css=option");
                string pric = driver.FindElement(By.CssSelector("strong")).Text;
                new SelectElement(driver.FindElement(By.Id("Items_0__Quantity"))).SelectByText("4");


                Thread.Sleep(3000);
                string prirc = driver.FindElement(By.CssSelector("strong")).Text;

                if (pric == prirc)
                {
                    datarow.newrow("Price Change with Quantity in Basket Page", pric, prirc, "FAIL", driver);
                }
                else
                {
                    datarow.newrow("Price Change with Quantity in Basket Page", pric, prirc, "PASS", driver);
                }

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement4 = driver.FindElement(By.XPath(checkout));
                if (url.Contains("user-scalable=yes") == false)
                {
                    string value1 = driver.FindElement(By.Id("BasketInfo")).Text;

                    if (value1 == "(4)")
                    {
                        datarow.newrow("Basket Value", "(4)", value1, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Basket Value", "(4)", value1, "FAIL", driver);
                        screenshot.screenshotfailed(driver);
                    }
                }
                new SelectElement(driver.FindElement(By.Id("Items_0__Quantity")));
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                screenshot.screenshotfailed(driver);
            }
        }
    }
}