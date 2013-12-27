using System;
using System.Threading;
using OpenQA.Selenium;

using WebDriver_Refining;

namespace MoBankUI
{
    class RelatedProducts : driverdefining
    {
        public void relatedproducts(IWebDriver driver,datarow datarow)
        {
            try
            {

            
            //Navigate to the Product
            
            datarow.newrow("","", "Related Products","");
           
            #region First Product
            
            datarow.newrow("","", "First Product","");
            driver.Navigate().GoToUrl("http://testshop.mobankdev.com/product/three-today-birthday-card");
            waitforpagetoload(driver,30000);
            //Validating Products
            Validateproduct(datarow,driver);
            
            //Validating click Working or  not 
            click(driver,datarow);

            //Validating Basket 
            if (IsElementPresent(driver,By.CssSelector("input.ui-btn-hidden")))
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should not be present", "FAIL");
            }
            else
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should not be present", "PASS");
            }
            #endregion

            #region Second Product
            //Second Product
            datarow.newrow("", "", "Second Product", "");
            driver.Navigate().GoToUrl("http://testshop.mobankdev.com/product/two-today-birthday-card");
            waitforpagetoload(driver,30000);
            Validateproduct(datarow, driver);
            try
            {
         
            driver.FindElement(By.XPath("//ul[@id='productList']/li/div/div/a/img")).Click();
            waitforpagetoload(driver,30000);
            datarow.newrow("Validating Element Clickable or not", "Element should be Clikcable","Elemenet is Clickable", "PASS");
            }
            catch (Exception ex)
            {

                datarow.newrow("Validating Element Clickable or not", "Element should be Clikcable","Elemenet is Clickable", "FAIL");
            }

             driver.Navigate().Back();
            waitforpagetoload(driver,30000);

            //Validating Basket 
            if (IsElementPresent(driver,By.CssSelector("input.ui-btn-hidden")))
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should not be present", "FAIL");
            }
            else
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should not be present", "PASS");
            }
            #endregion

            #region Third Product
            //Third Product
            datarow.newrow("", "", "Third Product", "");
            driver.Navigate().GoToUrl("http://testshop.mobankdev.com/product/one-today-birthday-card");
            waitforpagetoload(driver,30000);
            //Validating Click
            Validateproduct(datarow,driver);
            click(driver,datarow);

            if (IsElementPresent(driver,By.CssSelector("input.ui-btn-hidden")))
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should be present", "PASS");
            }
            else
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should be present", "FAIL");
            }
            #endregion

            #region Fourth Product
            //Fourth Product
            datarow.newrow("", "", "Fourth Product", "");
            driver.Navigate().GoToUrl("http://testshop.mobankdev.com/product/70-and-disgracefully-birthday-card");
            waitforpagetoload(driver,30000);
            Validateproduct(datarow, driver);
            if (IsElementPresent(driver,By.CssSelector("input.ui-btn-hidden")))
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should be present", "PASS");

                driver.FindElement(By.CssSelector("input.ui-btn-hidden")).Click(); 
                  waitforpagetoload(driver,30000);
                Thread.Sleep(3000);
                string basketcount = driver.FindElement(By.Id("BasketInfo")).Text;
                if (basketcount == "(1)")
                {
                    datarow.newrow("Validating Add to Basket for Related Product", "Add to Basket Should be working for Related Products ",basketcount, "PASS");

                }
                else
                {
                    datarow.newrow("Validating Add to Basket for Related Product", "Add to Basket Should be working for Related Products ", basketcount, "FAIL");
                }

            }
            else
            {
                datarow.newrow("Validating Add a Basket Element", "Add a Basket Element is present", "Add a Basket Element should be present", "FAIL");
            }
            driver.FindElement(By.XPath("//ul[@id='productList']/li/div/div/a/img")).Click();
            waitforpagetoload(driver,30000);

            #endregion
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception in Related Products","Exception not expected", e,"FAIL");
            }
           
        }

        public void Validateproduct(datarow datarow,IWebDriver driver)
        {
            try
            {
                string you = driver.FindElement(By.XPath("//div[@id='mainContent']/div/ul/li")).Text;
                if (you == "You also need...")
                {
                    datarow.newrow("Validating 'You also Need' Text", "You also need...", you, "PASS");
                }
                else
                {
                    datarow.newrow("Validating 'You also Need' Text", "You also need...", you, "FAIL");

                }

                decimal count = GetXpathCount(driver,"//ul[@id='productList']/li");
                if (count == 0)
                {
                    datarow.newrow("Validating Related Products", "Atleast one Related Product should be Present","No Related Products are found "+count+" ", "FAIL");
                }
                for (int i = 1; i <= count; i++)
                {

                    if (IsElementPresent(driver,By.XPath("//ul[@id='productList']/li[" + i + "]/div/div/img")))
                    {
                        datarow.newrow("Validating Related Product one", "Related Product one is Present","//ul[@id='productList']/li[" + i + "]/div/div/img" +"Related Product one is Present", "PASS");
                    }
                    if (IsElementPresent(driver,By.XPath("//ul[@id='productList']/li[" + i + "]/div/div/a/img")))
                    {
                        datarow.newrow("Validating Related Product one", "Related Product one is Present","//ul[@id='productList']/li[" + i + "]/div/div/a/img" +"Related Product one is Present", "PASS");
                    }
                 }

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception in Related Products-validate Product", "Exception not expected", e, "FAIL");
            }
        }

        public void click(IWebDriver driver, datarow datarow)
        {
           
            try
            {
                driver.FindElement(By.XPath("//ul[@id='productList']/li/div/div/img")).Click();
                waitforpagetoload(driver,30000);
                datarow.newrow("Validating Elemnet Clickable or not", "Element should not be Clikcable",
                               "Elemenet is Clickable", "FAIL");
            }
            catch (Exception ex)
            {
                datarow.newrow("Validating Elemnet Clickable or not", "Element should not be Clikcable",
                               "Elemenet is not Clickable", "PASS");

            }
           
        }

        
    }
}
