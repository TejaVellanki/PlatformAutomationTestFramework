using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;
         

namespace MoBankUI
{
    public class Bathroom:driverdefining

{
    public void bathroom(IWebDriver driver, datarow datarow)
    {

        driver.Navigate().GoToUrl("http://m.bathrooms.com/");
          
        driver.Manage().Cookies.DeleteAllCookies();
        driver.FindElement(By.LinkText("Bathroom suites")).Click();
          
        driver.FindElement(By.LinkText("Bathroom Ranges")).Click();
          
        driver.FindElement(By.CssSelector("h2.wrappable.ui-li-heading")).Click();
          
        driver.FindElement(By.CssSelector("div.price > p.ui-li-desc")).Click();
          
        driver.FindElement(By.XPath("(//input[@value='Add To Basket'])[2]")).Click();
          
        Thread.Sleep(5000);
        driver.FindElement(By.XPath("//div[@id='AddedDetail']/ul/li/p/a/span/span")).Click();
          
        Thread.Sleep(5000);
        driver.FindElement(By.CssSelector("#GoToCheckout > span.ui-btn-inner > span.ui-btn-text")).Click();
          
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
            