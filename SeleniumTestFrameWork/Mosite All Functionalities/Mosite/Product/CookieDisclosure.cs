using System;
using OpenQA.Selenium;

namespace MoBankUI.Mosite.Product
{
    internal class CookieDisclosure : Driverdefining
    {
        public void Cookie(IWebDriver driver, Datarow datrow)
        {
            try
            {
                //cookie Disclosure
                IsElementPresent(driver, By.CssSelector("div.cookieDisclosure"));
                var disclosuretext = driver.FindElement(By.CssSelector("div.cookieDisclosure")).Text;
                if (disclosuretext ==
                    "This site uses cookies. Some of the cookies we use are essential for parts of the site to operate and have already been set.")
                    datrow.newrow("Diclosure Text is Presnt",
                                  "This site uses cookies. Some of the cookies we use are essential for parts of the site to operate and have already been set.",
                                  disclosuretext, "PASS");
                else
                {
                    datrow.newrow("Diclosure Text is Presnt",
                                  "This site uses cookies. Some of the cookies we use are essential for parts of the site to operate and have already been set.",
                                  disclosuretext, "FAIL");
                }

                if (IsElementPresent(driver, By.Id("epdsubmit")))
                {
                    driver.FindElement(By.Id("epdsubmit")).Click();
                    datrow.newrow("Validating 'OK' Button in cookie disclosure ", "OK button is present",
                                  "OK button is present", "PASS");
                }
                else
                {
                    datrow.newrow("Validating 'OK' Button in cookie disclosure ", "OK button is present",
                                  "OK button is not present", "FAIL");
                }
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datrow.newrow("Exception Not Expceted", "Not Expected", e, "FAIL");
            }
        }
    }
}