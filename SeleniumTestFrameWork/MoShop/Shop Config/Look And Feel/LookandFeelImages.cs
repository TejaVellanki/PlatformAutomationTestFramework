using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MoBankUI.MoShop
{
    internal class LookandFeelImages : Driverdefining
    {
        public void Images(IWebDriver driver, Datarow datarow)
        {
            try
            {
                //*[@id="customisation-page-update-form"]/p/input
                //Logo and Home Page Image
                driver.FindElement(By.Id("HomeImageImport_Image"))
                      .SendKeys(
                          @"C:\Users\teja\Documents\GitHub\PlatformAutomationTestFramework\SeleniumTestFrameWork\ObjectRepository\Homepage and CategoryImages\Teja Home Image.jpg");
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("input.button")).Click();
                if (driver.PageSource.Contains("Server"))
                    driver.Navigate().Back();

                // pagerefresh(driver);
                driver.FindElement(By.Id("IconImageImport_Image"))
                      .SendKeys(
                          @"C:\Users\teja\Documents\GitHub\PlatformAutomationTestFramework\SeleniumTestFrameWork\ObjectRepository\Images\ion.ico");
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("input.button")).Click();

                if (driver.PageSource.Contains("Server"))
                    driver.Navigate().Back();
                //pagerefresh(driver);
                new SelectElement(driver.FindElement(By.Id("HomeImageJustification"))).SelectByText("Centre");
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("input.button")).Click();

                //  pagerefresh(driver);

                //Custom Basket Image


                driver.FindElement(By.XPath("//form[@id='customisation-page-update-form']/div[11]/h3")).Click();

                driver.FindElement(By.Id("CustomBasketImageImport_Image"))
                      .SendKeys(
                          @"C:\Users\teja\Documents\GitHub\PlatformAutomationTestFramework\SeleniumTestFrameWork\ObjectRepository\Images\Teja Custom Basket Image.png");

                if (driver.PageSource.Contains("Server"))
                    driver.Navigate().Back();
                //  pagerefresh(driver);

                // Click TO Call Image

                // driver.FindElement(By.XPath("//form[@id='customisation-page-update-form']/div[11]/h3")).Click();
                driver.FindElement(By.Id("ClickToCallImage_Image"))
                      .SendKeys(
                          @"C:\Users\teja\Documents\GitHub\PlatformAutomationTestFramework\SeleniumTestFrameWork\ObjectRepository\Images\Contact Us.jpg");
                driver.FindElement(By.Id("ClickToCallEnabled")).Click();

                if (driver.PageSource.Contains("Server"))
                    driver.Navigate().Back();
                driver.FindElement(By.Id("ClickToCallPhoneNumber")).Clear();
                driver.FindElement(By.Id("ClickToCallPhoneNumber")).SendKeys("0123456789");
                driver.FindElement(By.Id("ClickToCallText")).Clear();
                driver.FindElement(By.Id("ClickToCallText")).SendKeys("Call US");
                driver.FindElement(By.CssSelector("input.button")).Click();


                //driver.FindElement(By.Id("ClickToCallImage_Image")).SendKeys("C:\\Users\\teja\\Desktop\\Images and catalogues\\Teja Custom Basket Image.png");

                driver.FindElement(By.Id("SuccessImageImport_Image"))
                      .SendKeys(
                          @"C:\Users\teja\Documents\GitHub\PlatformAutomationTestFramework\SeleniumTestFrameWork\ObjectRepository\Images\success.png");
                driver.FindElement(By.CssSelector("input.button")).Click();

                if (driver.PageSource.Contains("Server"))
                    driver.Navigate().Back();
                // pagerefresh(driver);
                driver.FindElement(By.Id("FailureImageImport_Image"))
                      .SendKeys(
                          @"C:\Users\teja\Documents\GitHub\PlatformAutomationTestFramework\SeleniumTestFrameWork\ObjectRepository\Images\Failure.png");
                driver.FindElement(By.CssSelector("input.button")).Click();

                if (driver.PageSource.Contains("Server"))
                    driver.Navigate().Back();
                //  pagerefresh(driver);

                #region validations

                datarow.newrow("Home Page Logo Uploaded into Console", "css=img[alt=\"Home Image\"]",
                    "css=img[alt=\"Home Image\"]",
                    IsElementPresent(driver, By.CssSelector("img[alt=\"Home Image\"]"), 30) ? "PASS" : "FAIL");

                datarow.newrow("Home Page Icon Uploaded into Console", "css=img[alt='Icon']", "css=img[alt='Icon']",
                    IsElementPresent(driver, By.CssSelector("img[alt='Icon']"), 30) ? "PASS" : "FAIL");

                datarow.newrow("Custom Basket Image Uploaded into Console", "css=img[alt='Custom Basket Image']",
                    "css=img[alt='Custom Basket Image']",
                    IsElementPresent(driver, By.CssSelector("img[alt='Custom Basket Image']"), 30) ? "PASS" : "FAIL");

                datarow.newrow("Success Image Uploaded into Console", "css=img[alt='Custom Basket Image']",
                    "css=img[alt='Custom Basket Image']",
                    IsElementPresent(driver, By.CssSelector("img[alt=\"Order confirmation success Image\"]"), 30)
                        ? "PASS"
                        : "FAIL");

                datarow.newrow("Failure Image Uploaded into Console",
                    "css= img[alt=\"Order confirmation failure Image\"]",
                    "css= img[alt=\"Order confirmation failure Image\"]",
                    IsElementPresent(driver, By.CssSelector("img[alt=\"Order confirmation failure Image\"]"), 30)
                        ? "PASS"
                        : "FAIL");

                #endregion
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Exceprtion Not Expected", e, "FAIL");
            }
        }

        public void Pagerefresh(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Look & Feel")).Click();

            driver.FindElement(By.XPath("(//a[contains(text(),'…')])[3]")).Click();
        }
    }
}