using System;
using System.Drawing;
using MoBankUI.Mosite;
using MoBankUI.Mosite.HomePage;
using MoBankUI.Mosite.Modrophenia;
using MoBankUI.Mosite.Pay;
using MoBankUI.Mosite.Product;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MoBankUI.MoShop
{
    public class MoshopBatch : Driverdefining
    {
        public void Batchmoshop(IWebDriver driver, Datarow datarow, string items, string vers)
        {
            var screenshot = new Screenshot();
            try
            {
                var moshop = new MoShopConsole();
                moshop.Homepagetabs(driver, datarow);
                driver.Manage().Window.Maximize();

                var strArray = items.Split(new[] {','});

                foreach (var str in strArray)
                {
                    if (str.Length != 0)
                    {
                        #region Test Shop

                        if (str == "Create a Test Shop")
                        {
                            datarow.newrow("", "", "Create a Test Shop", "", driver);
                            var testshop = new CreateShop();
                            testshop.Testshop(driver, datarow);

                            new LookandFeel().Lookandfeel(driver, datarow);

                            #region Global Settings

                            var global = new GlobalSetting();
                            // global.globalsetting(driver);

                            #endregion
                        }

                        #endregion

                        #region Test Scrape

                        if (str == "Create a Test Scrape")
                        {
                            datarow.newrow("", "", "Create a Test Scarpe", "", driver);
                            new Createscrape().createscrape(driver, datarow);
                        }

                        #endregion

                        #region Run Manual Scrape

                        if (str == "Run Manual Scrape")
                        {
                            datarow.newrow("", "", "Run Manual Scrape", "", driver);
                            var run = new RunScrape();
                            run.Runscrape(driver, datarow);
                        }

                        #endregion

                        #region Custom Domain Name Feature and Localisation

                        if (str == "Validate Custom Domain Name Feature and Localisation")
                        {
                            datarow.newrow("", "", "Validate Custom domain Name", "", driver);
                            new Shop().Culture(driver, datarow);
                        }

                        #endregion

                        #region "Run the Test Site - Scrape

                        if (str == "Run the Test Site - Scrape")
                        {
                            try
                            {
                                driver.Manage().Window.Size = new Size(400, 550);
                                datarow.newrow("", "", "Run the Test Site", "", driver);
                                driver.Navigate().GoToUrl("http://testshop.mobankdev.com/");

                                var blob = new BlobStorage();
                                //blob.Blob(driver,datarow, "http://testshop.mobankdev.com/");
                                commtest(driver, datarow);
                            }
                            catch (Exception ex)
                            {
                                var e = ex.ToString();
                                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                            }
                        }

                        #endregion

                        #region Run the Test Site - DataFeed XML

                        if (str == "Run the Test Site - DataFeed XML")
                        {
                            var datafeed = new DatafeedXml();
                            datafeed.Datafeed(driver, datarow);
                            datarow.newrow("", "", "Run the Test Site-DataFeed", "", driver);
                            driver.Navigate().GoToUrl("http://testshop.mobankdev.com/");

                            datarow.newrow("", "", "Footer Links", "", driver);
                            var footer = new FooterTps();
                            footer.Footerhome(driver, "http://testshop.mobankdev.com/", datarow);
                            var relatedproduct = new RelatedProducts();
                            relatedproduct.Relatedproducts(driver, datarow);
                            //commtest(driver, datarow);
                        }

                        #endregion

                        #region Validate Products Against Live Site - Modropenia

                        if (str == "Validate Products Against Live Site - Modropenia")
                        {
                            var modrophenia = new Modrophenialive();
                            modrophenia.modrophenialiveproducts(driver);
                            var products = new modropheniaproducts();
                            products.product(datarow, driver);
                        }

                        #endregion

                        # region Delete Shop And Scrape

                        if (str == "Delete TestShop And TestScrape")
                        {
                            var delete = new DeleteTestShop();
                            delete.Deleteshop(driver);
                            delete.Deletedscrape(driver);
                        }

                        #endregion
                    }
                }
            }

            catch (Exception exception)
            {
                var str2 = exception.ToString();
                datarow.newrow("Exception", "Exception Not Expected", str2, "FAIL", driver);
                screenshot.screenshotfailed(driver);
            }

            finally
            {
                datarow.excelsave("MoshopConsole", driver, "teja.vellanki@mobankgroup.com");
                screenshot.screenshotfailed(driver);
                driver.Quit();
            }
        }

        [Test]
        public void commtest(IWebDriver driver, Datarow datarow)
        {
            var userjour = new UserJourneyTps();
            userjour.UserJourn(datarow, driver, "http://testshop.mobankdev.com/");
            datarow.newrow("", "", "Delete From Basket", "", driver);
            var delete = new Deletebasketstart();
            delete.deletebasstart(driver, datarow);
            datarow.newrow("", "", "Registration/Login", "", driver);
            var login = new LoginRegistration();
            login.Registration(driver, datarow);
            datarow.newrow("", "", "Mopay", "", driver);
            var pay = new BatchPay();
            pay.batchpay(driver, "http://testshop.mobankdev.com/", datarow);
        }
    }
}