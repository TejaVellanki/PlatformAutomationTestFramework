using System;
using OpenQA.Selenium;
using WebDriver_Refining;

namespace MoBankUI
{
    public class SuccessMessage : Driverdefining
    {
        public void Message(IWebDriver driver, Datarow datarow)
        {
            try
            {
                IsElementPresent(driver, By.CssSelector("div.toast-title"));
                string successmessage = driver.FindElement(By.CssSelector("div.toast-title")).Text;
                datarow.newrow("Add To Basket Success Message", "Success", successmessage, "PASS");
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Add To Basket Success Message", "Success", e, "FAIL");
            }
        }
    }
}