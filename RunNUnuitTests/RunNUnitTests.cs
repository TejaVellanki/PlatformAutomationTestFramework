using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Selenium;
using MoBankUI;

namespace SeleniumTests
{
    [TestFixture]
    public class seleniumnunittests
    {
        public IWebDriver driver;
        public WebDriverBackedSelenium selenium;
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
            selenium = new WebDriverBackedSelenium(driver, "http://m.bathrooms.com/");
            verificationErrors = new StringBuilder();
            selenium.Start();

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
            selenium.WaitForPageToLoad("30000");
            driver.Manage().Cookies.DeleteAllCookies();
            driver.FindElement(By.LinkText("Bathroom suites")).Click();
            selenium.WaitForPageToLoad("30000");
            string url = selenium.GetLocation();
            Console.WriteLine(url);
            driver.FindElement(By.LinkText("Bathroom Ranges")).Click();
            selenium.WaitForPageToLoad("30000");
            string url1 = selenium.GetLocation();
            Console.WriteLine(url1);
            driver.FindElement(By.CssSelector("h2.wrappable.ui-li-heading")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.CssSelector("div.price > p.ui-li-desc")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.XPath("(//input[@value='Add To Basket'])[2]")).Click();
            selenium.WaitForPageToLoad("30000");
            Thread.Sleep(5000);
            string url2 = selenium.GetLocation();
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
        
        [Test]
        public void Bathroomrandomproducts()
        { 
            #region Random Products
            
            selenium.Open("http://m.bathrooms.com/");
            selenium.WaitForPageToLoad("30000");
            decimal homepagecat = selenium.GetXpathCount("//body[@id='page-home-index']/div/div[2]/div/ul/li");
            for (int j = 2; j < homepagecat; j++)
            {
                driver.FindElement(By.XPath("//body[@id='page-home-index']/div/div[2]/div/ul/li["+j+"]/div/div/a/h2")).Click();
                selenium.WaitForPageToLoad("30000");
                string homepage = selenium.GetLocation();
                Console.WriteLine(homepage);
                decimal catelem = selenium.GetXpathCount("//body[@id='page-categories-details']/div/div[2]/div/ul/li");
                for (int k = 2; k <= catelem; k++)
                {
                    driver.FindElement(By.XPath("//body[@id='page-categories-details']/div/div[2]/div/ul/li["+k+"]/div/div/a")).Click();
                    selenium.WaitForPageToLoad("30000");
                    break;
                }
                decimal subcat = selenium.GetXpathCount("//body[@id='page-categories-details']/div/div[2]/div/ul/li");
                for (int s = 1; s <= subcat; s++)
                {
                    driver.FindElement(By.XPath("//body[@id='page-categories-details']/div/div[2]/div/ul/li[" + s + "]/div/div/a/h2")).Click();
                    selenium.WaitForPageToLoad("30000");
                    string catpage = selenium.GetLocation();
                    Console.WriteLine(catpage);
                    break;

                }
                decimal subsubcat =selenium.GetXpathCount("//body[@id='page-categories-details']/div/div[2]/div/ul/li");
                for (int p = 1; p <= subsubcat; p++)
                {

                    selenium.Click("//body[@id='page-categories-details']/div/div[2]/div/ul/li["+p+"]/div/div/a");
                    selenium.WaitForPageToLoad("30000");
                    string productpage = selenium.GetLocation();
                    Console.WriteLine(productpage);
                    if (productpage.Contains("product"))
                    {
                        driver.FindElement(By.XPath("(//input[@value='Add To Basket'])[2]")).Click();
                        selenium.WaitForPageToLoad("30000");
                        Thread.Sleep(5000);
                      
                    }
                    selenium.GoBack();
                    selenium.WaitForPageToLoad("30000");
                }
                break;
            }
            #endregion
            checkout();
        }

        public void checkout()
        {
            //Navigating to Bathroom Page
            driver.FindElement(By.Id("BasketInfo")).Click();
            selenium.WaitForPageToLoad("30000");
            string url3 = selenium.GetLocation();
            Console.WriteLine(url3);

            //Clicking on Checkout Button 
            driver.FindElement(By.CssSelector("#GoToCheckout > span.ui-btn-inner > span.ui-btn-text")).Click();
            selenium.WaitForPageToLoad("30000");
            Thread.Sleep(10000);
            string url4 = selenium.GetLocation();
            Console.WriteLine(url4);
         

            string productunvail = null;
            //Validating the Stock Status Page
            if (url4.Contains("StockStatus"))
            {
                decimal productsinbasket = selenium.GetXpathCount("//*[@id='Top']/div[1]/div[2]/div[2]/ul/li");
                for (int j = 1; j <= productsinbasket; j++)
                {
                    if (selenium.IsElementPresent("//*[@id='Top']/div[1]/div[2]/div[2]/ul/li[" + j + "]/div/div/p"))
                    {
                        productunvail = selenium.GetText("//*[@id='Top']/div[1]/div[2]/div[2]/ul/li[" + j + "]/div/div/p");
                        if (productunvail == "Product unavailable")
                        {
                            break;
                        }
                    }
                }
                if (productunvail == "Product unavailable" || selenium.IsTextPresent("Product unavailable"))
                    {
                        // Validating the Product Availability
                       Console.WriteLine("Product Unavailable");
                        driver.Quit();

                    }
                }
                else
                {
                   
                    if (selenium.IsElementPresent("id=Pagecontent_ButtonContinue"))
                    {
                        driver.FindElement(By.Id("Pagecontent_ButtonContinue")).Click();
                        selenium.WaitForPageToLoad("30000");
                    }
                    Assert.AreEqual("Checkout - Bathrooms", driver.Title);
                    address();
            }
        }

        public void address()
        {
            //Populating the Address page
            new SelectElement(driver.FindElement(By.Id("Pagecontent_ddlTitle"))).SelectByText("Mr");
            driver.FindElement(By.CssSelector("option.ui-state-valid")).Click();
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
            driver.FindElement(By.XPath("//form[@id='checkout']/section/div[16]/div/label/span")).Click();


            //Clicking On Continue Button
            driver.FindElement(By.Id("Pagecontent_ButtonContinue")).Click();
            selenium.WaitForPageToLoad("30000");
            string url5 = selenium.GetLocation();
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
            selenium.WaitForPageToLoad("30000");
            string url6 = selenium.GetLocation();
            Console.WriteLine(url6);

            //Clicking on Continute Button Page 3
            driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep2")).Click();
            selenium.WaitForPageToLoad("30000");
            string url7 = selenium.GetLocation();
            Console.WriteLine(url7);

            //Clicking on Continute Button Page 4

            driver.FindElement(By.Id("Pagecontent_ButtonConfirmCheckout")).Click();
            selenium.WaitForPageToLoad("30000");
            string url8 = selenium.GetLocation();
            Console.WriteLine(url8);

            //Asserting the MoPay Page
            Assert.AreEqual("Secure Payment Page", driver.Title);
            string title = driver.Title;
            Console.WriteLine(title);

        }


        private bool IsElementPresent(By by)
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



   