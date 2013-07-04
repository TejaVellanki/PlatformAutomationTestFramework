using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;

using Selenium;

namespace MoBankUI
{
    class RelatedProducts
    {
        public void relatedproducts(IWebDriver driver, ISelenium selenium,datarow datarow)
        {
            //Navigate to the Product
            
            datarow.newrow("","", "Related Products","");
           
             //First Product
             //Validating Products
            Validateproduct(selenium, datarow,driver);

            driver.Navigate().GoToUrl("http://qatheticklecompany.mobankdev.com/product/three-today-birthday-card");
            selenium.WaitForPageToLoad("30000");

            //Validating Products
            Validateproduct(selenium, datarow,driver);

            //Validating click Working or  not 
            click(selenium,driver,datarow);

            //Validating Basket 
            if (selenium.IsElementPresent("(//input[@value='Add To Basket'])[2]"))
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should not be present", "FAIL");
            }
            else
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should not be present", "PASS");
            }

            //Second Product
            driver.Navigate().GoToUrl("http://qatheticklecompany.mobankdev.com/product/two-today-birthday-card");
            selenium.WaitForPageToLoad("30000");
            Validateproduct(selenium, datarow, driver);
            try
            {
         
            driver.FindElement(By.XPath("//ul[@id='productList']/li/div/div/img")).Click();
            selenium.WaitForPageToLoad("30000");
            datarow.newrow("Validating Element Clickable or not", "Element should be Clikcable","Elemenet is Clickable", "PASS");
            }
            catch (Exception ex)
            {

                datarow.newrow("Validating Element Clickable or not", "Element should be Clikcable","Elemenet is Clickable", "FAIL");
            }

            selenium.GoBack();
            selenium.WaitForPageToLoad("30000");

            //Validating Basket 
            if (selenium.IsElementPresent("(//input[@value='Add To Basket'])[2]"))
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should not be present", "FAIL");
            }
            else
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should not be present", "PASS");
            }
            //Validating click Working or not 
         
            if (selenium.IsElementPresent("//input[@value='Add To Basket'])[2]"))
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should be present", "PASS");
            }
            else
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should be present", "FAIL");
            }


            //Third Product

            driver.Navigate().GoToUrl("http://qatheticklecompany.mobankdev.com/product/one-today-birthday-card");
            selenium.WaitForPageToLoad("30000");
        
          
            driver.FindElement(By.CssSelector("img[alt=\"Picture of Happy 70th Birthday Card\"]")).Click();
            Assert.AreEqual("Happy 70th Birthday Card", driver.FindElement(By.CssSelector("h2.productName")).Text);
            try
            {
                Assert.AreEqual("", driver.FindElement(By.CssSelector("img[alt=\"Picture of 40 And Older Birthday Card\"]")).Text);
            }
            catch (AssertionException e)
            {
                
            }
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=fbMainContainer | ]]
            driver.FindElement(By.Id("fbCloseButton")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            try
            {
             //   Assert.IsTrue(IsElementPresent(By.XPath("//img[@alt=\"Picture of 50 It's the New 30 Birthday Card\"]")));
            }
            catch (AssertionException e)
            {
                
            }
            try
            {
              //  Assert.IsTrue(IsElementPresent(By.CssSelector("img[alt=\"Picture of 21 All Downhill Birthday Card\"]")));
            }
            catch (AssertionException e)
            {
               
            }
            //Assert.IsTrue(IsElementPresent(By.CssSelector("img[alt=\"Picture of Happy 21st Metal Birthday Card\"]")));
            //Assert.IsTrue(IsElementPresent(By.CssSelector("img[alt=\"Picture of Elephant Age 2 Birthday Card\"]")));
        }

        public void Validateproduct(ISelenium selenium,datarow datarow,IWebDriver driver)
        {

            string you = driver.FindElement(By.CssSelector("BODY")).Text;
            if (you == "You also need...")
            {
                datarow.newrow("Validating 'You also Need' Text", "You also need...", you, "PASS");
            }
            else
            {
                datarow.newrow("Validating 'You also Need' Text", "You also need...", you, "FAIL");

            }
            if (selenium.IsElementPresent("//ul[@id='productList']/li/div/div/img"))
            {
                datarow.newrow("Validating Related Product one", "Related Product one is Present", "Related Product one is Present", "PASS");
            }
            else
            {
                datarow.newrow("Validating Related Product one", "Related Product one is Present", "Related Product one is Present", "FAIL");
            }


            if (selenium.IsElementPresent("  //ul[@id='productList']/li[2]/div/div/img"))
            {
                datarow.newrow("Valistaing Related Product one", "Related Product is Present", "Related Product is Present", "FAIL");
            }
            else
            {
                datarow.newrow("Validating 'You also Need' Text", "You also need...", you, "FAIL");
            }
        }

        public void click(ISelenium selenium,IWebDriver driver, datarow datarow)
        {
            try
            {
                driver.FindElement(By.XPath("//ul[@id='productList']/li/div/div/img")).Click();
                selenium.WaitForPageToLoad("30000");
                datarow.newrow("Validating Elemnet Clickable or not", "Element should not be Clikcable",
                               "Elemenet is Clickable", "FAIL");
            }
            catch (Exception ex)
            {
                datarow.newrow("Validating Elemnet Clickable or not", "Element should not be Clikcable",
                               "Elemenet is not Clickable", "PASS");

            }
        }

        private bool IsElementPresent(By by, IWebDriver driver)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
