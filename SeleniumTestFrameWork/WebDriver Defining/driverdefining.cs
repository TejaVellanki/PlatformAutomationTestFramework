using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace WebDriver_Refining
{
    class driverdefining
    {
        IWebDriver driver;
        public void waitforpagetoload(int time)
        {
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(time));
        }
    }
}
