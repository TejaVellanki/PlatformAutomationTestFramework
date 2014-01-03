using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI
{
    public class links_TPS
    {
        public void Links(datarow datarow, IWebDriver driver, string url)
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
            catch
            {
            }
        }
    }
}