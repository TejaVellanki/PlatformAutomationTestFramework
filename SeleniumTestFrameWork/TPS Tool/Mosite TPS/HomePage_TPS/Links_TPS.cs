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
    class links_TPS
    {
        Screenshot screenshot = new Screenshot();
        public void Links(datarow datarow, IWebDriver driver,ISelenium selenium,string url)
        {
            // This method counts the categories,sub-categories, product pages and validate every product link
            try
            {
                Imagevalidation Image = new Imagevalidation();
                //Home Page Image validation
                Image.homepageimage(driver, selenium, datarow);
                decimal linkcount = driver.FindElements(By.XPath("//html/body/div/div[2]/div/ul/li")).Count;
                if (linkcount == 0)
                {
                    datarow.newrow("Category Validation in Home Page", "Atleast One Category/product is Expected", "No Categories/Products are Identified", "FAIL", driver, selenium);
                }
                int j = 0;
                int s = 1;

              
                for (int i = 1; i <= linkcount; i++)
                {
                    try
                    {
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                        IWebElement myDynamicElement1 = driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li[" + i + "]/div/div/a/h2"));
                        driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li[" + i + "]/div/div/a/h2")).Click();
                        selenium.WaitForPageToLoad("30000");
                        string title = driver.Title.ToString();
                    }
                    catch (Exception ex)
                    {
                        string e = ex.ToString();
                        datarow.newrow("Category Element Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);

                    }
                    decimal categorycount = selenium.GetXpathCount("//html/body/div/div[2]/div/ul/li");
                    if (categorycount == 0)
                    {
                        datarow.newrow("Category Validation in  Page", "Atleast One Category/product", "No Categories/Products", "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                    for (int k = 1; ; k++)
                    {
                        try
                        {

                            if (selenium.IsElementPresent("//html/body/div/div[2]/div/ul/li[" + k + "]/div/div/a/h2"))
                            {
                                string location = selenium.GetLocation();
                                // Category Image validation
                                Image.categoryimage(driver, selenium, datarow);
                                driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li[" + k + "]/div/div/a/h2")).Click();
                                selenium.WaitForPageToLoad("30000");
                                string titlecategory = driver.Title.ToString();
                                string url1 = selenium.GetLocation();

                                // Sub-Category Image validation
                                Image.subcategoryimage(driver, selenium, datarow);
                                if (url1.Contains("category"))
                                {
                                    datarow.newrow("Category Title", "", titlecategory, "PASS", driver, selenium);
                                    k = 0;
                                }
                                else
                                {
                                    try
                                    {
                                        //This is to test the product page
                                        #region Product Details

                                        Image.productImage(driver, selenium, datarow);
                                        datarow.newrow("Product Title", "", titlecategory, "PASS", driver, selenium);
                                        if (selenium.IsElementPresent("//body[@id='page-products-details']/div/div[2]/div/div/div/p/strong"))
                                        {
                                            string price = driver.FindElement(By.XPath("//body[@id='page-products-details']/div/div[2]/div/div/div/p/strong")).Text;
                                            datarow.newrow("Product Price", "", price, "PASS", driver, selenium);
                                        }


                                        if (selenium.IsElementPresent("//div[@id='Description']/h4/a/span"))
                                        {
                                            selenium.Click("//div[@id='Description']/h4/a/span");

                                            if (selenium.IsElementPresent("//div[@id='Description']/div/div/div/p"))
                                            {
                                                string detail = selenium.GetText("css=html.ui-mobile body#page-products-details.ui-mobile-viewport div.ui-page div.pageContent div.productDetails div.ui-content div#Description.ui-collapsible div.ui-collapsible-content");
                                                datarow.newrow("Product Detail", "", detail, "PASS", driver, selenium);
                                            }
                                        }

                                        if (selenium.IsElementPresent("//html/body/div/div/div[2]/h2"))
                                        {
                                            string titles = selenium.GetText("//html/body/div/div/div[2]/h2");
                                            datarow.newrow("Product Title", "", titles, "PASS", driver, selenium);
                                        }

                                        if (selenium.IsElementPresent("id=Variants_0__OptionValue"))
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

                                        else if (selenium.IsElementPresent("id=OptionValue_0"))
                                        {
                                            string values = null;
                                            for (int q = 1; ; q++)
                                            {
                                                if (selenium.IsElementPresent("id=OptionValue_" + q + ""))
                                                {

                                                    string varinats = selenium.GetText("id=OptionValue_" + q + "");
                                                    if (varinats != "Please Select" || varinats != null)
                                                    {
                                                        values = values + "\r\n" + varinats;
                                                        selenium.Click("id=OptionValue_" + q + "");

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
                                    catch (Exception ex)
                                    {
                                        string e = ex.ToString();
                                        datarow.newrow("Exception For Product Details", "Exception Not Expected", e, "FAIL", driver, selenium);
                                        screenshot.screenshotfailed(driver, selenium);
                                    }
                                    driver.Navigate().Back();
                                    selenium.WaitForPageToLoad("30000");
                                }
                            }
                            else
                            {
                                k = s;
                                driver.Navigate().Back();
                                selenium.WaitForPageToLoad("30000");
                                s++;
                                string url2 = selenium.GetLocation();
                                if (url2.Contains("category"))
                                {
                                    datarow.newrow("Category URL", "", url2, "PASS", driver, selenium);
                                }
                                else
                                {
                                    s = 1;
                                    break;
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            string e = ex.ToString();
                            datarow.newrow("Category/Product Link Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                            screenshot.screenshotfailed(driver, selenium);
                        }
                        }
                    
                        j++;
                    
                    //driver.Navigate().Back();
                    //selenium.WaitForPageToLoad("30000");

                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }
          
    }
}
