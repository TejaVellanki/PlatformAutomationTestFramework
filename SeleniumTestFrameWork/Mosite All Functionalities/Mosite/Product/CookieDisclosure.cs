using System;
using MoBankUI;
using OpenQA.Selenium;
using WebDriver_Refining;

namespace MoBankUI
{
    class CookieDisclosure : driverdefining
    {
        public void cookie(IWebDriver driver,datarow datrow)
        {
            try
            {
            //cookie Disclosure
            IsElementPresent(driver, By.CssSelector("div.cookieDisclosure"));
            string disclosuretext =     driver.FindElement(By.CssSelector("div.cookieDisclosure")).Text;
           if(disclosuretext=="This site uses cookies. Some of the cookies we use are essential for parts of the site to operate and have already been set.")
               datrow.newrow("Diclosure Text is Presnt","This site uses cookies. Some of the cookies we use are essential for parts of the site to operate and have already been set.",disclosuretext,"PASS");
           else
           {
               datrow.newrow("Diclosure Text is Presnt","This site uses cookies. Some of the cookies we use are essential for parts of the site to operate and have already been set.",disclosuretext,"FAIL");
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
                string e = ex.ToString();
                datrow.newrow("Exception Not Expceted", "Not Expected", e, "FAIL");

            }
                
        }
    }
}
