using System;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using System.Data;
//using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Selenium;
using System.Data.OleDb;
using System.IO;
using System.Timers;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace MoBankUI
{
    class Baskets_TPS
    {
        Screenshot screenshot = new Screenshot();
        public void Basket(IWebDriver driver, ISelenium selenium,datarow datarow,string url)
        {
            try
            {
                          
             
                try
                {
                    driver.FindElement(By.Id("BasketInfo")).Click();
                    selenium.WaitForPageToLoad("30000");
                    datarow.newrow("Basket Info Button", "Basket Info Button Is Expected","Basket Info Button is Present", "PASS", driver, selenium);
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Basket Info Button", "Basket Info Button Is Expected", e, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);

                }
               
                try
                {
                    string value = driver.FindElement(By.Id("BasketInfo")).Text;


                    if (value == "(0)")
                    {
                        datarow.newrow("Basket Value", "(0)", value, "PASS", driver, selenium);

                    }
                    else
                    {
                        datarow.newrow("Basket Value", "(0)", value, "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Basket Info Text", "Basket Info Text Is Expected", e, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);

                }
                Footer_TPS footer = new Footer_TPS();
                footer.Footer(driver,selenium, datarow);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Excepetion Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }

        }
    }
}
