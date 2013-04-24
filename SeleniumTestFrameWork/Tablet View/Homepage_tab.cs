using System;
using System.Collections.Generic;
using MoBankUI;
using OpenQA.Selenium;
using objectrepository;
using Webinator;
using WebDriver_Refining;

namespace Tablet_View
{
    internal class Homepage_tab
    {
        driverdefining Driver;
      
        public void homepage(IWebDriver driver, datarow datarow)
        {
          
            IWebElement element;
         
            try
            {
                string basket = CollectionMap.basket.Value.ToString();
                
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
        }
    }
}