//-----------------------------------------------------------------------
// <copyright company="MoPowered">
//     Copyright (c) MoPowered. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace MoBankUI
{
    using System;
    using OpenQA.Selenium;
   
    internal class Mositebatch
    {
        public void mosite(IWebDriver driver, datarow datarow, string urls, string items)
        {
            var screenshot = new Screenshot();

            string[] strArray = items.Split(new[] {','});
            string[] urlarray = urls.Split(new[] {','});
            int num = 0;
            try
            {
                foreach (string url in urlarray)
                {
                    foreach (string str in strArray)
                    {
                        if (str != null)
                        {
                            if (str == "Test All Links in Mosite")
                            {
                                datarow.newrow("", "", "Test All Links in Mosite", "",driver);
                                var tick = new Tickle();
                                tick.HomepageTabsTickle(datarow,driver, url);
                            }

                          

                            if (str == "Test Footer Links")
                            {
                                datarow.newrow("", "", "Test Footer Links", "",driver);
                            }
                            if (str == "Test Basket Functionality")
                            {
                                datarow.newrow("", "", "Test Basket Functionality", "",driver);
                            }
                            if (str == "Test Produict Page - Test Add Product to Basket")
                            {
                                datarow.newrow("", "", "Test Produict Page - Test Add Product to Basket", "", driver);
                            }
                            if (str == "Test Delete From Basket - Test Product Unavailable")
                            {
                                datarow.newrow("", "", "Test Delete From Basket - Test Product Unavailable", "", driver);
                            }
                            if (str == "Test Registration/Login - CheckOut Pages")
                            {
                                datarow.newrow("", "", "Test Registration/Login - CheckOut Pages", "",driver);
                            }
                            if (str == "Test Mopay")
                            {
                                datarow.newrow("", "", "Test Mopay", "",driver);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                string str2 = exception.ToString();
                datarow.newrow("Exception", "", "Exception Not Expected", "FAIL",driver);
                screenshot.screenshotfailed(driver);
            }
            finally
            {
                datarow.excelsave("MoshopConsole",driver, "teja.vellanki@mobankgroup.com");
                screenshot.screenshotfailed(driver);
                driver.Quit();
            }
        }
    }
}