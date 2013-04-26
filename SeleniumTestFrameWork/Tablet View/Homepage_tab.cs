using System;
using System.Collections.Generic;
using MoBankUI;
using OpenQA.Selenium;
using ObjectRepository;
using Webinator;
using WebDriver_Refining;
using MoBankUI;
using Selenium; 

namespace Tablet_View
{
    internal class Homepage_tab
    {
        driverdefining Driver;
      
        public void homepage(IWebDriver driver,ISelenium selenium ,datarow datarow)
        {
            /*
              IWebElement element;
              try
              {
                  string basket = CollectionMapV2.basket.Value.ToString();
                  {
                     element = driver.FindElement(By.Id(basket));
                     driver.FindElement(By.Id(basket)).Click();
                     Driver.waitforpagetoload(30000);
                    
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