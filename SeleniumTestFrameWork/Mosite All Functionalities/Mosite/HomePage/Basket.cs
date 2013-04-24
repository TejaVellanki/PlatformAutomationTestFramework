using System;
using OpenQA.Selenium;
using Selenium;
//using System.Drawing;

namespace MoBankUI
{
    internal class Baskets_TPS
    {
        private readonly Screenshot screenshot = new Screenshot();

        public void Basket(IWebDriver driver, ISelenium selenium, datarow datarow, string url)
        {
            try
            {
                try
                {
                    driver.FindElement(By.Id("BasketInfo")).Click();
                    selenium.WaitForPageToLoad("30000");
                    datarow.newrow("Basket Info Button", "Basket Info Button Is Expected",
                                   "Basket Info Button is Present", "PASS", driver, selenium);
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Basket Info Button", "Basket Info Button Is Expected", e, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }

                try
                {
                    string value = driver.FindElement(By.Id("BasketInfo")).Text;


                    if (value == "(0)")
                    {
                        datarow.newrow("Basket Value", "(0)", value, "PASS", driver, selenium);
                    }
                    else
                    {
                        datarow.newrow("Basket Value", "(0)", value, "FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Basket Info Text", "Basket Info Text Is Expected", e, "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
                var footer = new Footer_TPS();
                footer.Footer(driver, selenium, datarow);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Excepetion Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }
    }
}