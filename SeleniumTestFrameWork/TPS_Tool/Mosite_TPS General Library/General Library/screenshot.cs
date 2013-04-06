using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Reflection;
using System.Management;
//using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium;
using System.Data.OleDb;
using System.IO;
using System.Timers;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;


namespace MoBankUI
{
    public class Screenshot
    {

       
        public Selenium.WebDriverBackedSelenium selenium;


        public void screenshotnotifications(IWebDriver driver, ISelenium selenium)
        {
            selenium.Open("http://ec2-174-129-69-123.compute-1.amazonaws.com:8080/notify/show");
            selenium.WaitForPageToLoad("30000");
            using (Bitmap b = new Bitmap(50, 50))
            { 
                //selenium.CaptureScreenshot(@"C:\Selenium\Input Data\Callback.png");
               
          string randomNumber = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture) +  
          DateTime.Now.Month.ToString(CultureInfo.InvariantCulture)

          +

          DateTime.Now.Day.ToString(CultureInfo.InvariantCulture)

          +

          DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture)

          +

          DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture)

          +

          DateTime.Now.Second.ToString(CultureInfo.InvariantCulture);

                string image = @"C:\Selenium\Input Data\Callback" + randomNumber + ".png";
                b.Save(image, System.Drawing.Imaging.ImageFormat.Png);

                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(image, System.Drawing.Imaging.ImageFormat.Png);
            }

              
            
        }
        public void screenshotfailed(IWebDriver driver, ISelenium selenium)
        {
            using (Bitmap b = new Bitmap(100,100))
            {
                //selenium.CaptureScreenshot(@"C:\Selenium\Input Data\Callback.png");

                string randomNumber = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture) +
                DateTime.Now.Month.ToString(CultureInfo.InvariantCulture)

                +

                DateTime.Now.Day.ToString(CultureInfo.InvariantCulture)

                +

                DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture)

                +

                DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture)

                +

                DateTime.Now.Second.ToString(CultureInfo.InvariantCulture);

                string image = @"C:\Selenium\Input Data\FailedScreenshots\" + randomNumber + ".png";
                b.Save(image, System.Drawing.Imaging.ImageFormat.Png);
       
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(image, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

    }
}