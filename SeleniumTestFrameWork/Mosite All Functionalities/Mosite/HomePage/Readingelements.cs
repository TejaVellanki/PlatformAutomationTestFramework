using OpenQA.Selenium;
using Selenium;

//using System.Drawing;

namespace MoBankUI
{
    public class links_TPS
    {
        public void Links(datarow datarow, IWebDriver driver, ISelenium selenium, string url)
        {
            try
            {
                if (url.Contains("smallDevice"))
                {
                    var link = new LinksExpand();
                    link.AllLink(driver, selenium, datarow);
                    //Productpage page = new Productpage();
                    // page.productPage(driver, selenium, datarow);
                }
                else
                {
                    var link = new LinksExpand();
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