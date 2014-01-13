using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI.Mosite.Pay
{
    public class BatchPay : Driverdefining
    {
// This needs to be extended for all the merchants
        [Test]
        public void Batchpay(IWebDriver driver, string url, Datarow datarow)
        {
            // Payment for Physioroom 

            if (url.Contains("physioroom") || url.Contains("trueshopping"))
            {
                driver.FindElement(By.XPath("//*[@id='ctl00']/section/fieldset/div[1]/label/span")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep3")).Click();

                driver.Navigate().Back();

                driver.FindElement(By.XPath("//*[@id='ctl00']/section/fieldset/div[2]/label/span")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep3")).Click();

                datarow.newrow("", "", "Mopay", "", driver);
                var Mopay = new MopayTps();
                Mopay.Mopay(driver, datarow);
            }
            else
            {
                // This is a general payment testing using Mopay and needs to be extended if the client offering more than one payment process for example Paypal. 
                datarow.newrow("", "", "Mopay", "", driver);
                var Mopay = new MopayTps();
                Mopay.Mopay(driver, datarow);
            }
        }
    }
}