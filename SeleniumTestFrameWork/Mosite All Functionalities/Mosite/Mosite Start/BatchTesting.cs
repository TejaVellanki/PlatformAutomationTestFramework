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
                        datarow.newrow("", "", "Search", "", driver);
                        new Searchsort().Search(driver);
                    }
                    if (function == "Test All Links in Mosite")
                    {
                        datarow.newrow("", "", "All Links in Mosite - Validations", "", driver);
                        var hom = new LinksTps();
                        hom.Links(datarow, driver, url);
                        i++;
                    }
                    if (function == "Test Footer Links")
                    {
                        datarow.newrow("", "", "Footer Links", "", driver);
                        var footer = new FooterTps();
                        footer.Footerhome(driver, url, datarow);
                        i++;
                    }
                    if (function == "Test Basket Functionality")
                    {
                        datarow.newrow("", "", "Basket Functionality", "", driver);
                        var basket = new BasketsTps();
                        basket.Basket(driver, datarow, url);
                        i++;
                    }
                    if (function == "Test Product page - Test Add Product to Basket")
                    {
                        datarow.newrow("", "", "User Journey", "", driver);
                        var userjour = new UserJourneyTps();
                        userjour.UserJourn(datarow, driver, url);
                        i++;
                    }
                    if (function == "Test Delete From Basket - Test product Unavailable")
                    {
                        datarow.newrow("", "", "Delete From Basket", "", driver);
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
                        datarow.newrow("", "", "Registration/Login", "", driver);
                        var login = new LoginRegistration();
                        login.Registration(driver, datarow);
                        i++;
                    }

                    if (function != "Test Mopay") continue;
                    try
                    {
                        datarow.newrow("", "", "Mopay", "", driver);
                        var pay = new BatchPay();
                        pay.Batchpay(driver, url, datarow);
                    }
                    catch (Exception)
                    {
                        datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver);
                        _screenshot.screenshotfailed(driver);
                    }

                    i++;
                }
            }
            catch (Exception)
            {
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver);
                _screenshot.screenshotfailed(driver);
            }

            finally
            {
                datarow.excelsave("Mosite", driver, "teja.vellanki@mobankgroup.com");
                _screenshot.screenshotfailed(driver);
                driver.Quit();
            }
        }
    }
}