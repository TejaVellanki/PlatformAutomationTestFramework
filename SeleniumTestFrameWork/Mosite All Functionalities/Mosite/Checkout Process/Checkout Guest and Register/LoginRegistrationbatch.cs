﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using WebDriver_Refining;

//using System.Drawing;

namespace MoBankUI
{
    public class LoginRegistration
    {
         [Test]
        public void registration(IWebDriver driver, datarow datarow)
        {
            var screenshot = new Screenshot();

            string logintitle = driver.Url;
            try
            {
                if (logintitle.Contains("Login") || logintitle.Contains("StepSelectAccountType") ||
                     driver.PageSource.Contains("Login"))
                {
                    //IF the User is a Guest Activate guest Class

                    //Guest guest = new Guest();
                    //guest.guest(driver, datarow);


                    //Calling the Login Class 
                    var login = new LoginandRegistration_TPS();
                    login.Login_TPS(driver, datarow);
                }

                else if (logintitle.Contains("Checkout"))
                {
                    // calling the checkout class
                    var data = new UserData_TPS();
                    data.userdata_TPS(driver, datarow);
                }
                else
                {
                    datarow.newrow("Checkout Process Not covered in the Framework", "Expected", logintitle, "FAIL",
                                  driver);
                    screenshot.screenshotfailed(driver);
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Not Expected", e, "FAIL",driver);
                screenshot.screenshotfailed(driver);
            }
        }
    }
}