using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI
{
    public class Screenshot
    {
        public void screenshotnotifications(IWebDriver driver)
        {
            using (var b = new Bitmap(50, 50))
            {
                //.CaptureScreenshot(@"C:\\Input Data\Callback.png");

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

                string image = @"C:\\Input Data\Callback" + randomNumber + ".png";
                b.Save(image, ImageFormat.Png);

                ((ITakesScreenshot) driver).GetScreenshot().SaveAsFile(image, ImageFormat.Png);
            }
        }

        public void screenshotfailed(IWebDriver driver)
        {
            using (var b = new Bitmap(100, 100))
            {
                //.CaptureScreenshot(@"C:\\Input Data\Callback.png");

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