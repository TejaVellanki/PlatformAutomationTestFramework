using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using OpenQA.Selenium;
using Selenium;

//using System.Drawing;

namespace MoBankUI
{
    public class Screenshot
    {
      


        public void screenshotnotifications(IWebDriver driver, ISelenium selenium)
        {
            selenium.Open("http://ec2-174-129-69-123.compute-1.amazonaws.com:8080/notify/show");
            selenium.WaitForPageToLoad("30000");
            using (var b = new Bitmap(50, 50))
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
                b.Save(image, ImageFormat.Png);

                ((ITakesScreenshot) driver).GetScreenshot().SaveAsFile(image, ImageFormat.Png);
            }
        }

        public void screenshotfailed(IWebDriver driver, ISelenium selenium)
        {
            using (var b = new Bitmap(100, 100))
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
                b.Save(image, ImageFormat.Png);

                ((ITakesScreenshot) driver).GetScreenshot().SaveAsFile(image, ImageFormat.Png);
            }
        }
    }
}