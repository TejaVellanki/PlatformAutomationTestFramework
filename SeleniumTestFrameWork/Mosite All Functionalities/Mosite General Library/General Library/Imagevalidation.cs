using System;
using MoBankUI.ObjectRepository;
using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI
{
    internal class Imagevalidation : Driverdefining
    {
        private string _homepageimage;
        private string _categoryimagecss;
        private int l = 1;

        public void homepageimage(IWebDriver driver, Datarow datarow)
        {
            try
            {
                var url = driver.Url;

                var title = driver.PageSource;
                _homepageimage = title.Contains("user-scalable=yes") ? ImagesV2.Homepageimage : ImagesV1.Homepageimage;

                // Home Page Image Validation
                if (IsElementPresent(driver, By.XPath("Homepageimage"), 30))
                {
                    if (title.Contains("user-scalable=yes"))
                    {
                        var contactus = driver.FindElement(By.XPath("//*[@id='main-page']/div[4]/h1/a/img"));
                        var path1 = contactus.GetAttribute("src");
                        datarow.newrow("Contact US Image Validation", "", path1, "PASS", driver);
                    }
                    var element = driver.FindElement(By.XPath(_homepageimage));
                    var path = element.GetAttribute("src");
                    datarow.newrow("Image Validation", "", path, "PASS", driver);
                    if (path.Contains("http") || path.Contains("https") || path.Contains("blob"))
                    {
                        datarow.newrow("Image URL Validation", "Image url shouldnot contain http/https", path, "FAIL",
                                       driver);
                    }
                    else
                    {
                        datarow.newrow("Image URL Validation", "Image url shouldnot contain http/https", path, "PASS",
                                       driver);
                    }
                    clickimage(driver, datarow, By.XPath(_homepageimage));
                }
                else if (IsElementPresent(driver, By.CssSelector("img.categoryImage"), 30))
                {
                    var element = driver.FindElement(By.CssSelector("img.categoryImage"));
                    var path = element.GetAttribute("src");
                    datarow.newrow("Image Validation", "", path, "PASS", driver);
                    clickimage(driver, datarow, By.CssSelector("img.categoryImage"));
                }
                else
                {
                    datarow.newrow("Image Validation", "", "No Image for Home Page" + "-" + url, "FAIL", driver);
                }
            }

            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver);
            }
        }

        public void categoryimage(IWebDriver driver, Datarow datarow)
        {
            try
            {
                if (l >= 3) return;
                var title = driver.PageSource;
                _categoryimagecss = title.Contains("user-scalable=yes") ? ImagesV2.Categoryimagecss : ImagesV1.Categoryimagecss;
                var location = driver.Url;
                if (IsElementPresent(driver, By.CssSelector(_categoryimagecss), 30))
                {
                    var element = driver.FindElement(By.CssSelector(_categoryimagecss));
                    var path = element.GetAttribute("src");
                    datarow.newrow("Image Validation", "", path, "PASS", driver);
                    if (path.Contains("http") || path.Contains("https") || path.Contains("blob"))
                    {
                        datarow.newrow("Image URL Validation", "Image url shouldnot contain http/https", path,
                            "FAIL", driver);
                    }
                    else
                    {
                        datarow.newrow("Image URL Validation", "Image url shouldnot contain http/https", path,
                            "PASS", driver);
                    }
                    clickimage(driver, datarow, By.CssSelector(_categoryimagecss));
                }
                else
                {
                    datarow.newrow("Image Validation", "", "No Image for Category page" + "-" + location, "FAIL",
                        driver);
                }
                l++;
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver);
            }
        }

        public void subcategoryimage(IWebDriver driver, Datarow datarow)
        {
            try
            {
                //string location = driver.Url;
                //if (IsElementPresent("css=img.categoryImage"))
                //{
                //    IWebElement element = driver.FindElement(By.XPath("//body[@id='page-categories-details']/div/div[2]/div/img"));
                //    string path = element.GetAttribute("src");
                //    datarow.newrow("Image Validation", "", path, "PASS",driver);

                //}
                //else
                //{
                //    datarow.newrow("Image Validation", "", "No Image for Sub-Category page" + "-" + location, "FAIL",driver);

                //}
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver);
            }
        }

        public void productImage(IWebDriver driver, Datarow datarow)
        {
            try
            {
                string productimage;
                string productimagelink;
                string multiproductimage;

                var url = driver.PageSource;
                var location = driver.Url;
                if (url.Contains("user-scalable=yes"))
                {
                    productimage = ImagesV2.productimage;
                    productimagelink = ImagesV2.productimagelink;
                    multiproductimage = ImagesV2.multiproductimage;
                }
                else
                {
                    productimage = ImagesV1.productimage;
                    productimagelink = ImagesV1.productimagelink;
                    multiproductimage = ImagesV1.multiproductimage;
                }

                if (IsElementPresent(driver, By.XPath("" + productimage + "" + productimagelink + "")))
                {
                    var element = driver.FindElement(By.XPath("" + productimage + "" + productimagelink + ""));
                    var path = element.GetAttribute("src");
                    datarow.newrow("Image Validation", "", path, "PASS", driver);
                }
                    //multi- Product Image
                    //body[@id='page-products-details']/div/div[2]/div/div[2]/div/ul/li[2]/img
                else if (IsElementPresent(driver, By.XPath(multiproductimage)))
                {
                    decimal count = driver.FindElements(By.XPath("" + productimage + "")).Count;
                    for (var o = 2; o < count; o++)
                    {
                        var element =
                            driver.FindElement(By.XPath("" + productimage + "[" + o + "]" + productimagelink + ""));
                        var path = element.GetAttribute("src");
                        datarow.newrow("Image Validation", "", path, "PASS", driver);
                    }
                }
                else
                {
                    datarow.newrow("Image Validation", "", "No Image in Product Page" + "-" + location, "FAIL", driver);
                }
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver);
            }
        }

        public void clickimage(IWebDriver driver, Datarow datarow, By by)
        {
            driver.FindElement(by).Click();
            var url = driver.Url;
            datarow.newrow("Image Click Validation", "http://qamodrophenia.mobankdev.com/", url,
                url == "http://qamodrophenia.mobankdev.com/" ? "PASS" : "FAIL");
            driver.Navigate().Back();
        }
    }
}