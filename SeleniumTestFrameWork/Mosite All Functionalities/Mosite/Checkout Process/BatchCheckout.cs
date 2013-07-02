using OpenQA.Selenium;
using Selenium;

//using System.Drawing;

namespace MoBankUI
{
    internal class BatchCheckout
    {
        public void checkout(IWebDriver driver, ISelenium selenium, string url, datarow datarow)
        {
            if (url.Contains("countryhouseoutdoor"))
            {
                //country house checkout process 
                var contry = new Countryhouse();
                contry.checkoutprocess(driver, selenium);
            }

            if (url.Contains("wolford"))
            {
                var wolford = new Wolford();
                wolford.wolfordcheckout(driver, selenium, datarow);
            }
            if (url.Contains("bathrooms"))
            {
                var contry = new Countryhouse();
                contry.bathroomcheckout(driver, selenium);
            }
        }
    }
}