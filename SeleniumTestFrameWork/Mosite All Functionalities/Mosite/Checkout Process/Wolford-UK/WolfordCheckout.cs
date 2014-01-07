using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MoBankUI.Mosite
{
    internal class Wolford : Driverdefining
    {
        public void Wolfordcheckout(IWebDriver driver, Datarow datarow)
        {
            try
            {
                var page1 = driver.Url;
                datarow.newrow("Reached the custom Checkout Page", "", page1, "");
                driver.FindElement(By.Id("Pagecontent_ButtonGuest")).Click();

                driver.FindElement(By.Id("Pagecontent_TextBoxFirstName")).Clear();
                driver.FindElement(By.Id("Pagecontent_TextBoxFirstName")).SendKeys("Test");
                driver.FindElement(By.Id("Pagecontent_TextBoxLastname")).Clear();
                driver.FindElement(By.Id("Pagecontent_TextBoxLastname")).SendKeys("Test");
                driver.FindElement(By.Id("Pagecontent_TextBoxHouseNumber")).Clear();
                driver.FindElement(By.Id("Pagecontent_TextBoxHouseNumber")).SendKeys("27");
                driver.FindElement(By.Id("Pagecontent_TextBoxStreet")).Clear();
                driver.FindElement(By.Id("Pagecontent_TextBoxStreet")).SendKeys("Ross Road");
                driver.FindElement(By.Id("Pagecontent_TextBoxCity")).Clear();
                driver.FindElement(By.Id("Pagecontent_TextBoxCity")).SendKeys("Twickenham");
                driver.FindElement(By.Id("Pagecontent_TextBoxPostCode")).Clear();
                driver.FindElement(By.Id("Pagecontent_TextBoxPostCode")).SendKeys("tw2 6jr");
                driver.FindElement(By.Id("Pagecontent_TextBoxEmail")).SendKeys("teja.vellanki@mobankgroup.com");
                driver.FindElement(By.Id("Pagecontent_TextBoxDOB")).Clear();
                driver.FindElement(By.Id("Pagecontent_TextBoxDOB")).SendKeys("13.08.1984");
                driver.FindElement(By.Id("Pagecontent_ButtonContinue")).Click();

                var page2 = driver.Url;
                datarow.newrow("Reached the Delivery Checkout Page", "", page2, "");
                //Free Delivery
                //driver.FindElement(By.XPath("//fieldset[@id='__sizzle__']/div[2]/label/span/span")).Click();
                driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep2")).Click();

                var page3 = driver.Url;
                datarow.newrow("Reached the Confirm Page to Accept Terms and Conditions", "", page3, "");
                //terms and conditions
                driver.FindElement(By.XPath("//label[@id='lblTnc']/span")).Click();
                driver.FindElement(By.Id("Pagecontent_ButtonConfirmCheckout")).Click();

                Assert.AreEqual("Checkout - Wolford UK", driver.Title);
                var page4 = driver.Url;
                datarow.newrow("Reached the Payment Page", "", page4, "");
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Exopected", e, "FAIL");
            }
        }
    }
}