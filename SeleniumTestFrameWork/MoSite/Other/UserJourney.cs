// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;

namespace MoBankUI
{
    internal class UserJourney : Driverdefining
    {
        public void productunavailabl(IWebDriver driver, int l)
        {
            driver.FindElement(By.XPath("//ul[@id='Basket']/li[2]/a/span")).Click();

            driver.FindElement(By.XPath("//body[@id='page-basket-index']/div/div[2]/div/div[2]/a/span/span")).Click();

            driver.FindElement(By.XPath("//body[@id='page-home-index']/div/div[2]/div/ul/li/div/div/a/h2")).Click();

            driver.FindElement(
                By.XPath("//body[@id='page-categories-details']/div/div[2]/div/ul/li[" + l + "]/div/div/a/p")).Click();

            string str =
                driver.FindElement(By.XPath("//form[@id='AddToBasketForm']/ul/li[2]/fieldset/div[2]/div/div/select"))
                      .Text;
            if (str.Contains("30"))
            {
                if (IsElementPresent(driver,
                                     By.XPath("//form[@id='AddToBasketForm']/ul/li[2]/fieldset/div[2]/div/div/select")))
                {
                    new SelectElement(
                        driver.FindElement(
                            By.XPath("//form[@id='AddToBasketForm']/ul/li[2]/fieldset/div[2]/div/div/select")))
                        .SelectByText("30");
                }
            }
            else if (str.Contains("S") &&
                     IsElementPresent(driver,
                                      By.XPath("//form[@id='AddToBasketForm']/ul/li[2]/fieldset/div[2]/div/div/select")))
            {
                new SelectElement(
                    driver.FindElement(
                        By.XPath("//form[@id='AddToBasketForm']/ul/li[2]/fieldset/div[2]/div/div/select"))).SelectByText
                    ("S");
            }
            driver.FindElement(By.XPath("//p[@id='AddToBasketButton']/div[2]/input")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
            IWebElement element = driver.FindElement(By.XPath("//div[@id='AddedDetail']/ul/li/p/a/span/span"));
            driver.FindElement(By.XPath("//div[@id='AddedDetail']/ul/li/p/a/span/span")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
            IWebElement element2 = driver.FindElement(By.XPath("//a[@id='GoToCheckout']/span/span"));
        }

        public void UserJourn(Datarow datarow, IWebDriver driver)
        {
            try
            {
                driver.Navigate().GoToUrl("http://qatheticklecompany.mobankdev.com/");
                driver.FindElement(By.CssSelector("img")).Click();

                string str = driver.PageSource;
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                IWebElement element =
                    driver.FindElement(By.XPath("//body[@id='page-home-index']/div/div[2]/div/ul/li/div/div/a/h2"));
                driver.FindElement(By.XPath("//body[@id='page-home-index']/div/div[2]/div/ul/li/div/div/a/h2")).Click();
                string str2 = driver.PageSource;
                if (IsElementPresent(driver,
                                     By.XPath("//body[@id='page-categories-details']/div/div[2]/div/ul/li/div/div/a/h2")))
                {
                    driver.FindElement(
                        By.XPath("//body[@id='page-categories-details']/div/div[2]/div/ul/li/div/div/a/h2")).Click();
                }
                driver.FindElement(By.XPath("//body[@id='page-categories-details']/div/div[2]/div/ul/li/div/div/a/p"))
                      .Click();

                if (IsElementPresent(driver,
                                     By.XPath(
                                         "//html/body/div/div[2]/div/div[3]/form/ul/li[2]/fieldset/div[2]/div/label/span")))
                {
                    driver.FindElement(
                        By.XPath("//html/body/div/div[2]/div/div[3]/form/ul/li[2]/fieldset/div[2]/div/label/span"))
                          .Click();
                }
                string str3 = driver.PageSource;
                if (IsElementPresent(driver,
                                     By.XPath("//form[@id='AddToBasketForm']/ul/li[2]/fieldset/div[2]/div/div/select")))
                {
                    new SelectElement(
                        driver.FindElement(
                            By.XPath("//form[@id='AddToBasketForm']/ul/li[2]/fieldset/div[2]/div/div/select")))
                        .SelectByText("Medium");
                }
                var executor = (IJavaScriptExecutor) driver;
                executor.ExecuteScript("window.scrollBy(0,400)", new object[0]);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                driver.FindElement(By.XPath("//p[@id='AddToBasketButton']/div[2]/input")).Click();
                Thread.Sleep(0x1388);
                if (driver.FindElement(By.Id("BasketInfo")).Text == "(1)")
                {
                    datarow.newrow("Basket Value", "(1)", "(1)", "PASS", driver);
                }
                else
                {
                    datarow.newrow("Basket Value", "(1)", "(1)", "FAIL", driver);
                }
                driver.FindElement(By.XPath("//div[@id='AddedDetail']/ul/li/p/a/span/span")).Click();

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                IWebElement element2 = driver.FindElement(By.XPath("//a[@id='GoToCheckout']/span/span"));
                if (driver.FindElement(By.Id("BasketInfo")).Text == "(1)")
                {
                    datarow.newrow("Basket Value", "(1)", "(1)", "PASS", driver);
                }
                else
                {
                    datarow.newrow("Basket Value", "(1)", "(1)", "FAIL", driver);
                }
                string str6 = driver.PageSource;
                Thread.Sleep(0x1388);
                executor.ExecuteScript("window.scrollBy(0,80)", new object[0]);
                driver.FindElement(By.Id("GoToCheckout")).Click();

                Thread.Sleep(3000);
                if (
                    !IsElementPresent(driver,
                                      By.XPath("//body[@id='page-basket-index']/div/div[2]/div/div[3]/a/span/span")) ||
                    driver.FindElement(By.XPath("//ul[@id='Basket']/li[2]/div/div/p")).Text != "Product unavailable")
                {
                    goto Label_03D4;
                }
                int l = 2;
                goto Label_03CD;
                Label_0365:
                if (driver.FindElement(By.XPath("//ul[@id='Basket']/li[2]/div/div/p")).Text == "Product unavailable")
                {
                    productunavailabl(driver, l);
                    driver.FindElement(By.XPath("//a[@id='GoToCheckout']/span")).Click();
                }
                else
                {
                    goto Label_03D4;
                }
                l++;
                Label_03CD:
                goto Label_0365;
                Label_03D4:
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                IWebElement element3 =
                    driver.FindElement(
                        By.XPath("//body[@id='page-checkout-process']/div/div[2]/div/form/fieldset/div[2]/div/button"));
                string str9 = driver.PageSource;
            }
            catch (Exception exception)
            {
                string actual = exception.ToString();
                datarow.newrow("Exception", "Not Expected", actual, "FAIL", driver);
            }
        }
    }
}