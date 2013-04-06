using System;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using System.Data;
//using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Selenium;
using System.Data.OleDb;
using System.IO;
using System.Timers;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace MoBankUI
{
    
    class products_TPS
    {
        Screenshot screenshot = new Screenshot();
        //Product page validations
        public void product(IWebDriver driver, ISelenium selenium,datarow datarow)
        {
            Imagevalidation Image = new Imagevalidation();
            try
            {
                Image.productImage(driver, selenium, datarow);

                #region Product price
                // Product Price
                if(selenium.IsElementPresent("//body[@id='page-products-details']/div/div[2]/div/div/div/p/strong"))
                {
                    string price = driver.FindElement(By.XPath("//body[@id='page-products-details']/div/div[2]/div/div/div/p/strong")).Text;
                    datarow.newrow("Product Price", "", price, "PASS", driver, selenium);
                }
                else if(!selenium.IsElementPresent("//body[@id='page-products-details']/div/div[2]/div/div/div/p/strong"))
                {
                    datarow.newrow("Product Price", "Product Price is Expected", "Element Not Identified", "FAIL", driver, selenium);
                }
                else
                {
                    datarow.newrow("Product Price", "Product Price is Expected", "Product Is Not Displayed", "FAIL", driver, selenium);
                }
                #endregion               
                #region Product Detail
                if (selenium.IsElementPresent("//div[@id='Description']/h4/a/span"))
                {
                    selenium.Click("//div[@id='Description']/h4/a/span");

                    if (selenium.IsElementPresent("//div[@id='Description']/div/div/div/p"))
                    {
                        string detail = selenium.GetText("css=html.ui-mobile body#page-products-details.ui-mobile-viewport div.ui-page div.pageContent div.productDetails div.ui-content div#Description.ui-collapsible div.ui-collapsible-content");
                        datarow.newrow("Product Detail", "", detail, "PASS", driver, selenium);
                    }
                    else if (selenium.IsElementPresent("//div[@id='Description']/h4/a/span"))
                    {
                        datarow.newrow("Product Detail", "Product Details Element Is Expected", "Product Detail Element Not identified", "FAIL", driver, selenium);
                    }
                    else
                    {
                        datarow.newrow("Product Detail", "Product Details are Expected", "Product Details Not identified", "FAIL", driver, selenium);
                    }

                }
                #endregion
                #region Product Title
                // Product Title
                if (selenium.IsElementPresent("//html/body/div/div/div[2]/h2"))
                {
                    string title = selenium.GetText("//html/body/div/div/div[2]/h2");
                    datarow.newrow("Product Title", "", title, "PASS", driver, selenium);
                }
                else if (!selenium.IsElementPresent("//html/body/div/div/div[2]/h2"))
                {
                    datarow.newrow("Product Title", "Product Title Element is Expected", "Product Title Element Not Found", "FAIL", driver, selenium);
                }
                else
                {
                    datarow.newrow("Product Title", "Product Title is Expected", "Product Title Not Found", "FAIL", driver, selenium);
                }
                #endregion
                #region Product Variant
                // Product Variants
                if (selenium.IsElementPresent("id=Variants_0__OptionValue"))
                {
                    try
                    {
                        decimal couent = selenium.GetXpathCount("//html/body/div/div[2]/div/div[4]/form/ul/li[2]/fieldset/div[2]/div/label/span");
                        if (couent != 1)
                        {
                            string[] varinats = selenium.GetSelectOptions("id=Variants_0__OptionValue");
                            string values = null;
                            foreach (string value in varinats)
                            {
                                if (value != "Please Select")
                                {
                                    values = values + "\r\n" + value;
                                    new SelectElement(driver.FindElement(By.Id("Variants_0__OptionValue"))).SelectByText(value);

                                }

                            }
                            datarow.newrow("Variants", "", values, "PASS", driver, selenium);
                        }

                        else
                        {
                            string varinats = selenium.GetValue("id=Variants_0__OptionValue");
                            datarow.newrow("Variants", "", varinats, "PASS", driver, selenium);

                        }
                    }
                    catch (Exception ex)
                    {
                        string e = ex.ToString();
                        datarow.newrow("Exception at Product variants", "Exception Not Expected", e, "FAIL", driver, selenium);
                    }


                }

                else if (selenium.IsElementPresent("id=OptionValue_0"))
                {
                    try
                    {
                        string values = null;
                        for (int i = 1; ; i++)
                        {
                            if (selenium.IsElementPresent("id=OptionValue_" + i + ""))
                            {

                                string varinats = selenium.GetText("id=OptionValue_" + i + "");
                                if (varinats != "Please Select" || varinats != null)
                                {
                                    values = values + "\r\n" + varinats;
                                    selenium.Click("id=OptionValue_" + i + "");

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
                        datarow.newrow("Exception at Product Variants", "Exception Not Expected", e, "FAIL", driver, selenium);
                    }
                }

                #endregion

                string product = driver.PageSource;
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,400)");
                try
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    driver.FindElement(By.XPath("//p[@id='AddToBasketButton']/div[2]/input")).Click();
                    datarow.newrow("Add to Basket Button", "Add To Basket Button is Expected", "//p[@id='AddToBasketButton']/div[2]/input"+"Add To Basket Element Is Present", "PASS", driver, selenium);
                    Thread.Sleep(5000);
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Add to Basket Button", "Add To Basket Button is Expected", e, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
                string basval = driver.FindElement(By.Id("BasketInfo")).Text;

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
                driver.FindElement(By.XPath("//div[@id='AddedDetail']/ul/li/p/a/span/span")).Click();
                selenium.WaitForPageToLoad("30000");

                selenium.Select("id=Items_0__Quantity", "label=1");
                selenium.WaitForPageToLoad(("30000"));
                // selenium.Click("css=option");
                string pric = selenium.GetText("css=strong");

                selenium.Select("id=Items_0__Quantity", "label=4");
                selenium.WaitForPageToLoad("30000");
                string prirc = selenium.GetText("css=strong");

                if (pric == prirc)
                {
                    datarow.newrow("Price Change with Quantity in Basket Page", pric, prirc, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Price Change with Quantity in Basket Page", pric, prirc, "FAIL", driver, selenium);
                }

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement4 = driver.FindElement(By.XPath("//a[@id='GoToCheckout']/span/span"));
                string value1 = driver.FindElement(By.Id("BasketInfo")).Text;

                if (value1 == "(1)")
                {
                    datarow.newrow("Basket Value", "(1)", value1, "PASS", driver, selenium);

                }
                else
                {
                    datarow.newrow("Basket Value", "(1)",value1, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
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


