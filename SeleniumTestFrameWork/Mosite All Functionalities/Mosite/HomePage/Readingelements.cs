using System;
using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI.Mosite.HomePage
{
    public class LinksTps
    {
        public void Links(Datarow datarow, IWebDriver driver, string url)
        {
            try
            {
                if (url.Contains("user-scalable=yes"))
                {
                    var link = new LinksExpand();
                    link.AllLink(driver, datarow);
                    //Productpage page = new Productpage();
                    // page.productPage(driver, datarow);
                }
                else
                {
                    var link = new LinksExpand();
                    link.AllLink(driver, datarow);
                    //  Productpage page = new Productpage();
                    // page.productPage(driver, datarow);
                }
            }
            catch(Exception ex)
            {
                var e = ex.ToString();
                datarow.Newrow("Exception", "Exception Not Exopected", e, "FAIL");
            }
        }
    }
}