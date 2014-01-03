using System;
using ObjectRepository;
using OpenQA.Selenium;
using WebDriver_Refining;

//using System.Drawing;

namespace MoBankUI
{
    internal class Baskets_TPS : driverdefining
    {
        private readonly Screenshot screenshot = new Screenshot();

        public void Basket(IWebDriver driver, datarow datarow, string url)
        {
            try
            {
                string basketempty = null;
                string title = driver.PageSource;

                if (title.Contains("user-scalable=yes"))
                {
                    basketempty = BasketV2.basketempty;
                }
                else
                {
                    basketempty = BasketV1.basketempty;
                }
                try
                {
                    driver.FindElement(By.Id("BasketInfo")).Click();

                    datarow.newrow("Basket Info Button", "Basket Info Button Is Expected",
                                   "Basket Info Button is Present", "PASS", driver);
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Basket Info Button", "Basket Info Button Is Expected", e, "FAIL", driver);
                    screenshot.screenshotfailed(driver);
                }

                try
                {
                    if (!title.Contains("user-scalable=yes"))
                    {
                        string value = driver.FindElement(By.Id("BasketInfo")).Text;
                        if (value == "(0)")
                        {
                            datarow.newrow("Basket Value", "(0)", value, "PASS", driver);
                        }
                        else
                        {
                            datarow.newrow("Basket Value", "(0)", value, "FAIL", driver);
                            screenshot.screenshotfailed(driver);
                        }
                    }


                    string basket = driver.FindElement(By.Id(basketempty)).Text;
                    if (basket == "Your basket is empty")
                    {
                        datarow.newrow("Basket Page Text", "Your basket is empty", basket, "PASS", driver);
                    }
                    else
                    {
                        datarow.newrow("Basket Page Text", "Your basket is empty", basket, "FAIL", driver);
                        screenshot.screenshotfailed(driver);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Basket Info Text", "Basket Info Text Is Expected", e, "FAIL", driver);
                    screenshot.screenshotfailed(driver);
                }
                string basketurl = driver.Url;
                var footer = new Footer_TPS();
                footer.Footer(driver, datarow, basketurl);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Excepetion Not Expected", e, "FAIL", driver);
                screenshot.screenshotfailed(driver);
            }
        }
    }
}