    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selenium;
    using System;

namespace MoBankUI
{
    class MoshopBatch
    {
        public void batchmoshop(IWebDriver driver, ISelenium selenium, datarow datarow,string items)
        {
            Screenshot screenshot = new Screenshot();
            try
            {
                
                MoShopConsole moshop = new MoShopConsole();
                moshop.Homepagetabs(driver, selenium, datarow);
            }
            catch (Exception ex)
            {
            }

            string[] strArray = items.Split(new char[] { ',' });
            int num = 0;
            try
            {
            foreach (var str in strArray)
            {
               
                    if(str!=null)
                    {
                     
                        if(str== "Create a Test Shop")
                        {
                            datarow.newrow("", "", "Create a Test Shop", "", driver, selenium);
                            createShop testshop = new createShop();
                            testshop.Testshop(driver, selenium, datarow);                 
                            new LookandFeel().lookandfeel(driver, selenium, datarow);      
                        }
                         if(str =="Create a Test Scrape")
                        {
                             datarow.newrow("", "", "Create a Test Scarpe", "", driver, selenium);                
              
                           new Createscrape().createscrape(driver, selenium, datarow);        
                        }                    
                                                                               
                         

                      if(str== "Run Manual Scrape")
                        {
                            datarow.newrow("", "", "Run Manual Scrape", "", driver, selenium);
                           RunScrape run = new RunScrape();
                           run.runscrape(driver, selenium, datarow);
                        }
                          

                     if(str== "Validate Localisation feature")
                     {
                            datarow.newrow("", "", "Validate Localisation Feature", "", driver, selenium);
                     }
                     if (str == "Validate Custom Domain Name Feature")
                     {
                         datarow.newrow("", "", "Validate Custom domain Name", "", driver, selenium);
                     }
                     if (str == "Run the Test Site")
                     {
                         
                         datarow.newrow("", "", "Run the Test Site", "", driver, selenium);
                         datarow.newrow("", "", "All Links in Mosite - Validations", "", driver, selenium);
                         links_TPS hom = new links_TPS();
                         hom.Links(datarow, driver, selenium, "testshop.mobankdev.com");
                         datarow.newrow("", "", "Footer Links", "", driver, selenium);
                         Footer_TPS footer = new Footer_TPS();
                         footer.Footerhome(driver, selenium, "testshop.mobankdev.com", datarow);
                         datarow.newrow("", "", "Basket Functionality", "", driver, selenium);
                         Baskets_TPS basket = new Baskets_TPS();
                         basket.Basket(driver, selenium, datarow, "testshop.mobankdev.com");
                         datarow.newrow("", "", "User Journey", "", driver, selenium);
                         UserJourney_TPS userjour = new UserJourney_TPS();
                         userjour.UserJourn(datarow, driver, selenium, "testshop.mobankdev.com");
                         datarow.newrow("", "", "Delete From Basket", "", driver, selenium);
                         Deletebasketstart delete = new Deletebasketstart();
                         delete.deletebasstart(driver, selenium, datarow);
                         BatchCheckout ckout = new BatchCheckout();
                         ckout.checkout(driver, selenium, "testshop.mobankdev.com", datarow);
                         datarow.newrow("", "", "Registration/Login", "", driver, selenium);
                         LoginRegistration login = new LoginRegistration();
                         login.registration(driver, selenium, datarow);
                         datarow.newrow("", "", "Mopay", "", driver, selenium);
                         BatchPay pay = new BatchPay();
                         pay.batchpay(driver, selenium, "testshop.mobankdev.com", datarow);
                     }
                     if (str == "DataFeed XML")
                     {
                         DatafeedXML datafeed = new DatafeedXML();
                         datafeed.datafeed(driver, selenium, datarow);
                     }
                                          
                    
                  }
                }
                
              
            }
              catch (Exception exception)
                {
                    string str2 = exception.ToString();
                    datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
                finally
                {
                    datarow.excelsave("MoshopConsole", driver, selenium, "teja.vellanki@mobankgroup.com");
                    screenshot.screenshotfailed(driver, selenium);
                    driver.Quit();
                }
            
        }
    }
}
