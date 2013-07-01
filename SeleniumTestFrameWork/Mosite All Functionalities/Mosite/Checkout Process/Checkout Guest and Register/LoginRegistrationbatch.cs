using System;
using OpenQA.Selenium;
using Selenium;

//using System.Drawing;

namespace MoBankUI
{
    public class LoginRegistration
    {
        public void registration(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            var screenshot = new Screenshot();

            string logintitle = selenium.GetLocation();
            try
            {
                if (logintitle.Contains("Login") || logintitle.Contains("StepSelectAccountType") ||
                    selenium.IsTextPresent("Login"))
                {
                    //IF the User is a Guest Activate guest Class

                    //Guest guest = new Guest();
                    //guest.guest(driver, selenium, datarow);


                    //Calling the Login Class 
                    var login = new LoginandRegistration_TPS();
                    login.Login_TPS(driver, selenium, datarow);
                }

                else if (logintitle.Contains("Checkout"))
                {
                    // calling the checkout class
                    var data = new UserData_TPS();
                    data.userdata_TPS(driver, selenium, datarow);
                }
                else
                {
                    datarow.newrow("Checkout Process Not covered in the Framework", "Expected", logintitle, "FAIL",
                                   driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }
    }
}