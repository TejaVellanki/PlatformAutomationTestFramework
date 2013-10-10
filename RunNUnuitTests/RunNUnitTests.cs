using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;
using MoBankUI;

namespace Tests
{
    [TestFixture]
    public class nunittests :driverdefining
    {
        public IWebDriver driver;
       
        public StringBuilder verificationErrors;
        public MoBankUI.Screenshot screenshot;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            FirefoxProfile firefoxProfile = new FirefoxProfile();
            firefoxProfile.SetPreference("browser.private.browsing.autostart", true);
            driver = new FirefoxDriver(firefoxProfile);
            driver.Manage().Cookies.DeleteAllCookies();
            verificationErrors = new StringBuilder();
            

        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }


        [Test]
        public void BathroomLinearTestRun()
        {
            driver.Navigate().GoToUrl("http://m.bathrooms.com/");
          waitforpagetoload(30000);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.FindElement(By.LinkText("Bathroom suites")).Click();
          waitforpagetoload(30000);
            string url = driver.Url;
            Console.WriteLine(url);
            driver.FindElement(By.LinkText("Bathroom Ranges")).Click();
          waitforpagetoload(30000);
            string url1 = driver.Url;
            Console.WriteLine(url1);
            driver.FindElement(By.CssSelector("h2.wrappable.ui-li-heading")).Click();
          waitforpagetoload(30000);
            driver.FindElement(By.CssSelector("div.price > p.ui-li-desc")).Click();
          waitforpagetoload(30000);
            driver.FindElement(By.XPath("(//input[@value='Add To Basket'])[2]")).Click();
          waitforpagetoload(30000);
            Thread.Sleep(5000);
            string url2 = driver.Url;
            Console.WriteLine(url2);


            //Navigating to multiple Product Pages
            #region Visiting Products Page
            try
            {

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                Console.WriteLine(e);
            }
           #endregion
            // Navigating to random pages 
           checkout();
           
        }
        

        public void checkout()
        {
            //Navigating to Bathroom Page
            driver.FindElement(By.Id("BasketInfo")).Click();
          waitforpagetoload(30000);
            string url3 = driver.Url;
            Console.WriteLine(url3);

            //Clicking on Checkout Button 
            driver.FindElement(By.CssSelector("#GoToCheckout > span.ui-btn-inner > span.ui-btn-text")).Click();
          waitforpagetoload(30000);
            Thread.Sleep(10000);
            string url4 = driver.Url;
            Console.WriteLine(url4);
         

            string productunvail = null;
            //Validating the Stock Status Page
            if (url4.Contains("StockStatus"))
            {
                decimal productsinbasket = GetXpathCount("//*[@id='Top']/div[1]/div[2]/div[2]/ul/li");
                for (int j = 1; j <= productsinbasket; j++)
                {
                    if (IsElementPresent(driver, By.XPath("//*[@id='Top']/div[1]/div[2]/div[2]/ul/li[" + j + "]/div/div/p")))
                    {
                        productunvail =  driver.FindElement(By.XPath("//*[@id='Top']/div[1]/div[2]/div[2]/ul/li[" + j + "]/div/div/p")).Text;
                        if (productunvail == "Product unavailable")
                        {
                            break;
                        }
                    }
                }
                if (productunvail == "Product unavailable" ||  driver.PageSource.Contains("Product unavailable"))
                    {
                        // Validating the Product Availability
                       Console.WriteLine("Product Unavailable");
                       Assert.Fail("Product Unavailable");
                    }
                }
                else
                {
                   
                    if (IsElementPresent(driver,By.Id("Pagecontent_ButtonContinue")))
                    {
                        driver.FindElement(By.Id("Pagecontent_ButtonContinue")).Click();
                      waitforpagetoload(30000);
                    }
                    Assert.AreEqual("Checkout - Bathrooms", driver.Title);
                    address();
                }
        }

        public void address()
        {
            //Populating the Address page
            new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlTitle"))).SelectByText("Mr");
            driver.FindElement(By.Id("Pagecontent_TextBoxFirstName")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxFirstName")).SendKeys("Mobank");
            driver.FindElement(By.Id("Pagecontent_TextBoxLastname")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxLastname")).SendKeys("Mopowered");
            driver.FindElement(By.Id("Pagecontent_TextStreetaddress1")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextStreetaddress1")).SendKeys("37");
            driver.FindElement(By.Id("Pagecontent_TextStreetaddress2")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextStreetaddress2")).SendKeys("albertembankment");
            driver.FindElement(By.Id("Pagecontent_TextBoxCity")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxCity")).SendKeys("vauxhall");
            driver.FindElement(By.Id("Pagecontent_TextBoxPostCode")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxPostCode")).SendKeys("se1 7tl");
            driver.FindElement(By.Id("Pagecontent_TextBoxEmail")).SendKeys("mopowered@mopowered.com");
            driver.FindElement(By.Id("Pagecontent_TextBoxTelephone1")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxTelephone1")).SendKeys("0123456789");

            new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlHearAbout"))).SelectByText("Online Search");
            driver.FindElement(By.XPath("//form[@id='checkout']/section/div[17]/div/label/span/span")).Click();


            //Clicking On Continue Button
            driver.FindElement(By.Id("Pagecontent_ButtonContinue")).Click();
          waitforpagetoload(30000);
            string url5 = driver.Url;
            Console.WriteLine(url5);

            //Asserting the Checkout Page Title
            Assert.AreEqual("Checkout - Bathrooms", driver.Title);

            //Populating the Delivery Page
            driver.FindElement(By.Id("Pagecontent_TextBoxFirstName")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxFirstName")).SendKeys("mobank");
            driver.FindElement(By.Id("Pagecontent_TextBoxLastname")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxLastname")).SendKeys("mopowered");
            driver.FindElement(By.Id("Pagecontent_TextStreetaddress1")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextStreetaddress1")).SendKeys("36");
            driver.FindElement(By.Id("Pagecontent_TextStreetaddress2")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextStreetaddress2")).SendKeys("albertembankment");
            driver.FindElement(By.Id("Pagecontent_TextBoxCity")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxCity")).SendKeys("vauxhall");
            driver.FindElement(By.Id("Pagecontent_TextBoxPostCode")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxPostCode")).SendKeys("se1 7tl");


            //Clicking on Continute Button Page 2
            driver.FindElement(By.Id("Pagecontent_ButtonContinue")).Click();
          waitforpagetoload(30000);
            string url6 = driver.Url;
            Console.WriteLine(url6);

            //Clicking on Continute Button Page 3
            driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep2")).Click();
          waitforpagetoload(30000);
            string url7 = driver.Url;
            Console.WriteLine(url7);

            driver.FindElement(By.XPath("//*[@id='checkout']/fieldset/div[2]/label/span")).Click();
            Thread.Sleep(2000);
            //Clicking on Continute Button Page 4

            driver.FindElement(By.Id("Pagecontent_ButtonConfirmCheckout")).Click();
          waitforpagetoload(30000);
            string url8 = driver.Url;
            Console.WriteLine(url8);

            //Asserting the MoPay Page
            Assert.AreEqual("Secure Payment Page", driver.Title);
            string title = driver.Title;
            Console.WriteLine(title);

        }


        private bool IsElementPresent(IWebDriver unknown, By @by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() 
        
        {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alert.Text;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}



   