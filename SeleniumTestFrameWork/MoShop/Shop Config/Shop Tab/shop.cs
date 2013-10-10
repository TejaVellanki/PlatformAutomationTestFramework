﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;

namespace MoBankUI
{
    internal class shop : driverdefining
    {
        public void culture(IWebDriver driver , datarow datarow)
        {
            try
            {
              driver.FindElement(By.LinkText("MoShop")).Click();
                waitforpagetoload(driver,30000);
              driver.FindElement(By.CssSelector("#IndexMenuLeaf3 > a")).Click();
                waitforpagetoload(driver,30000);
              driver.FindElement(By.LinkText("testshop")).Click();
                waitforpagetoload(driver,30000);
             driver.FindElement(By.LinkText("Shop")).Click();  
                waitforpagetoload(driver,30000);
                try
                {
                     driver.FindElement(By.CssSelector("h3.collapsible.collapsed")).Click();
                    waitforpagetoload(driver,30000);
                     driver.FindElement(By.CssSelector("h3.collapsible.collapsed")).Click();
                    waitforpagetoload(driver,30000);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                
                driver.FindElement(By.Id("CustomDomainName")).SendKeys("m.testshop.com");
               driver.FindElement(By.CssSelector("input.button")).Click();
                waitforpagetoload(driver,30000);
                  new SelectElement(driver.FindElement(By.Id("DefaultCultureSelected"))).SelectByText("Telugu (India) - ₹ [te-IN]");
              
                driver.FindElement(By.CssSelector("input.button")).Click();
                waitforpagetoload(driver,30000);


            
                decimal count = driver.FindElements(By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr")).Count;
                for (int i = 1; i <= count; i++)
                {

                    string name =GetValue(driver,By.XPath("//div[@id='CataloguesControl']/div/table/tbody/tr[" + i + "]/td/input"),30);
                    if (name == "Default")
                    {
                        driver.FindElement(By.XPath("//*[@id='CataloguesControl']/div/table/tbody/tr["+i+"]/th[2]/a")).Click();
                        driver.FindElement(By.CssSelector("input.button")).Click();
                          waitforpagetoload(driver,30000);
                        new SelectElement(driver.FindElement(By.Id("Culture_Value"))).SelectByText("Telugu (India) - ₹ [te-IN]");
                        driver.FindElement(By.CssSelector("input.button")).Click();
                           waitforpagetoload(driver,30000);
                        break;
                        

                    }
                }

                driver.Navigate().GoToUrl("http://m.testshop.com"); 
                  waitforpagetoload(driver,30000);
                string url = driver.Url;
                if (url == "http://m.testshop.com")
                {
                    datarow.newrow("Customa Domain Name", "http://m.testshop.com/", url, "PASS",driver);
                }
                else
                {
                    datarow.newrow("Customa Domain Name", "http://m.testshop.com/", url, "FAIL",driver);
                }
              
            }

            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Exopected", e, "PASS",driver);
            }
        }
    }
}