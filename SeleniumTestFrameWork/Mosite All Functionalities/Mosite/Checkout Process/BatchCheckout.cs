using System;
using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI
{
    internal class BatchCheckout
    {
        public void Checkout(IWebDriver driver, string url, datarow datarow)
        {
            try
            {
                if (url.Contains("countryhouseoutdoor"))
                {
                    //country house checkout process 
                    var contry = new Countryhouse();
                    contry.checkoutprocess(driver);
                }

                if (url.Contains("wolford"))
                {
                    var wolford = new Wolford();
                    wolford.wolfordcheckout(driver, datarow);
                }
                if (url.Contains("bathrooms"))
                {
                    var contry = new Countryhouse();
                    contry.bathroomcheckout(driver);
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                throw;
            }
        }
    }
}