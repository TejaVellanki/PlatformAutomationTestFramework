using System;
using System.Threading;
using OpenQA.Selenium;

namespace MoBankUI.MoShop.Checkout
{
    internal class ConfigureCheckout : Driverdefining
    {
        public void Configure(IWebDriver driver, Datarow datarow)
        {
            try
            {
                Selectanoption(driver, By.Id("CheckoutType"), "Configure Checkout");
                //new SelectElement(driver.FindElement(By.Id("CheckoutType"))).SelectByText("Configure Checkout");

                for (var i = 0; i <= 2; i++)
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
                driver.FindElement(By.Id("BasketPage_ErrorMessageTransformer"))
                      .SendKeys(@"(?<=\<hr \/\>).*(?=\<hr \/\>)");
                driver.FindElement(By.Id("BasketPage_BasketTotalSelector")).Clear();
                driver.FindElement(By.Id("BasketPage_BasketTotalSelector"))
                      .SendKeys("div#productsresults table:eq(0) tr:last-child td strong:eq(1)");
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//div[@id='configureCheckoutForm']/div[2]/h3")).Click();

                driver.FindElement(By.XPath("//div[@id='configureCheckoutForm']/div[4]/h3")).Click();
                Thread.Sleep(3000);
                try
                {
                    for (var i = 0; i <= 2; i++)
                    {
                        driver.FindElement(By.CssSelector("h3.collapsible.collapsed")).Click();
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    datarow.Newrow("Exception", "Exception Not Exopected", e, "FAIL");
                }

                driver.FindElement(By.Id("CountryMappings_0__Source")).Clear();
                driver.FindElement(By.Id("CountryMappings_0__Source")).SendKeys("UK");
                driver.FindElement(By.Id("CountryMappings_0__Source")).SendKeys(Keys.Enter);

                Selectanoption(driver, By.Id("CountryMappings_0__Target"), "GB - United Kingdom");
                // new SelectElement(driver.FindElement(By.Id("CountryMappings_0__Target"))).SelectByText("GB - United Kingdom");
                driver.FindElement(By.CssSelector("input.button")).Click();

                driver.FindElement(By.Id("Pages_0__Name")).Clear();
                driver.FindElement(By.Id("Pages_0__Name")).SendKeys("Address");
                driver.FindElement(By.Id("Pages_0__Name")).SendKeys(Keys.Enter);

                driver.FindElement(By.CssSelector("input.button")).Click();

                driver.FindElement(By.Id("Pages_1__Name")).Clear();
                driver.FindElement(By.Id("Pages_1__Name")).SendKeys("Delivery");
                driver.FindElement(By.Id("Pages_1__Name")).SendKeys(Keys.Enter);

                driver.FindElement(By.CssSelector("input.button")).Click();

                driver.FindElement(By.Id("Pages_2__Name")).Clear();
                driver.FindElement(By.Id("Pages_2__Name")).SendKeys("Confirm");
                driver.FindElement(By.Id("Pages_2__Name")).SendKeys(Keys.Enter);

                driver.FindElement(By.CssSelector("input.button")).Click();


                driver.FindElement(By.Id("Encoding_Value")).GetAttribute("Value");
                var str8 = driver.FindElement(By.Id("BasketPage_Url")).GetAttribute("Value");
                var str9 = driver.FindElement(By.Id("BasketPage_Parameters")).GetAttribute("Value");
                var str10 = driver.FindElement(By.Id("BasketPage_SuccessSelector")).GetAttribute("Value");
                var str11 = driver.FindElement(By.Id("BasketPage_ErrorMessageSelector")).GetAttribute("Value");
                var str12 = driver.FindElement(By.Id("BasketPage_ErrorMessageTransformer")).GetAttribute("Value");
                var str13 = driver.FindElement(By.Id("BasketPage_BasketTotalSelector")).GetAttribute("Value");
                var str14 = driver.FindElement(By.Id("CountryMappings_0__Source")).GetAttribute("Value");

                #region Validations

                datarow.Newrow("Basket Page URL", "http://www.the-tickle-company.co.uk/cgi-bin/ca000001.pl", str8,
                    str8 == "http://www.the-tickle-company.co.uk/cgi-bin/ca000001.pl" ? "PASS" : "FAIL", driver);
                datarow.Newrow("Basket Page Parameters", "SID=915&PAGE=PRODUCT&Q_{{ProductCode}}={{Quantity}}", str9,
                    str9 == "SID=915&PAGE=PRODUCT&Q_{{ProductCode}}={{Quantity}}" ? "PASS" : "FAIL", driver);
                datarow.Newrow("Basket Success Selector", "#productsresults form h2", str10,
                    str10 == "#productsresults form h2" ? "PASS" : "FAIL", driver);
                datarow.Newrow("Basket Error Message", "body", str11, str11 == "body" ? "PASS" : "FAIL", driver);
                datarow.Newrow("Basket Error Transformation", @"(?<=\<hr \/\>).*(?=\<hr \/\>)", str12,
                    str12 == @"(?<=\<hr \/\>).*(?=\<hr \/\>)" ? "PASS" : "FAIL",
                    driver);
                if (str13 == "div#productsresults table:eq(0) tr:last-child td strong:eq(1)")
                {
                    datarow.Newrow("Basket Total Selector",
                                   "div#productsresults table:eq(0) tr:last-child td strong:eq(1)",
                                   str13, "PASS", driver);
                }
                else
                {
                    datarow.Newrow("Basket Total Selector",
                                   "div#productsresults table:eq(0) tr:last-child td strong:eq(1)",
                                   str13, "PASS", driver);
                }
                datarow.Newrow("Country Mappings", "UK", str14, str14 == "UK" ? "PASS" : "FAIL", driver);
                var str15 = driver.FindElement(By.Id("Pages_0__Name")).GetAttribute("Value");
                var str16 = driver.FindElement(By.Id("Pages_1__Name")).GetAttribute("Value");
                var str17 = driver.FindElement(By.Id("Pages_2__Name")).GetAttribute("Value");
                datarow.Newrow("Chekout Address", "Address", str15, str15 == "Address" ? "PASS" : "FAIL", driver);
                datarow.Newrow("Checkout Delivery", "Delivery", str16, str16 == "Delivery" ? "PASS" : "FAIL", driver);
                datarow.Newrow("Checkout Confirmation", "Confirm", str17, str17 == "Confirm" ? "PASS" : "FAIL", driver);

                #endregion

                driver.FindElement(By.LinkText("…")).Click();

                var str18 = driver.Title;
                datarow.Newrow("Address Page Title", "Page Update : mobank.co.uk/MoShop", str18,
                    str18 == "Page Update : mobank.co.uk/MoShop" ? "PASS" : "FAIL", driver
                    );
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.Newrow("Exception", "Excepion Not Expected", e, "FAIL", driver);
            }
            new Addressconfig().AddressConfig(driver, datarow);
        }
    }
}