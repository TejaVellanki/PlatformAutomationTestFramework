using System;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using System.Data;
//using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Selenium;
using System.Data.OleDb;
using System.IO;
using System.Timers;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;


namespace MoBankUI
{
    class LoginRegistration
    {
        public void registration(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            Screenshot screenshot = new Screenshot();

            string logintitle = selenium.GetLocation();
            try
            {
                if (logintitle.Contains("Login")||logintitle.Contains("StepSelectAccountType")||selenium.IsTextPresent("Login"))
                {
                  

                    //IF the User is a Guest Activate guest Class

                    //Guest guest = new Guest();
                    //guest.guest(driver, selenium, datarow);


                    //Calling the Login Class 
                    LoginandRegistration_TPS login = new LoginandRegistration_TPS();
                    login.Login_TPS(driver, selenium, datarow);
                }

                else if (logintitle.Contains("Checkout"))
                {
                    // calling the checkout class
                    UserData_TPS data = new UserData_TPS();
                    data.userdata_TPS(driver, selenium, datarow);
                }
                else
                {
                    datarow.newrow("Checkout Process Not covered in the Framework", "Expected", logintitle, "FAIL", driver, selenium);
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
