using System;
using OpenQA.Selenium;

namespace MoBankUI
{
    internal class HomepageTab
    {
        public HomepageTab(Driverdefining driver)
        {
        }

        public HomepageTab()
        {
            throw new NotImplementedException();
        }

        public void Homepage(IWebDriver driver, Datarow datarow)
        {
            /*
              IWebElement element;
              try
              {
                  string basket = CollectionMapV2.basket.Value.ToString();
                  {
                     element = driver.FindElement(By.Id(basket));
                     driver.FindElement(By.Id(basket)).Click();
                     Driver.  
                    
                  }
                      // Identifying the Basket Element. 
                  datarow.newrow("Validate Basket Element","Basket Info","Basket Elemnt is Present","PASS");
              }
              catch (Exception ex)
              {
                  string e = ex.ToString();
                  datarow.newrow("Validate Basket Element","Exception Not Expected- Basket Element Should Be Present",e,"FAIL");
              }
             * */
        }
    }
}