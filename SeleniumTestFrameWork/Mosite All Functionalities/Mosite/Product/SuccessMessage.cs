using System;
using WebDriver_Refining;
using OpenQA.Selenium;

namespace MoBankUI
{
    public class SuccessMessage :driverdefining
    {
        public void message(IWebDriver driver,datarow datarow)
        {
            try
            {
            IsElementPresent(driver, By.CssSelector("div.toast-title"));
            string successmessage =  driver.FindElement(By.CssSelector("div.toast-title")).Text;
            datarow.newrow("Add To Basket Success Message","Success",successmessage,"PASS");
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Add To Basket Success Message", "Success", e, "FAIL");
            }
        }
    }
}
