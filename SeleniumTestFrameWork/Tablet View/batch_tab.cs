﻿using MoBankUI.Mosite.HomePage;
using OpenQA.Selenium;

namespace MoBankUI
{
    internal class BatchTab
    {
        public void Tabbatch(Datarow datarow, IWebDriver driver)
        {
            //Method Homapge validations

            #region HomePage Validations

            driver.Navigate().GoToUrl("http://tablet.mobankdev.com");
            var Driver = new Driverdefining();

            var title = driver.Title;
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
            var home = new HomepageTab();
            home.homepage(driver, datarow);
            var allproducts = new LinksExpand();
            allproducts.AllLink(driver, datarow);

            #endregion
        }
    }
}