using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using Selenium;
using OpenQA.Selenium;
using  OpenQA.Selenium.Interactions;

namespace MoBankUI
{
    class Wolford
    {
    public void wolfordcheckout(IWebDriver driver, ISelenium selenium,datarow datarow)
    {
        try
        {
      
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
        driver.FindElement(By.Id("Pagecontent_TextBoxCity")).SendKeys("Twicickenham");
        driver.FindElement(By.Id("Pagecontent_TextBoxPostCode")).Clear();
        driver.FindElement(By.Id("Pagecontent_TextBoxPostCode")).SendKeys("tw2 6jr");
        driver.FindElement(By.Id("Pagecontent_TextBoxDOB")).Clear();
        driver.FindElement(By.Id("Pagecontent_TextBoxDOB")).SendKeys("13.08.1984");
        driver.FindElement(By.Id("Pagecontent_ButtonContinue")).Click();
        driver.FindElement(By.XPath("//form[@id='checkout']/section/div[13]/div/label/span/span")).Click();
        driver.FindElement(By.XPath("//form[@id='checkout']/section/div[13]/div/label/span/span")).Click();
        Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.Id("checkout")).Text,
                                    "^exact:Sub-total:(\n|\r\n) £55\\.00 (\n|\r\n) (\n|\r\n) Delivery: (\n|\r\n) (\n|\r\n) £0\\.00 (\n|\r\n) (\n|\r\n) Total:(\n|\r\n) £55\\.00 (\n|\r\n) (\n|\r\n) Incl VAT:(\n|\r\n) £9\\.17 (\n|\r\n) (\n|\r\n) (\n|\r\n) (\n|\r\n) Billing address  (\n|\r\n) Test Test (\n|\r\n) Ross Road 27 (\n|\r\n) TW2 6JR Twickenham (\n|\r\n) GB (\n|\r\n)   (\n|\r\n) Edit(\n|\r\n) Delivery address  (\n|\r\n) Test Test (\n|\r\n) Ross Road 27 (\n|\r\n) TW2 6JR Twickenham (\n|\r\n) GB (\n|\r\n)   (\n|\r\n) Edit(\n|\r\n) (\n|\r\n) I have taken note of the general terms and conditions and the data protection information\\.(\n|\r\n) Within 7 days I can send back the goods received without any reasons, free of charge\\. [\\s\\S]* (\n|\r\n) I agree(\n|\r\n) (\n|\r\n) (\n|\r\n) (\n|\r\n) (\n|\r\n) (\n|\r\n) Continue to payment(\n|\r\n) (\n|\r\n) Back$"));
        try
        {
            Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.Id("checkout")).Text,
                                        "^exact:Sub-total:(\n|\r\n) £55\\.00 (\n|\r\n) (\n|\r\n) Delivery: (\n|\r\n) (\n|\r\n) £0\\.00 (\n|\r\n) (\n|\r\n) Total:(\n|\r\n) £55\\.00 (\n|\r\n) (\n|\r\n) Incl VAT:(\n|\r\n) £9\\.17 (\n|\r\n) (\n|\r\n) (\n|\r\n) (\n|\r\n) Billing address  (\n|\r\n) Test Test (\n|\r\n) Ross Road 27 (\n|\r\n) TW2 6JR Twickenham (\n|\r\n) GB (\n|\r\n)   (\n|\r\n) Edit(\n|\r\n) Delivery address  (\n|\r\n) Test Test (\n|\r\n) Ross Road 27 (\n|\r\n) TW2 6JR Twickenham (\n|\r\n) GB (\n|\r\n)   (\n|\r\n) Edit(\n|\r\n) (\n|\r\n) I have taken note of the general terms and conditions and the data protection information\\.(\n|\r\n) Within 7 days I can send back the goods received without any reasons, free of charge\\. [\\s\\S]* (\n|\r\n) I agree(\n|\r\n) (\n|\r\n) (\n|\r\n) (\n|\r\n) (\n|\r\n) (\n|\r\n) Continue to payment(\n|\r\n) (\n|\r\n) Back$"));
        }
        catch (AssertionException e)
        {
            
        }
        // Warning: verifyTextPresent may require manual changes
        try
        {
            Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text,
                                        "^[\\s\\S]*\r(\n|\r\n)Test Test\r(\n|\r\n)Ross Road 27\r(\n|\r\n)TW2 6JR Twickenham\r(\n|\r\n)GB [\\s\\S]*$"));
        }
        catch (AssertionException e)
        {
            
        }
        driver.FindElement(By.Id("Pagecontent_ButtonConfirmCheckout")).Click();
        Assert.AreEqual("Checkout - Wolford UK", driver.Title);
        }
        catch (Exception)
        {

            throw;
        }
    }
    }
}
