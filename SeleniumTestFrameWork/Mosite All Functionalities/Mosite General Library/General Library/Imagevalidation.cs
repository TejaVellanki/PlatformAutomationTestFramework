﻿using System;
using OpenQA.Selenium;
using Selenium;
//using System.Drawing;


namespace MoBankUI
{
    internal class Imagevalidation
    {
        private int l = 1;

        public void homepageimage(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            try
            {
                string url = selenium.GetLocation();

                // Home Page Image Validation
                if (selenium.IsElementPresent("//body[@id='page-home-index']/div/div[2]/div/img"))
                {
                    IWebElement element =
                        driver.FindElement(By.XPath("//body[@id='page-home-index']/div/div[2]/div/img"));
                    string path = element.GetAttribute("src");
                    datarow.newrow("Image Validation", "", path, "PASS", driver, selenium);
                    if (path.Contains("http") || path.Contains("https")||path.Contains("blob"))
                    {
                        datarow.newrow("Image URL Validation", "Image url shouldnot contain http/https", path, "FAIL",driver, selenium);
                    }
                    else
                    {
                        datarow.newrow("Image URL Validation", "Image url shouldnot contain http/https", path, "PASS",driver, selenium);

                    }

                }
                else if (selenium.IsElementPresent("css=img.categoryImage"))
                {
                    IWebElement element = driver.FindElement(By.CssSelector("img.categoryImage"));
                    string path = element.GetAttribute("src");
                    datarow.newrow("Image Validation", "", path, "PASS", driver, selenium);
                }
             else
                {
                    datarow.newrow("Image Validation", "", "No Image for Home Page" + "-" + url, "FAIL", driver,selenium);
                }
            }
        
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver, selenium);
            }
        }

        public void categoryimage(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            try
            {
                if (l < 3)
                {
                    string location = selenium.GetLocation();
                    if (selenium.IsElementPresent("css=img.categoryImage"))
                    {
                        IWebElement element =driver.FindElement(By.XPath("//body[@id='page-categories-details']/div/div[2]/div/img"));
                        string path = element.GetAttribute("src");
                        datarow.newrow("Image Validation", "", path, "PASS", driver, selenium);
                        if (path.Contains("http") || path.Contains("https") || path.Contains("blob"))
                        {
                            datarow.newrow("Image URL Validation", "Image url shouldnot contain http/https", path, "FAIL",driver, selenium);
                        }
                        else
                        {
                            datarow.newrow("Image URL Validation", "Image url shouldnot contain http/https", path, "PASS",
                                           driver, selenium);

                        }
                    }
                    else
                    {
                        datarow.newrow("Image Validation", "", "No Image for Category page" + "-" + location, "FAIL",
                                       driver, selenium);
                    }
                    l++;
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver, selenium);
            }
        }

        public void subcategoryimage(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            try
            {
                //string location = selenium.GetLocation();
                //if (selenium.IsElementPresent("css=img.categoryImage"))
                //{
                //    IWebElement element = driver.FindElement(By.XPath("//body[@id='page-categories-details']/div/div[2]/div/img"));
                //    string path = element.GetAttribute("src");
                //    datarow.newrow("Image Validation", "", path, "PASS", driver, selenium);

                //}
                //else
                //{
                //    datarow.newrow("Image Validation", "", "No Image for Sub-Category page" + "-" + location, "FAIL", driver, selenium);

                //}
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver, selenium);
            }
        }

        public void productImage(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            try
            {
                string location = selenium.GetLocation();
                //single product Image ////body[@id='page-products-details']/div/div[2]/div/div[2]/ul/li/img
                if (selenium.IsElementPresent("//body[@id='page-products-details']/div/div[2]/div/div[2]/ul/li/img"))
                {
                    IWebElement element =driver.FindElement(By.XPath("//body[@id='page-products-details']/div/div[2]/div/div[2]/ul/li/img"));
                    string path = element.GetAttribute("src");
                    datarow.newrow("Image Validation", "", path, "PASS", driver, selenium);
                }
                    //multi- Product Image
                    //body[@id='page-products-details']/div/div[2]/div/div[2]/div/ul/li[2]/img
                else if (selenium.IsElementPresent("css=li.flex-active-slide > img"))
                {
                    decimal count =
                        selenium.GetXpathCount("//body[@id='page-products-details']/div/div[2]/div/div[2]/div/ul/li");
                    for (int o = 2; o < count; o++)
                    {
                        IWebElement element =driver.FindElement(By.XPath("//body[@id='page-products-details']/div/div[2]/div/div[2]/div/ul/li[" + o +"]/img"));
                        string path = element.GetAttribute("src");
                        datarow.newrow("Image Validation", "", path, "PASS", driver, selenium);
                    }
                }
                else
                {
                    datarow.newrow("Image Validation", "", "No Image in Product Page" + "-" + location, "PASS", driver,
                                   selenium);
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver, selenium);
            }
        }
    }
}