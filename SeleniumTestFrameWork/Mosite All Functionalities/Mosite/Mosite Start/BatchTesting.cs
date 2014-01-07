using System;
using OpenQA.Selenium;
using Tablet_View;

//using System.Drawing;

namespace MoBankUI
{
    internal class BatchTesting
    {
        private readonly Screenshot _screenshot = new Screenshot();

        public void Batchtesting(string items, string url, IWebDriver driver, Datarow datarow)
        {
            try
            {
                var blob = new BlobStorage();
                // blob.Blob(driver,datarow, url);


                //string[] vesion = verson.Split(',');

                //foreach (string vsion in vesion)
                //{
                //    public const string version = vsion;
                //}

                string[] selectedvalue = items.Split(',');
                int i = 0;
                foreach (string function in selectedvalue)
                {
                    if (function == "Search")
                    {
                        datarow.newrow("", "", "Search", "", driver);
                        new searchsort().search(driver);
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
                        delete.deletebasstart(driver, datarow);
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

                    if (function == "Test Mopay")
                    {
                        try
                        {
                            datarow.newrow("", "", "Mopay", "", driver);
                            var pay = new BatchPay();
                            pay.batchpay(driver, url, datarow);
                        }
                        catch (Exception ex)
                        {
                            string e = ex.ToString();
                            datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver);
                            _screenshot.screenshotfailed(driver);
                        }

                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
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