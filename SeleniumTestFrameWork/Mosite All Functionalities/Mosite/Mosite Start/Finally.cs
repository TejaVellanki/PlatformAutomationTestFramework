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
    class MositeGeneral 
    {

        GeneralLibrary generalLibrary;
       
        public void Finally(IWebDriver driver, ISelenium selenium, string url,datarow datarow,string emails)
        {
            generalLibrary = new GeneralLibrary();
            try
            {            
                               
                //Footer_TPS footer = new Footer_TPS();
                //footer.Footer(driver, selenium, url, datarow);

                //Baskets_TPS basket = new Baskets_TPS();
                //basket.Basket(driver, selenium, datarow);

                //links_TPS hom = new links_TPS();
                //hom.Links(datarow, driver, selenium, url);

                //UserJourney_TPS userjour = new UserJourney_TPS();
                //userjour.UserJourn(datarow, driver, selenium, url);

                //Mopay_TPS Mopay = new Mopay_TPS();
                //Mopay.Mopay(driver, selenium, datarow);
              
            }
            catch (Exception e)
            {
                Console.Write(e);
                string ex = e.ToString();
                Screenshot scree = new Screenshot();
                datarow.newrow("Exception", "Not Expected", ex, "FAIL", driver, selenium);
                scree.screenshotfailed(driver, selenium);

            }
            finally
            {
                
                string[] split = url.Split(new Char[] { ' ', ',', '.', '/', '\t' });

                foreach (string sr in split)
                {
                    if (split[2] == "m"||split[2]== "www")
                    {
                        if (sr == split[3])
                        {
                            datarow.consolidatedreport(emails);
                            datarow.excelsave("Mosite-" + sr + "",driver,selenium,emails);
                          
                            driver.Quit();
                            break;
                        }
                    }
                    else
                    {
                        if (sr == split[2])
                        {
                            datarow.consolidatedreport(emails);
                            datarow.excelsave("Mosite-" + sr + "",driver,selenium,emails);
                           
                            driver.Quit();
                            break;
                        }
                    }
                }
                

            }

        }

    }
}