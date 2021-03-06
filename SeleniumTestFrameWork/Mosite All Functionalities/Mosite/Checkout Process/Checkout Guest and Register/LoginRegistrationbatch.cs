﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI.Mosite
{
    public class LoginRegistration
    {
        [Test]
        public void Registration(IWebDriver driver, Datarow datarow)
        {
            var screenshot = new Screenshot();

            var logintitle = driver.Url;
            try
            {
                if (logintitle.Contains("Login") || logintitle.Contains("StepSelectAccountType") ||
                    driver.PageSource.Contains("Login"))
                {
                    //IF the User is a Guest Activate guest Class

                    //Guest guest = new Guest();
                    //guest.guest(driver, datarow);


                    //Calling the Login Class 
                    var login = new LoginandRegistrationTps();
                    login.Login_TPS(driver, datarow);
                }

                else if (logintitle.Contains("Checkout"))
                {
                    // calling the checkout class
                    var data = new UserDataTps();
                    data.userdata_TPS(driver, datarow);
                }
                else
                {
                    datarow.Newrow("Checkout Process Not covered in the Framework", "Expected", logintitle, "FAIL",
                                   driver);
                    screenshot.Screenshotfailed(driver);
                }
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.Newrow("Exception", "Not Expected", e, "FAIL", driver);
                screenshot.Screenshotfailed(driver);
            }
        }
    }
}