using MoBankUI;
using OpenQA.Selenium;
using Selenium;

namespace Tablet_View
{
    internal class batch_tab
    {
        public void tabbatch(datarow datarow,ISelenium selenium,IWebDriver driver)
        {
            //Method Homapge validations
            #region HomePage Validations

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
            var home = new Homepage_tab();
            home.homepage(driver, selenium, datarow);
           #endregion
        }
    }
}