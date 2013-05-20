using System;
using System.Threading;
using ObjectRepository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium;
//using System.Drawing;

namespace MoBankUI
{
    internal class products_TPS
    {
        private readonly Screenshot screenshot = new Screenshot();
        //Product page validations
        public void product(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            var Image = new Imagevalidation();
            try
            {

                string url = driver.Title;

                string productprice = null;
                string productVarinat = null;
                string productdescription = null;
                string productdescriptiontab = null;
                string producttitle = null;
                string Detail = null;
                string AddToBasket = null;
                string checkout = null;
                string basketvalue = null;
               
                var screenshot = new Screenshot();
                #region object reading
                if (url.Contains("Tablet"))
                {
                    productprice = CollectionMapV2.ProductPrice;
                    productdescription = CollectionMapV2.productDescription;
                    productdescriptiontab = CollectionMapV2.ProductDescriptiontab;
                    producttitle = CollectionMapV2.producttitle;
                    Detail  = CollectionMapV2.detail;
                    productVarinat = CollectionMapV2.productVariant;
                    AddToBasket = CollectionMapV2.addtobasket;
                    checkout = CollectionMapV2.checkout;
                    basketvalue = BasketV2.basketvalue;
                }
                else
                {
                    productprice = CollectionMapV1.ProductPrice;
                    productdescription = CollectionMapV1.productDescription;
                    productdescriptiontab = CollectionMapV1.ProductDescriptiontab;
                    producttitle = CollectionMapV1.producttitle;
                    Detail = CollectionMapV1.detail;
                    productVarinat = CollectionMapV1.productVariant;
                    AddToBasket = CollectionMapV1.addtobasket;
                    checkout = CollectionMapV1.checkout;
                    basketvalue = BasketV1.basketvalue;
                }
                #endregion


                Image.productImage(driver, selenium, datarow);

                #region Product price

                // Product Price
                if (selenium.IsElementPresent(productprice))
                {
                    string price =driver.FindElement(By.XPath(productprice)).Text;
                    datarow.newrow("Product Price", "", price, "PASS", driver, selenium);
                }
                else if (!selenium.IsElementPresent(productprice))
                {
                    datarow.newrow("Product Price", "Product Price is Expected", "Element Not Identified", "FAIL",driver, selenium);
                }
                else
                {
                    datarow.newrow("Product Price", "Product Price is Expected", "Product Is Not Displayed", "FAIL",driver, selenium);
                }

                #endregion

                #region Product Detail

                try
                {
              
                 //selenium.Click(productdescriptiontab);

                    if (selenium.IsElementPresent(productdescription))
                    {
                        string detail =selenium.GetText(Detail);
                        datarow.newrow("Product Detail", "", detail, "PASS", driver, selenium);
                    }
                    else if (!selenium.IsElementPresent(productdescriptiontab))
                    {
                        datarow.newrow("Product Detail", "Product Details Element Is Expected","Product Detail Element Not identified", "FAIL", driver, selenium);
                    }
                    else
                    {
                        selenium.Click(productdescriptiontab);
                        if (selenium.IsElementPresent(productdescription))
                        {
                            string detail = selenium.GetText(Detail);
                            datarow.newrow("Product Detail", "", detail, "PASS", driver, selenium);
                        }
                        else
                        {
                            datarow.newrow("Product Detail", "Product Details are Expected", "Product Details Not identified", "FAIL", driver, selenium);
                            
                        }
                       
                    }
                }
                catch (Exception ex)
                {

                    string e = ex.ToString();
                }

                #endregion

                #region Product Title

                // Product Title
                try
                {
                    string title = selenium.GetText(producttitle);
                    datarow.newrow("Product Title", "", title, "PASS", driver, selenium);
                }
                catch (Exception ex)
                {
                    string e = ex.ToString(); 
                  
                }
                if(selenium.IsElementPresent(producttitle)==false)
                {
                    datarow.newrow("Product Title", "Product Title Element is Expected","Product Title Element Not Found", "FAIL", driver, selenium);
                }

                #endregion

                #region Product Variant

                // Product Variants
                if (selenium.IsElementPresent("id=" + productVarinat + ""))
                {
                    try
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
                    catch (Exception ex)
                    {
                        string e = ex.ToString();

                        datarow.newrow("Exception Not Expected", "Exception Not Expected", e, "FAIL");
                    }


                }

                else if (selenium.IsElementPresent("id=" + productVarinat + "_0"))
                {
                    try
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
                    catch (Exception ex)
                    {
                        string e = ex.ToString();
                        throw;
                    }
                }

                #endregion

                string product = driver.PageSource;
                var js = (IJavaScriptExecutor) driver;
                js.ExecuteScript("window.scrollBy(0,400)");
                try
                {
                   
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                        driver.FindElement(By.XPath(AddToBasket)).Click();
                        datarow.newrow("Add to Basket Button", "Add To Basket Button is Expected",
                                       AddToBasket + "Add To Basket Element Is Present", "PASS", driver, selenium);
                        Thread.Sleep(5000);
                    
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Add to Basket Button", "Add To Basket Button is Expected", e, "FAIL", driver,selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }

               
                    string basval = driver.FindElement(By.XPath(basketvalue)).Text;

                    if (basval == "(1)")
                    {
                        datarow.newrow("Basket Value", "(1)", basval, "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrow("Basket Value", "(1)", basval, "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
              
                //Footer_TPS footer = new Footer_TPS();
                //footer.Footer(driver, selenium, datarow);

                driver.FindElement(By.Id("BasketInfo")).Click();
                selenium.WaitForPageToLoad("30000");

                selenium.Select("id=Items_0__Quantity", "label=1");
                selenium.WaitForPageToLoad(("30000"));
                // selenium.Click("css=option");
                string pric = selenium.GetText("css=strong");

                selenium.Select("id=Items_0__Quantity", "label=4");
                selenium.WaitForPageToLoad("30000");
                Thread.Sleep(3000);
                string prirc = selenium.GetText("css=strong");

                if (pric == prirc)
                {
                    datarow.newrow("Price Change with Quantity in Basket Page", pric, prirc, "FAIL", driver, selenium);
                }
                else
                {
                    datarow.newrow("Price Change with Quantity in Basket Page", pric, prirc, "PASS", driver, selenium);
                }

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement4 = driver.FindElement(By.XPath(checkout));
                 if (url.Contains("Tablet")==false)
                {
                    string value1 = driver.FindElement(By.Id("BasketInfo")).Text;

                    if (value1 == "(4)")
                    {
                        datarow.newrow("Basket Value", "(4)", value1, "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrow("Basket Value", "(4)", value1, "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }
    }
}