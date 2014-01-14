using System;
using MoBankUI.Mosite.HomePage;
using MoBankUI.Mosite.Pay;
using MoBankUI.Mosite.Product;
using MoBankUI.Mosite.Search;
using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI.Mosite
{
    internal class BatchTesting
    {
        private readonly Screenshot _screenshot = new Screenshot();

        public void Batchtesting(string items, string url, IWebDriver driver, Datarow datarow)
        {
            try
            {
                new BlobStorage();
                // blob.Blob(driver,datarow, url);


                //string[] vesion = verson.Split(',');

                //foreach (string vsion in vesion)
                //{
                //    public const string version = vsion;
                //}

                var selectedvalue = items.Split(',');
                var i = 0;
                foreach (var function in selectedvalue)
                {
                    if (function == "Search")
                    {
                        datarow.Newrow("", "", "Search", "", driver);
                        new Searchsort().Search(driver);
                    }
                    if (function == "Test All Links in Mosite")
                    {
                        datarow.Newrow("", "", "All Links in Mosite - Validations", "", driver);
                        var hom = new LinksTps();
                        hom.Links(datarow, driver, url);
                        i++;
                    }
                    if (function == "Test Footer Links")
                    {
                        datarow.Newrow("", "", "Footer Links", "", driver);
                        var footer = new FooterTps();
                        footer.Footerhome(driver, url, datarow);
                        i++;
                    }
                    if (function == "Test Basket Functionality")
                    {
                        datarow.Newrow("", "", "Basket Functionality", "", driver);
                        var basket = new BasketsTps();
                        basket.Basket(driver, datarow, url);
                        i++;
                    }
                    if (function == "Test Product page - Test Add Product to Basket")
                    {
                        datarow.Newrow("", "", "User Journey", "", driver);
                        var userjour = new UserJourneyTps();
                        userjour.UserJourn(datarow, driver, url);
                        i++;
                    }
                    if (function == "Test Delete From Basket - Test product Unavailable")
                    {
                        datarow.Newrow("", "", "Delete From Basket", "", driver);
                        var delete = new Deletebasketstart();
                        delete.Deletebasstart(driver, datarow);
                        i++;
                    }

                    if (function == "Custom Checkout")
                    {
                        var ckout = new BatchCheckout();
                        ckout.Checkout(driver, url, datarow);
                    }

                    if (function == "Test Registration/Login - CheckOut Pages")
                    {
                        datarow.Newrow("", "", "Registration/Login", "", driver);
                        var login = new LoginRegistration();
                        login.Registration(driver, datarow);
                        i++;
                    }

                    if (function != "Test Mopay") continue;
                    try
                    {
                        datarow.Newrow("", "", "Mopay", "", driver);
                        var pay = new BatchPay();
                        pay.Batchpay(driver, url, datarow);
                    }
                    catch (Exception)
                    {
                        datarow.Newrow("Exception", "", "Exception Not Expected", "FAIL", driver);
                        _screenshot.Screenshotfailed(driver);
                    }

                    i++;
                }
            }
            catch (Exception)
            {
                datarow.Newrow("Exception", "", "Exception Not Expected", "FAIL", driver);
                _screenshot.Screenshotfailed(driver);
            }

            finally
            {
                datarow.Excelsave("Mosite", driver, "teja.vellanki@mobankgroup.com");
                _screenshot.Screenshotfailed(driver);
                driver.Quit();
            }
        }
    }
}