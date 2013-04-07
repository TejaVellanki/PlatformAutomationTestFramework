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
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;


namespace MoBankUI
{
    class BatchPay
    {// This needs to be extended for all the merchants

        public void batchpay(IWebDriver driver,ISelenium selenium, string url, datarow datarow)
        {

            // Payment for Physioroom 
            
            if (url.Contains("physioroom")||url.Contains("trueshopping"))
            {
                driver.FindElement(By.XPath("//*[@id='ctl00']/section/fieldset/div[1]/label/span")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep3")).Click();
                selenium.WaitForPageToLoad("30000");
                string titl = driver.Title.ToString();
                selenium.GoBack();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.XPath("//*[@id='ctl00']/section/fieldset/div[2]/label/span")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep3")).Click();
                selenium.WaitForPageToLoad("300000");
                datarow.newrow("", "", "Mopay", "", driver, selenium);
                Mopay_TPS Mopay = new Mopay_TPS();
                Mopay.Mopay(driver, selenium, datarow);
            }
            else
            {
                // This is a general payment testing using Mopay and needs to be extended if the client offering more than one payment process for example Paypal. 
                datarow.newrow("", "", "Mopay", "", driver, selenium);
                Mopay_TPS Mopay = new Mopay_TPS();
                Mopay.Mopay(driver, selenium, datarow);
            }

        }

   
    }
}
