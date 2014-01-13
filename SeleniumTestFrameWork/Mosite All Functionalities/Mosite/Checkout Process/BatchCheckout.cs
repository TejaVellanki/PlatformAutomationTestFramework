using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI.Mosite
{
    internal class BatchCheckout
    {
        public void Checkout(IWebDriver driver, string url, Datarow datarow)
        {
            Countryhouse contry;
            if (url.Contains("countryhouseoutdoor"))
            {
                //country house checkout process 
                contry = new Countryhouse();
                contry.Checkoutprocess(driver);
            }

            if (url.Contains("wolford"))
            {
                var wolford = new Wolford();
                wolford.Wolfordcheckout(driver, datarow);
            }
            if (!url.Contains("bathrooms")) return;
            contry = new Countryhouse();
            contry.bathroomcheckout(driver);
        }
    }
}