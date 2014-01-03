using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;

//using System.Drawing;

namespace MoBankUI
{
    internal class Countryhouse : driverdefining
    {
        public void checkoutprocess(IWebDriver driver)
        {
            //country house checkout process
            driver.FindElement(By.Id("Pagecontent_TextBoxUserName")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxUserName")).SendKeys("mopoweredtest@mobankgroup.com");
            driver.FindElement(By.Id("Pagecontent_TextBoxPassword")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxPassword")).SendKeys("M0Test08");
            driver.FindElement(By.Id("Pagecontent_ButtonLogin")).Click();

            driver.FindElement(By.XPath("//span[@id='Pagecontent_RadioButtonListDeliveryMethods']/div/label/span"))
                  .Click();


            driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[2]/input")).Clear();
            driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[2]/input")).SendKeys("test");
            driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[3]/input")).Clear();
            driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[3]/input")).SendKeys("99999");
            new SelectElement(
                driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[4]/fieldset/div[2]/div/div/select")))
                .SelectByText("12 - Dec");
            new SelectElement(
                driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[4]/fieldset/div[2]/div[2]/div/select")))
                .SelectByText("22");
            driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[5]/input")).Clear();
            driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[5]/input")).SendKeys("123");
            new SelectElement(
                driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[6]/fieldset/div[2]/div/div/select")))
                .SelectByText("12 - Dec");
            driver.FindElement(By.XPath("//select[@id='Pagecontent_ddlStartMonth']/option[13]")).Click();
            new SelectElement(
                driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[6]/fieldset/div[2]/div[2]/div/select")))
                .SelectByText("4");
            driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep3")).Click();
            driver.FindElement(By.Id("Pagecontent_ButtonConfirmCheckout")).Click();
        }

        public void bathroomcheckout(IWebDriver driver)
        {
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


            driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep2")).Click();


            driver.FindElement(By.Id("Pagecontent_ButtonConfirmCheckout")).Click();


            Assert.AreEqual("Secure Payment Page", driver.Title);
            string title = driver.Title;
        }
    }
}