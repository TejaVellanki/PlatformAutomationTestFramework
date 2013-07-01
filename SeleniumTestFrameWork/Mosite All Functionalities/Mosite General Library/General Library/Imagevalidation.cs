using System;
using ObjectRepository;
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
                string Homepageimage = null;
                string title = driver.PageSource;
                if (title.Contains("smallDevice"))
                {
                    Homepageimage = ImagesV2.Homepageimage;
                }
                else
                {
                    Homepageimage = ImagesV1.Homepageimage;
                }

                // Home Page Image Validation
                if (selenium.IsElementPresent(Homepageimage))
                {
                    if (title.Contains("smallDevice"))
                    {
                        IWebElement contactus = driver.FindElement(By.XPath("//*[@id='main-page']/div[4]/h1/a/img"));
                        string path1 = contactus.GetAttribute("src");
                        datarow.newrow("Contact US Image Validation", "", path1, "PASS", driver, selenium);
                    }
                    IWebElement element = driver.FindElement(By.XPath(Homepageimage));
                    string path = element.GetAttribute("src");
                    datarow.newrow("Image Validation", "", path, "PASS", driver, selenium);
                    if (path.Contains("http") || path.Contains("https") || path.Contains("blob"))
                    {
                        datarow.newrow("Image URL Validation", "Image url shouldnot contain http/https", path, "FAIL",
                                       driver, selenium);
                    }
                    else
                    {
                        datarow.newrow("Image URL Validation", "Image url shouldnot contain http/https", path, "PASS",
                                       driver, selenium);
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
                    datarow.newrow("Image Validation", "", "No Image for Home Page" + "-" + url, "FAIL", driver,
                                   selenium);
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
            string CategoryImage = null;
            string categoryimagecss = null;
            try
            {
                if (l < 3)
                {
                    string title = driver.PageSource;
                    if (title.Contains("smallDevice"))
                    {
                        CategoryImage = ImagesV2.Categoryimage;
                        categoryimagecss = ImagesV2.Categoryimagecss;
                    }
                    else
                    {
                        CategoryImage = ImagesV1.Categoryimage;
                        categoryimagecss = ImagesV1.Categoryimagecss;
                    }
                    string location = selenium.GetLocation();
                    if (selenium.IsElementPresent(categoryimagecss))
                    {
                        IWebElement element = driver.FindElement(By.XPath(CategoryImage));
                        string path = element.GetAttribute("src");
                        datarow.newrow("Image Validation", "", path, "PASS", driver, selenium);
                        if (path.Contains("http") || path.Contains("https") || path.Contains("blob"))
                        {
                            datarow.newrow("Image URL Validation", "Image url shouldnot contain http/https", path,
                                           "FAIL", driver, selenium);
                        }
                        else
                        {
                            datarow.newrow("Image URL Validation", "Image url shouldnot contain http/https", path,
                                           "PASS", driver, selenium);
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
                string Productimage = null;
                string Productimagelink = null;
                string multiproductimage = null;

                string url = driver.PageSource;
                string location = selenium.GetLocation();
                if (url.Contains("smallDevice"))
                {
                    Productimage = ImagesV2.productimage;
                    Productimagelink = ImagesV2.productimagelink;
                    multiproductimage = ImagesV2.multiproductimage;
                }
                else
                {
                    Productimage = ImagesV1.productimage;
                    Productimagelink = ImagesV1.productimagelink;
                    multiproductimage = ImagesV1.multiproductimage;
                }
                //single product Image ////body[@id='page-products-details']/div/div[2]/div/div[2]/ul/li/img
                if (selenium.IsElementPresent("" + Productimage + "" + Productimagelink + ""))
                {
                    IWebElement element = driver.FindElement(By.XPath("" + Productimage + "" + Productimagelink + ""));
                    string path = element.GetAttribute("src");
                    datarow.newrow("Image Validation", "", path, "PASS", driver, selenium);
                }
                    //multi- Product Image
                    //body[@id='page-products-details']/div/div[2]/div/div[2]/div/ul/li[2]/img
                else if (selenium.IsElementPresent(multiproductimage))
                {
                    decimal count = selenium.GetXpathCount("" + Productimage + "");
                    for (int o = 2; o < count; o++)
                    {
                        IWebElement element =
                            driver.FindElement(By.XPath("" + Productimage + "[" + o + "]" + Productimagelink + ""));
                        string path = element.GetAttribute("src");
                        datarow.newrow("Image Validation", "", path, "PASS", driver, selenium);
                    }
                }
                else
                {
                    datarow.newrow("Image Validation", "", "No Image in Product Page" + "-" + location, "FAIL", driver,
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