// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MoBankUI.MoShop
{
    [TestFixture]
    public class MoShopConsole : Driverdefining
    {
        private readonly Screenshot _screenshot = new Screenshot();


/*
        private bool IsElementPresent(By by, ISearchContext driver)
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
*/

        [Test]
        [Category("Fixture")]
        public void Homepagetabs(IWebDriver driver, Datarow datarow)
        {
            try
            {
                var actual = driver.Title;

                if (actual == "Log On : mobank.co.uk/MoShop")
                {
                    datarow.Newrow("MoshopTitle", "Log On : mobank.co.uk/MoShop", actual, "PASS", driver);
                }
                else
                {
                    datarow.Newrow("MoshopTitle", "Log On : mobank.co.uk/MoShop", actual, "FAIL", driver);
                    _screenshot.Screenshotfailed(driver);
                }
                driver.FindElement(By.Id("Email")).Clear();
                driver.FindElement(By.Id("Email")).SendKeys("teja.vellanki@mobankgroup.com");
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys("Apple12345");
                driver.FindElement(By.Id("LogOn_Action_LogOn")).Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                driver.FindElement(By.XPath("//div[@id='IndexMenu']/ul/li/ul/li/a"));
                var str2 = driver.Title;

                if (str2 == "mobank.co.uk/MoShop")
                {
                    datarow.Newrow("MoshopHomepageTitle", "mobank.co.uk/MoShop", str2, "PASS", driver);
                }
                else
                {
                    datarow.Newrow("MoshopHomepageTitle", "mobank.co.uk/MoShop", str2, "FAIL", driver);
                    _screenshot.Screenshotfailed(driver);
                }
                //Expanding Manage and Security
                driver.FindElement(By.XPath("//li[@id='IndexMenuLeaf1']/span")).Click();

                driver.FindElement(By.XPath("//li[@id='IndexMenuLeaf8']/span")).Click();

                driver.FindElement(By.LinkText("Scrapes")).Click();

                var str3 = driver.Title;


                if (str3 == "Scrapes : mobank.co.uk/MoShop")
                {
                    datarow.Newrow("Scrape Page", "Scrapes : mobank.co.uk/MoShop", str3, "PASS", driver);
                }
                else
                {
                    datarow.Newrow("Scrape Page", "Scrapes : mobank.co.uk/MoShop", str3, "FAIL", driver);
                    _screenshot.Screenshotfailed(driver);
                }
                driver.FindElement(By.LinkText("MoShop")).Click();

                driver.FindElement(By.XPath("(//a[contains(text(),'Shops')])[2]")).Click();

                var str4 = driver.Title;
                if (str4 == "Shops : mobank.co.uk/MoShop")
                {
                    datarow.Newrow("Shops Page", "Scrapes : mobank.co.uk/MoShop", str4, "PASS", driver);
                }
                else
                {
                    datarow.Newrow("Shops Page", "Scrapes : mobank.co.uk/MoShop", str4, "FAIL", driver);
                    _screenshot.Screenshotfailed(driver);
                }
                driver.FindElement(By.LinkText("MoShop")).Click();

                driver.FindElement(By.XPath("(//a[contains(text(),'Global Customisations')])[2]")).Click();

                var str5 = driver.Title;
                if (str5 == "Global Customisations : mobank.co.uk/MoShop")
                {
                    datarow.Newrow("Global Customerisations Page", "Global Customisations : mobank.co.uk/MoShop", str5,
                                   "PASS", driver);
                }
                else
                {
                    datarow.Newrow("Global Customerisations Page", "Global Customisations : mobank.co.uk/MoShop", str5,
                                   "FAIL", driver);
                    _screenshot.Screenshotfailed(driver);
                }
                driver.FindElement(By.LinkText("MoShop")).Click();

                driver.FindElement(By.XPath("(//a[contains(text(),'Transformations')])[2]")).Click();

                var str6 = driver.Title;
                if (str6 == "Transformations : mobank.co.uk/MoShop")
                {
                    datarow.Newrow("Transformations Page", "Transformations : mobank.co.uk/MoShop", str6, "PASS", driver);
                }
                else
                {
                    datarow.Newrow("Transformations Page", "Transformations : mobank.co.uk/MoShop", str6, "FAIL", driver);
                    _screenshot.Screenshotfailed(driver);
                }
                driver.FindElement(By.LinkText("MoShop")).Click();


                driver.FindElement(By.XPath("(//a[contains(text(),'Global Settings')])[2]")).Click();

                var str7 = driver.Title;
                if (str7 == "mobank.co.uk/MoShop")
                {
                    datarow.Newrow("Global settings Page", "mobank.co.uk/MoShop", str7, "PASS", driver);
                }
                else
                {
                    datarow.Newrow("Global settings Page", "mobank.co.uk/MoShop", str7, "FAIL", driver);
                    _screenshot.Screenshotfailed(driver);
                }
                driver.FindElement(By.LinkText("MoShop")).Click();

                driver.FindElement(By.XPath("(//a[contains(text(),'Security')])[2]")).Click();

                var str8 = driver.Title;
                if (str8 == "mobank.co.uk/MoShop")
                {
                    datarow.Newrow("Security Page", "mobank.co.uk/MoShop", str8, "PASS", driver);
                }
                else
                {
                    datarow.Newrow("Security Page", "mobank.co.uk/MoShop", str8, "FAIL", driver);
                    _screenshot.Screenshotfailed(driver);
                }
                driver.FindElement(By.CssSelector("#IndexMenu > ul > li > a")).Click();

                driver.FindElement(By.XPath("(//a[contains(text(),'Security')])[2]")).Click();

                driver.FindElement(By.XPath("(//a[contains(text(),'Groups')])[2]")).Click();

                driver.FindElement(By.LinkText("MoShop")).Click();

                driver.FindElement(By.XPath("(//a[contains(text(),'Teja Vellanki')])[2]")).Click();

                var str9 = driver.Title;
                if (str9 == "Teja Vellanki : mobank.co.uk/MoShop")
                {
                    datarow.Newrow("Account Page", "Teja Vellanki : mobank.co.uk/MoShop", str9, "PASS", driver);
                }
                else
                {
                    datarow.Newrow("Account Page", "Teja Vellanki : mobank.co.uk/MoShop", str9, "FAIL", driver);
                    _screenshot.Screenshotfailed(driver);
                }
                driver.FindElement(By.LinkText("MoShop")).Click();
            }
            catch (Exception exception3)
            {
                var str10 = exception3.ToString();
                datarow.Newrow("Exception", "Exception Not Expected", str10, "FAIL", driver);
            }
        }
    }
}