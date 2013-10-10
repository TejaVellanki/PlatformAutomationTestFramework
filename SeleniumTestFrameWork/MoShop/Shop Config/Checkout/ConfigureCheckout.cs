using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;

namespace MoBankUI 
{ 
    internal class ConfigureCheckout : driverdefining 
    {
        public void configure(IWebDriver driver , datarow datarow)
        {
            try
            {
            Selectanoption(driver, By.Id("CheckoutType"),"Configure Checkout");
            //new SelectElement(driver.FindElement(By.Id("CheckoutType"))).SelectByText("Configure Checkout");
            waitforpagetoload(driver,30000);
            for (int i = 0; i <= 2; i++)
            {
                driver.FindElement(By.CssSelector("h3.collapsible.collapsed")).Click();
            }
            Selectanoption(driver, By.Id("Encoding_Value"), "iso-8859-1 - Western European (ISO)");
            // new SelectElement(driver.FindElement(By.Id("Encoding_Value"))).SelectByText("iso-8859-1 - Western European (ISO)");
            //Add To Basket Page           
            driver.FindElement(By.Id("BasketPage_Url"))
                  .SendKeys("http://www.the-tickle-company.co.uk/cgi-bin/ca000001.pl");
            Selectanoption(driver, By.Id("BasketPage_Method"), "POST");
            // new SelectElement(driver.FindElement(By.Id("BasketPage_Method"))).SelectByText("POST");
            driver.FindElement(By.Id("BasketPage_Parameters")).Clear();
            driver.FindElement(By.Id("BasketPage_Parameters"))
                  .SendKeys("SID=915&PAGE=PRODUCT&Q_{{ProductCode}}={{Quantity}}");
            driver.FindElement(By.Id("BasketPage_SuccessSelector")).Clear();
            driver.FindElement(By.Id("BasketPage_SuccessSelector")).SendKeys("#productsresults form h2");
            driver.FindElement(By.Id("BasketPage_ErrorMessageSelector")).Clear();
            driver.FindElement(By.Id("BasketPage_ErrorMessageSelector")).SendKeys("body");
            driver.FindElement(By.Id("BasketPage_ErrorMessageTransformer")).Clear();
            driver.FindElement(By.Id("BasketPage_ErrorMessageTransformer")).SendKeys(@"(?<=\<hr \/\>).*(?=\<hr \/\>)");
            driver.FindElement(By.Id("BasketPage_BasketTotalSelector")).Clear();
            driver.FindElement(By.Id("BasketPage_BasketTotalSelector"))
                  .SendKeys("div#productsresults table:eq(0) tr:last-child td strong:eq(1)");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='configureCheckoutForm']/div[2]/h3")).Click();
            int num = 0;

            if (num == 0)
            {
                driver.FindElement(By.XPath("//div[@id='configureCheckoutForm']/div[4]/h3")).Click();
                Thread.Sleep(3000);
            }
            try
            {
                for (int i = 0; i <= 2; i++)
                {
                    driver.FindElement(By.CssSelector("h3.collapsible.collapsed")).Click();
                }
            }
            catch (Exception ex)
            {
            }

            driver.FindElement(By.Id("CountryMappings_0__Source")).Clear();
            driver.FindElement(By.Id("CountryMappings_0__Source")).SendKeys("UK");
            driver.FindElement(By.Id("CountryMappings_0__Source")).SendKeys(Keys.Enter);
            waitforpagetoload(driver,30000);
            Selectanoption(driver, By.Id("CountryMappings_0__Target"), "GB - United Kingdom");  
            // new SelectElement(driver.FindElement(By.Id("CountryMappings_0__Target"))).SelectByText("GB - United Kingdom");
            driver.FindElement(By.CssSelector("input.button")).Click();
            waitforpagetoload(driver,30000);
            driver.FindElement(By.Id("Pages_0__Name")).Clear();
            driver.FindElement(By.Id("Pages_0__Name")).SendKeys("Address");
            driver.FindElement(By.Id("Pages_0__Name")).SendKeys(Keys.Enter);
            waitforpagetoload(driver,30000);
            driver.FindElement(By.CssSelector("input.button")).Click();
            waitforpagetoload(driver,30000);
            driver.FindElement(By.Id("Pages_1__Name")).Clear();
            driver.FindElement(By.Id("Pages_1__Name")).SendKeys("Delivery");
            driver.FindElement(By.Id("Pages_1__Name")).SendKeys(Keys.Enter);
            waitforpagetoload(driver,30000);
            driver.FindElement(By.CssSelector("input.button")).Click();
            waitforpagetoload(driver,30000);
            driver.FindElement(By.Id("Pages_2__Name")).Clear();
            driver.FindElement(By.Id("Pages_2__Name")).SendKeys("Confirm");
            driver.FindElement(By.Id("Pages_2__Name")).SendKeys(Keys.Enter);
            waitforpagetoload(driver,30000);
            driver.FindElement(By.CssSelector("input.button")).Click();
            waitforpagetoload(driver,30000);

            string str7 = driver.FindElement(By.Id("Encoding_Value")).GetAttribute("Value");
            string str8 = driver.FindElement(By.Id("BasketPage_Url")).GetAttribute("Value");
            string str9 = driver.FindElement(By.Id("BasketPage_Parameters")).GetAttribute("Value");
            string str10 = driver.FindElement(By.Id("BasketPage_SuccessSelector")).GetAttribute("Value");
            string str11 = driver.FindElement(By.Id("BasketPage_ErrorMessageSelector")).GetAttribute("Value");
            string str12 = driver.FindElement(By.Id("BasketPage_ErrorMessageTransformer")).GetAttribute("Value");
            string str13 = driver.FindElement(By.Id("BasketPage_BasketTotalSelector")).GetAttribute("Value");
            string str14 = driver.FindElement(By.Id("CountryMappings_0__Source")).GetAttribute("Value");

            #region Validations

            if (str8 == "http://www.the-tickle-company.co.uk/cgi-bin/ca000001.pl")
            {
                datarow.newrow("Basket Page URL", "http://www.the-tickle-company.co.uk/cgi-bin/ca000001.pl", str8,"PASS", driver);
            }
            else
            {
                datarow.newrow("Basket Page URL", "http://www.the-tickle-company.co.uk/cgi-bin/ca000001.pl", str8,"FAIL", driver);
            }
            if (str9 == "SID=915&PAGE=PRODUCT&Q_{{ProductCode}}={{Quantity}}")
            {
                datarow.newrow("Basket Page Parameters", "SID=915&PAGE=PRODUCT&Q_{{ProductCode}}={{Quantity}}", str9,"PASS", driver);
            }
            else
            {
                datarow.newrow("Basket Page Parameters", "SID=915&PAGE=PRODUCT&Q_{{ProductCode}}={{Quantity}}", str9,"FAIL", driver);
            }
            if (str10 == "#productsresults form h2")
            {
                datarow.newrow("Basket Success Selector", "#productsresults form h2", str10, "PASS", driver);
            }
            else
            {
                datarow.newrow("Basket Success Selector", "#productsresults form h2", str10, "FAIL", driver);
            }
            if (str11 == "body")
            {
                datarow.newrow("Basket Error Message", "body", str11, "PASS", driver);
            }
            else
            {
                datarow.newrow("Basket Error Message", "body", str11, "FAIL", driver);
            }
            if (str12 == @"(?<=\<hr \/\>).*(?=\<hr \/\>)")
            {
                datarow.newrow("Basket Error Transformation", @"(?<=\<hr \/\>).*(?=\<hr \/\>)", str12, "PASS", driver);
            }
            else
            {
                datarow.newrow("Basket Error Transformation", @"(?<=\<hr \/\>).*(?=\<hr \/\>)", str12, "FAIL", driver);
            }
            if (str13 == "div#productsresults table:eq(0) tr:last-child td strong:eq(1)")
            {
                datarow.newrow("Basket Total Selector", "div#productsresults table:eq(0) tr:last-child td strong:eq(1)",
                               str13, "PASS", driver);
            }
            else
            {
                datarow.newrow("Basket Total Selector", "div#productsresults table:eq(0) tr:last-child td strong:eq(1)",
                               str13, "PASS", driver);
            }
            if (str14 == "UK")
            {
                datarow.newrow("Country Mappings", "UK", str14, "PASS", driver);
            }
            else
            {
                datarow.newrow("Country Mappings", "UK", str14, "FAIL", driver);
            }
            string str15 = driver.FindElement(By.Id("Pages_0__Name")).GetAttribute("Value");
            string str16 = driver.FindElement(By.Id("Pages_1__Name")).GetAttribute("Value");
            string str17 = driver.FindElement(By.Id("Pages_2__Name")).GetAttribute("Value");
            if (str15 == "Address")
            {
                datarow.newrow("Chekout Address", "Address", str15, "PASS", driver);
            }
            else
            {
                datarow.newrow("Chekout Address", "Address", str15, "FAIL", driver);
            }
            if (str16 == "Delivery")
            {
                datarow.newrow("Checkout Delivery", "Delivery", str16, "PASS", driver);
            }
            else
            {
                datarow.newrow("Checkout Delivery", "Delivery", str16, "FAIL", driver);
            }
            if (str17 == "Confirm")
            {
                datarow.newrow("Checkout Confirmation", "Confirm", str17, "PASS", driver);
            }
            else
            {
                datarow.newrow("Checkout Confirmation", "Confirm", str17, "FAIL", driver);
            }

            #endregion
                

            driver.FindElement(By.LinkText("…")).Click();
            waitforpagetoload(driver,30000);
            string str18 = driver.Title;
            if (str18 == "Page Update : mobank.co.uk/MoShop")
            {
                datarow.newrow("Address Page Title", "Page Update : mobank.co.uk/MoShop", str18, "PASS", driver
                               );
            }
            else
            {
                datarow.newrow("Address Page Title", "Page Update : mobank.co.uk/MoShop", str18, "FAIL", driver
                               );
            }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Excepion Not Expected", e, "FAIL", driver);
            }
            new Addressconfig().addressconfig(driver,datarow);
        }
    }
}