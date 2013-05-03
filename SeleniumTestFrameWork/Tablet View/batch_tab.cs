using MoBankUI;
using OpenQA.Selenium;
using Selenium;
using MoBankUI;
using WebDriver_Refining;

namespace Tablet_View
{
    internal class batch_tab
    {
        public void tabbatch(datarow datarow,ISelenium selenium,IWebDriver driver)
        {
            //Method Homapge validations
            #region HomePage Validations
            driver.Navigate().GoToUrl("http://tablet.mobankdev.com");
             driverdefining Driver = new driverdefining();
            
            string title = driver.Title.ToString();
            //Validating the Home page title. 
            
            if(title == "Tablet: Tickle Shop")
            {
                datarow.newrow("Home Page Title", "Tablet: Tickle Shop",title,"PASS");
            }
            else
            {
                datarow.newrow("Home Page Title", "Tablet: Tickle Shop", title, "FAIL");
            }
            BlobStorage blob = new BlobStorage();
            blob.Blob( selenium,driver,datarow);
            var home = new Homepage_tab();
            home.homepage(driver, selenium, datarow);
           #endregion
        }
    }
}