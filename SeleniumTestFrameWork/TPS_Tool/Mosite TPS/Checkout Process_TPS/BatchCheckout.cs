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
    class BatchCheckout
    {
        public void checkout(IWebDriver driver, ISelenium selenium,string url,datarow datarow)
        {
            if(url.Contains("countryhouseoutdoor"))
            {
                //country house checkout process 
                Countryhouse contry = new Countryhouse();
                contry.checkoutprocess(driver, selenium);
            }
            
        }
    }
}
