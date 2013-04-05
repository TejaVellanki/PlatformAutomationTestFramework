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
            MoShopConsole moshop = new MoShopConsole();
            moshop.Homepagetabs(driver, selenium, datarow);

            string[] strArray = items.Split(new char[] { ',' });
            int num = 0;
            foreach (var str in strArray)
            {
                try
                {
                    switch (str)
                    {
                        case "Create a Test Shop":
                            datarow.newrow("", "", "Create a Test Shop", "", driver, selenium);
                            createShop testshop = new createShop();                                                   
                            new LookandFeel().lookandfeel(driver, selenium, datarow);                
                            num++;
                            break;

                        case "Create a Test Scrape":
                            datarow.newrow("", "", "Create a Test Scarpe", "", driver, selenium);                   
              
                             new Createscrape().createscrape(driver, selenium, datarow);             
                             num++;
                             break;

                        case "Run Manual Scrape":
                            datarow.newrow("", "", "Run Manual Scrape", "", driver, selenium);
                            RunScrape run = new RunScrape();
                            run.runscrape(driver, selenium, datarow);
                            num++;
                            break;

                        case "Validate Localisation feature":
                            datarow.newrow("", "", "Validate Localisation Feature", "", driver, selenium);
                            num++;
                            break;

                        case "Validate Custom Domain Name Feature":
                            datarow.newrow("", "", "Validate Custom domain Name", "", driver, selenium);                          
                            num++;
                            break;

                    
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
                    datarow.excelsave("MoshopConsole", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                    driver.Quit();
                }
            }
        }
    }
}
