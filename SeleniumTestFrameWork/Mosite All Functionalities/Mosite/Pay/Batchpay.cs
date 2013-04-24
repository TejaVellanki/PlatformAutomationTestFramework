using System.Threading;
using OpenQA.Selenium;
using Selenium;
//using System.Drawing;


namespace MoBankUI
{
    internal class BatchPay
    {
// This needs to be extended for all the merchants

        public void batchpay(IWebDriver driver, ISelenium selenium, string url, datarow datarow)
        {
            // Payment for Physioroom 

            if (url.Contains("physioroom") || url.Contains("trueshopping"))
            {
                driver.FindElement(By.XPath("//*[@id='ctl00']/section/fieldset/div[1]/label/span")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep3")).Click();
                selenium.WaitForPageToLoad("30000");
                string titl = driver.Title;
                selenium.GoBack();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.XPath("//*[@id='ctl00']/section/fieldset/div[2]/label/span")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep3")).Click();
                selenium.WaitForPageToLoad("300000");
                datarow.newrow("", "", "Mopay", "", driver, selenium);
                var Mopay = new Mopay_TPS();
                Mopay.Mopay(driver, selenium, datarow);
            }
            else
            {
                // This is a general payment testing using Mopay and needs to be extended if the client offering more than one payment process for example Paypal. 
                datarow.newrow("", "", "Mopay", "", driver, selenium);
                var Mopay = new Mopay_TPS();
                Mopay.Mopay(driver, selenium, datarow);
            }
        }
    }
}