using System;
using OpenQA.Selenium;

namespace MoBankUI.Mosite.Product
{
    public class SuccessMessage : Driverdefining
    {
        public void Message(IWebDriver driver, Datarow datarow)
        {
            try
            {
                IsElementPresent(driver, By.CssSelector("div.toast-title"));
                var successmessage = driver.FindElement(By.CssSelector("div.toast-title")).Text;
                datarow.newrow("Add To Basket Success Message", "Success", successmessage, "PASS");
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Add To Basket Success Message", "Success", e, "FAIL");
            }
        }
    }
}