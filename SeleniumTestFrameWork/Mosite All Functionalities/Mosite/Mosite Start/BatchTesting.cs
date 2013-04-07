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
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace MoBankUI
{
    class BatchTesting
    {
        Screenshot screenshot = new Screenshot();
        public void batchtesting(string items,string url,IWebDriver driver, ISelenium selenium,datarow datarow)
        {
                         string[] selectedvalue = items.Split(',');
                         int i = 0;
                         foreach (string function in selectedvalue)
                         {
                             try
                             {                     

                                 if (function == "Test All Links in Mosite")
                                 {
                                     datarow.newrow("", "", "All Links in Mosite - Validations", "", driver, selenium);
                                     links_TPS hom = new links_TPS();
                                     hom.Links(datarow, driver, selenium, url);
                                     i++;
                                 }
                                 if (function == "Test Footer Links")
                                 {
                                     datarow.newrow("", "", "Footer Links", "", driver, selenium);
                                     Footer_TPS footer = new Footer_TPS();
                                     footer.Footerhome(driver, selenium, url, datarow);
                                     i++;
                                 }
                                 if (function == "Test Basket Functionality")
                                 {
                                     datarow.newrow("", "", "Basket Functionality", "", driver, selenium);
                                     Baskets_TPS basket = new Baskets_TPS();
                                     basket.Basket(driver, selenium, datarow, url);
                                     i++;
                                 }
                                 if (function == "Test Product page - Test Add Product to Basket")
                                 {
                                     datarow.newrow("", "", "User Journey", "", driver, selenium);
                                     UserJourney_TPS userjour = new UserJourney_TPS();
                                     userjour.UserJourn(datarow, driver, selenium, url);
                                     i++;
                                 }
                                 if (function == "Test Delete From Basket - Test product Unavailable")
                                 {
                                     datarow.newrow("", "", "Delete From Basket", "", driver, selenium);
                                     Deletebasketstart delete = new Deletebasketstart();
                                     delete.deletebasstart(driver, selenium, datarow);
                                     i++;
                                 }

                                 
                                 if (function == "Test Registration/Login - CheckOut Pages")
                                 {

                                     BatchCheckout ckout = new BatchCheckout();
                                     ckout.checkout(driver, selenium, url,datarow);
                                     datarow.newrow("", "", "Registration/Login", "", driver, selenium);
                                     LoginRegistration login = new LoginRegistration();
                                     login.registration(driver, selenium, datarow);
                                     i++;
                                 }

                                 if (function == "Test Mopay")
                                 {
                                     try
                                     {
                                         datarow.newrow("", "", "Mopay", "", driver, selenium);
                                         BatchPay pay = new BatchPay();
                                         pay.batchpay(driver, selenium, url, datarow);
                                     }
                                     catch (Exception ex)
                                     {
                                         string e = ex.ToString();
                                         datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver, selenium);
                                         screenshot.screenshotfailed(driver, selenium);
                                     }                                   
                                   
                                     i++;
                                 }
                                
                                
                             }
                             catch (Exception ex)
                             {
                                 string e = ex.ToString();
                                 datarow.newrow("Exception", "", "Exception Not Expected", "FAIL", driver, selenium);
                                 screenshot.screenshotfailed(driver, selenium);
                             }
                            
            
                            
                        }                               
                         
        }

      
    }
}
