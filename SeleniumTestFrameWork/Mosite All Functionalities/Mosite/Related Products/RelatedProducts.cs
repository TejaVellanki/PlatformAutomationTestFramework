using System;
using System.Threading;
using OpenQA.Selenium;

namespace MoBankUI.Mosite
{
    internal class RelatedProducts : Driverdefining
    {
        public void Relatedproducts(IWebDriver driver, Datarow datarow)
        {
            try
            {
                //Navigate to the Product

                datarow.Newrow("", "", "Related Products", "");

                #region First Product

                datarow.Newrow("", "", "First Product", "");
                driver.Navigate().GoToUrl("http://testshop.mobankdev.com/product/three-today-birthday-card");

                //Validating Products
                Validateproduct(datarow, driver);

                //Validating click Working or  not 
                click(driver, datarow);

                //Validating Basket 
                datarow.Newrow("Validating Add a Basket Element", "Add a Basket Element is present",
                    "Add a Basket Element should not be present",
                    IsElementPresent(driver, By.CssSelector("input.ui-btn-hidden")) ? "FAIL" : "PASS");

                #endregion

                #region Second Product

                //Second Product
                datarow.Newrow("", "", "Second Product", "");
                driver.Navigate().GoToUrl("http://testshop.mobankdev.com/product/two-today-birthday-card");

                Validateproduct(datarow, driver);
                try
                {
                    driver.FindElement(By.XPath("//ul[@id='productList']/li/div/div/a/img")).Click();

                    datarow.Newrow("Validating Element Clickable or not", "Element should be Clikcable",
                                   "Elemenet is Clickable", "PASS");
                }
                catch (Exception)
                {
                    datarow.Newrow("Validating Element Clickable or not", "Element should be Clikcable",
                                   "Elemenet is Clickable", "FAIL");
                }

                driver.Navigate().Back();


                //Validating Basket 
                datarow.Newrow("Validating Add a Basket Element", "Add a Basket Element is present",
                    "Add a Basket Element should not be present",
                    IsElementPresent(driver, By.CssSelector("input.ui-btn-hidden")) ? "FAIL" : "PASS");

                #endregion

                #region Third Product

                //Third Product
                datarow.Newrow("", "", "Third Product", "");
                driver.Navigate().GoToUrl("http://testshop.mobankdev.com/product/one-today-birthday-card");

                //Validating Click
                Validateproduct(datarow, driver);
                click(driver, datarow);

                datarow.Newrow("Validating Add a Basket Element", "Add a Basket Element is present",
                    "Add a Basket Element should be present",
                    IsElementPresent(driver, By.CssSelector("input.ui-btn-hidden")) ? "PASS" : "FAIL");

                #endregion

                #region Fourth Product

                //Fourth Product
                datarow.Newrow("", "", "Fourth Product", "");
                driver.Navigate().GoToUrl("http://testshop.mobankdev.com/product/70-and-disgracefully-birthday-card");

                Validateproduct(datarow, driver);
                if (IsElementPresent(driver, By.CssSelector("input.ui-btn-hidden")))
                {
                    datarow.Newrow("Validating Add a Basket Element", "Add a Basket Element is present",
                                   "Add a Basket Element should be present", "PASS");

                    driver.FindElement(By.CssSelector("input.ui-btn-hidden")).Click();

                    Thread.Sleep(3000);
                    var basketcount = driver.FindElement(By.Id("BasketInfo")).Text;
                    datarow.Newrow("Validating Add to Basket for Related Product",
                        "Add to Basket Should be working for Related Products ", basketcount,
                        basketcount == "(1)" ? "PASS" : "FAIL");
                }
                else
                {
                    datarow.Newrow("Validating Add a Basket Element", "Add a Basket Element is present",
                                   "Add a Basket Element should be present", "FAIL");
                }
                driver.FindElement(By.XPath("//ul[@id='productList']/li/div/div/a/img")).Click();

                #endregion
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.Newrow("Exception in Related Products", "Exception not expected", e, "FAIL");
            }
        }

        public void Validateproduct(Datarow datarow, IWebDriver driver)
        {
            try
            {
                var you = driver.FindElement(By.XPath("//div[@id='mainContent']/div/ul/li")).Text;
                datarow.Newrow("Validating 'You also Need' Text", "You also need...", you,
                    you == "You also need..." ? "PASS" : "FAIL");

                var count = GetXpathCount(driver, "//ul[@id='productList']/li");
                if (count == 0)
                {
                    datarow.Newrow("Validating Related Products", "Atleast one Related Product should be Present",
                                   "No Related Products are found " + count + " ", "FAIL");
                }
                for (var i = 1; i <= count; i++)
                {
                    if (IsElementPresent(driver, By.XPath("//ul[@id='productList']/li[" + i + "]/div/div/img")))
                    {
                        datarow.Newrow("Validating Related Product one", "Related Product one is Present",
                                       "//ul[@id='productList']/li[" + i + "]/div/div/img" +
                                       "Related Product one is Present", "PASS");
                    }
                    if (IsElementPresent(driver, By.XPath("//ul[@id='productList']/li[" + i + "]/div/div/a/img")))
                    {
                        datarow.Newrow("Validating Related Product one", "Related Product one is Present",
                                       "//ul[@id='productList']/li[" + i + "]/div/div/a/img" +
                                       "Related Product one is Present", "PASS");
                    }
                }
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.Newrow("Exception in Related Products-validate Product", "Exception not expected", e, "FAIL");
            }
        }

        public void click(IWebDriver driver, Datarow datarow)
        {
            try
            {
                driver.FindElement(By.XPath("//ul[@id='productList']/li/div/div/img")).Click();

                datarow.Newrow("Validating Elemnet Clickable or not", "Element should not be Clikcable",
                               "Elemenet is Clickable", "FAIL");
            }
            catch (Exception)
            {
                datarow.Newrow("Validating Elemnet Clickable or not", "Element should not be Clikcable",
                               "Elemenet is not Clickable", "PASS");
            }
        }
    }
}