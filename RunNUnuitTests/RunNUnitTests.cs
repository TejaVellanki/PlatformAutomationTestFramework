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
            FirefoxProfile firefoxProfile = new FirefoxProfile("Default");
            driver = new FirefoxDriver(firefoxProfile);
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
        public void bathroomTest()
        {
            driver.Navigate().GoToUrl("http://m.bathrooms.com/");
            selenium.WaitForPageToLoad("30000");
            driver.Manage().Cookies.DeleteAllCookies();
            driver.FindElement(By.LinkText("Bathroom suites")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.LinkText("Bathroom Ranges")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.CssSelector("h2.wrappable.ui-li-heading")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.CssSelector("div.price > p.ui-li-desc")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.XPath("(//input[@value='Add To Basket'])[2]")).Click();
            selenium.WaitForPageToLoad("30000");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[@id='AddedDetail']/ul/li/p/a/span/span")).Click();
            selenium.WaitForPageToLoad("30000");
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("#GoToCheckout > span.ui-btn-inner > span.ui-btn-text")).Click();
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("Checkout - Bathrooms", driver.Title);
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
            driver.FindElement(By.Id("Pagecontent_ButtonContinue")).Click();
            selenium.WaitForPageToLoad("30000");

            Assert.AreEqual("Checkout - Bathrooms", driver.Title);

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

            driver.FindElement(By.Id("Pagecontent_ButtonContinue")).Click();
            selenium.WaitForPageToLoad("30000");

            driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep2")).Click();
            selenium.WaitForPageToLoad("30000");


            driver.FindElement(By.Id("Pagecontent_ButtonConfirmCheckout")).Click();
            selenium.WaitForPageToLoad("30000");

            Assert.AreEqual("Secure Payment Page", driver.Title);
            string title = driver.Title;
           
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



   