using System;
using OpenQA.Selenium;
using Selenium;
using Tablet_View;
//using System.Drawing;

namespace MoBankUI
{
    internal class BatchTesting
    {
        private readonly Screenshot screenshot = new Screenshot();

        public void batchtesting(string items, string url, IWebDriver driver, ISelenium selenium, datarow datarow)
        {

            try
            {
                BlobStorage blob = new BlobStorage();
                blob.Blob(selenium,driver,datarow);

                //string[] vesion = verson.Split(',');

                //foreach (string vsion in vesion)
                //{
                //    public const string version = vsion;
                //}

                string[] selectedvalue = items.Split(',');
                int i = 0;
                foreach (string function in selectedvalue)
                {

                    if (function == "Test All Links in Mosite")
                    {
                        datarow.newrow("", "", "All Links in Mosite - Validations", "", driver, selenium);
                        var hom = new links_TPS();
                        hom.Links(datarow, driver, selenium, url);
                        i++;
                    }
                    if (function == "Test Footer Links")
                    {
                        datarow.newrow("", "", "Footer Links", "", driver, selenium);
                        var footer = new Footer_TPS();
                        footer.Footerhome(driver, selenium, url, datarow);
                        i++;
                    }
                    if (function == "Test Basket Functionality")
                    {
                        datarow.newrow("", "", "Basket Functionality", "", driver, selenium);
                        var basket = new Baskets_TPS();
                        basket.Basket(driver, selenium, datarow, url);
                        i++;
                    }
                    if (function == "Test Product page - Test Add Product to Basket")
                    {
                        datarow.newrow("", "", "User Journey", "", driver, selenium);
                        var userjour = new UserJourney_TPS();
                        userjour.UserJourn(datarow, driver, selenium, url);
                        i++;
                    }
                    if (function == "Test Delete From Basket - Test product Unavailable")
                    {
                        datarow.newrow("", "", "Delete From Basket", "", driver, selenium);
                        var delete = new Deletebasketstart();
                        delete.deletebasstart(driver, selenium, datarow);
                        i++;
                    }


                    if (function == "Test Registration/Login - CheckOut Pages")
                    {
                        var ckout = new BatchCheckout();
                        ckout.checkout(driver, selenium, url, datarow);
                        datarow.newrow("", "", "Registration/Login", "", driver, selenium);
                        var login = new LoginRegistration();
                        login.registration(driver, selenium, datarow);
                        i++;
                    }

                    if (function == "Test Mopay")
                    {
                        try
                        {
                            datarow.newrow("", "", "Mopay", "", driver, selenium);
                            var pay = new BatchPay();
                            pay.batchpay(driver, selenium, url, datarow);
                        }
                        catch (Exception ex)
                        {
                            string e = ex.ToString();
                            datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver, selenium);
                            screenshot.screenshotfailed(driver, selenium);
                        }

                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
              
            finally
            {
                datarow.excelsave("Mosite", driver, selenium, "teja.vellanki@mobankgroup.com");
                screenshot.screenshotfailed(driver, selenium);
                driver.Quit();
            }
        }
      }
  }
