using MoBankUI;
using OpenQA.Selenium;
using WebDriver_Refining;

namespace Tablet_View
{
    internal class batch_tab
    {
        public void tabbatch(datarow datarow, IWebDriver driver)
        {
            //Method Homapge validations

            #region HomePage Validations

            driver.Navigate().GoToUrl("http://tablet.mobankdev.com");
            var Driver = new driverdefining();

            string title = driver.Title;
            //Validating the Home page title. 

            if (title == "Tablet: Tickle Shop")
            {
                datarow.newrow("Home Page Title", "Tablet: Tickle Shop", title, "PASS");
            }
            else
            {
                datarow.newrow("Home Page Title", "Tablet: Tickle Shop", title, "FAIL");
            }
            var blob = new BlobStorage();
            blob.Blob(driver, datarow, "http://tablet.mobankdev.com");
            var home = new Homepage_tab();
            home.homepage(driver, datarow);
            var allproducts = new LinksExpand();
            allproducts.AllLink(driver, datarow);

            #endregion
        }
    }
}