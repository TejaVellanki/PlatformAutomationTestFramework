using System;
using System.Collections.Generic;
using System.Drawing;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;
using NUnit.Framework;
using OpenQA.Selenium;
using Tablet_View;


namespace MoBankUI
{
    public class MoshopBatch :driverdefining
    {
        public void batchmoshop(IWebDriver driver, datarow datarow, string items, string vers) 
        {
            var screenshot = new Screenshot();
            try
            {
                var moshop = new MoShopConsole();
                 moshop.Homepagetabs(driver, datarow);             
                 driver.Manage().Window.Maximize();
                               
                        string[] strArray = items.Split(new[] {','});
                        int num = 0;

                        foreach (string str in strArray)
                        {
                            if (str.Length != 0)
                            {
                               
                                #region Test Shop

                                if (str == "Create a Test Shop")
                                {
                                    datarow.newrow("", "", "Create a Test Shop", "", driver);
                                    var testshop = new createShop();
                                    testshop.Testshop(driver,datarow);
                                   
                                    new LookandFeel().lookandfeel(driver,datarow);
                                    #region Global Settings
                                    GlobalSetting global = new GlobalSetting();
                                   // global.globalsetting(driver);
                                    #endregion
                                }
                                #endregion
                                #region Test Scrape
                                if (str == "Create a Test Scrape")
                                {
                                    datarow.newrow("", "", "Create a Test Scarpe", "", driver);
                                    new Createscrape().createscrape(driver,datarow);
                                }
                                #endregion
                                #region Run Manual Scrape
                                if (str == "Run Manual Scrape")
                                {
                                    datarow.newrow("", "", "Run Manual Scrape", "",driver);
                                    var run = new RunScrape();
                                    run.runscrape(driver, datarow);
                                }
                                #endregion
                                #region Custom Domain Name Feature and Localisation
                                if (str == "Validate Custom Domain Name Feature and Localisation")
                                {
                                    datarow.newrow("", "", "Validate Custom domain Name", "",driver);
                                    new shop().culture(driver, datarow);
                                }
                                #endregion
                                #region "Run the Test Site - Scrape
                                if (str == "Run the Test Site - Scrape")
                                {
                                    try
                                    {
                                        driver.Manage().Window.Size = new Size(400,550);
                                        datarow.newrow("", "", "Run the Test Site", "",driver);
                                        driver.Navigate().GoToUrl("http://testshop.mobankdev.com/");
                                        
                                        BlobStorage blob = new BlobStorage();
                                        //blob.Blob(driver,datarow, "http://testshop.mobankdev.com/");
                                        commtest(driver,datarow);
                                    }
                                    catch (Exception ex)
                                    {
                                        string e = ex.ToString();
                                        datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
                                    }
                                }
                                #endregion
                                #region Run the Test Site - DataFeed XML

                                if (str == "Run the Test Site - DataFeed XML")
                                {
                                   
                                    var datafeed = new DatafeedXML();
                                    datafeed.datafeed(driver,datarow);
                                    datarow.newrow("", "", "Run the Test Site-DataFeed", "",driver);
                                    driver.Navigate().GoToUrl("http://testshop.mobankdev.com/");
                                    
                                    datarow.newrow("", "", "Footer Links", "",driver);
                                    var footer = new Footer_TPS();
                                    footer.Footerhome(driver, "http://testshop.mobankdev.com/", datarow);
                                    var relatedproduct = new RelatedProducts();
                                    relatedproduct.relatedproducts(driver,datarow);
                                    //commtest(driver, datarow);
                                }
                                #endregion
                                #region Validate Products Against Live Site - Modropenia
                                if (str == "Validate Products Against Live Site - Modropenia")
                                {
                                    Modrophenialive modrophenia = new Modrophenialive();
                                    modrophenia.modrophenialiveproducts(driver);
                                    modropheniaproducts products = new modropheniaproducts();
                                    products.product(datarow,driver);

                                }
                                #endregion
                                # region Delete Shop And Scrape
                                if (str == "Delete TestShop And TestScrape")
                                {
                                     DeleteTestShop delete = new DeleteTestShop();
                                     delete.deleteshop(driver);
                                     delete.deletedscrape(driver);
                                }
                                #endregion

                            }
                        }
                    }
             
            catch (Exception exception)
            {
                string str2 = exception.ToString();
                datarow.newrow("Exception", "Exception Not Expected", str2, "FAIL",driver);
                screenshot.screenshotfailed(driver);
            }
           
            finally
            {
                datarow.excelsave("MoshopConsole",driver, "teja.vellanki@mobankgroup.com");
                screenshot.screenshotfailed(driver);
                driver.Quit();
            }
        }

        [Test]
        public void commtest(IWebDriver driver, datarow datarow)
        {
            var userjour = new UserJourney_TPS();
            userjour.UserJourn(datarow,driver, "http://testshop.mobankdev.com/");
            datarow.newrow("", "", "Delete From Basket", "",driver);
            var delete = new Deletebasketstart();
            delete.deletebasstart(driver, datarow);
            datarow.newrow("", "", "Registration/Login", "",driver);
            var login = new LoginRegistration();
            login.registration(driver, datarow);
            datarow.newrow("", "", "Mopay", "",driver);
            var pay = new BatchPay();
            pay.batchpay(driver,"http://testshop.mobankdev.com/", datarow);
                                        
        }


    }
}