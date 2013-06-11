using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium;
using ObjectRepository;

//using System.Drawing;

namespace MoBankUI
{
    public class links_TPS
    {
      
        public void Links(datarow datarow,IWebDriver driver, ISelenium selenium, string url)
        {
           
         
            try
            {
                if (url.Contains("smallDevice"))
                { 
                    LinksExpand link = new LinksExpand();
                    link.AllLink(driver, selenium, datarow);
                    //Productpage page = new Productpage();
                   // page.productPage(driver, selenium, datarow);

                }
                else
                {
                    LinksExpand link = new LinksExpand();
                    link.AllLink(driver, selenium, datarow);
                  //  Productpage page = new Productpage();
                   // page.productPage(driver, selenium, datarow);

                }

            }
            catch
            {

            }
        }

    }
}