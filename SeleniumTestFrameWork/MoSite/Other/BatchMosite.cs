using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium;
using System;

namespace MoBankUI
{
    class Mositebatch
    {
        public void mosite(IWebDriver driver, ISelenium selenium, datarow datarow, string urls,string items)
        {
            Screenshot screenshot = new Screenshot();
           
            string[] strArray = items.Split(new char[] { ',' });
            string[] urlarray = urls.Split(new char[] { ',' });
            int num = 0;
            try
            {
                foreach (string url in urlarray)
                {
                    foreach (var str in strArray)
                    {

                        if (str != null)
                        {

                            if (str == "Test All Links in Mosite")
                            {
                                datarow.newrow("", "", "Test All Links in Mosite", "", driver, selenium);
                                Tickle tick = new Tickle();
                                tick.HomepageTabsTickle(datarow, driver, selenium, url);
                            }


                            if (str == "Test Footer Links")
                            {
                                datarow.newrow("", "", "Test Footer Links", "", driver, selenium);

                            }
                            if (str == "Test Basket Functionality")
                            {
                                datarow.newrow("", "", "Test Basket Functionality", "", driver, selenium);

                            }
                            if (str == "Test Produict Page - Test Add Product to Basket")
                            {
                                datarow.newrow("", "", "Test Produict Page - Test Add Product to Basket", "", driver, selenium);
                            }
                            if (str == "Test Delete From Basket - Test Product Unavailable")
                            {
                                datarow.newrow("", "", "Test Delete From Basket - Test Product Unavailable", "", driver, selenium);
                            }
                            if (str == "Test Registration/Login - CheckOut Pages")
                            {
                                datarow.newrow("", "", "Test Registration/Login - CheckOut Pages", "", driver, selenium);
                            }
                            if (str == "Test Mopay")
                            {
                                datarow.newrow("", "", "Test Mopay", "", driver, selenium);
                            }


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
